using System;
using System.Runtime.Serialization;

namespace Barocert.passcert
{
    [DataContract]
    public class IdentityReceipt
    {
        [DataMember]
        public String receiptId;
        [DataMember]
        public String scheme;
        [DataMember]
        public String marketUrl;
    }
}
