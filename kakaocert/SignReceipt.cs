using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class SignReceipt
    {
        [DataMember]
        public string receiptId;
        [DataMember]
        public string scheme;
    }

}
