using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ClientNetwork.Moudle.sub
{
	/*
	public delegate void receive(IAsyncResult ar);

	// 받는 데이터에 따른 상수
	static public class Receive_Const
	{
		public const int Other = -1;		// 예외값이 들어온 경우 
		public const int Distribute = 0;	// 분배기, 다음에 들어올 명령이 무엇인지 확인
		public const int Receive = 1;		// 기본 수신
	}

	// 서버에서 값을 받아오는 메소드
	public static class Receive
	{
		// 데이터를 받아올 수 있는 스트림을 저장
		static private NetworkStream stream;
		// 한번에 받을 수 있는 바이트 수에 따른 바이트 배열을 저장
		static private byte[] received_byte;

		//static private string receive_strin;
		//static private int receive_int;
		//static private StringBuilder str_builder;

		// 데이터 형태에 따라 각기 다른 행위를 하기 위한 메소드
		// 데이터의 형태에 따라 서로 다른 델리게이트를 호출한다.
		// ex 메시지, 캘린더, user
		static private Dictionary<int, receive> receive_dict
			= new Dictionary<int, receive>()
			{
				{ Receive_Const.Distribute, new receive(_Receive) },		// 데이터 판별
				{ Receive_Const.Receive, new receive( MessageReceive ) }	// 메시지 입력
			};

		// 최초로 입력을 받기 시작하는 메소드
		static public void StartReceive()
		{
			if (stream == null)
			{
				Console.WriteLine("Stream이 정의되지 않았습니다.\n" +
					"SetStream 메소드를 통해 초기화 하세요");
				return;
			}

			Console.WriteLine("네트워크로 입력을 받기 시작합니다.");
			
			// 디스트리뷰터를 발동 시킨다.
			NextReceive(Receive_Const.Distribute);

			// 네트워크로 입력을 받기 시작
			// 입력 받을 경우 Distributer로 연결된다.
			//stream.BeginRead(received_byte, 0, received_byte.Length,
			//	new AsyncCallback(receive_dict[Receive_Const.Distribute])
			//	, null);
		}

		// 기존 데이터에 대한 처리가 끝났으므로
		// 다음메시지 처리를 위한 준비를 함
		// Receive_Const 안의 상수에 대하여 실행한다.
		// 메시지를 받을 프로토콜을 발동시키는 메소드
		static private void NextReceive(int i)
		{
			try
			{
				// 데이터를 받을 배열 재선언
				received_byte = new byte[1024];

				//데이터를 받기 시작하여  해당 메소드에 전달한다.
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

		// 최초의 입력을 받는 부분
		// 최초 입력은 메시지의 종류를 확인하고 메시지의 종류에 따라 다른 메소드를 연결해준다.
		static private void _Receive(IAsyncResult ar)
		{

			string receive_data = Encoding.Default.GetString(received_byte);
			Console.WriteLine("데이터 받음\t: " + receive_data);

			// 처리 끝 다음 데이터를 받음
			NextReceive(Receive_Const.Distribute);
		}


		static private void MessageReceive(IAsyncResult ar)
		{
			//IAsyncResult result = null;

			return;
		}


		




		// 스트림을 현재 스트림으로 설정한다.
		static public void SetStream(NetworkStream temp_stream)
		{
			stream = temp_stream;
		}
	}
	*/
}
