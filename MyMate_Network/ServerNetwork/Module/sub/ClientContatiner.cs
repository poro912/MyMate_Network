using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


// 해당 클래스에 동기화를 적용시켜 한번에 한 객체만 접근하도록 해야 함

namespace ServerNetwork.Module.sub
{
    // 21억명의 정보를 저장할 수 있겠지
    public class ClientContatiner
    {
        public List<Client> clients;

        public ClientContatiner()
        {
            clients = new List<Client>();
        }

        public void add( Client client)
        {
            // 객체 생성이 안되거나 유저가 없으면 종료
            if (client == null )
                return;
            clients.Add(client);
        }

		public void SendAll(ref string data)
		{
			foreach (var client in clients)
			{
                client.send(ref data);
			}
		}
	}
}
