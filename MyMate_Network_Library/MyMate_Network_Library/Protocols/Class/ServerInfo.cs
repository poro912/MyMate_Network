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
            public bool isSingle;
			public bool isDelete;

			public Server()
            {
                serverCode = 0;
                title = "";
                adminCode = 0;
				isSingle = false;
				isDelete = false;
			}
            public Server(
                int serverCode = 0,
                string title = "",
                int adminCode = 0,
                bool isSingle = false,
				bool isDelete = false
				)
            {
                this.serverCode = serverCode;
                this.title = title;
                this.adminCode = adminCode;
                this.isSingle = isSingle;
				this.isDelete = isDelete;
			}

            public void Set(
                int serverCode,
                string title,
                int adminCode,
                bool isSingle,
				bool isDelete = false
				)
            {
                this.serverCode = serverCode;
                this.title = title;
                this.adminCode = adminCode;
                this.isSingle = isSingle;
				this.isDelete = isDelete;   
			}

            public void Get(
                out int serverCode,
                out string title,
                out int adminCode,
                out bool isSingle,
				out bool isDelete
			)
            {
                serverCode = this.serverCode;
                title = this.title;
                adminCode = this.adminCode;
                isSingle = this.isSingle;
				isDelete = this.isDelete;
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
			Generater.Generate(target.isSingle, ref destination);
			Generater.Generate(target.isDelete, ref destination);
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

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.isSingle = (bool)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.isDelete = (bool)temp.Value;

			return new(DataType.SERVER, result);
        }
    }
}
