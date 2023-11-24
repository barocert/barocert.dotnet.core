﻿using Linkhub;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
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
        public string extraMessage;
        [DataMember]
        public int? expireIn;
        [DataMember]
        public List<MultiSignTokens> tokens = new List<MultiSignTokens>();
        [DataMember]
        public string tokenType;
        [DataMember]
        public string returnURL;
        [DataMember]
        public bool appUseYN;

        public void AddToken(MultiSignTokens token)
        {
            tokens.Add(token);
        }
    }
}
