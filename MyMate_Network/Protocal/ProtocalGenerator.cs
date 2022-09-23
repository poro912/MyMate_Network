using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocal
{
	static public class dataType
	{
		public const int ERROR = -1;
		public const int OBJECT = 0;
		public const int STRING = 1;
		public const int BYTE = 2;
		public const int CHAR = 3;
		public const int SHORT = 4;
		public const int INT = 5;
		public const int LONG = 6;
		public const int FLOAT = 7;
		public const int DOUBLE = 8;
		public const int BOOL = 9;
		public const int BOOLEAN = 10;
		public const int BYTEARRAY = 11;
		public const int CHARARRAY = 12;
		public const int SHORTARRAY = 13;
		public const int INTARRAY = 14;
		public const int LONGARRAY = 15;
		public const int FLOATARRAY = 16;
		public const int DOUBLEARRAY = 17;
		public const int BOOLARRAY = 18;
	}
	static public class ProtocalGenerator
	{
		// 전송에 필요한 형태로 변환
		// int를 string 형으로 변환
		static public byte[] IntSender(ref int target)
		{
			byte[] result = new byte[2];
			result[0] = (byte)dataType.INT;
			result[1] = (byte)target;
			return result;
		}

		// 받은 값을 해석
		// string 을 int 형으로 변환
		static public int IntReseiver(ref byte[] target)
		{
			
			return 0;
		}

		static public object? Reseiver(ref byte[] target)
		{
			int key = target[0];
			object? value = null;
			

			switch (key)
			{
				case dataType.INT:
					value = (int)target[1];
					break;
			}

			return value;
		}

	}
}
