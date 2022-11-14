namespace Protocol
{
    public class ChannelProtocol
    {
        public class CHANNEL
        {
            // Data Declear
            public int serverCode;
            public int channelCode;
            public string title;
            public int type;
			public bool isDelete;

			public CHANNEL()
            {
                serverCode = 0;
                channelCode = 0;
                title = "";
                type = 0;
				isDelete = false;
			}

            public CHANNEL(
                int serverCode = 0,
                int channelCode = 0,
                string title = "",
                int state = 0,
				bool isDelete = false
				)
            {
                this.serverCode = serverCode;
                this.channelCode = channelCode;
                this.title = title;
                this.type = state;
				this.isDelete = isDelete;
			}

            public void Set(
                int serverCode,
                int channelCode,
                string title,
                int state,
				bool isDelete = false
				)
            {
                this.serverCode = serverCode;
                this.channelCode = channelCode;
                this.title = title;
                this.type = state;
				this.isDelete = isDelete;
			}

            public void Get(
                out int serverCode,
                out int channelCode,
                out string title,
                out int state,
				out bool isDelete
			)
            {
                serverCode = this.serverCode;
                channelCode = this.channelCode;
                title = this.title;
                state = this.type;
				isDelete = this.isDelete;
			}
        }

        static public void Generate(
            CHANNEL target,
            ref ByteList destination
            )
        {
            destination.Add(DataType.CHNNEL);
            Generater.Generate(target.serverCode, ref destination);
            Generater.Generate(target.channelCode, ref destination);
            Generater.Generate(target.title, ref destination);
            Generater.Generate(target.type, ref destination);
			Generater.Generate(target.isDelete, ref destination);   
		}

        // List<byte>를 클래스로 변환
        static public RcdResult Convert(ByteList target)
        {
            RcdResult temp;
            CHANNEL result = new();

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.serverCode = (int)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.channelCode = (int)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.title = (string)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.type = (int)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.isDelete = (bool)temp.Value;

			return new(DataType.CHNNEL, result);
        }
    }
}
