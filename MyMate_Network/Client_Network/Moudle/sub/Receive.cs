using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ClientNetwork.Moudle.sub
{

	public delegate void receive(IAsyncResult ar);

	// 받는 데이터에 따른 상수
	static public class Receive_Const
	{
		public const int Distribute = 0;	// 분배기, 다음에 들어올 명령이 무엇인지 확인
		public const int Receive = 1;		// 기본 수신
	}

	// 서버에서 값을 받아오는 메소드
	public static class Receive
	{
		static private NetworkStream stream;
		static private byte[] received_byte = new Byte[1024];
		static private string receive_strin;
		static private int receive_int;
		static private StringBuilder str_builder;

		static private Dictionary<int, receive> receive_dict
			= new Dictionary<int, receive>()
			{

				{ Receive_Const.Distribute, _Receive },		// 데이터 판별
				{ Receive_Const.Receive, MessageReceive }	// 메시지 입력
			};

		static public void SetStream(NetworkStream temp_stream)
		{
			stream = temp_stream;
		}

		static public void StartReceive()
		{
			if (stream == null)
			{
				Console.WriteLine("Stream이 정의되지 않았습니다.\n" +
					"SetStream 메소드를 통해 초기화 하세요");
				return;
			}

			Console.WriteLine("네트워크로 입력을 받기 시작합니다.");
			stream.BeginRead(received_byte, 0, received_byte.Length,
				new AsyncCallback(receive_dict[0]), null);
			NextReceive(Receive_Const.Distribute);
		}

	
		// 최초의 입력을 받는 부분
		// 최초 입력은 메시지의 종류를 확인하고 메시지의 종류에 따라 다른 메소드를 연결해준다.
		static private void _Receive(IAsyncResult ar)
		{
			//int t = 0;
			
			string receive_data = Encoding.Default.GetString(received_byte);
			Console.WriteLine("데이터 받음\t: " + receive_data);

			// 처리 끝 다음 데이터를 받음
			NextReceive(0);
		}


		static private void MessageReceive(IAsyncResult ar)
		{
			IAsyncResult result = null;

			return;
		}


		// 기존 데이터에 대한 처리가 끝났으므로
		// 다음메시지 처리를 위한 준비를 함
		static private void NextReceive(int i)
		{
			try
			{
				stream.BeginRead(received_byte, 0, received_byte.Length,
				new AsyncCallback(receive_dict[i]), null);
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
		}
	}
}
