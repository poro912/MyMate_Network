using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Protocol;

namespace Client_to_Server
{
	static public class Default
	{
		public const int port = 8090;
		public const string Address = "127.0.0.1";
	}

	// 서버에 대한 연결 정보를 갖고 있기위한 클래스
	public class Server : Communicater
	{
		// 서버의 tcpclient 정보 저장
		public TcpClient tcpclient;

		// 서버의 stream 저장
		private NetworkStream? stream;
		public readonly string address;
		public readonly int port;

		public Send send;
		public DynamicSend dynamicSend;
		public Receive receive;

		public Communicater? communicater;

		// 싱글톤 구현
		static private Server? instance;
		static public Server Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Server();
				}
				return instance;
			}
		}

		private Server(
			string address = Default.Address,
			int port = Default.port
			)
		{
			Console.WriteLine("Connect 객체 생성");
			this.address = address;
			this.port = port;

			Console.WriteLine("데이터 삽입 완료");
			tcpclient = new();

			Console.WriteLine("객체 생성 완료");

			// 클라이언트의 전송 클래스
			send = new();

			// 클라이언트의 수신 클래스
			receive = new();

			// 송수신 시작
			Start();
		}

		~Server()
		{
			tcpclient.Close();
		}

		// 통신을 시작할 때 실행한다.
		public void Start()
		{
			Console.Write("커넥트 실행 \t");
			try
			{
				//this.tcpclient.Connect("127.0.0.1", 8090);
				tcpclient.Connect(address, port);

				// 스트림을 현재 객체에 저장
				stream = tcpclient.GetStream();

				
				// 클라이언트의 전송 클래스
				dynamicSend = new(stream);

				// 전송 객체에 스트림을 저장한다.
				send.setStream(stream);

				// 수신 객체에 스트림을 저장한다.
				receive.setStream(stream);

				// 수신을 시작한다.
				receive.Start();



				// 송수신 스트림 설정
				SetStream(stream);

				//수신을 시작한다.
				this.ReceiveStart();
			}
			catch (Exception e)
			{
				Console.Write("\n커넥트 에러 발생 \t");
				Console.WriteLine(e.ToString());
				return;
			}
			Console.WriteLine("성공");
		}
	}
}
