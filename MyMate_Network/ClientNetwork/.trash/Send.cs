using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientNetwork.trash
{
    /*
    static public class Send
    {
        // byte 형태의 데이터 전송
        static public void Data(ref NetworkStream stream, ref byte[] data)
        {
            // 들어온 데이터가 없다면 종료
            if (data.Length.Equals(0))
                return;
            try
            {
                stream.Write(data, 0, data.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // 문자열 전송
        static public void Data(ref NetworkStream stream, ref string data)
        {
            // String 을 byte 배열로 변환하여 전송
            byte[] buf = Encoding.Default.GetBytes(data);
            Console.WriteLine("전송 데이터 : " + data);
            // 해당 스트림으로 문자열 전송
            Data(ref stream, ref buf);
        }
    }
    */
}
