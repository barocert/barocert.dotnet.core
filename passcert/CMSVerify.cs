using System;
using System.Runtime.Serialization;

namespace Barocert.passcert
{
    [DataContract]
    public class CMSVerify
    {
        [DataMember]
        public string receiverHP;
        [DataMember]
        public string receiverName;
    }
}
