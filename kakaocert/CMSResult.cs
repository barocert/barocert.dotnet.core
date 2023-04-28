using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class CMSResult
    {
        [DataMember]
        public string receiptID;
        [DataMember]
        public string requestID;
        [DataMember]
        public string state;
        [DataMember]
        public string signedData;
        [DataMember]
        public string ci;
    }
}
