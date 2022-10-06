using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Protocols
{
	public class LogoutProtocol
	{
		public class Logout
		{
			// Data Declear
			public string usercode;
			public string id;
			public Logout() { }
			public Logout(
				string usercode,
				string id
				)
			{
				this.usercode = usercode;
				this.id = id;
			}

			public void Get(
				out string usercode,
				out string id
			)
			{
				usercode = this.usercode;
				id = this.id;
			}

			public void Set(
				string usercode,
				string id
				)
			{
				this.usercode = usercode;
				this.id = id;
			}
		}


		static public void Generate(ref Logout target, ref List<byte> destination)
		{
			destination.Add(DataType.LOGINOUT);
			Generater.Generate(ref target.usercode, ref destination);
			Generater.Generate(ref target.id, ref destination);
		}
		// List<byte>를 클래스로 변환
		static public KeyValuePair<byte, object?> Convert(ref List<byte> target)
		{
			KeyValuePair<byte, object?> temp;
			Logout result = new();

			temp = Converter.Convert(ref target);
			if (temp.Value != null)
				result.usercode = (string)temp.Value;

			temp = Converter.Convert(ref target);
			if (temp.Value != null)
				result.id = (string)temp.Value;

			return new(DataType.LOGOUT, result);
		}
	}
}
