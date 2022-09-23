// 하나만 동작해야함

// Endpoint 를 사용한 코드
// #define ENDPOINT

// 소켓 리스너를 이용한 코드
#define SOCKET


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

#if ENDPOINT
		public Socket socket;
		public IPEndPoint endpoint;
		
		private void Init(IPAddress address, int port)
		{
			this.address = address;
			this.port = port;

			// TCP 방식으로 소켓 초기화
			socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			endpoint = new(this.address, this.port);

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bind">임시 대기 가능한 클라언트 수</param>
		public void bind(int bind = 5)
		{
			// 포트 설정
			try
			{
				// 포트를 바인드
				Console.Write("포트 바인드  포트번호 : " + port + "\t");
				// 소켓과 End point bind
				socket.Bind(endpoint);

				// 대기를 하는 포트의 수를 지정
				socket.Listen(bind);
			}
			catch (Exception ex)
			{
				Console.WriteLine(port + "포트 바인드 실패");
				Console.WriteLine("에러 내용 : " + ex.Message);
				Close();
			}
		}

		public void Start()
		{
			bind();
		}

		public void Close()
		{
			socket.Close();
			socket.Dispose();
		}

#elif SOCKET
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
#endif
	}

}
