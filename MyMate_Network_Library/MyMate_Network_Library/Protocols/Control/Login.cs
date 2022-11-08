using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol
{
    public class LoginProtocol
    {
        public class LOGIN
        {
            public string id;
            public string pw;

            public LOGIN()
            {
                id = "";
                pw = "";
            }
            public LOGIN(
                string id = "",
                string pw = ""
                )
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

        static public void Generate(
            LOGIN target,
            ref ByteList destination
            )
        {
            destination.Add(DataType.LOGIN);
            Generater.Generate(target.id, ref destination);
            Generater.Generate(target.pw, ref destination);
        }

        // List<byte>를 클래스로 변환
        static public RcdResult Convert(ByteList target)
        {
            RcdResult temp;
            LOGIN result = new();

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
