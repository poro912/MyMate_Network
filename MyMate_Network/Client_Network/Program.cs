// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Net.Sockets;
using System.Net;

Console.WriteLine("Start Client");
Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

//IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.158.1"), 7000);
IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7000);
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