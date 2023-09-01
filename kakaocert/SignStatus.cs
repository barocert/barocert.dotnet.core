﻿using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class SignStatus
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
        public String reqTitle;
        [DataMember]
        public String authCategory;
        [DataMember]
        public String returnURL;
        [DataMember]
        public String tokenType;
        [DataMember]
        public String requestDT;
        [DataMember]
        public String viewDT;
        [DataMember]
        public String completeDT;
        [DataMember]
        public String expireDT;
        [DataMember]
        public String verifyDT;
        [DataMember]
        public String scheme;
        [DataMember]
        public bool appUseYN;
    }
}
