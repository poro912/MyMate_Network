// TDS 작동 상수
#define CLIENT_TDS

global using RcdResult = System.Collections.Generic.KeyValuePair<byte, object?>;
using ClientToServer;
using MyMate_Network_Library.Protocols;
using Protocol;
using TestDataSender;

namespace TestClinet
{
	class TestClient
	{
		static Server server;
		static void Main(string[] args)
		{
			// 서버에 대한 정보를 받기 시작함으로서 통신을 시작함

			Console.WriteLine("Start Client");
			server = Server.Instance;

#if CLIENT_TDS
			Console.WriteLine("Start TDS");
			TDS tds = new TDS(Server.Instance);
#endif
			server.ReceiveEvent += new DataReceived(Wakeup);
			while (true)
			{
				Thread.Sleep(1000);
			}
		}
		static public void Wakeup()
		{
			Console.WriteLine("Receive로 일어남");

			while (!server.IsEmpty())
			{
				RcdResult result = server.Receive();
				object? value = result.Value;

				Console.WriteLine("Key : " + result.Key);
				Console.WriteLine("value : " + value);

				if (null != value || result.Key == 0)
					break;

				Console.WriteLine("전달받은 데이터 타입 : " + result.Key);
				Console.WriteLine("전달받은 값 : " + result.Value);
				((IProtocolClass)value).Print();
			}
		}
	}
}