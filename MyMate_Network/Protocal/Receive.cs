using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
	public delegate void receive(IAsyncResult ar);

	// Receive receive = new(stream);
	// receive.Start();

	// 1024 byte 데이터를 읽어와 넘겨주며 다음 데이터를 읽기위해 대기한다.
	// Receive.Data()를 사용하게 되면 네트워크 에서 데이터를 읽어와 queue에 저장하기 시작한다.
	// 읽어온 데이터는 receive_queue에 저장된다.
	// Receive.pop() 하면 다음 데이터를 가져온다.	// 이 때 null 값인지 확인해야함
	// 수신 시 데이터는 byte[] 형태이다.
	public class Receive
	{
		// 입력받은 byte[1024] 데이터를 저장하는 큐
		public ConcurrentQueue<byte[]> receive_queue ;

		// 스트림 저장 멤버
		public NetworkStream stream { get; set; }

		// 이벤트 발생기
		private event EventHandler _receive_event;

		public event EventHandler ReceiveEvent
		{
			add
			{
				_receive_event += value;
			}
			remove
			{
				_receive_event -= value;
			}
		}

		// 임시 변수
		private byte[] received_byte;

		public bool run = false;

		public Receive(NetworkStream stream)
		{
			setStream(stream);
			this.run = true;
			receive_queue = new ConcurrentQueue<byte[]>();
			//received_byte = new byte[1024];
		}
		public Receive()
		{
			this.run = true;
			receive_queue = new ConcurrentQueue<byte[]>();
			//received_byte = new byte[1024];
		}

		public void setStream(NetworkStream stream)
		{
			this.stream = stream;
		}

		public void Start()
		{
			run = true;
			Data();
		}
		public void Stop()
		{
			run = false;
		}

		// Receive.Data()
		// 데이터를 읽어오기 시작한다	.
		private void Data()
		{
			received_byte = new byte[1024];
			// 실행 상태가 아니라면종료
			if (!this.run)
				return;
			// 스트림이 설정되어 있지 않다면 종료
			if (this.stream == null)
				return;
			try
			{
				// 데이터를 받기 시작한다.
				// 데이터를 received_byte에 저장한다.
				// 데이터 수신을 완료하면 SaveData를 호출한다.
				this.stream.BeginRead(
					this.received_byte, 0, this.received_byte.Length,
					new AsyncCallback(SaveDataInQueue), null);
			}
			catch (System.IO.IOException)
			{
				Console.WriteLine("서버와 연결이 끊어졌습니다.");
			}
			catch (Exception ex)
			{
				Console.Write("Receive 오류 발생 \t: ");
				Console.WriteLine(ex.ToString());
			}
			Console.WriteLine("데이터를 읽기 시작합니다.");
		}

		// 데이터 삽입
		private void SaveDataInQueue(IAsyncResult ar)
		{
			// byte[] 의 내용을 string 으로 번역하여 출력
			string receive_data = Encoding.Default.GetString(this.received_byte);
			Console.WriteLine("데이터 받음\t: " + receive_data);

			// 데이터를 받아오는 대로 queue에 저장
			receive_queue.Enqueue(this.received_byte);

			// 이벤트 호출
			if(_receive_event != null)
				_receive_event(this, EventArgs.Empty);

			/*foreach (var i in this.received_byte)
			{
				Console.Write(i + " ");
			}
			Console.WriteLine();
			*/
			// 새로운 byte 배열을 저장
			// this.received_byte = new byte[1024];

			// 처리 끝 다음 데이터를 받을 준비를 함
			Data();
		}

		// get 이후 NULL값 확인을 해야함
		public void Pop(out byte[]? destination)
		{
			this.receive_queue.TryDequeue(out destination);
		}
		public byte[]? Pop()
		{
			this.receive_queue.TryDequeue(out byte[]? temp);
			return temp;
		}
	}

	public class DynamicReceive
	{

	}
}
