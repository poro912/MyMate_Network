using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Net;

namespace ServerToClinet
{
	// 기본값 설정
	// 소켓과 Endpoint 정보를 저장하는 클래스
	public class SocketAndEndPoint
	{
		public IPAddress address;
		public int port;

		public TcpListener Listener;
		public TcpClient? Client;

		public SocketAndEndPoint(int port = Default.Network.port) : this(IPAddress.Any, port){}
		public SocketAndEndPoint(IPAddress address, int port = Default.Network.port)
		{
			this.address = address;
			this.port = port;

			Listener = new TcpListener(address, port);
		}

		~SocketAndEndPoint()
		{
			Close();
		}

		public void Start()
		{
			Console.WriteLine("소켓 활성화");
			Listener.Start();
		}

		public void Close()
		{
			Console.WriteLine("소켓 중지");
			Listener.Stop();
			if(Client != null)
				Client.Close();
		}

		// 소켓에 들어오는 Accept 요청을 받기위한 메소드
		public TcpClient? Accept()
		{
			TcpClient? client = null;
			try
			{
				client = Listener.AcceptTcpClient();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw;
			}
			return client;
		}
	}
}
