﻿using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Barocert.navercert
{
    [DataContract]
    public class MultiSignResult
    {
        [DataMember]
        public String receiptID;
        [DataMember]
        public int state;
        [DataMember]
        public List<String> multiSignedData;
        [DataMember]
        public String ci;
        [DataMember]
        public String receiverName;
        [DataMember]
        public String receiverDay;
        [DataMember]
        public String receiverYear;
        [DataMember]
        public String receiverHP;
        [DataMember]
        public String receiverGender;
        [DataMember]
        public String receiverEmail;
        [DataMember]
        public String receiverForeign;
    }
}