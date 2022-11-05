namespace Protocol
{
    public class ToastProtocol
    {
        public class TOAST
        {
            public int userCode;
            public string title;
            public string content;

            public TOAST()
            {
                userCode = 0;
                title = "";
                content = "";
            }

            public TOAST(
                int userCode = 0,
                string title = "",
                string content = ""
                )
            {
                this.userCode = userCode;
                this.title = title;
                this.content = content;
            }

            public void Set(
                int userCode,
                string title,
                string content
                )
            {
                this.userCode = userCode;
                this.title = title;
                this.content = content;
            }

            public void Get(
                out int userCode,
                out string title,
                out string content
                )
            {
                userCode = this.userCode;
                title = this.title;
                content = this.content;
            }

            static public void Generate(
                TOAST target,
                ref ByteList destination
                )
            {
                destination.Add(DataType.TOAST);
                Generater.Generate(target.userCode, ref destination);
                Generater.Generate(target.title, ref destination);
                Generater.Generate(target.content, ref destination);
            }

            static public RcdResult Convert(ByteList target)
            {
                RcdResult temp;
                TOAST result = new();

                temp = Converter.Convert(target);
                if (temp.Value != null)
                    result.userCode = (int)temp.Value;

                temp = Converter.Convert(target);
                if (temp.Value != null)
                    result.title = (string)temp.Value;

                temp = Converter.Convert(target);
                if (temp.Value != null)
                    result.content = (string)temp.Value;

                return new(DataType.TOAST, result);
            }
        }
    }
}
