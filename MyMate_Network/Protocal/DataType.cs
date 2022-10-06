using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
	// 자료형에 따른 상수를 정의
	static public class DataType
	{
		// 기본 자료형 타입
		public const byte OBJECT		= 0; //0
		public const byte STRING		= 1; //1
		public const byte BYTE			= 2; //2
		public const byte CHAR			= 3; //3
		public const byte INT			= 4; //4
		public const byte LONG			= 5; //5
		public const byte FLOAT			= 6; //6
		public const byte DOUBLE		= 7; //7
		public const byte BOOL			= 8; //8
		public const byte BYTEARRAY		= 9; //9
		public const byte INTARRAY		= 10; //10
		public const byte LONGARRAY		= 11; //11
		public const byte FLOATARRAY	= 12; //12
		public const byte DOUBLEARRAY	= 13; //13
		public const byte BOOLARRAY		= 14; //14
		public const byte TIME			= 15; //15

		// 제어 타입
		public const byte CONTROLLBASE	= 0b_0000_1111; //15
		// 로그인
		public const byte LOGIN			= CONTROLLBASE + 1;
		// 로그아웃
		public const byte LOGOUT		= CONTROLLBASE + 2;
		// 연결 확인
		public const byte ISCONNECT		= CONTROLLBASE + 3;


		// 클래스 타입
		public const byte CLASSBASE		= 0b_0001_1111; //31
		// 유저 정보
		public const byte USER_INFO		= CLASSBASE + 1;
		// 메시지
		public const byte MESSAGE		= CLASSBASE + 2;
	}
}
