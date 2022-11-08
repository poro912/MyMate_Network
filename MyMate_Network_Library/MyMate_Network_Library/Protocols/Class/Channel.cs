namespace Protocol
{
    public class ChannelProtocol
    {
        public class CHNNEL
        {
            // Data Declear
            public int serverCode;
            public int channelCode;
            public string title;
            public int state;

            public CHNNEL()
            {
                serverCode = 0;
                channelCode = 0;
                title = "";
                state = 0;
            }

            public CHNNEL(
                int serverCode = 0,
                int channelCode = 0,
                string title = "",
                int state = 0
                )
            {
                this.serverCode = serverCode;
                this.channelCode = channelCode;
                this.title = title;
                this.state = state;
            }

            public void Set(
                int serverCode,
                int channelCode,
                string title,
                int state
                )
            {
                this.serverCode = serverCode;
                this.channelCode = channelCode;
                this.title = title;
                this.state = state;
            }

            public void Get(
                out int serverCode,
                out int channelCode,
                out string title,
                out int state
            )
            {
                serverCode = this.serverCode;
                channelCode = this.channelCode;
                title = this.title;
                state = this.state;
            }
        }

        static public void Generate(
            CHNNEL target,
            ref ByteList destination
            )
        {
            destination.Add(DataType.CHNNEL);
            Generater.Generate(target.serverCode, ref destination);
            Generater.Generate(target.channelCode, ref destination);
            Generater.Generate(target.title, ref destination);
            Generater.Generate(target.state, ref destination);
        }

        // List<byte>를 클래스로 변환
        static public RcdResult Convert(ByteList target)
        {
            RcdResult temp;
            CHNNEL result = new();

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
                result.state = (int)temp.Value;

            return new(DataType.CHNNEL, result);
        }
    }
}
