﻿using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Barocert.navercert
{
    [DataContract]
    public class MultiSign
    {
        [DataMember]
        public string receiverHP;
        [DataMember]
        public string receiverName;
        [DataMember]
        public string receiverBirthday;
        [DataMember]
        public string reqTitle;
        [DataMember]
        public string reqMessage;
        [DataMember]
        public string callCenterNum;
        [DataMember]
        public int? expireIn;
        [DataMember]
        public string returnURL;
        [DataMember]
        public string deviceOSType;
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
