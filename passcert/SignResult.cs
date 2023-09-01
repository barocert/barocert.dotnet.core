﻿using System;
using System.Runtime.Serialization;

namespace Barocert.passcert
{
    [DataContract]
    public class SignResult
    {
        [DataMember]
        public string receiptID;
        [DataMember]
        public int state;
        [DataMember]
        public string receiverHP;
        [DataMember]
        public string receiverName;
        [DataMember]
        public string receiverDay;
        [DataMember]
        public string receiverYear;
        [DataMember]
        public string receiverGender;
        [DataMember]
        public string receiverForeign;
        [DataMember]
        public string receiverTelcoType;
        [DataMember]
        public string signedData;
        [DataMember]
        public string ci;
    }
}
