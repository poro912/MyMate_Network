// See https://aka.ms/new-console-template for more information
#define INTEGRATED
using System.Text;
using System.Net.Sockets;
using System.Net;

// 클라이언트 통신을 위한 using
using ClientNetwork.Moudle;

// 뮤텍스 해야함

Console.WriteLine("Start Client");

#if INTEGRATED
// 클라이언트 통신을 여는 문장
Client client = Client.Instance;


while(true)
{
	// cpu 부하를 줄이기 위한 스레드 sleep
	Thread.Sleep(10000);
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






