using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * 1. 아래의 형태로 클래스 생성
 * 2. DataType에 상수 등록
 * 3. Generater에 등록
 * 4. Converter에 등록
 */

namespace Protocol
{

	// Generator와 Convertor에 추가할 내용
	// Generator
	// Base
	
	
	// Convertor
	
	 

	
	public class InviteProtocol
	{
		public class Invite
		{
			// Data Declear
			public int userCode;
			public int serverCode;
			public string id;
			public Invite()
			{
				userCode = 0;
				serverCode = 0;
				id = "";
			}
			public Invite(
				int userCode,
				int serverCode,
				string id
				)
			{
				this.userCode = userCode;
				this.serverCode = serverCode;
				this.id = id;
			}

			public void Set(
				int userCode,
				int serverCode,
				string id
				)
			{
				this.userCode = userCode;
				this.serverCode = serverCode;
				this.id = id;
			}

			public void Get(
				out int userCode,
				out int serverCode,
				out string id
			)
			{
				userCode = this.userCode;
				serverCode = this.serverCode;
				id = this.id;
			}
		}


		static public void Generate(Invite target, ref ByteList destination)
		{
			destination.Add(DataType.INVITE);
			Generater.Generate(target.userCode, ref destination);
			Generater.Generate(target.serverCode, ref destination);
		}
		// List<byte>를 클래스로 변환
		static public RcdResult Convert(ByteList target)
		{
			RcdResult temp;
			Invite result = new();

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.userCode = (int)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.serverCode = (int)temp.Value;

			if (temp.Value != null)
				result.id = (string)temp.Value;

			return new(DataType.INVITE, result);
		}
	}
	
}
