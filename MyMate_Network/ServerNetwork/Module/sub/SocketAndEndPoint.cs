

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Net;

namespace ServerNetwork.Module.sub
{
	// 기본값 설정
	static public class Default
	{
		public const int port = 8090;
		public const string Address = "127.0.0.1";
	}

	// 소켓과 Endpoint 정보를 저장하는 클래스
	public class SocketAndEndPoint
	{
		public IPAddress address;
		public int port;

		public SocketAndEndPoint()
		{
			Init();
		}
		public SocketAndEndPoint(int port)
		{
			Init(port);
		}

		~ SocketAndEndPoint()
		{
			this.Close();
		}

		private void Init()
		{
			Init(Default.port);
		}
		private void Init(int port)
		{
			Init(IPAddress.Any, port);
		}

		public TcpListener Listener;
		public TcpClient Client;

		private void Init(IPAddress address, int port)
		{
			this.address = address;
			this.port = port;

			this.Listener = new TcpListener(address, port);
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
			Client.Close();
		}

		// 소켓에 들어오는 Accept 요청을 받기위한 메소드
		public TcpClient? Accept()
		{
			TcpClient ?client = null;

			try
			{
				client = Listener.AcceptTcpClient();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			return client;
		}
	}

}
