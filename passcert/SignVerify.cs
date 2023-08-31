using System;
using System.Runtime.Serialization;

namespace Barocert.passcert
{
    [DataContract]
    public class SignVerify
    {
        [DataMember]
        public String receiverHP;
        [DataMember]
        public String receiverName;
    }
}
