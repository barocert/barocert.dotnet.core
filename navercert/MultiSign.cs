﻿using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Barocert.navercert
{
    [DataContract]
    public class MultiSign
    {
        [DataMember]
        public String receiverHP;
        [DataMember]
        public String receiverName;
        [DataMember]
        public String receiverBirthday;
        [DataMember]
        public String reqTitle;
        [DataMember]
        public String reqMessage;
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
        [DataMember]
        public List<MultiSignTokens> tokens = new List<MultiSignTokens>();

        public void addToken(MultiSignTokens token)
        {
            tokens.Add(token);
        }
    }
}
