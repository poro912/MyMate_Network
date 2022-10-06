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


		static public void Generate(ref Login target, ref List<byte> destination)
		{
			destination.Add(DataType.LOGIN);
			Generater.Generate(ref target.id, ref destination);
			Generater.Generate(ref target.pw, ref destination);
		}
		// List<byte>를 클래스로 변환
		static public KeyValuePair<byte, object?> Convert(ref List<byte> target)
		{
			KeyValuePair<byte, object?> temp;
			Login result = new();

			temp = Converter.Convert(ref target);
			if (temp.Value != null)
				result.id = (string)temp.Value;

			temp = Converter.Convert(ref target);
			if (temp.Value != null)
				result.pw = (string)temp.Value;

			return new(DataType.LOGIN, result);
		}
	}
}
