using System;
using System.Runtime.Serialization;

namespace Barocert.passcert
{
    [DataContract]
    public class IdentityVerify
    {
        [DataMember]
        public string receiverHP;
        [DataMember]
        public string receiverName;
    }
}
