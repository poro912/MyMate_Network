using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
	// 데이터 변환기
	// List<byte> -> 값

	// 읽은 데이터는 삭제해준다.
	// |분류데이터|값|			// 단일 변수
	// |분류데이터|길이|배열|	// 배열
	static public class Converter
	{
		// 데이터 컨버터
		// byte_arr 형태의 데이터를 해석해주는 형태의 델리게이트를 배열로 저장
		static public Dictionary<byte, Convert?> convert_dict =
			new Dictionary<byte, Convert?> {
				{DataType.STRING    , ConvertString },
				{DataType.INT       , ConvertInt },
				{DataType.BOOL       , ConvertBool },

				{DataType.LOGIN     , LoginProtocol.Convert},
				{DataType.LOGOUT     , LogoutProtocol.Convert},
				{DataType.ISCONNECT     , isConnectProtocol.Convert},

				{DataType.USER_INFO , UserInfoProtocol.Convert},
				{DataType.MESSAGE   , MessageProtocol.Convert },

		};
		static public RcdResult Convert(byte[] target)
		{
			ByteList bytes = new ByteList();

			// 자동으로 변경해서 넘겨준다.
			bytes = target.ToList();

			return Convert(bytes);
		}


		static public RcdResult Convert(ByteList target)
		{
			// 컨버터 메소드를 임시저장할 델리게이트 변수
			Convert? converter;

			// 가장 처음에 있는 분류 데이터
			byte key = target[0];
			// 분류 데이터는 삭제
			target.RemoveAt(0);

			// key값에 따라 메소드 호출
			convert_dict.TryGetValue(key, out converter);
			// key값에 따라 델리게이트를 호출하여 변환
			if (converter != null)
				return converter(target);

			// 반환할 수 없다면 0,0 반환
			return ReturnNull();
		}


		// Int
		static private RcdResult ConvertInt(ByteList target)
		{
			// 임시 변수에 데이터를 넣어 저장 후
			byte[] temp = new byte[4];
			target.CopyTo(0, temp, 0, 4);

			// 읽은 데이터 만큼 삭제
			target.RemoveRange(0, 4);

			// 키값과 함께 데이터를 넘겨 줌
			// 해석을 완료하여 넘겨줌
			return new(DataType.INT, BitConverter.ToInt32(temp, 0));
		}

		// String
		static private RcdResult ConvertString(ByteList target)
		{
			// 문자열의 길이를 읽어옴
			int? n = (int?)ConvertInt(target).Value;
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

		// bool
		static private RcdResult ConvertBool(ByteList target)
		{
			// 임시 변수에 데이터를 넣어 저장 후
			byte[] temp = new byte[1];

			target.CopyTo(0, temp, 0, 1);

			// 읽은 데이터 만큼 삭제
			target.RemoveRange(0, 0);

			// 키값과 함께 데이터를 넘겨 줌
			// 해석을 완료하여 넘겨줌
			return new(DataType.BOOL, BitConverter.ToBoolean(temp, 0));
		}


		static private RcdResult ReturnNull()
		{
			return new(0, null);
		}

	}
}
