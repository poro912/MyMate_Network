using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using ServerNetwork.Module.sub;

namespace ServerNetwork.Module
{
	// 해당 클래스의 인스턴스에 대한 정보를 가져오면 자동으로 바인드가 시작된다.
	public class Server
	{
		// 서버 클래스를 가져오면 곧바로 네트워킹이 실행되며 동작된다.

		// 싱글톤 구현
		static private Server instance;
		public static Server Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new();
				}
				return instance;
			}
		}
		static private SocketAndEndPoint sep;
		
		static private Thread thread;
		static private Thread accept_thread;
		static private ClientContatiner clients = new ();
		static private bool run = false;

		

		// 객체가 생성된 직후 스레드를 생성하여 문장을 지속 실행함
		private Server()
		{
			// 포트를 할당
			Console.Write("포트 생성 \t\t");
			sep = new();
			Console.WriteLine("성공");

			// Accept 스레드에 메소드 할당
			Console.Write("Accept 스레드 생성 \t");
			accept_thread = new Thread(() => AcceptRun());
			Console.WriteLine("성공");

			// Accept 스레드 실행
			Start();
		}

		// 외부로부터 통신 요청이 있다면 통신 요청을 받아 클라이언트 스레드로 만들어줌
		static private void AcceptRun()
		{
			Console.WriteLine("Accept 스레드 실행\n");

			// run 변수가 true 일동안 실행
			while (run)
			{
				TcpClient ?client = null;		// 클라이언트 정보 저장 null able 형 
				
				// Accept 실행 후 값을 반환하면 새로운 클라이언트 접근
				client = sep.Accept();
				if(client != null)
				{
					Console.Write("새로운 클라이언트 접근 : \t");
					Console.Write(client.Client.RemoteEndPoint.ToString());
					Console.WriteLine("\n");
					clients.add(client);
				}
			}

			Console.WriteLine("Accept 스레드 종료\n");
			return;
		}

		// 스레드를 동작시키는 메소드
		public void Start()
		{
			// 스레드가 동작상태가 아니라면 
			if (!run)
			{
				// 동작할 수 있도록 상태 변경
				run = true;
				sep.Start();

				// Accept 스레드 실행
				accept_thread.Start();
			}
		}

		// 스레드를 중지 시키는 메소드
		public void Stop()
		{
			// 동작을 false로 전환
			// 동작 마무리 이후 자동 종료
			run = false;
			sep.Close();
		}

	}

}
