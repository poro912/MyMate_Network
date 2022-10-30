using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 1. 아래의 형태로 클래스 생성
 * 2. DataType에 상수 등록
 * 3. Generater에 등록
 * 4. Converter에 등록
 */

namespace Protocol.Protocols
{
	/*
	public class BaseProtocol
	{
		public class DataName
		{
			// Data Declear
			public string data1;
			public string data2;
			public DataName() { }
			public DataName(
				string data1,
				string data2
				)
			{
				this.data1 = data1;
				this.data2 = data2;
			}

			public void Set(
				string data1,
				string data2
				)
			{
				this.data1 = data1;
				this.data2 = data2;
			}

			public void Get(
				out string data1,
				out string data2
			)
			{
				data1 = this.data1;
				data2 = this.data2;
			}
		}


		static public void Generate(DataName target, ref ByteList destination)
		{
			destination.Add(DataType.DataName);
			Generater.Generate(target.data1, ref destination);
			Generater.Generate(target.data2, ref destination);
		}
		// List<byte>를 클래스로 변환
		static public RcdResult Convert(ByteList target)
		{
			RcdResult temp;
			DataName result = new();

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.data1 = (string)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.data2 = (string)temp.Value;

			return new(DataType.DataName, result);
		}
	}
	*/
}
