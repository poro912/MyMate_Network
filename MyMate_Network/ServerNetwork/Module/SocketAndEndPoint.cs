using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Net;

namespace MyMate_Network
{
	public class SocketAndEndPoint
	{
		public Socket socket;
		public IPEndPoint endpoint;
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

		private void Init()
		{
			Init(8090);
		}
		private void Init(int port)
		{
			Init(IPAddress.Any, port);
		}
		private void Init(IPAddress address ,int port)
		{
			this.address = address;
			this.port = port;

			// TCP 방식으로 소켓 초기화
			this.socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			this.endpoint = new(this.address, this.port);

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
				Console.Write("포트 바인드  포트번호 : " + this.port + "\t");
				// 소켓과 End point bind
				this.socket.Bind(endpoint);

				// 대기를 하는 포트의 수를 지정
				this.socket.Listen(bind);
			}
			catch (Exception ex)
			{
				Console.WriteLine(this.port + "포트 바인드 실패");
				Console.WriteLine("에러 내용 : " + ex.Message);
				this.Close();
			}
		}
		
		public void Start()
		{
			bind();
		}

		public void Close()
		{
			this.socket.Close();
			this.socket.Dispose();
		}
	}
}
