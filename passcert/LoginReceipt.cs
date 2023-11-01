using System;
using System.Runtime.Serialization;

namespace Barocert.passcert
{
    [DataContract]
    public class LoginReceipt
    {
        [DataMember]
        public string receiptID;
        [DataMember]
        public string scheme;
        [DataMember]
        public string marketUrl;
    }
}
