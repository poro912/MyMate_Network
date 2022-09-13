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
		public string address;
		public int port;
		public Connect()
		{
			Init();
		}

		public Connect(
			string address = Default.Address
			,int port = Default.port)
		{
			Init(address,port);
		}

		~Connect()
		{
			tcpclient.Close();
		}

		private void Init()
		{
			Init(Default.port);
		}
		private void Init(int port)
		{
			Init(Default.Address, port);
		}

		private void Init(String address ,int port)
		{
			this.address=address;
			this.port = port;
			this.tcpclient = new TcpClient();
		}

		public void Start()
		{
			try
			{
				//this.tcpclient.Connect("127.0.0.1", 8090);
				this.tcpclient.Connect(address, port);
			}
			catch(Exception e)
			{
				Console.Write("\n커넥트 에러 발생 \t");
				Console.WriteLine(e.ToString());
			}
		}
	}
}
