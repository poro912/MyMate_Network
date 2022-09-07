using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMate_Network
{
	// 해당 클래스의 인스턴스에 대한 정보를 가져오면 자동으로 바인드가 시작된다.
	public class Server
	{
		static private SocketAndEndPoint sep;
		static private Server instance;
		static private Thread thread;
		static private bool run = false; 

		// 서버 클래스를 가져오면 곧바로 네트워킹이 실행되며 동작된다.
		public static Server Instance
		{
			get {
				if (instance == null)
				{
					instance = new ();
				}
				return instance;
			}
		}

		// 객체가 생성된 직후 스레드를 생성하여 문장을 지속 실행함
		private Server()
		{
			// 포트를 할당
			Console.Write("포트 생성 \t");
			sep = new();
			Console.WriteLine("포트 생성 성공");
			
			// 포트 바인드
			Console.Write("포트 바인드 \t");
			sep.bind();
			Console.WriteLine("포트 바인드 성공");

			// 스레드에 메소드 할당
			thread = new Thread( () => Run() );

			// 스레드 실행
			thread.Start();

			Console.WriteLine("서버 스레드 생성 성공");
		}

		// 외부로부터 통신 요청이 있다면 통신 요청을 받아 클라이언트 스레드로 만들어줌
		static private void Run()
		{
			Console.WriteLine("서버 스레드가 실행되었습니다.");

			// 해당 변수의 원자성이 확보되지 않아 문제가 생길 수 있다.
			// 변수의 내용이 바뀌는 것 보다 스레드의 실행이 먼저되어 실행이 안되는 경우가 발생하였다.
			Server.run = true;

			while(Server.run)
			{
				
			}
			Console.WriteLine("서버 스레드가 종료되었습니다.");
			return;
		}

		// 스레드를 동작시키는 메소드
		static public void Start()
		{
			// 스레드가 동작상태가 아니라면 
			if(!Server.run)
			{
				// 동작한다 알리고 스레드 실행
				Server.run = true;
				thread.Start();
			}
		}

		// 스레드를 중지 시키는 메소드
		static public void Stop()
		{
			// 동작을 false로 전환
			// 동작 마무리 이후 자동 종료
			Server.run = false;
		}


		public void Accept()
		{

		}

	}

}
