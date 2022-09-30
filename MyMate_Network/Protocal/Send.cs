using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
	// 사용시 스트림을 저장하거나 스트림을 매개변수로 줘야한다.
	public class Send
	{
		// 전송할 byte[1024] 데이터를 저장하는 큐
		public ConcurrentQueue<byte[]> send_queue;

		// 스트림 저장 멤버
		public NetworkStream stream { get; set; }

		// 스트림을 설정한다.
		public void setStream(NetworkStream stream)
		{
			this.stream = stream;
		}

		public Send(NetworkStream stream)
		{
			setStream(stream);
			send_queue = new ConcurrentQueue<byte[]>();
		}
		public Send()
		{
			send_queue = new ConcurrentQueue<byte[]>();
		}

		// byte 형태의 데이터 전송
		// 하나의 바이트 배열을 전송 할 때 사용
		public void Data(
			ref Byte[] data
		)
		{
			// 들어온 데이터가 없다면 종료
			if (data.Length.Equals(0))
				return;
			try
			{
				this.stream.Write(data, 0, data.Length);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
		public void Data(
			ref NetworkStream stream,
			ref Byte[] data
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
			}
		}

		// 단순 문자열 전송
		// 문자열의 양 끝 공백을 제거한 후 byte 단위로 변환하여 전달
		public void Data(
			ref String data
		)
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
			Data(ref buf);
		}
		public void Data(
			ref NetworkStream stream,
			ref String data
		){
			// String 을 byte 배열로 변환하여 전송
			data.Trim();

			byte[] buf = Encoding.Default.GetBytes(data);
			Console.WriteLine("전송 데이터 : " + data);
			// 해당 스트림으로 문자열 전송
			Data(ref stream, ref buf);
		}

		// 데이터를 삽입한다.
		public void push(
			ref Byte[] data
			)
		{
			send_queue.Enqueue(data);
		}
		

	}
}
