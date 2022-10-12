using Protocol;
using ServerNetwork.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataSender;

namespace ServerNetwork
{
	public class Temp
	{
		public Client client;
		public TDS tds;

		public void Accept(Client cli)
		{
			Console.WriteLine("객체 접속");
			List<byte> bytes = new List<byte>();
			string hi = "hello";
			this.client = cli;
			this.client.start();
			Generater.Generate(hi, ref bytes);
			this.client.send.Data(bytes);

			tds = new(client.send);
		}
	};

}
