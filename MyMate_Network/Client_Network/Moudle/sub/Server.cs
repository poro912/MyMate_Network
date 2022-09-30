using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Diagnostics;
using ClientNetwork.trash;
using Protocol;

namespace ClientNetwork.Moudle.sub
{
	static public class Default
	{
		public const int port = 8090;
		public const string Address = "127.0.0.1";
	}

	// 서버의 접속 정보를 담는 클래스
	public class Server
	{
		// 서버의 tcpclient 정보 저장
		public TcpClient tcpclient;
		// 서버의 stream 저장
		public NetworkStream stream;
		public string address;
		public int port;

		public Send send;
		public Receive receive;


		public Server(
			string address = Default.Address
			,int port = Default.port)
		{
			Console.WriteLine("Connect 객체 생성");
			this.address = address;
			this.port = port;
			Console.WriteLine("데이터 삽입 완료");
			this.tcpclient = new TcpClient();
			Console.WriteLine("객체 생성 완료");

			// 클라이언트의 전송 클래스
			this.send = new Send();

			// 클라이언트의 수신 클래스
			this.receive = new();

		}

		~Server()
		{
			tcpclient.Close();
		}

		public void Start()
		{
			Console.Write("커넥트 실행 \t");
			try
			{
				//this.tcpclient.Connect("127.0.0.1", 8090);
				this.tcpclient.Connect(address, port);
				
				//
				this.stream = tcpclient.GetStream();

				this.send.setStream(stream);

				this.receive.setStream(stream);

				this.receive.Start();

				//stream.BeginRead()
			}
			catch(Exception e)
			{
				Console.Write("\n커넥트 에러 발생 \t");
				Console.WriteLine(e.ToString());
				return;
			}
			Console.WriteLine("성공");
		}

		
		public void MessageRecieved(IAsyncResult ar)
		{
			
		}

	}
}
