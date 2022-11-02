using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol
{
	public class CheckListProtocol
	{
		public class CHECKLIST
		{
			// Data Declear
			public int code;
			public int servercode;
			public int channelcode;
			public int ownercode;		// 소유자
			public DateTime startDate;
			public DateTime endDate;
			public string title;
			bool status;

			public CHECKLIST()
			{
				data1 = "";
				data2 = "";
			}
			public CHECKLIST(
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


		static public void Generate(CHECKLIST target, ref ByteList destination)
		{
			destination.Add(DataType.CHECKLIST);
			Generater.Generate(target.data1, ref destination);
			Generater.Generate(target.data2, ref destination);
		}
		// List<byte>를 클래스로 변환
		static public RcdResult Convert(ByteList target)
		{
			RcdResult temp;
			CHECKLIST result = new();

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.data1 = (string)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.data2 = (string)temp.Value;

			return new(DataType.CHECKLIST, result);
		}
	}
	
}
