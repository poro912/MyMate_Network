using Protocol.trash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Protocols
{
    public class MessageProtocol
	{
		public class Message
		{
			public int usercode;
			public int servercode;
			public String context;
			public DateTime date;

			public Message() { }
			public Message(int usercode, int servercode, string context, DateTime date)
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
		}

		// 클래스를 List<byte>로 변환
		static public void Generate(Message target, ref ByteList destination)
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
			Message result = new();

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
