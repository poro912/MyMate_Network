using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerNetwork.Module.sub
{
	static public class Send
	{
		static private void SendData(Stream stream, ref Byte[] data)
		{
			try
			{
				stream.Write(data, 0, data.Length);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
		static public void SendString(Stream stream, ref String data)
		{
			// String 을 byte 배열로 변환하여 전송
			byte[] buf = Encoding.Default.GetBytes(data);
			
			SendData(stream, ref buf);
		}
		static public void SendByteArray(Stream stream, ref Byte[] data)
		{
			SendData(stream, ref data);
		}
		
		static public void SendToUser(object data)
		{

		}
	}
}
