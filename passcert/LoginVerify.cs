using System;
using System.Runtime.Serialization;

namespace Barocert.passcert
{
    [DataContract]
    public class LoginVerify
    {
        [DataMember]
        public string receiverHP;
        [DataMember]
        public string receiverName;
    }
}
