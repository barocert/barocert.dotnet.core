using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Barocert.passcert
{
    [DataContract]
    public class LoginResult
    {
        [DataMember]
        public String receiptID;
        [DataMember]
        public int state;
        [DataMember]
        public String receiverName;
        [DataMember]
        public String receiverDay;
        [DataMember]
        public String receiverYear;
        [DataMember]
        public String receiverGender;
        [DataMember]
        public String receiverForeign;
        [DataMember]
        public String receiverTelcoType;
        [DataMember]
        public String signedData;
        [DataMember]
        public String ci;
    }
}
