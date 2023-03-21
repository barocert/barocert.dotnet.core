using System;
using System.Runtime.Serialization;

namespace Kakaocert
{
    [DataContract]
    public class ResponseCMS
	{
		[DataMember]
		public String receiptId;
		[DataMember]
		public String tx_id;
	}

}
