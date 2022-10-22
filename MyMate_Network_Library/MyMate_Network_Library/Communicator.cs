using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Collections.Concurrent;

namespace MyMate_Network_Library
{
	public delegate void DataReceived();

	public class Communicator
	{
		// 공통 변수
		private NetworkStream? stream;
		// 스트림 저장 멤버
		public NetworkStream Stream { get; set; }

		// Sender 변수
		// 전송할 byte[1024] 데이터를 저장하는 큐
		public ConcurrentQueue<byte[]> send_queue;


		// Receiver 변수

		// 입력받은 byte[1024] 데이터를 저장하는 큐
		public ConcurrentQueue<byte[]> receive_queue;

		// 이벤트 발생기
		private event DataReceived Receive_event;
		public event DataReceived ReceiveEvent
		{
			add
			{
				Receive_event += value;
			}
			remove
			{
				Receive_event -= value;
			}
		}

		public Communicator(NetworkStream stream)
		{
			this.stream = stream;
		}

		// 스트림을 설정한다.
		public void setStream(NetworkStream stream)
		{
			this.stream = stream;
		}

		// ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡSenderㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
		// byte 형태의 데이터 전송
		// 하나의 바이트 배열을 전송 할 때 사용
		public void Send(ByteList data)
		{
			Send(data.ToArray());
		}

		// byte 형태의 데이터 전송
		// 하나의 바이트 배열을 전송 할 때 사용
		public void Send(Byte[] data)
		{
			// 들어온 데이터가 없다면 종료
			if (data.Length.Equals(0))
				return;
			if (this.stream == null)
				return;
			try
			{
				this.stream.Write(data, 0, data.Length);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				throw;
			}
		}
		// ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡReceiverㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ

		
	}
}
