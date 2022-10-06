using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


		static public void Generate(ref IsConnect target, ref List<byte> destination)
		{
			destination.Add(DataType.ISCONNECT);
			Generater.Generate(ref target.connectInfo, ref destination);
		}
		// List<byte>를 클래스로 변환
		static public KeyValuePair<byte, object?> Convert(ref List<byte> target)
		{
			KeyValuePair<byte, object?> temp;
			IsConnect result = new();

			temp = Converter.Convert(ref target);
			if (temp.Value != null)
				result.connectInfo = (int)temp.Value;

			return new(DataType.ISCONNECT, result);
		}

	}
}
