using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Collections.Concurrent;
using System.Threading;


namespace Protocol
{
	// Receive에 사용할 델리게이트
	public delegate void DataReceived();

	/// <summary>
	/// 통신을 위한 클래스 
	/// Sender와 Receiver를 동시에 포함한다
	/// 전송 후 수신 완료 메시지도 만들어준다.
	/// </summary>
	public class Communicater
	{
		// 공통 변수
		private NetworkStream? stream;
		// 스트림 저장 멤버
		public NetworkStream? Stream { get; private set; }

		// Sender 변수
		// 전송할 byte[1024] 데이터를 저장하는 큐
		private ConcurrentQueue<byte[]> send_queue;
		private Semaphore send_semaphore;
		private Task send_task;

		// Receiver 변수
		// 입력받은 byte[1024] 데이터를 저장하는 큐
		private ConcurrentQueue<byte[]> receive_queue;
		// 임시 변수
		private byte[] received_byte;
		private bool ReceiveRun = false;
		// 이벤트 발생기
		private event DataReceived? Receive_event;
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

		public Communicater()
		{
			// send 변수
			send_queue = new ConcurrentQueue<byte[]>();
			send_semaphore = new(1, 1);
			send_task = new Task(this.SnedSatrt);
			// receive 변수
			receive_queue = new ConcurrentQueue<byte[]>();
			ReceiveRun = false;
			received_byte = new byte[1024];
		}

		public Communicater(NetworkStream stream)
		{
			// 공통 변수
			this.Stream = stream;
			// send 변수
			send_queue = new ConcurrentQueue<byte[]>();
			send_semaphore = new(1, 1);
			send_task = new Task(this.SnedSatrt);
			// receive 변수
			receive_queue = new ConcurrentQueue<byte[]>();
			ReceiveRun = false;
			received_byte = new byte[1024];
		}

		// 스트림을 설정한다.
		public void SetStream(NetworkStream stream)
		{
			this.stream = stream;
		}

		// ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡSenderㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
		
		
		// 큐에 데이터를 삽입한 후 비동기로 데이터 전송
		public void Send(ByteList data)
		{
			send_queue.Enqueue(data.ToArray());
			send_task.Start();
			//Task.Run(this.SnedSatrt);
		}
		public void Send(byte[] data)
		{
			send_queue.Enqueue(data);
			send_task.Start();
			//Task.Run(this.SnedSatrt);
		}

		// 데이터 연속전송
#pragma warning disable CS1998 // 이 비동기 메서드에는 'await' 연산자가 없으며 메서드가 동시에 실행됩니다.
		private async void SnedSatrt()
#pragma warning restore CS1998 // 이 비동기 메서드에는 'await' 연산자가 없으며 메서드가 동시에 실행됩니다.
		{
			send_task = new Task(this.SnedSatrt);
			if (!send_semaphore.WaitOne(10))
				return;

			// 큐가 빌때까지 반복실행
			while (!send_queue.IsEmpty)
			{
				// 만약 읽어온 항목이 있다면
				if (send_queue.TryDequeue(out byte[]? data))
				{
					SendProcess(data);
				}
				else
					break;
			}
			
			send_semaphore.Release();
		}

		// byte 형태의 데이터 전송
		// 하나의 바이트 배열을 전송 할 때 사용
		public void SendProcess(Byte[] data)
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

		// 수신 시작
		public void StartReceive()
		{
			if(false == this.ReceiveRun)
			{
				this.ReceiveRun = true;
				ReceiveProcess();
			}
		}
		// 수신 중지
		public void StopReceive()
		{
			this.ReceiveRun = false;
		}
		
		// Receive.Data()
		// 데이터를 읽어오기 시작한다.
		private void ReceiveProcess()
		{
			received_byte = new byte[1024];
			// 실행 상태가 아니라면종료
			if (!this.ReceiveRun)
				return;
			// 스트림이 설정되어 있지 않다면 종료
			if (this.stream == null)
				return;
			try
			{
				// 데이터를 받기 시작한다.
				// 받은 데이터를 received_byte에 저장한다.
				// 데이터 수신을 완료하면 SaveData를 호출한다.
				this.stream.BeginRead(
					this.received_byte, 0, this.received_byte.Length,
					new AsyncCallback(SaveDataInQueue), null);
			}
			catch (System.IO.IOException)
			{
				Console.WriteLine("서버와 연결이 끊어졌습니다.");
				throw;
			}
			catch (Exception ex)
			{
				Console.Write("Receive 오류 발생 \t: ");
				Console.WriteLine(ex.ToString());
				throw;
			}
		}

		// 데이터 삽입
		private void SaveDataInQueue(IAsyncResult ar)
		{
			Console.WriteLine("데이터 들어옴");
			Console.WriteLine("데이터 길이 : " + received_byte.Length);
			string receive_data = Encoding.Default.GetString(this.received_byte);
			Console.WriteLine("내용 : " + receive_data);

			// 데이터를 받아오는 대로 queue에 저장
			receive_queue.Enqueue(this.received_byte);

			// 처리 끝 다음 데이터를 받을 준비를 함
			// 다음 데이터 받을 준비를 먼저 한 후 이벤트를 호출한다.
			ReceiveProcess();

			// 이벤트 호출
			// 이벤트가 할당되어 있으며, 큐가 비어있지 않은 경우
			if (Receive_event != null)
				if (!this.IsEmpty())
					Receive_event();
		}

		// get 이후 NULL값 확인을 해야함
		// byte[] 형태로 반환하는 pop
		public void Receive(out byte[]? destination)
		{
			this.receive_queue.TryDequeue(out destination);
		}
		public RcdResult Receive()
		{
			this.receive_queue.TryDequeue(out byte[]? temp);
			if (temp == null)
				return new(0, 0);
			return Protocol.Converter.Convert(temp);
		}

		// get 이후 NULL값 확인을 해야함
		// ByteList 형태로 반환하는 pop
		public void Receive(out ByteList destination)
		{
			byte[]? temp;
			this.receive_queue.TryDequeue(out temp);
			if (temp != null)
				destination = temp.ToList();
			else
				destination = new ByteList();
		}

		// 큐가 비었는지 확인
		public bool IsEmpty()
		{
			return this.receive_queue.IsEmpty;
		}
	}
}
