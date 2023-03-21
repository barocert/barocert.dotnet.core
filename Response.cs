using System;
using System.Runtime.Serialization;

namespace Kakaocert
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public long code;
        [DataMember]
        public String message;
    }
}
