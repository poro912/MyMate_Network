using System.Text;
using System.Collections;
using System.Net.Sockets;
using Protocol.Protocols;

namespace Protocol.trash
{
	// 프로토콜에 맞춰 자료(클래스)를 byte로 변환해주는 클래스
	// 해당 프로토콜 내부에 있는 메시지 형태의 클래스로 변환해 넘겨줘야 함
	/*

	interface IClassProtocol
	{
		// 클래스를 List<byte>로 변환
		// 데이터를 Generate 할 때는 ClassType을 가장 앞에 추가해야 한다.
		public void Generate(object target, ref List<byte>destination);

		// List<byte>를 클래스로 변환
		public object Convert(ref List<byte> target);
	}
	// public delegate class

	static public class ClassConvertor
	{
		// 클래스 컨버터
		// byte_arr 형태의 데이터를 해석해주는 형태의 델리게이트를 배열로 저장
		static public Dictionary<byte, Converter?> convert_arr =
			new Dictionary<byte, Converter?> {
				{ClassType.Login, LoginProtocol.Convert},
				{ClassType.UserInfo, UserInfoProtocol.Convert},
				{DataType.INT, MessageProtocol.Convert },
				
		};
		static KeyValuePair<byte, object?> Convert(ref List<byte> target)
		{
			// 컨버터 메소드를 임시저장할 델리게이트 변수
			Converter? converter;

			// 가장 처음에 있는 분류 데이터
			byte key = target[0];
			// 분류 데이터는 삭제
			target.RemoveAt(0);

			convert_arr.TryGetValue(key,out converter);

			if (converter != null)
				return converter(ref target);
			

			return ReturnNull();
		}
		static private KeyValuePair<byte, object?> ReturnNull()
		{
			return new(0, null);
		}
	}
	
	*/
}


	/*
	// 받는 데이터에 따른 상수
	static public class Receive_Const
	{
		public const byte Other = 0;        // 예외값이 들어온 경우 
		public const byte Distribute = 1;    // 분배기, 다음에 들어올 명령이 무엇인지 확인
		public const byte Receive = 2;       // 기본 수신
	}

	// 서버에서 값을 받아오는 메소드
	public static class Receive_
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
		static private Dictionary<byte, receive> receive_dict
			= new Dictionary<byte, receive>()
			{
				{ Receive_Const.Distribute, _Receive },		// 데이터 판별
				{ Receive_Const.Receive, MessageReceive }	// 메시지 입력
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

			Console.WriteLine("네트워크 수신을 시작합니다.");

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
				new AsyncCallback(receive_dict[(byte)i]), null);
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