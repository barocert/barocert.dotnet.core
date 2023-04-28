using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class MultiSignReceipt
    {
        [DataMember]
        public string receiptId;
        [DataMember]
        public string scheme;
    }
}
