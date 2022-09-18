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
		TcpClient tcpClient;
		NetworkStream stream;
		// Thread thread;

		public Client(TcpClient tcpClient)
		{
			this.tcpClient = tcpClient;
			this.stream = tcpClient.GetStream();
		}

		public void send(string at)
		{
			Console.WriteLine("클라이언트에 데이터를 전송합니다.");
			Send.SendString(this.stream,"Hello World");

		}
	}
}
