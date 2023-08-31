using System;
using System.Runtime.Serialization;

namespace Barocert.passcert
{
    [DataContract]
    public class IdentityVerify
    {
        [DataMember]
        public String receiverHP;
        [DataMember]
        public String receiverName;
    }
}
