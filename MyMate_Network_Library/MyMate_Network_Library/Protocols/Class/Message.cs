namespace Protocol
{
    public class MessageProtocol
    {
        public class MESSAGE
        {
            public int messageCode;
            public int serverCode;
            public int channelCode;
            public int creater;
            public string content;
            public DateTime startTime;
            public bool isPrivate;

            public MESSAGE()
            {
                messageCode = 0;
                serverCode = 0;
                channelCode = 0;
                creater = 0;
                content = "";
                startTime = new();
                isPrivate = false;
            }
            public MESSAGE(
                int messageCode = 0,
                int serverCode = 0,
                int channelCode = 0,
                int creater = 0,
                string content = "",
                DateTime startTime = new(),
                bool isPrivate = false
                )
            {
                this.messageCode = messageCode;
                this.serverCode = serverCode;
                this.channelCode = channelCode;
                this.creater = creater;
                this.content = content;
                this.startTime = startTime;
                this.isPrivate = isPrivate;
            }

            public void Set(
                int messageCode,
                int serverCode,
                int channelCode,
                int creater,
                string content,
                DateTime startTime,
                bool isPrivate
                )
            {
                this.messageCode = messageCode;
                this.serverCode = serverCode;
                this.channelCode = channelCode;
                this.creater = creater;
                this.content = content;
                this.startTime = startTime;
                this.isPrivate = isPrivate;
            }

            // 데이터를 각 변수에 저장
            public void Get(
                out int messageCode,
                out int serverCode,
                out int channelCode,
                out int creater,
                out string content,
                out DateTime startTime,
                out bool isPrivate
                )
            {
                messageCode = this.messageCode;
                serverCode = this.serverCode;
                channelCode = this.channelCode;
                creater = this.creater;
                content = this.content;
                startTime = this.startTime;
                isPrivate = this.isPrivate;
            }
        }

        // 클래스를 List<byte>로 변환
        static public void Generate(
            MESSAGE target,
            ref ByteList destination
            )
        {
            destination.Add(DataType.MESSAGE);
            Generater.Generate(target.messageCode, ref destination);
            Generater.Generate(target.serverCode, ref destination);
            Generater.Generate(target.channelCode, ref destination);
            Generater.Generate(target.creater, ref destination);
            Generater.Generate(target.content, ref destination);
            Generater.Generate(target.startTime, ref destination);
            Generater.Generate(target.isPrivate, ref destination);
        }

        // List<byte>를 클래스로 변환
        static public RcdResult Convert(ByteList target)
        {
            RcdResult temp;
            MESSAGE result = new();

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.messageCode = (int)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.serverCode = (int)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.channelCode = (int)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.creater = (int)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.content = (string)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.startTime = (DateTime)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.isPrivate = (bool)temp.Value;

            return new(DataType.MESSAGE, result);
        }
    }
}
