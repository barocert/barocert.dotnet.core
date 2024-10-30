using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class MultiSignResult
    {
        [DataMember]
        public string receiptID;
        [DataMember]
        public string state;
        [DataMember]
        public List<string> multiSignedData;
        [DataMember]
        public string ci;
        [DataMember]
        public string receiverName;
        [DataMember]
        public string receiverYear;
        [DataMember]
        public string receiverDay;
        [DataMember]
        public string receiverHP;
        [DataMember]
        public string receiverGender;
    }
}
