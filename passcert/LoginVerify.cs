using System;
using System.Runtime.Serialization;

namespace Barocert.passcert
{
    [DataContract]
    public class LoginVerify
    {
        [DataMember]
        public String receiverHP;
        [DataMember]
        public String receiverName;
    }
}
