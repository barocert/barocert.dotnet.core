﻿using System;
using System.Runtime.Serialization;

namespace Barocert
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public long code;
        [DataMember]
        public string message;
    }
}
