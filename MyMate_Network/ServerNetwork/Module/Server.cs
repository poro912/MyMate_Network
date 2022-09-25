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
				if (instance == null )
				{
					instance = new();
				}
				return instance;
			}
		}

		// 서버에 대한 포트 정보를 저장하기위한 멤버
		private SocketAndEndPoint sep;
		
		// 서버 스레드를 돌리기 위한 스레드 현재 미할당
		private Thread thread;

		// Accept 정보를 받기 위한 스레드
		// 내부 매커니즘으로 cpu를 과하게 차지하는 현상이 없음
		private Thread accept_thread;
		private bool run = false;

		// 클라이언트의 정보를 저장하기 위한 멤버
		private ClientContatiner clients = new();


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
			Console.WriteLine("스레드 종료 신호 발생");
			run = false;
			sep.Close();
		}

		// 외부로부터 통신 요청이 있다면 통신 요청을 받아 클라이언트 스레드로 만들어줌
		static private void AcceptRun()
		{
			Console.WriteLine("Accept 스레드 실행\n");

			// run 변수가 true 일동안 실행
			while (Instance.run)
			{
				TcpClient ?client;		// 클라이언트 정보 저장 null able 형 
				
				// Accept 실행 후 값을 반환하면 새로운 클라이언트 접근
				// 해당 문장이 sleep 과 같은 행위를 하기때문에 부하 없음
				client = Instance.sep.Accept();

				// 접근한 클라이언트가 있다면
				Instance.Accept(ref client);

				// 각 클라이언트를 실험하기위한 문장
				foreach (var i in instance.clients.clients)
				{
					string a = "send Test Data";
					i.send(ref a);
				}
			}

			Console.WriteLine("Accept 스레드 종료\n");
			return;
		}

		private void Accept(ref TcpClient? client)
		{
			if (client == null)
				return;

			// 접근한 클라이언트에 대해 Client 자료형으로 변환해 관리
			Client tempClient = new(client);
			Console.Write("새로운 클라이언트 접근 : \t");

			// 해당 클라이언트의 소켓에 대한 정보를 출력
			if (tempClient.socket.RemoteEndPoint != null)
				Console.Write(tempClient.socket.RemoteEndPoint.ToString());

			Console.WriteLine("\n");

			// 클라이언트 리스트에 추가
			Instance.clients.add(tempClient);
		}
		public void SendAll(ref string data)
		{
			instance.clients.SendAll(ref data);
		}

	}
}
