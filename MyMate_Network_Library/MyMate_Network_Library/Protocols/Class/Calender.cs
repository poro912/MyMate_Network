namespace Protocol
{
    public class CalenderProtocol
    {
        public class CALENDER
        {
            public int serverCode;
            public int channelCode;
            public int calenderCode;
            public string content;
            public int creater;
            public DateTime startTime;
            public DateTime endTime;
            public bool isPrivate;

            public CALENDER()
            {
                serverCode = 0;
                channelCode = 0;
                calenderCode = 0;
                content = "";
                creater = 0;
                startTime = new();
                endTime = new();
                isPrivate = false;
            }

            public CALENDER(
                int serverCode = 0,
                int channelCode = 0,
                int calenderCode = 0,
                string content = "",
                int creater = 0,
                DateTime startTime = new(),
                DateTime endTime = new(),
                bool isPrivate = false
                )
            {
                this.serverCode = serverCode;
                this.channelCode = channelCode;
                this.calenderCode = calenderCode;
                this.content = content;
                this.creater = creater;
                this.startTime = startTime;
                this.endTime = endTime;
                this.isPrivate = isPrivate;
            }

            public void Set(
                int serverCode,
                int channelCode,
                int calenderCode,
                string content,
                int creater,
                DateTime startTime,
                DateTime endTime,
                bool isPrivate
                )
            {
                this.serverCode = serverCode;
                this.channelCode = channelCode;
                this.calenderCode = calenderCode;
                this.content = content;
                this.creater = creater;
                this.startTime = startTime;
                this.endTime = endTime;
                this.isPrivate = isPrivate;
            }

            public void Get(
                out int serverCode,
                out int channelCode,
                out int calenderCode,
                out string content,
                out int creater,
                out DateTime startTime,
                out DateTime endTime,
                out bool isPrivate
            )
            {
                serverCode = this.serverCode;
                channelCode = this.channelCode;
                calenderCode = this.calenderCode;
                content = this.content;
                creater = this.creater;
                startTime = this.startTime;
                endTime = this.endTime;
                isPrivate = this.isPrivate;
            }
        }

        static public void Generate(
            CALENDER target,
            ref ByteList destination
            )
        {
            destination.Add(DataType.CALENDER);
            Generater.Generate(target.serverCode, ref destination);
            Generater.Generate(target.channelCode, ref destination);
            Generater.Generate(target.calenderCode, ref destination);
            Generater.Generate(target.content, ref destination);
            Generater.Generate(target.creater, ref destination);
            Generater.Generate(target.startTime, ref destination);
            Generater.Generate(target.endTime, ref destination);
            Generater.Generate(target.isPrivate, ref destination);
        }

        // List<byte>를 클래스로 변환
        static public RcdResult Convert(ByteList target)
        {
            RcdResult temp;
            CALENDER result = new();

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.serverCode = (int)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.channelCode = (int)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.calenderCode = (int)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.content = (string)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.creater = (int)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.startTime = (DateTime)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.endTime = (DateTime)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.isPrivate = (bool)temp.Value;

            return new(DataType.CALENDER, result);
        }
    }
}
