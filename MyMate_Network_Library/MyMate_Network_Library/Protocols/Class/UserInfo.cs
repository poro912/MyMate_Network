using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol
{
	public class UserInfoProtocol
	{
		public class USER
		{
			public int code;
			public string name;
			public string nick;
			public string email;
			public string phone;
			public string description;
			public bool ismyfriend;
			public bool isblind;
			public USER()
			{
				code = 0;
				name = "";
				nick = "";
				email = "";
				phone = "";
				description = "";
			}
			public USER(
				int code = 0,
				string name = "",
				string nick = "",
				string email = "",
				string phone = "",
				string description = ""
				)
			{
				this.code = code;
				this.name = name;
				this.nick = nick;
				this.email = email;
				this.phone = phone;
				this.description = description;
			}

			public void Get(
				out int code,
				out string name,
				out string nick,
				out string email,
				out string phone,
				out string description
				)
			{
				code = this.code;
				name = this.name;
				nick = this.nick;
				email = this.email;
				phone = this.phone;
				description = this.description;
			}
			public void Set(
				int code,
				string name,
				string nick,
				string email,
				string phone,
				string description
				)
			{
				this.code = code;
				this.name = name;
				this.nick = nick;
				this.email = email;
				this.phone = phone;
				this.description = description;
			}
		}

		// byte 데이터를 생성
		static public void Generate(USER target, ref ByteList destination)
		{
			destination.Add(DataType.USER);
			Generater.Generate(target.code, ref destination);
			Generater.Generate(target.name, ref destination);
			Generater.Generate(target.nick, ref destination);
			Generater.Generate(target.email, ref destination);
			Generater.Generate(target.phone, ref destination);
			Generater.Generate(target.description, ref destination);
			return;
		}

		static public RcdResult Convert(ByteList target)
		{
			RcdResult temp;
			USER result = new();

			// code 값 입력 받음
			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.code = (int)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.name = (string)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.nick = (string)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.email = (string)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.phone = (string)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.description = (string)temp.Value;

			return new(DataType.USER, result);
		}
	}
}