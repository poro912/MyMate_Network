using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// byte 에서 int 로 변환하기 예제 https://learn.microsoft.com/ko-kr/dotnet/csharp/programming-guide/types/how-to-convert-a-byte-array-to-an-int
// & 참조자 선언


// 기본 자료형을 해석하는 클래스
namespace Protocal
{
	static public class DataType
	{
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
	}

	// 전송 데이터 생성기
	// 값 -> List<byte>
	static public class DataGenerater
	{
		// 전송에 필요한 형태로 변환
		// int를 string 형으로 변환
		static public void Generate(ref int target, ref byte[] destination)
		{
			// 해석하기 위한 데이터 삽입
			destination.Append(DataType.INT);

			// int 형 데이터를 해당 byte 형으로 변환
			BitConverter.GetBytes(target).CopyTo(destination, destination.Length);
		}

		// List<byte>
		static public void Generate(ref int target, ref List<byte> destination)
		{
			// 해석하기 위한 데이터 삽입
			destination.Add(DataType.INT);

			// int 형 데이터를 해당 byte 형으로 변환
			destination.AddRange(BitConverter.GetBytes(target));
		}

	}

	public delegate KeyValuePair<byte, object?> Converter(ref List<byte> target);


	// 데이터 변환기
	// List<byte> -> 값
	static public class DataConvertor
	{
		static public Converter[] convert_arr = new Converter[] { };

		static public KeyValuePair<byte, object?> Convert(ref List<byte> target)
		{
			KeyValuePair<byte, object?> result;

			// 가장 처음 데이터는 분류 데이터
			byte key = target[0];

			// 따로 저장했으므로 삭제
			target.RemoveAt(0);

			byte[] temp;

			object? value = null;

			switch (key)
			{
				case DataType.INT:
					temp = new byte[4];
					target.CopyTo(0, temp, 0, 4);
					target.RemoveRange(0, 4);

					value = BitConverter.ToInt32(temp, 0);
					break;
			}

			// key 값으로 자동 변환
			// result = convert_arr[key](ref target);
				
			result = new KeyValuePair<byte, object?>(key, value);
			return result;
		}
	}
}
