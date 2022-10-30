using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol.Protocols
{
	public class isConnectProtocol
	{
		public class IsConnect
		{
			// Data Declear
			public int connectInfo;

			public IsConnect() { }
			public IsConnect(
				int connectInfo
				)
			{
				this.connectInfo = connectInfo;
			}

			public void Get(
				out int connectInfo
			)
			{
				connectInfo= this.connectInfo;
			}

			public void Set(
				int connectInfo
				)
			{
				this.connectInfo = connectInfo;
			}
		}


		static public void Generate(IsConnect target, ref ByteList destination)
		{
			destination.Add(DataType.ISCONNECT);
			Generater.Generate(target.connectInfo, ref destination);
		}
		// ByteList를 클래스로 변환
		static public RcdResult Convert(ByteList target)
		{
			RcdResult temp;
			IsConnect result = new();

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.connectInfo = (int)temp.Value;

			return new(DataType.ISCONNECT, result);
		}

	}
}
