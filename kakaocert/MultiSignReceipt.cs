﻿using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class MultiSignReceipt
    {
        [DataMember]
        public string receiptID;
        [DataMember]
        public string scheme;
    }
}
