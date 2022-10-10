#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Diagnostics;
using ClientNetwork.Moudle.sub;
using System.Net.Http;

using Protocol;

namespace ClientNetwork.trash
{
    /*
	public class Client
	{
		// 커넥트 객체
		public Server server;

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

		}
		
		public void Send(string data)
		{
			this.server.send.Data(data);
		}

	}
	*/
}


// 통신 스레드
//private Thread thread;
// 스레드 정지 신호가 발생했는지 확인
//private bool run = false;

/*
		~Client()
		{
			//this.Stop();
			//this.thread.Interrupt();
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

				//server.receive.getNextData();
			}
		}

		// 스레드 정지 신호를 발생 시킨다.
		public void Stop()
		{
			Console.WriteLine("스레드 종료 신호 발생");
			this.run = false;
		}
		*/

// 스레드를 생성하고 시작한다.
//this.thread = new Thread(Run);
// this.Start();