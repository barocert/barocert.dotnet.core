using System;
using System.Runtime.Serialization;

namespace Kakaocert
{
    [DataContract]
    public class ResponseESign
	{
		[DataMember]
		public String receiptId;
		[DataMember]
		public String scheme;
	}

}
