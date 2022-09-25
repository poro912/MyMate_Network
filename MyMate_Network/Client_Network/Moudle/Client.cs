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

		private Connect connect;
		private Thread thread;
		private bool run = false;

		private Client()
		{
			Console.Write("포트 생성 \t\t");
			this.connect = new ();
			Console.WriteLine("성공");

			Console.Write("포트 실행 \t\t");
			try
			{
				this.connect.Start();
				Console.WriteLine("성공");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			this.thread = new Thread(Run);
			this.Start();
		}

		~Client()
		{
			this.Stop();
			this.thread.Interrupt();
		}

		private void Run()
		{
			Console.WriteLine("스레드 실행");
			while(this.run)
			{

			}
			Console.WriteLine("스레드 종료");
		}

		public void Start()
		{
			if(!this.run)
			{
				//client.Connect();
				this.run = true;
				this.thread.Start();

				// Receive 객체에 스트림을 지정해준다.
				Receive.SetStream(this.connect.stream);
				Receive.StartReceive();
			}
		}

		public void Stop()
		{
			Console.WriteLine("스레드 종료 신호 발생");
			this.run = false;
		}
	}
}
