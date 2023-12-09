﻿using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class IdentityStatus
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
        public string authCategory;
        [Obsolete]
        public string returnURL;
        [Obsolete]
        public string tokenType;
        [DataMember]
        public string requestDT;
        [DataMember]
        public string viewDT;
        [DataMember]
        public string completeDT;
        [DataMember]
        public string expireDT;
        [DataMember]
        public string verifyDT;
        [Obsolete]
        public string scheme;
        [Obsolete]
        public bool appUseYN;
    }
}
