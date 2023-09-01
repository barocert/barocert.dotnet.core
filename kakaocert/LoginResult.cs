using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class LoginResult
    {
        [DataMember]
        public string txID;
        [DataMember]
        public string state;
        [DataMember]
        public string signedData;
        [DataMember]
        public string ci;
    }
}
