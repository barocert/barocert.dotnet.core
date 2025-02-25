﻿using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class CMSResult
    {
        [DataMember]
        public string receiptID;
        [DataMember]
        public string state;
        [DataMember]
        public string signedData;
        [DataMember]
        public string ci;
        [DataMember]
        public string receiverName;
        [DataMember]
        public string receiverYear;
        [DataMember]
        public string receiverDay;
        [DataMember]
        public string receiverHP;
        [DataMember]
        public string receiverGender;
        [DataMember]
        public string receiverForeign;
        [DataMember]
        public string receiverTelcoType;
    }
}
