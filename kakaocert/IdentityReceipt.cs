using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class IdentityReceipt
    {
        [DataMember]
        public string clientCode;
        [DataMember]
        public string receiptID;
    }
}
