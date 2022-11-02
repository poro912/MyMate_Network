using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Protocol
{
	public class ChannelProtocol
	{
		public class CHNNEL
		{
			// Data Declear
			public int servercode;
			public int channelcode;
			public string title;
			public CHNNEL()
			{
				data1 = "";
				data2 = "";
			}
			public CHNNEL(
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


		static public void Generate(CHNNEL target, ref ByteList destination)
		{
			destination.Add(DataType.CHNNEL);
			Generater.Generate(target.data1, ref destination);
			Generater.Generate(target.data2, ref destination);
		}
		// List<byte>를 클래스로 변환
		static public RcdResult Convert(ByteList target)
		{
			RcdResult temp;
			CHNNEL result = new();

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.data1 = (string)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.data2 = (string)temp.Value;

			return new(DataType.CHNNEL, result);
		}
	}
	
}
