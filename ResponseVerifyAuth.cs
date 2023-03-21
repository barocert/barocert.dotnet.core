using System;
using System.Runtime.Serialization;

namespace Kakaocert
{
    [DataContract]
    public class ResponseVerifyAuth
	{
		[DataMember]
		public String clientCode;
		[DataMember]
		public String receiptID;
	}
}
