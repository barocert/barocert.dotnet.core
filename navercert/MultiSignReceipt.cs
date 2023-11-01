using System;
using System.Runtime.Serialization;

namespace Barocert.navercert
{
    [DataContract]
    public class MultiSignReceipt
    {
        [DataMember]
        public string receiptID;
        [DataMember]
        public string scheme;
        [DataMember]
        public string marketUrl;
    }
}
