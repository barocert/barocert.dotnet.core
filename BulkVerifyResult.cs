using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kakaocert
{
    [DataContract]
    public class BulkVerifyResult
	{
        [DataMember]
		public String receiptID;
		[DataMember]
		public String requestID;
		[DataMember]
		public String state;
		[DataMember]
		public List<String> bulkSignedData;
		[DataMember]
		public String ci;

	}
}
