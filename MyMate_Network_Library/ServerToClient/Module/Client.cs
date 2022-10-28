using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Protocol;

namespace ServerToClinet
{
    public class Client:Communicater
    {
		private NetworkStream stream;

		public TcpClient tcpClient;
        public Socket socket;

        //public Communicater communicater;
        //public DynamicSend dynamicSend;
        //public Receive receive;

		// 생성된 클라이언트 구조체를 초기화
		public Client(TcpClient tcpClient)
        {
            // tcpClinet 객체를 저장
            this.tcpClient = tcpClient;

            // 클라이언트의 스트림을 저장
            stream = tcpClient.GetStream();

            // 클라이언트의 소켓을 저장
            socket = tcpClient.Client;

            // 클라이언트의 전송 클래스
            //send = new(stream);

            // 클라이언트의 전송 클래스
            //dynamicSend = new(stream);

            // 클라이언트의 수신 클래스
            //receive = new(stream);
            SetStream(stream);
            //Start();
        }

        ~Client()
        {
            //receive.Stop();
            //dynamicSend.Stop();
            StopReceive();
        }

        public void Start()
        {
            //receive.Start();
			StartReceive();
		}

    }
}
