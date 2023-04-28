using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
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
