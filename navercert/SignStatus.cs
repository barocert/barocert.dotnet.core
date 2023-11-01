using System;
using System.Runtime.Serialization;

namespace Barocert.navercert
{
    [DataContract]
    public class SignStatus
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
        public string reqTitle;
        [DataMember]
        public string returnURL;
        [DataMember]
        public string expireDT;
        [DataMember]
        public string tokenType;
        [DataMember]
        public string scheme;
        [DataMember]
        public string deviceOSType;
        [DataMember]
        public bool appUseYN;
    }
}
