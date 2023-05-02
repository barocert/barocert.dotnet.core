using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class CMSReceipt
    {
		[DataMember]
		public string receiptID;
		[DataMember]
		public string scheme;
	}

}
