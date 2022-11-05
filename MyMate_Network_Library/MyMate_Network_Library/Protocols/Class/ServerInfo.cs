namespace Protocol
{
    public class ServerProtocol
    {
        public class Server
        {
            // Data Declear
            public int serverCode;
            public string title;
            public int adminCode;

            public Server()
            {
                serverCode = 0;
                title = "";
                adminCode = 0;
            }
            public Server(
                int serverCode = 0,
                string title = "",
                int adminCode = 0
                )
            {
                this.serverCode = serverCode;
                this.title = title;
                this.adminCode = adminCode;
            }

            public void Set(
                int serverCode,
                string title,
                int adminCode
                )
            {
                this.serverCode = serverCode;
                this.title = title;
                this.adminCode = adminCode;
            }

            public void Get(
                out int serverCode,
                out string title,
                out int adminCode
            )
            {
                serverCode = this.serverCode;
                title = this.title;
                adminCode = this.adminCode;
            }
        }

        static public void Generate(
            Server target,
            ref ByteList destination
            )
        {
            destination.Add(DataType.SERVER);
            Generater.Generate(target.serverCode, ref destination);
            Generater.Generate(target.title, ref destination);
            Generater.Generate(target.adminCode, ref destination);
        }

        // List<byte>를 클래스로 변환
        static public RcdResult Convert(ByteList target)
        {
            RcdResult temp;
            Server result = new();

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.serverCode = (int)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.title = (string)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.adminCode = (int)temp.Value;

            return new(DataType.SERVER, result);
        }
    }
}
