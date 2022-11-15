using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Default
{
	public class Network
	{
		// 기본값 설정
		public const int port = 8090;
		public const string Address = "172.18.7.140";

#if DEBUG
		//public const string Address = "127.0.0.1";
#elif RELEASE
		
#endif
		public const string IP = "172.18.7.140";
		public const string SubNetmask = "255.255.255.0";
		public const string Gateway = "172.18.7.254";
		public const string DNS = "220.66.10.11";
		public const string SubDNS = "220.66.10.12";

		public const string Address_LoopBack = "127.0.0.1";
		public const string Address_Seat = "172.18.7.140";
	}
}
