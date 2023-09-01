﻿using System;
using System.Runtime.Serialization;

namespace Barocert.passcert
{
    [DataContract]
    public class SignStatus
    {
        [DataMember]
        public string receiptID;
        [DataMember]
        public string clientCode;
        [DataMember]
        public int state;
        [DataMember]
        public int expireIn;
        [DataMember]
        public string callCenterName;
        [DataMember]
        public string callCenterNum;
        [DataMember]
        public string reqTitle;
        [DataMember]
        public string reqMessage;
        [DataMember]
        public string requestDT;
        [DataMember]
        public string completeDT;
        [DataMember]
        public string expireDT;
        [DataMember]
        public string rejectDT;
        [DataMember]
        public string tokenType;
        [DataMember]
        public bool userAgreementYN;
        [DataMember]
        public bool receiverInfoYN;
        [DataMember]
        public string telcoType;
        [DataMember]
        public string deviceOSType;
        [DataMember]
        public string originalTypeCode;
        [DataMember]
        public string originalURL;
        [DataMember]
        public string originalFormatCode;
        [DataMember]
        public string scheme;
        [DataMember]
        public bool appUseYN;
    }
}
