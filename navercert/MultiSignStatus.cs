using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Barocert.navercert
{
    [DataContract]
    public class MultiSignStatus
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
        public List<string> tokenTypes;
        [DataMember]
        public string expireDT;
        [DataMember]
        public string scheme;
        [DataMember]
        public string deviceOSType;
        [DataMember]
        public bool appUseYN;
    }
}
