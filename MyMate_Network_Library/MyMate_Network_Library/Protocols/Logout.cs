using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol
{
	public class LogoutProtocol
	{
		public class LOGOUT
		{
			// Data Declear
			public int usercode;
			public string id;
			public LOGOUT() 
			{
				id = "";
			}
			public LOGOUT(
				int usercode = 0,
				string id = ""
				)
			{
				this.usercode = usercode;
				this.id = id;
			}

			public void Get(
				out int usercode,
				out string id
			)
			{
				usercode = this.usercode;
				id = this.id;
			}

			public void Set(
				int usercode,
				string id
				)
			{
				this.usercode = usercode;
				this.id = id;
			}
			public void Print()
			{
				Console.WriteLine("Logout");
				Console.WriteLine("usercode : " +usercode);
				Console.WriteLine("id : " + id); 
			}
		}


		static public void Generate(
			LOGOUT target, 
			ref ByteList destination
			)
		{
			destination.Add(DataType.LOGOUT);
			Generater.Generate(target.usercode, ref destination);
			Generater.Generate(target.id, ref destination);
		}
		// List<byte>를 클래스로 변환
		static public RcdResult Convert(ByteList target)
		{
			RcdResult temp;
			LOGOUT result = new();

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.usercode = (int)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.id = (string)temp.Value;

			return new(DataType.LOGOUT, result);
		}
	}
}
