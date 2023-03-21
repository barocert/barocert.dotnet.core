using System;
using System.Runtime.Serialization;

namespace Kakaocert
{
    [DataContract]
    public class Tokens
	{
		[DataMember]
		public String reqTitle;
		[DataMember]
		public String token;
	}
}
