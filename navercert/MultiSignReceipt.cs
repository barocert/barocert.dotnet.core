using System;
using System.Runtime.Serialization;

namespace Barocert.navercert
{
    [DataContract]
    public class MultiSignReceipt
    {
        [DataMember]
        public String receiptID;
        [DataMember]
        public String scheme;
        [DataMember]
        public String marketUrl;
    }
}
