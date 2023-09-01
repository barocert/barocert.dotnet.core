using System;
using System.Runtime.Serialization;

namespace Barocert.passcert
{
    [DataContract]
    public class CMSResult
    {
        [DataMember]
        public string receiptID;
        [DataMember]
        public string state;
        [DataMember]
        public string receiverHP;
        [DataMember]
        public string receiverName;
        [DataMember]
        public string receiverYear;
        [DataMember]
        public string receiverDay;
        [DataMember]
        public string receiverGender;
        [DataMember]
        public string receiverForeign;
        [DataMember]
        public string receiverTelcoType;
        [DataMember]
        public string signedData;
        [DataMember]
        public string ci;
    }
}
