using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Diagnostics;

namespace ClientNetwork.Moudle.sub
{
	static public class Default
	{
		public const int port = 8090;
		public const string Address = "127.0.0.1";
	}

	public class Connect
	{
		public TcpClient tcpclient;
		public NetworkStream stream;
		public string address;
		public int port;


		public Connect(
			string address = Default.Address
			,int port = Default.port)
		{
			Console.WriteLine("Connect 객체 생성");
			this.address = address;
			this.port = port;
			Console.WriteLine("데이터 삽입 완료");
			this.tcpclient = new TcpClient();
			Console.WriteLine("객체 생성 완료");
		}

		~Connect()
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
