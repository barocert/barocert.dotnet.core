﻿using System;
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
        [Obsolete]
        public int expireIn;
        [Obsolete]
        public string callCenterName;
        [Obsolete]
        public string callCenterNum;
        [Obsolete]
        public string reqTitle;
        [Obsolete]
        public string returnURL;
        [DataMember]
        public string expireDT;
        [Obsolete]
        public string tokenType;
        [Obsolete]
        public string scheme;
        [Obsolete]
        public string deviceOSType;
        [Obsolete]
        public bool appUseYN;
    }
}
