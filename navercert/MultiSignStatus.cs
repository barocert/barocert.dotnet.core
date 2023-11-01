﻿using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Barocert.navercert
{
    [DataContract]
    public class MultiSignStatus
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
        public String returnURL;
        [DataMember]
        public List<String> tokenTypes;
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
