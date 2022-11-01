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
			public string id;
			public string name;
			public string nick;
			public string phone;

			public USER() {
				id = "";
				name = "";
				nick = "";
				phone = "";
			}
			public USER(
				int code = 0,
				string id = "",
				string name = "",
				string nick = "",
				string phone = ""
				)
			{
				this.code = code;
				this.id = id;
				this.name = name;
				this.nick = nick;
				this.phone = phone;
			}

			public void Get(
				out int code,
				out string id,
				out string name,
				out string nick,
				out string phone
				)
			{
				code = this.code;
				id = this.id;
				name = this.name;
				nick = this.nick;
				phone = this.phone;
			}
			public void Set(
				int code, 
				string id, 
				string name, 
				string nick, 
				string phone
				)
			{
				this.code = code;
				this.id = id;
				this.name = name;
				this.nick = nick;
				this.phone = phone;
			}
			public void Print()
			{
				Console.WriteLine("UserInfo");
				Console.WriteLine("code : " + code);
				Console.WriteLine("id : " + id);
				Console.WriteLine("name : " + name);
				Console.WriteLine("nick : " + nick);
				Console.WriteLine("phone : " + phone);
			}
		}

		// byte 데이터를 생성
		static public void Generate(USER target, ref ByteList destination)
		{
			destination.Add(DataType.USER);
			Generater.Generate(target.code, ref destination);
			Generater.Generate(target.id, ref destination);
			Generater.Generate(target.name, ref destination);
			Generater.Generate(target.nick, ref destination);
			Generater.Generate(target.phone, ref destination);
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
				result.id = (string)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.name = (string)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.nick = (string)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.phone = (string)temp.Value;

			return new (DataType.USER, result);
		}
	}
}