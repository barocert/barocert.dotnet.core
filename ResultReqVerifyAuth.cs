using System;
using System.Runtime.Serialization;

namespace Kakaocert
{
    [DataContract]
    public class ResultReqVerifyAuth
    {
        [DataMember]
        public String receiptId;
        [DataMember]
        public String scheme;
    }
}
