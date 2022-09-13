using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


// 해당 클래스에 동기화를 적용시켜 한번에 한 객체만 접근하도록 해야 함

namespace ServerNetwork.Module.sub
{
    internal class ClientContatiner
    {
        private List<TcpClient> clients;

        public ClientContatiner()
        {
            clients = new List<TcpClient>();
        }

        public void add(TcpClient client)
        {
            clients.Add(client);
        }
    }
}
