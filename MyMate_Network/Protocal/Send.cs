using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
	// 사용시 스트림을 저장하거나 스트림을 매개변수로 줘야한다.
	// Send.Data() 와 같은 형식으로 데이터를 전송한다.
	// 단일 데이터 전송 Send.Data();
	// 다중 데이터 전송 Send.Push();
	// 전송 시 데이터는 byte[] 형태이다.
	public class Send
	{
		private NetworkStream stream;
		// 스트림 저장 멤버
		public NetworkStream Stream { get; set; }

		// 스트림을 설정한다.
		public void setStream(NetworkStream stream)
		{
			this.stream = stream;
		}

		public Send(NetworkStream stream)
		{
			setStream(stream);
		}

		public Send()
		{
		}

		// byte 형태의 데이터 전송
		// 하나의 바이트 배열을 전송 할 때 사용
		public void Data(List<byte> data)
		{
			Data(data.ToArray());
		}

		// byte 형태의 데이터 전송
		// 하나의 바이트 배열을 전송 할 때 사용
		public void Data(Byte[] data)
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

		public void Data(
			ref NetworkStream stream,
			Byte[] data
		)
		{
			// 들어온 데이터가 없다면 종료
			if (data.Length.Equals(0))
				return;
			try
			{
				stream.Write(data, 0, data.Length);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				throw;
			}
		}

		// 단순 문자열 전송
		// 문자열의 양 끝 공백을 제거한 후 byte 단위로 변환하여 전달
		public void Data(String data)
		{
			// String 을 byte 배열로 변환하여 전송
			data.Trim();

			byte[] buf = Encoding.Default.GetBytes(data);
			Console.WriteLine("전송 데이터 : " + data);
			foreach (var i in buf)
			{
				Console.Write(i + " ");
			}
			Console.WriteLine();
			// 해당 스트림으로 문자열 전송
			Data(buf);
		}

		public void Data(
			ref NetworkStream stream,
			String data
		){
			// String 을 byte 배열로 변환하여 전송
			data.Trim();

			byte[] buf = Encoding.Default.GetBytes(data);
			Console.WriteLine("전송 데이터 : " + data);
			// 해당 스트림으로 문자열 전송
			Data(ref stream, buf);
		}

		
	}
	
	// 지속적인 송신을 위한 클래스
	//push중에 스레드가 종료되는 동기화 문제가 있을 수 있음
	public class DynamicSend
	{
		// 전송할 byte[1024] 데이터를 저장하는 큐
		public ConcurrentQueue<byte[]> send_queue;

		private Thread sendThread;

		private Send send;

		public DynamicSend(NetworkStream stream)
		{
			//mutex = new Mutex();

			send = new(stream);

			send_queue = new ConcurrentQueue<byte[]>();

			sendThread = new Thread(SendThread);
		}

		// 데이터를 큐에 집어 넣으면서 스레드를 실행한다.
		public void Push(byte[] data)
		{
			send_queue.Enqueue(data);
			// 스레드가 현재 동작중이 아니라면 동작시킨다.
			if (!this.sendThread.IsAlive)
			{
				sendThread.Start();
			}
		}

		public void Push(ref List<byte> data)
		{
			send_queue.Enqueue(data.ToArray());
			if (!this.sendThread.IsAlive)
			{
				sendThread.Start();
			}
		}

		public void Stop()
		{
			sendThread.Interrupt();
			sendThread.Join();	// 스레드가 제대로 중지되는지 모르겠음
		}


		private void SendThread()
		{
			// 혹시라도 입력중에 스레드가 꺼지는 것을 방지하기 위한 count 변수
			int count = 0;

			// 큐가 빌때까지 메시지를 전송
			do
			{
				if (this.send_queue.IsEmpty && count > 5)
					break;

				// 큐에서 데이터를 가져옴
				send_queue.TryDequeue(out byte[]? temp);

				// 더이상 읽을 데이터가 없는지 5회(0.05초) 확인 후 스레드 종료
				if (temp == null)
				{
					count++;
					Thread.Sleep(10);
					continue;
				}

				try
				{
					// 데이터를 전송한다.
					send.Data(temp);
				}
				catch(Exception e)
				{
					throw;
					break;
				}
				

				// 읽은 데이터가 있다면 count 0으로 초기화
				count = 0;
			} while (true);
		}
	}
}
