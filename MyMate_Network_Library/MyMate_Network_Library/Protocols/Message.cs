using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol
{
    public class MessageProtocol
	{
		public class MESSAGE
		{
			public int usercode;
			public int servercode;
			public String context;
			public DateTime date;

			public MESSAGE() 
			{
				context = "";
				date = DateTime.Now;
			}
			public MESSAGE(
				int usercode = 0, 
				int servercode = 0, 
				string context = "", 
				DateTime date = new DateTime()
				)
			{
				this.usercode = usercode;
				this.servercode = servercode;
				this.context = context;
				this.date = date;
			}

			// 데이터를 각 변수에 저장
			public void Get(
				out int usercode,
				out int servercode,
				out String context,
				out DateTime date
			)
			{
				usercode = this.usercode;
				servercode = this.servercode;
				context = this.context;
				date = this.date;
				return;
			}

			public void Set(
				int usercode,
				int servercode,
				String context,
				DateTime date
			)
			{
				this.usercode = usercode;
				this.servercode = servercode;
				this.context = context;
				this.date = date;
			}

			public void Print()
			{
				Console.WriteLine("Message");
				Console.WriteLine("usercode : " + usercode);
				Console.WriteLine("servercode : " + servercode);
				Console.WriteLine("context : " + context);
				Console.WriteLine("date : " + date.ToString());
			}
		}

		// 클래스를 List<byte>로 변환
		static public void Generate(
			MESSAGE target, 
			ref ByteList destination
			)
		{
			destination.Add(DataType.MESSAGE);
			Generater.Generate(target.servercode,	ref destination);
			Generater.Generate(target.usercode,		ref destination);
			Generater.Generate(target.context,		ref destination);
		}

		// List<byte>를 클래스로 변환
		static public RcdResult Convert(ByteList target)
		{
			RcdResult temp;
			MESSAGE result = new();

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.servercode = (int)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.usercode = (int)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.context = (string)temp.Value;

			return new (DataType.MESSAGE, result);
		}
	}
}
