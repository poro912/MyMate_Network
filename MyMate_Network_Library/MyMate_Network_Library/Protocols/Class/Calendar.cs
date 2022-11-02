using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol
{
	public class CalenderProtocol
	{
		public class CALENDER
		{
			public int code;
			public string title;
			public string context;
			public DateTime StartDate;
			public DateTime EndDate;
			public bool isdone;
			public bool isrepeat;   // 매년 반복?
			public bool isprivate;
			public CALENDER()
			{
				data1 = "";
				data2 = "";
			}
			public CALENDER(
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
			public void Print()
			{
				
				Console.WriteLine("Base");
				Console.WriteLine("data1 : " + data2);
				Console.WriteLine("data2 : " + data2);
			}
		}


		static public void Generate(CALENDER target, ref ByteList destination)
		{
			destination.Add(DataType.CALENDER);
			Generater.Generate(target.data1, ref destination);
			Generater.Generate(target.data2, ref destination);
		}
		// List<byte>를 클래스로 변환
		static public RcdResult Convert(ByteList target)
		{
			RcdResult temp;
			CALENDER result = new();

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.data1 = (string)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.data2 = (string)temp.Value;

			return new(DataType.CALENDER, result);
		}
	}
	
}
