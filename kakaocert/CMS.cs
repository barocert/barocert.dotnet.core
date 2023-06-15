﻿using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class CMS
    {
		[DataMember]
		public string receiverHP;
		[DataMember]
		public string receiverName;
		[DataMember]
		public string receiverBirthday;
		[DataMember]
		public string reqTitle;
		[DataMember]
		public int? expireIn;
		[DataMember]
		public string returnURL;
		[DataMember]
		public string requestCorp;
		[DataMember]
		public string bankName;
		[DataMember]
		public string bankAccountNum;
		[DataMember]
		public string bankAccountName;
		[DataMember]
		public string bankAccountBirthday;
		[DataMember]
		public string bankServiceType;
		[DataMember]
		public bool appUseYN;
	}
}
