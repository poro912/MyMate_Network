using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 해당 클래스에 동기화를 적용시켜 한번에 한 객체만 접근하도록 해야 함

namespace MyMate_Network
{
	internal class ClientContatiner
	{
		private static ClientContatiner instance;
		private static List<Client> clients;

		public static ClientContatiner Instance
		{
			get {
				if (instance == null)
					instance = new ClientContatiner();
				return instance;
			}
		}

		private ClientContatiner()
		{
			clients = new List<Client>();
		}
	}
}
