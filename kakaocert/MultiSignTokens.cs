using System;
using System.Runtime.Serialization;

namespace Barocert.kakaocert
{
    [DataContract]
    public class MultiSignTokens
    {
		[DataMember]
		public string reqTitle;
		[DataMember]
		public string token;
	}
}
