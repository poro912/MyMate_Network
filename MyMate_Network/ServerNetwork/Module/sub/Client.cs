using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerNetwork.Module.sub
{
	public class Client
	{
		public TcpClient tcpClient;
		private NetworkStream stream;
		public Socket socket;
		// Thread thread;

		// 생성된 클라이언트 구조체를 초기화
		public Client(TcpClient tcpClient)
		{
			// tcpClinet 객체를 저장
			this.tcpClient = tcpClient;
			// 클라이언트의 스트림을 저장
			this.stream = tcpClient.GetStream();
			// 
			this.socket = tcpClient.Client;
		}

		public void send(string at)
		{
			if (this.socket.RemoteEndPoint != null)
				Console.WriteLine(this.socket.RemoteEndPoint.ToString() + "클라이언트에 데이터를 전송합니다.");
			string temp = "Hello World";
			Send.SendString(this.stream, ref temp);
		}
	}
}
