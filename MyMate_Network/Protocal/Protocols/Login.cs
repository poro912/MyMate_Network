using Protocol;
using Protocol.trash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Protocol.Protocols
{
	public class LoginProtocol
	{
		public class Login
		{
			public string id;
			public string pw;

			public Login() { }
			public Login(string id, string pw)
			{
				this.id = id;
				this.pw = pw;
			}

			public void Get(
				out string id,
				out string pw
			)
			{
				id = this.id;
				pw = this.pw;
			}

			public void Set(
				string id,
				string pw
				)
			{
				this.id = id;
				this.pw = pw;
			}
		}


		static public void Generate(Login target, ref ByteList destination)
		{
			destination.Add(DataType.LOGIN);
			Generater.Generate(target.id, ref destination);
			Generater.Generate(target.pw, ref destination);
		}
		// List<byte>를 클래스로 변환
		static public RcdResult Convert(ByteList target)
		{
			RcdResult temp;
			Login result = new();

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.id = (string)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.pw = (string)temp.Value;

			return new(DataType.LOGIN, result);
		}
	}
}
