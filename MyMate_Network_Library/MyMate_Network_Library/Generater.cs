using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
	static public class Generater
	{
		// List<byte>

		// 일반 자료형
		// int
		static public void Generate(int target, ref ByteList destination)
		{
			// 해석하기 위한 데이터 삽입
			destination.Add(DataType.INT);

			// int 형 데이터를 해당 byte 형으로 변환
			destination.AddRange(BitConverter.GetBytes(target));
		}
		static public ByteList Generate(int target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// string
		static public void Generate(string target, ref ByteList destination)
		{
			// 해석하기 위한 데이터 삽입
			destination.Add(DataType.STRING);

			// 문자열의 길이 삽입
			destination.AddRange(BitConverter.GetBytes(target.Length));

			// 문자열의 내용 삽입
			destination.AddRange(Encoding.UTF8.GetBytes(target));
		}
		static public ByteList Generate(string target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// bool
		static public void Generate(bool target, ref ByteList destination)
		{
			// 해석하기 위한 데이터 삽입
			destination.Add(DataType.BOOL);

			// int 형 데이터를 해당 byte 형으로 변환
			destination.AddRange(BitConverter.GetBytes(target));
		}
		static public ByteList Generate(bool target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// int array
		static public void Generate(List<int> target, ref ByteList destination)
		{
			// 해석하기 위한 데이터 삽입
			destination.Add(DataType.INTARRAY);
			destination.AddRange(BitConverter.GetBytes(target.Count));

			for (int i = 0; i < target.Count; i++)
			{
				// int 형 데이터를 해당 byte 형으로 변환
				destination.AddRange(BitConverter.GetBytes(target[i]));
			}
		}
		static public ByteList Generate(List<int> target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// DateTime
		static public void Generate(DateTime target, ref ByteList destination)
		{
			// 해석하기 위한 데이터 삽입
			destination.Add(DataType.DATETIME);

			// int 형 데이터를 해당 byte 형으로 변환
			destination.AddRange(BitConverter.GetBytes(target.Ticks));
		}
		static public ByteList Generate(DateTime target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// 제어 데이터형
		// Login
		static public void Generate(LoginProtocol.LOGIN target, ref ByteList destination)
		{
			LoginProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(LoginProtocol.LOGIN target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// LogOut
		static public void Generate(LogoutProtocol.LOGOUT target, ref ByteList destination)
		{
			LogoutProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(LogoutProtocol.LOGOUT target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// IsConnect
		static public void Generate(isConnectProtocol.ISCONNECT target, ref ByteList destination)
		{
			isConnectProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(isConnectProtocol.ISCONNECT target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		//FAIL
		/*static public void Generate(FailProtocol.FAIL target, ref ByteList destination)
		{
			FailProtocol.Generate(target, ref destination);
			return;
		}
		//static public ByteList Generate(FailProtocol.FAIL target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}
		*/

		// TOAST
		static public void Generate(ToastProtocol.TOAST target, ref ByteList destination)
		{
			ToastProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(ToastProtocol.TOAST target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// Request
		static public void Generate(RequestProtocol.REQUEST target, ref ByteList destination)
		{
			RequestProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(RequestProtocol.REQUEST target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// REQUEST_RECENT_ALL
		static public void Generate(
			RequestRecentAllProtocol.REQUESTRECENTALL target,
			ref ByteList destination
			)
		{
			RequestRecentAllProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(
			RequestRecentAllProtocol.REQUESTRECENTALL target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// SignUp
		static public void Generate(
			SignUpProtocol.SiginUp target,
			ref ByteList destination
			)
		{
			SignUpProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(
			SignUpProtocol.SiginUp target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}
		// LoginUser
		static public void Generate(LoginUserProtocol.LOGINUSER target, ref ByteList destination)
		{
			LoginUserProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(LoginUserProtocol.LOGINUSER target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}


		// 클래스 형
		// User
		static public void Generate(UserProtocol.USER target, ref ByteList destination)
		{
			UserProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(UserProtocol.USER target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// Message
		static public void Generate(MessageProtocol.MESSAGE target, ref ByteList destination)
		{
			MessageProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(MessageProtocol.MESSAGE target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// Server
		static public void Generate(ServerProtocol.Server target, ref ByteList destination)
		{
			ServerProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(ServerProtocol.Server target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// CheckList
		static public void Generate(CheckListProtocol.CHECKLIST target, ref ByteList destination)
		{
			CheckListProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(CheckListProtocol.CHECKLIST target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// Chnnel
		static public void Generate(ChannelProtocol.CHNNEL target, ref ByteList destination)
		{
			ChannelProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(ChannelProtocol.CHNNEL target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// Calender
		static public void Generate(CalenderProtocol.CALENDER target, ref ByteList destination)
		{
			CalenderProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(CalenderProtocol.CALENDER target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}

		// Friend
		static public void Generate(FriendProtocol.FRIEND target, ref ByteList destination)
		{
			FriendProtocol.Generate(target, ref destination);
			return;
		}
		static public ByteList Generate(FriendProtocol.FRIEND target)
		{
			ByteList destination = new();
			Generate(target, ref destination);
			return destination;
		}
	}
}
