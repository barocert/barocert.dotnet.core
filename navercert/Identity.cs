﻿using System;
using System.Runtime.Serialization;

namespace Barocert.navercert
{
    [DataContract]
    public class Identity
    {
        [DataMember]
        public String receiverHP;
        [DataMember]
        public String receiverName;
        [DataMember]
        public String receiverBirthday;
        [DataMember]
        public String callCenterNum;
        [DataMember]
        public int? expireIn;
        [DataMember]
        public String returnURL;
        [DataMember]
        public String deviceOSType;
        [DataMember]
        public bool appUseYN;
    }
}
