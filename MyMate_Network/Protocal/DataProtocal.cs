using System.Text;
using System.Collections;

namespace Protocal
{
	// 프로토콜에 맞춰 자료를 byte로 변환해주는 클래스
	// 해당 프로토콜 내부에 있는 메시지 형태의 클래스로 변환해 넘겨줘야 함
	
	static public class ProtocalConst
	{
		public const int Distribute = 0;    // 분배기, 다음에 들어올 명령이 무엇인지 확인
		public const int Receive = 1;       // 기본 수신
	}

	public delegate void receive(IAsyncResult ar);
	public abstract class ProtocalStruct
	{
		public abstract object Send(object obj);
		public abstract object Receive(object obj);
	}

	

	public class MessageProtocal : ProtocalStruct
	{
		public class Message
		{
			public int usercode;
			public int target;
			public String Context;
			public DateTime date;
		}
		public override object Send(object obj)
		{
			Message message = (Message)obj;
			List<byte> t = new();





			return message; 
		}

		public override object Receive(object obj)
		{
			Message msg = new Message();
			
			
			return (object)msg;
		}

		
	}
}