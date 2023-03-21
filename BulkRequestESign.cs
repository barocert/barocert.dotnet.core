using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using static Kakaocert.KakaocertService;

namespace Kakaocert
{
    [DataContract]
    public class BulkRequestESign
	{
		[DataMember]
		public String clientCode;
		[DataMember]
		public String requestID;
		[DataMember]
		public String receiverHP;
		[DataMember]
		public String receiverName;
		[DataMember]
		public String receiverBirthday;
		[DataMember]
		public String ci;
		[DataMember]
		public String reqTitle;
		[DataMember]
		public int expireIn;

		[DataMember]
		public List<Tokens> token;

		[DataMember]
		public String tokenType;
		[DataMember]
		public String returnURL;
		[DataMember]
		public bool appUseYN;
	}

}
