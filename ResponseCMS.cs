using System;
using System.Runtime.Serialization;

namespace Kakaocert
{
    [DataContract]
    public class ResultVerifyEsign
    {
		[DataMember]
		public String receiptID;
		[DataMember]
		public String requestID;
		[DataMember]
		public String state;
		[DataMember]
		public String signedData;
		[DataMember]
		public String ci;
	}

}
