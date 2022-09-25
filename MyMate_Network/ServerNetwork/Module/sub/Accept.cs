using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Net;

namespace ServerNetwork.Module.sub

{
	// 사용 안되고 있음
    class Accept
	{
		// Accept가 일어났을 때 진행할 명령어 순서
		public Socket process(ref SocketAndEndPoint sop)
		{
			Socket socket = null;
			//socket = sop.socket.Accept();

			// 포트할당 및 스레드 생성
			// 지속 통신 시작 
			
			// 새로운 연결이 완료되었으므로 공개연결 종료
			//sop.socket.Close();
			return socket;
		}
	}
}
	