using System;
using System.Runtime.Serialization;

namespace Barocert.navercert
{
    [DataContract]
    public class MultiSignTokens
    {
        [DataMember]
        public string token;
        [DataMember]
        public string tokenType;
    }
}
