// TDS 작동 상수
#define CLIENT_TDS

global using RcdResult = System.Collections.Generic.KeyValuePair<byte, object?>;

using ServerToClinet;
using Protocol;
using TestDataSender;
using ServerToClient;
using MyMate_Network_Library.Protocols;

namespace TestServer
{
	class TestServer
	{
		static Client client;
#if CLIENT_TDS
		static TDS tds;
#endif
		static void Main(string[] args)
		{
			// 서버에 대한 정보를 받기 시작함으로서 통신을 시작함
			Server server = Server.Instance;
			Console.WriteLine("Start Client");

			server.clientAccept += ClientAcceptProcess;

			while (true)
			{
				Thread.Sleep(1000);
			}
		}

		static void ClientAcceptProcess(Client cli)
		{
			client = cli;
			client.Start();

			client.ReceiveEvent += Wakeup;

#if CLIENT_TDS
			Console.WriteLine("Start TDS");
			TDS tds = new TDS(client);
#endif
		}

		static public void Wakeup()
		{
			Console.WriteLine("Receive로 일어남");

			while (!client.IsEmpty())
			{
				RcdResult result = client.Receive();
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