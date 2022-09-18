using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerNetwork.Module.sub
{
	static public class Send
	{
		static public void SendString(Stream stream, String data)
		{
			byte[] buf = Encoding.Default.GetBytes(data);
			
			try
			{
				stream.Write(buf, 0, buf.Length);
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString());
			}
			/*catch (System.InvalidOperationException e)
			{
				
			}*/
		}

	}
}
