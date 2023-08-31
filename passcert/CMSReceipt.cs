using System;
using System.Runtime.Serialization;

namespace Barocert.passcert
{
    [DataContract]
    public class CMSReceipt
    {
		[DataMember]
		public string receiptId;
		[DataMember]
		public string scheme;
        [DataMember]
        public string marketUrl;
    }

}
