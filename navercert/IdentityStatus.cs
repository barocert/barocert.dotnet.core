﻿using System;
using System.Runtime.Serialization;

namespace Barocert.navercert
{
    [DataContract]
    public class IdentityStatus
    {
        [DataMember]
        public String receiptID;
        [DataMember]
        public String clientCode;
        [DataMember]
        public int state;
        [DataMember]
        public int expireIn;
        [DataMember]
        public String callCenterName;
        [DataMember]
        public String callCenterNum;
        [DataMember]
        public String returnURL;
        [DataMember]
        public String expireDT;
        [DataMember]
        public String scheme;
        [DataMember]
        public String deviceOSType;
        [DataMember]
        public bool appUseYN;
    }
}
