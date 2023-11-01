using System;
using System.Runtime.Serialization;

namespace Barocert.navercert
{
    [DataContract]
    public class MultiSignTokens
    {
        [DataMember]
        public String token;
        [DataMember]
        public String tokenType;
    }
}
