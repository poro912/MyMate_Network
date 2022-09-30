using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


// byte 에서 int 로 변환하기 예제 https://learn.microsoft.com/ko-kr/dotnet/csharp/programming-guide/types/how-to-convert-a-byte-array-to-an-int
// & 참조자 선언


// Generator : 기본 자료형을 전송이 가능한 형태의 List<Byte> 자료형으로 변환
//				저장할 List를 명시해야 한다.
// Convertor : List<Byte> 자료형을 기본 자료형으로 변환
//				KeyAndValuepair 형으로 반환되며, 읽은 값은 배열에서 사라진다.
namespace Protocol
{
	// 컨버터 메소드
	// byte_arr 형태의 데이터를 해당 자료형으로 변환해준다.
	public delegate KeyValuePair<byte, object?> Converter(ref List<byte> target);

	// 자료형에 따른 상수를 정의
	static public class DataType
	{
		public const byte OBJECT		= 0;	//0
		public const byte STRING		= 1;	//1
		public const byte BYTE			= 2;	//2
		public const byte CHAR			= 3;	//3
		public const byte SHORT			= 4;	//4
		public const byte INT			= 5;	//5
		public const byte LONG			= 6;	//6
		public const byte FLOAT			= 7;	//7
		public const byte DOUBLE		= 8;	//8
		public const byte BOOL			= 9;	//9
		public const byte BOOLEAN		= 10;	//10
		public const byte BYTEARRAY		= 11;	//11
		public const byte CHARARRAY		= 12;	//12
		public const byte SHORTARRAY	= 13;	//13
		public const byte INTARRAY		= 14;	//14
		public const byte LONGARRAY		= 15;	//15
		public const byte FLOATARRAY 	= 16;	//16
		public const byte DOUBLEARRAY 	= 17;	//17
		public const byte BOOLARRAY		= 18;   //18
		public const byte TIME			= 19;	//19
	}
	

	// 전송 데이터 생성기
	// 값 -> List<byte>
	static public class DataGenerater
	{
		// 전송에 필요한 형태로 변환
		// int 를 byte 형으로 변환
		static public void Generate(ref int target, ref byte[] destination)
		{
			// 해석하기 위한 데이터 삽입
			destination.Append(DataType.INT);

			// int 형 데이터를 해당 byte 형으로 변환
			BitConverter.GetBytes(target).CopyTo(destination, destination.Length);
		}
		static public void Generate(ref string target, ref byte[] destination)
		{
			destination.Append(DataType.STRING);


			// 해석하기 위한 데이터 삽입
			foreach (var i in BitConverter.GetBytes(destination.Length))
			{
				destination.Append(i);
			}

		}

		// List<byte>
		// int 데이터 삽입
		static public void Generate(ref int target, ref List<byte> destination)
		{
			// 해석하기 위한 데이터 삽입
			destination.Add(DataType.INT);

			// int 형 데이터를 해당 byte 형으로 변환
			destination.AddRange(BitConverter.GetBytes(target));
		}
		
		// string 데이터 삽입
		static public void Generate(ref string target, ref List<byte> destination)
		{
			// 해석하기 위한 데이터 삽입
			destination.Add(DataType.STRING);

			// 문자열의 길이 삽입
			destination.AddRange(BitConverter.GetBytes(target.Length));

			// 문자열의 내용 삽입
			destination.AddRange(Encoding.UTF8.GetBytes(target));
		}
	}


	// 데이터 변환기
	// List<byte> -> 값

	// 읽은 데이터는 삭제해준다.
	// |분류데이터|값|			// 단일 변수
	// |분류데이터|길이|배열|	// 배열
	static public class DataConvertor
	{
		// 데이터 컨버터
		// byte_arr 형태의 데이터를 해석해주는 형태의 델리게이트를 배열로 저장
		static public Dictionary<byte,Converter?> convert_arr = 
			new Dictionary<byte,Converter?> {
				{DataType.STRING,ConvertString },
				{DataType.INT, ConvertInt },	// int형으로 Convert
		};

		static public KeyValuePair<byte, object?> Convert(ref List<byte> target)
		{
			// 컨버터 메소드를 임시저장할 델리게이트 변수
			Converter? converter;

			// 가장 처음에 있는 분류 데이터
			byte key = target[0];
			// 분류 데이터는 삭제
			target.RemoveAt(0);
			
			// key값에 따라 메소드 호출
			convert_arr.TryGetValue(key, out converter);
			// key값에 따라 델리게이트를 호출하여 변환
			if (converter != null)
				return converter(ref target);

			// 반환할 수 없다면 0,0 반환
			return ReturnNull();
		}

		/*
		public const byte OBJECT		= 0;
		public const byte STRING		= 1;
		public const byte BYTE			= 2;
		public const byte CHAR			= 3;
		public const byte SHORT			= 4;
		public const byte INT			= 5;
		public const byte LONG			= 6;
		public const byte FLOAT			= 7;
		public const byte DOUBLE		= 8;
		public const byte BOOL			= 9;
		public const byte BOOLEAN		= 10;
		public const byte BYTEARRAY		= 11;
		public const byte CHARARRAY		= 12;
		public const byte SHORTARRAY	= 13;
		public const byte INTARRAY		= 14;
		public const byte LONGARRAY		= 15;
		public const byte FLOATARRAY	= 16;
		public const byte DOUBLEARRAY	= 17;
		public const byte BOOLARRAY		= 18;
		*/

		// Int
		static private KeyValuePair<byte, object?> ConvertInt(ref List<byte> target)
		{
			// 임시 변수에 데이터를 넣어 저장 후
			byte [] temp = new byte[4];
			target.CopyTo(0, temp, 0, 4);

			// 읽은 데이터 만큼 삭제
			target.RemoveRange(0, 4);

			// 키값과 함께 데이터를 넘겨 줌
			// 해석을 완료하여 넘겨줌
			return new (DataType.INT, BitConverter.ToInt32(temp, 0));
		}

		// String
		static private KeyValuePair<byte, object?> ConvertString(ref List<byte> target)
		{
			// 문자열의 길이를 읽어옴
			int? n = (int?)ConvertInt(ref target).Value;
			// 결과를 저장할 문자열
			string result;

			// 뒤의 데이터가 없다면 null 반환 및 종료
			if (n == null || n == 0)
				return ReturnNull();

			// target을 array 로 바꿔 변환
			result = Encoding.Default.GetString(target.ToArray(), 0, (int)n);

			// 읽은 만큼 데이터 삭제
			target.RemoveRange(0, (int)n);

			return new(DataType.STRING, result);
		}

		
		static private KeyValuePair<byte, object?> ReturnNull()
		{
			return new (0, null);
		}
	}

}


