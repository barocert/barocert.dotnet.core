using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class CMSReceipt
    {
        [DataMember]
        public string receiptId;
        [DataMember]
        public string tx_id;
    }

}
