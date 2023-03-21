using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Net;
using Linkhub;
using System.Security.Cryptography;


namespace Kakaocert
{

    public class KakaocertService
    {
        private const string ServiceID = "BAROCERT";
        private const String ServiceURL_Default = "https://bc-api.linkhub.kr";
        private const String ServiceURL_Static = "https://static-barocert.linkhub.co.kr";
        private const String ServiceURL_GA = "https://ga-barocert.linkhub.co.kr";

        private const String APIVersion = "2.0";
        private const String CRLF = "\r\n";

        private Dictionary<String, Token> _tokenTable = new Dictionary<String, Token>();
        private bool _IPRestrictOnOff;
        private bool _UseStaticIP;
        private bool _UseGAIP;
        private bool _UseLocalTimeYN = true;
        private String _LinkID;
		private String _SecretKey;
        private Authority _LinkhubAuth;
        private List<String> _Scopes = new List<string>();


        public bool IPRestrictOnOff
        {
            set { _IPRestrictOnOff = value; }
            get { return _IPRestrictOnOff; }
        }

        public bool UseStaticIP
        {
            set { _UseStaticIP = value; }
            get { return _UseStaticIP; }
        }

        public bool UseGAIP
        {
            set { _UseGAIP = value; }
            get { return _UseGAIP; }
        }

        public bool UseLocalTimeYN
        {
            set { _UseLocalTimeYN = value; }
            get { return _UseLocalTimeYN; }
        }

        public KakaocertService(String LinkID, String SecretKey)
        {
            _LinkhubAuth = new Authority(LinkID, SecretKey);
            _Scopes.Add("partner");
            _Scopes.Add("401");
            _Scopes.Add("402");
            _Scopes.Add("403");
			_Scopes.Add("404");
			_LinkID = LinkID;
            _SecretKey = SecretKey;
            _IPRestrictOnOff = true;
        }

        protected String toJsonString(Object graph)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(graph.GetType());
                ser.WriteObject(ms, graph);
                ms.Seek(0, SeekOrigin.Begin);
                return new StreamReader(ms).ReadToEnd();
            }
        }

        protected T fromJson<T>(Stream jsonStream)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            return (T)ser.ReadObject(jsonStream);
        }

        protected string ServiceURL
        {
            get
            {
                if (UseGAIP)
                {
                    return ServiceURL_GA;
                }
                else if (UseStaticIP)
                {
                    return ServiceURL_Static;
                }
                else
                {
                    return ServiceURL_Default;
                }

            }
        }

        private String getSession_Token(String CorpNum)
        {
            Token _token = null;

            if (_tokenTable.ContainsKey(CorpNum))
            {
                _token = _tokenTable[CorpNum];
            }

            bool expired = true;
            if (_token != null)
            {
                DateTime now = DateTime.Parse(_LinkhubAuth.getTime(UseStaticIP, UseLocalTimeYN, UseGAIP));

                DateTime expiration = DateTime.Parse(_token.expiration);

                expired = expiration < now;

            }

            if (expired)
            {
                try
                {
                    if (_IPRestrictOnOff) // IPRestrictOnOff 사용시
                    {
                        _token = _LinkhubAuth.getToken(ServiceID, CorpNum, _Scopes, null, UseStaticIP, UseLocalTimeYN, UseGAIP);
                    }
                    else
                    {
                        _token = _LinkhubAuth.getToken(ServiceID, CorpNum, _Scopes, "*", UseStaticIP, UseLocalTimeYN, UseGAIP);
                    }


                    if (_tokenTable.ContainsKey(CorpNum))
                    {
                        _tokenTable.Remove(CorpNum);
                    }
                    _tokenTable.Add(CorpNum, _token);
                }
                catch (LinkhubException le)
                {
                    throw new BarocertException(le);
                }
            }

            return _token.session_token;
        }

        protected T httpget<T>(String url, String CorpNum, String UserID)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ServiceURL + url);

            if (String.IsNullOrEmpty(CorpNum) == false)
            {
                String bearerToken = getSession_Token(CorpNum);
                request.Headers.Add("Authorization", "Bearer" + " " + bearerToken);
            }

            request.Headers.Add("x-lh-version", APIVersion);

            request.Headers.Add("Accept-Encoding", "gzip, deflate");

            request.AutomaticDecompression = DecompressionMethods.GZip;

            if (String.IsNullOrEmpty(UserID) == false)
            {
                request.Headers.Add("x-pb-userid", UserID);
            }

            request.Method = "GET";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stReadData = response.GetResponseStream())
                    {
                        return fromJson<T>(stReadData);
                    }
                }
            }
            catch (Exception we)
            {
                if (we is WebException && ((WebException)we).Response != null)
                {
                    using (Stream stReadData = ((WebException)we).Response.GetResponseStream())
                    {
                        Response t = fromJson<Response>(stReadData);
                        throw new BarocertException(t.code, t.message);
                    }
                }
                throw new BarocertException(-99999999, we.Message);
            }

        }

		private byte[] GenerateIV()
		{
			using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
			{
				byte[] nonce = new byte[16];
				rng.GetBytes(nonce);

				return nonce;
			}
		}

		protected String Encrypt(String plainText) {
			if (String.IsNullOrEmpty(plainText)) 
                throw new BarocertException(-99999999, "plainText empty");

			try
			{
				byte[] encrypted;
			    byte[] iv = GenerateIV();
			    byte[] encryptedAndIV = null;

			    using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
			    {
				    aes.KeySize = 256;
				    aes.BlockSize = 128;
				    aes.Key = Convert.FromBase64String(_SecretKey);
				    aes.IV = iv;
				    aes.Mode = CipherMode.CBC;
				    aes.Padding = PaddingMode.PKCS7;

				    ICryptoTransform enc = aes.CreateEncryptor(aes.Key, aes.IV);

				    using (MemoryStream ms = new MemoryStream())
				    {
					    using (CryptoStream cs = new CryptoStream(ms, enc, CryptoStreamMode.Write))
					    {
						    using (StreamWriter sw = new StreamWriter(cs))
						    {
							    sw.Write(plainText);
						    }
						    encrypted = ms.ToArray();

						    encryptedAndIV = new byte[encrypted.Length + aes.IV.Length];
						    aes.IV.CopyTo(encryptedAndIV, 0);
						    encrypted.CopyTo(encryptedAndIV, 16);
					    }
				    }
			    }
				return Encoding.Default.GetString(encrypted);
			} catch (LinkhubException le) {
				throw new BarocertException(-99999999, "Encrypt Error");
			}
		}

		protected T httppost<T>(String url, String CorpNum, String UserID, String PostData, String httpMethod)
        {
            return httppost<T>(url, CorpNum, UserID, PostData, httpMethod, null);
        }

        protected T httppost<T>(String url, String CorpNum, String UserID, String PostData, String httpMethod, String contentsType)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ServiceURL + url);

            if (contentsType == null)
            {
                request.ContentType = "application/json;";
            }
            else
            {
                request.ContentType = contentsType;
            }


            if (String.IsNullOrEmpty(CorpNum) == false)
            {
                String bearerToken = getSession_Token(CorpNum);
                request.Headers.Add("Authorization", "Bearer" + " " + bearerToken);
            }

            request.Headers.Add("x-lh-version", APIVersion);

            request.Headers.Add("Accept-Encoding", "gzip, deflate");

            request.AutomaticDecompression = DecompressionMethods.GZip;

            if (String.IsNullOrEmpty(UserID) == false)
            {
                request.Headers.Add("x-pb-userid", UserID);
            }

            if (String.IsNullOrEmpty(httpMethod) == false)
            {
                request.Headers.Add("X-HTTP-Method-Override", httpMethod);
            }

            request.Method = "POST";

            String xDate = _LinkhubAuth.getTime(UseStaticIP, false, UseGAIP);

            request.Headers.Add("x-lh-date", xDate);

            if (String.IsNullOrEmpty(PostData)) PostData = "";

            byte[] btPostDAta = Encoding.UTF8.GetBytes(PostData);

            String HMAC_target = "POST\n";
            HMAC_target += Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(PostData))) + "\n";
            HMAC_target += xDate + "\n";
            HMAC_target += APIVersion + "\n";
            HMACSHA256 hmac = new HMACSHA256(Convert.FromBase64String(_SecretKey));

            String hmac_str = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(HMAC_target)));

            request.Headers.Add("x-bc-auth", _LinkID + " " + hmac_str);
			request.Headers.Add("x-bc-encryptionmode", "CBC");

			request.ContentLength = btPostDAta.Length;

            request.GetRequestStream().Write(btPostDAta, 0, btPostDAta.Length);

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stReadData = response.GetResponseStream())
                    {
                        return fromJson<T>(stReadData);
                    }
                }
            }
            catch (Exception we)
            {
                if (we is WebException && ((WebException)we).Response != null)
                {
                    using (Stream stReadData = ((WebException)we).Response.GetResponseStream())
                    {
                        Response t = fromJson<Response>(stReadData);
                        throw new KakaocertException(t.code, t.message);
                    }
                }
                throw new KakaocertException(-99999999, we.Message);
            }
        }


        public ResponseESign requestESign(String ClientCode, RequestESign requestESign, bool isAppUseYN = false)
        {
            if (String.IsNullOrEmpty(ClientCode)) 
                throw new BarocertException(-99999999, "이용기관코드가 입력되지 않았습니다.");
            if (requestESign == null) 
                throw new BarocertException(-99999999, "전자서명 요청정보가 입력되지 않았습니다.");

            if (requestESign.ci == null || requestESign.ci.Length == 0) {
				requestESign.receiverHP = Encrypt(requestESign.receiverHP);
				requestESign.receiverName = Encrypt(requestESign.receiverName);
				requestESign.receiverBirthday = Encrypt(requestESign.receiverBirthday);
			} else {
				requestESign.ci = Encrypt(requestESign.ci);
            }

			requestESign.token = Encrypt(requestESign.receiverBirthday);

			requestESign.clientCode = ClientCode;
			requestESign.appUseYN = isAppUseYN;

            String PostData = toJsonString(requestESign);

			ResponseESign response = httppost<ResponseESign>("/KAKAO/ESign/Request", ClientCode, "", PostData, ""); ;

            return response;
        }

		public ResponseESign bulkRequestESign(String ClientCode, BulkRequestESign bulkRequestESign, bool isAppUseYN = false)
		{
			if (String.IsNullOrEmpty(ClientCode)) 
                throw new BarocertException(-99999999, "이용기관코드가 입력되지 않았습니다.");
			if (bulkRequestESign == null) 
                throw new BarocertException(-99999999, "자동이체 출금동의 요청정보가 입력되지 않았습니다.");

			if (bulkRequestESign.ci == null || bulkRequestESign.ci.Length == 0)
			{
				bulkRequestESign.receiverHP = Encrypt(bulkRequestESign.receiverHP);
				bulkRequestESign.receiverName = Encrypt(bulkRequestESign.receiverName);
				bulkRequestESign.receiverBirthday = Encrypt(bulkRequestESign.receiverBirthday);
			}
			else
			{
				bulkRequestESign.ci = Encrypt(bulkRequestESign.ci);
			}

			List<Tokens> tokens = bulkRequestESign.token;
			foreach (Tokens result in tokens)
			{
				String token = result.token;
				String encrypt = Encrypt(token);
				result.token = encrypt;
			}

			bulkRequestESign.clientCode = ClientCode;
			bulkRequestESign.appUseYN = isAppUseYN;

			String PostData = toJsonString(bulkRequestESign);

			ResponseESign response = httppost<ResponseESign>("/KAKAO/ESign/BulkRequest", ClientCode, "", PostData, ""); ;

			return response;
		}

		public ResultESign getESignState(String ClientCode, String receiptID)
		{
			if (String.IsNullOrEmpty(ClientCode)) 
                throw new BarocertException(-99999999, "이용기관코드가 입력되지 않았습니다.");
			if (String.IsNullOrEmpty(receiptID)) 
                throw new BarocertException(-99999999, "접수아이디가 입력되지 않았습니다.");

			return httpget<ResultESign>("/KAKAO/ESign/Status/" + ClientCode + "/" + receiptID, ClientCode, null);
		}

		public BulkResultESign getBulkESignState(String ClientCode, String receiptID)
		{
			if (String.IsNullOrEmpty(ClientCode)) 
                throw new BarocertException(-99999999, "이용기관코드가 입력되지 않았습니다.");
			if (String.IsNullOrEmpty(receiptID)) 
                throw new BarocertException(-99999999, "접수아이디가 입력되지 않았습니다.");

			return httpget<BulkResultESign>("/KAKAO/ESign/BulkStatus/" + ClientCode + "/" + receiptID, ClientCode, null);
		}

		public ResultVerifyEsign verifyESign(String ClientCode, String receiptID)
		{
			if (String.IsNullOrEmpty(ClientCode)) 
                throw new BarocertException(-99999999, "이용기관코드가 입력되지 않았습니다.");
			if (String.IsNullOrEmpty(receiptID)) 
                throw new BarocertException(-99999999, "접수아이디가 입력되지 않았습니다.");

			RequestVerify requestVerify = new RequestVerify();
			requestVerify.clientCode = ClientCode;
			requestVerify.receiptID = receiptID;

			String PostData = toJsonString(requestVerify);

			ResultVerifyEsign response = httppost<ResultVerifyEsign>("/KAKAO/ESign/Verify", ClientCode, "", PostData, ""); ;

			return response;
		}

		public BulkVerifyResult bulkVerifyESign(String ClientCode, String receiptID)
		{
			if (String.IsNullOrEmpty(ClientCode)) 
                throw new BarocertException(-99999999, "이용기관코드가 입력되지 않았습니다.");
			if (String.IsNullOrEmpty(receiptID)) 
                throw new BarocertException(-99999999, "접수아이디가 입력되지 않았습니다.");

			RequestVerify requestVerify = new RequestVerify();
			requestVerify.clientCode = ClientCode;
			requestVerify.receiptID = receiptID;

			String PostData = toJsonString(requestVerify);

			BulkVerifyResult response = httppost<BulkVerifyResult>("/KAKAO/ESign/BulkVerify", ClientCode, "", PostData, ""); ;

			return response;
		}


		public ResultReqVerifyAuth requestVerifyAuth(String ClientCode, RequestVerifyAuth requestVerifyAuth, bool isAppUseYN = false)
        {
            if (String.IsNullOrEmpty(ClientCode)) 
                throw new BarocertException(-99999999, "이용기관코드가 입력되지 않았습니다.");
            if (requestVerifyAuth == null) 
                throw new BarocertException(-99999999, "본인인증 요청정보가 입력되지 않았습니다.");

			if (requestVerifyAuth.ci == null || requestVerifyAuth.ci.Length == 0) {
				requestVerifyAuth.receiverHP = Encrypt(requestVerifyAuth.receiverHP);
				requestVerifyAuth.receiverName = Encrypt(requestVerifyAuth.receiverName);
				requestVerifyAuth.receiverBirthday = Encrypt(requestVerifyAuth.receiverBirthday);
			} else {
				requestVerifyAuth.ci = Encrypt(requestVerifyAuth.ci);
			}

			requestVerifyAuth.token = Encrypt(requestVerifyAuth.token);
			requestVerifyAuth.clientCode = ClientCode;
			requestVerifyAuth.appUseYN = isAppUseYN;

			String PostData = toJsonString(requestVerifyAuth);

			ResultReqVerifyAuth response = httppost<ResultReqVerifyAuth>("/KAKAO/VerifyAuth/Request", ClientCode, "", PostData, ""); ;

            return response;
        }

		public ResultVerifyAuthState getVerifyAuthState(String ClientCode, String receiptID)
		{
			if (String.IsNullOrEmpty(ClientCode)) 
                throw new BarocertException(-99999999, "이용기관코드가 입력되지 않았습니다.");
			if (String.IsNullOrEmpty(receiptID)) 
                throw new BarocertException(-99999999, "접수아이디가 입력되지 않았습니다.");

			return httpget<ResultVerifyAuthState>("/KAKAO/VerifyAuth/Status/" + ClientCode + "/" + receiptID, ClientCode, null);
		}

		public ResultVerifyAuth verifyAuth(String ClientCode, String receiptID)
		{
			if (String.IsNullOrEmpty(ClientCode)) 
                throw new BarocertException(-99999999, "이용기관코드가 입력되지 않았습니다.");
			if (String.IsNullOrEmpty(receiptID)) 
                throw new BarocertException(-99999999, "접수아이디가 입력되지 않았습니다.");

			ResponseVerifyAuth requestVerify = new ResponseVerifyAuth();
			requestVerify.clientCode = ClientCode;
			requestVerify.receiptID = receiptID;

			String PostData = toJsonString(requestVerify);

			ResultVerifyAuth response = httppost<ResultVerifyAuth>("/KAKAO/VerifyAuth/Verify", ClientCode, "", PostData, ""); ;

			return response;
		}


		public ResponseCMS requestCMS(String ClientCode, RequestCMS requestCMS, bool isAppUseYN = false)
		{
			if (String.IsNullOrEmpty(ClientCode)) 
                throw new BarocertException(-99999999, "이용기관코드가 입력되지 않았습니다.");
			if (requestCMS == null) 
                throw new BarocertException(-99999999, "자동이체 출금동의 요청정보가 입력되지 않았습니다.");

			if (requestCMS.ci == null || requestCMS.ci.Length == 0) {
				requestCMS.receiverHP = Encrypt(requestCMS.receiverHP);
				requestCMS.receiverName = Encrypt(requestCMS.receiverName);
				requestCMS.receiverBirthday = Encrypt(requestCMS.receiverBirthday);
			} else {
				requestCMS.ci = Encrypt(requestCMS.ci);
			}

			requestCMS.requestCorp = Encrypt(requestCMS.requestCorp);
			requestCMS.bankName = Encrypt(requestCMS.bankName);
			requestCMS.bankAccountNum = Encrypt(requestCMS.bankAccountNum);
			requestCMS.bankAccountName = Encrypt(requestCMS.bankAccountName);
			requestCMS.bankAccountBirthday = Encrypt(requestCMS.bankAccountBirthday);
			requestCMS.bankServiceType = Encrypt(requestCMS.bankServiceType);

			requestCMS.clientCode = ClientCode;
			requestCMS.appUseYN = isAppUseYN;

			String PostData = toJsonString(requestCMS);

			ResponseCMS response = httppost<ResponseCMS>("/KAKAO/CMS/Request", ClientCode, "", PostData, ""); ;

			return response;
		}

		public ResultCMS getCMSState(String ClientCode, String receiptID)
        {
            if (String.IsNullOrEmpty(ClientCode)) 
                throw new BarocertException(-99999999, "이용기관코드가 입력되지 않았습니다.");
            if (String.IsNullOrEmpty(receiptID)) 
                throw new BarocertException(-99999999, "접수아이디가 입력되지 않았습니다.");

            return httpget<ResultCMS>("/KAKAO/CMS/Status/" + ClientCode + "/" + receiptID, ClientCode, null);
        }
		
        public ResultVerifyCMS verifyCMS(String ClientCode, String receiptID)
        {
            if (String.IsNullOrEmpty(ClientCode)) 
                throw new BarocertException(-99999999, "이용기관코드가 입력되지 않았습니다.");
            if (String.IsNullOrEmpty(receiptID)) 
                throw new BarocertException(-99999999, "접수아이디가 입력되지 않았습니다.");

            return httpget<ResultVerifyCMS>("/KAKAO/CMS/Verify", ClientCode, null);
        }
	}
}