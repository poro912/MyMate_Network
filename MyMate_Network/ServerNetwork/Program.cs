// See https://aka.ms/new-console-template for more information
//
// C#소켓 통신 방법 : https://luv-n-interest.tistory.com/1093
// https://www.sysnet.pe.kr/2/0/12856
//


using ServerNetwork.Module;

Console.WriteLine("Start Server");


Server server = Server.Instance;

while (true)
{
	Thread.Sleep(10000);
} 
