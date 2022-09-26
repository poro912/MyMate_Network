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

		// 커넥트 객체
		private Server server;
		// 통신 스레드
		private Thread thread;
		// 스레드 정지 신호가 발생했는지 확인
		private bool run = false;

		// 생성자
		// 포트 할당과 스레드 실행을 동시에 한다.
		private Client()
		{
			// 포트를 할당
			Console.Write("포트 생성 \t\t");
			this.server = new ();
			Console.WriteLine("성공");

			Console.Write("포트 실행 \t\t");
			try
			{
				// 커넥트 시도
				this.server.Start();
				Console.WriteLine("성공");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			// 스레드를 생성하고 시작한다.
			// this.thread = new Thread(Run);
			// this.Start();
		}

		~Client()
		{
			this.Stop();
			this.thread.Interrupt();
		}

		// 송신을 위한 스레드
		private void Run()
		{
			Console.WriteLine("스레드 실행");
			while(this.run)
			{

			}
			Console.WriteLine("스레드 종료");
		}

		// 스레드를 실행한다.
		public void Start()
		{
			if(!this.run)
			{
				
				//client.Connect();
				this.run = true;
				this.thread.Start();

				// Receive 객체에 스트림을 지정해준다.
				Receive.SetStream(this.server.stream);
				// 수신을 받기 시작한다.
				Receive.StartReceive();
			}
		}

		// 스레드 정지 신호를 발생 시킨다.
		public void Stop()
		{
			Console.WriteLine("스레드 종료 신호 발생");
			this.run = false;
		}

		public void Send(ref string data)
		{
			server.send(ref data);
		}
	}
}
