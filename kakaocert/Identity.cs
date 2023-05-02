﻿using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class Identity
    {
		[DataMember]
		public string receiverHP;
		[DataMember]
		public string receiverName;
		[DataMember]
		public string receiverBirthday;
		[DataMember]
		public string ci;
		[DataMember]
		public string reqTitle;
		[DataMember]
		public int? expireIn;
		[DataMember]
		public string token;
		[DataMember]
		public string returnURL;
		[DataMember]
		public bool appUseYN;
	}
}
