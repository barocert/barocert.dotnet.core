using System;
using System.Runtime.Serialization;

namespace Barocert.navercert
{
    [DataContract]
    public class CMSStatus
    {
        [DataMember]
        public string receiptID;
        [DataMember]
        public string clientCode;
        [DataMember]
        public int state;
        [DataMember]
        public string expireDT;
    }
}
