// See https://aka.ms/new-console-template for more information
//
// C#소켓 통신 방법 : https://luv-n-interest.tistory.com/1093
// https://www.sysnet.pe.kr/2/0/12856
//

// 서버 통신을 위한 using
using ServerNetwork.Module;

Console.WriteLine("Start Server");

// 서버 통신을 여는 문장.
Server server = Server.Instance;

while (true)
{
	// cpu 부하를 줄이기 위한 스레드 sleep
	// Thread.Sleep(10000);

	String? input = Console.ReadLine();
	byte[] buffer = new byte[1024];
	if(input != null)
	{
		server.SendAll(ref input);
		Protocol.DataGenerater.Generate(ref input, ref buffer);
		server.SendAll(ref buffer);
	}
		
} 
