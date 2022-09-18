#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Diagnostics;
using ClientNetwork.Moudle.sub;

namespace ClientNetwork.Moudle
{
	public class Client
	{
		// 싱글톤 구현
		static private Client instance;
		static public Client Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Client();
				}
				return instance;
			}
		}

		static private Connect connect;
		static private Thread thread;
		static private bool run = false;

		private Client()
		{
			Console.Write("포트 생성 \t\t");
			connect = new();
			Console.WriteLine("성공");

			Console.Write("포트 실행 \t\t");
			try
			{
				connect.Start();
				Console.WriteLine("성공");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			thread = new Thread(Run);
			this.Start();
		}

		~Client()
		{
			Stop();
		}

		static private void Run()
		{
			Console.WriteLine("스레드 실행");
			while(run)
			{

			}
			Console.WriteLine("스레드 종료");
		}

		public void Start()
		{
			if(!run)
			{
				//client.Connect();
				run = true;
				thread.Start();

				// Receive 객체에 스트림을 지정해준다.
				Receive.SetStream(connect.stream);
				Receive.StartReceive();
			}
		}

		public void Stop()
		{
			run = false;
		}
	}
}
