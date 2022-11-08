using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Protocol;

namespace ServerToClient
{
    public class Client:Communicater
    {
		private NetworkStream stream;

		public TcpClient tcpClient;
        public Socket socket;

		// 생성된 클라이언트 구조체를 초기화
		public Client(TcpClient tcpClient)
        {
            // tcpClient 객체를 저장
            this.tcpClient = tcpClient;

            // 클라이언트의 스트림을 저장
            stream = tcpClient.GetStream();

            // 클라이언트의 소켓을 저장
            socket = tcpClient.Client;

            SetStream(stream);
        }

        ~Client()
        {
            StopReceive();
        }

        public void Start()
        {
			StartReceive();
		}

    }
}
