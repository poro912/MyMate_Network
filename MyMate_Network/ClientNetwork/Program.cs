// See https://aka.ms/new-console-template for more information
#define INTEGRATED
using System.Text;
using System.Net.Sockets;
using System.Net;

// 클라이언트 통신을 위한 using
using ClientNetwork;
using Protocol;
using Protocol.Protocols;
using TestDataSender;

// 뮤텍스 해야함

Console.WriteLine("Start Client");

#if INTEGRATED
// 클라이언트 통신을 여는 문장
Server server = Server.Instance;

// 데이터를 받기위한 변수들
KeyValuePair<byte, object?> result;
byte[]? a_data;
List<byte> l_data = new();

// TDS 필요시 주석 해제
TDS tds = new TDS(server.send);

while (true)
{
	// cpu 부하를 줄이기 위한 스레드 sleep
	Thread.Sleep(100);

	a_data = server.receive.Pop();
	if(a_data != null)
	{
		result = Converter.Convert(a_data);
		if(result.Key == DataType.ISCONNECT)
			continue;
		Console.WriteLine("전송받은 데이터 타입 : " + result.Key);
		Console.WriteLine("전송받은 데이터 : " + result.Value);

		LoginProtocol.Login login = new();
		login.Set("admin", "1234");

		Generater.Generate(login, ref l_data);
		server.send.Data(l_data);

		a_data = null;
	}
	//string data = "test data";
	//Thread.Sleep(1000);
	//client.Send(ref data);
}


#else

Socket sock = new (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

//IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.158.1"), 7000);
IPEndPoint ep = new (IPAddress.Parse("127.0.0.1"), 8090);
sock.Connect(ep);

String cmd = string.Empty;
byte[] recieiverBuff = new byte[8192];

Console.WriteLine("Connected  Enter Q to exit");

while ((cmd = Console.ReadLine()) != "Q")
{
	// Console.WriteLine(data);
	byte[] buff = Encoding.UTF8.GetBytes(cmd);

	sock.Send(buff);

	//Thread.Sleep(500);
	//int n = sock.Receive(recieiverBuff);

	//String data = Encoding.UTF8.GetString(buff, 0, n);

}
sock.Close();

#endif






