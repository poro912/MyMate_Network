// 전역으로 사용하는 별칭 설정
global using RcdResult = System.Collections.Generic.KeyValuePair<byte, object?>;
global using ByteList = System.Collections.Generic.List<byte>;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMate_Network_Library
{
	// 컨버터 메소드
	// byte_arr 형태의 데이터를 해당 자료형으로 변환해준다.
	public delegate RcdResult Convert(ByteList target);

	// 자료형에 따른 상수를 정의
	static public class DataType
	{
		// 가장 앞의 비트가 1이라면 nullable
		// 현재 사용 안함
		public const byte nullable = 0b1000_0000;

		// 기본 자료형 타입
		public const byte OBJECT = 0; //0
		public const byte STRING = 1; //1
		public const byte BYTE = 2; //2
		public const byte CHAR = 3; //3
		public const byte INT = 4; //4
		public const byte LONG = 5; //5
		public const byte FLOAT = 6; //6
		public const byte DOUBLE = 7; //7
		public const byte BOOL = 8; //8
		public const byte BYTEARRAY = 9; //9
		public const byte INTARRAY = 10; //10
		public const byte LONGARRAY = 11; //11
		public const byte FLOATARRAY = 12; //12
		public const byte DOUBLEARRAY = 13; //13
		public const byte BOOLARRAY = 14; //14
		public const byte TIME = 15; //15


		// 제어 타입
		public const byte CONTROLLBASE = 0b_0000_1111; //15

		// 전송 완료
		public const byte SUCCESS = CONTROLLBASE + 1;
		// 전송 실패
		public const byte FAIL	= CONTROLLBASE + 2;
		// 연결 확인
		public const byte ISCONNECT = CONTROLLBASE + 3;
		// 로그인
		public const byte LOGIN = CONTROLLBASE + 4;
		// 로그아웃
		public const byte LOGOUT = CONTROLLBASE + 5;
		// 요청
		public const byte REQUEST = CONTROLLBASE + 6;
		// 대량 데이터(다중 데이터)
		// 가변 데이터
		public const byte VARIABLE = CONTROLLBASE + 7;
		// 최근 데이터 모두 요청
		public const byte REQUEST_RECENT_ALL = CONTROLLBASE + 8;
		

		// 클래스 타입
		public const byte CLASSBASE = 0b_0001_1111; //31

		// 유저 정보
		public const byte USER_INFO = CLASSBASE + 1;
		// 메시지
		public const byte MESSAGE = CLASSBASE + 2;
		// 서버
		public const byte SERVER = CLASSBASE + 3;
		// 캘린더
		public const byte CALENDER = CLASSBASE + 4;
		// 체크리스트
		public const byte CHECKLIST = CLASSBASE + 5;
		// 친구
		public const byte FRIEND = CLASSBASE + 6;

	}
}
