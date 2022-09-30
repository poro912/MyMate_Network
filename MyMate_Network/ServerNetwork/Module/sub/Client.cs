using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Protocol;
using ServerNetwork.trash;

namespace ServerNetwork.Module.sub
{
	public class Client
	{
		public TcpClient tcpClient;
		private NetworkStream stream;
		public Socket socket;
		// Thread thread;

		public Send send;
		public Receive receive;

		// 생성된 클라이언트 구조체를 초기화
		public Client(TcpClient tcpClient)
		{
			// tcpClinet 객체를 저장
			this.tcpClient = tcpClient;
			// 클라이언트의 스트림을 저장
			this.stream = tcpClient.GetStream();
			// 클라이언트의 소켓을 저장
			this.socket = tcpClient.Client;
			// 클라이언트의 전송 클래스
			this.send = new(stream);
			// 클라이언트의 수신 클래스
			this.receive = new(stream);
		}
	}
}
