using System;
using System.Runtime.Serialization;

namespace Barocert.passcert
{
    [DataContract]
    public class CMSStatus
    {
		[DataMember]
		public string receiptID;
		[DataMember]
		public string clientCode;
		[DataMember]
		public int state;
		[DataMember]
		public int expireIn;
		[DataMember]
		public string callCenterName;
		[DataMember]
		public string callCenterNum;
        [DataMember]
        public String reqTitle;
        [DataMember]
        public String reqMessage;
        [DataMember]
        public String requestDT;
        [DataMember]
        public String completeDT;
        [DataMember]
        public String expireDT;
        [DataMember]
        public String rejectDT;
        [DataMember]
        public String tokenType;
        [DataMember]
        public bool userAgreementYN;
        [DataMember]
        public bool receiverInfoYN;
        [DataMember]
        public String telcoType;
        [DataMember]
        public String deviceOSType;
        [DataMember]
		public string scheme;
		[DataMember]
		public bool appUseYN;

    }
}
