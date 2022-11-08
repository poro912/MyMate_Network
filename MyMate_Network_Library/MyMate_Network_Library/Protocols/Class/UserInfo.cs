namespace Protocol
{
    public class UserProtocol
    {
        public class USER
        {
            public int userCode;
            public string name;
            public string nickname;
            public string email;
            public string phone;
            public string content;
            public DateTime recentTime;

            public USER()
            {
                userCode = 0;
                name = "";
                nickname = "";
                email = "";
                phone = "";
                content = "";
                recentTime = new();
            }

            public USER(
                int userCode = 0,
                string name = "",
                string nickname = "",
                string email = "",
                string phone = "",
                string content = "",
                DateTime recentTime = new()
                )
            {
                this.userCode = userCode;
                this.name = name;
                this.nickname = nickname;
                this.email = email;
                this.phone = phone;
                this.content = content;
                this.recentTime = recentTime;
            }
            public void Set(
                int userCode,
                string name,
                string nickname,
                string email,
                string phone,
                string content,
                DateTime recentTime
                )
            {
                this.userCode = userCode;
                this.name = name;
                this.nickname = nickname;
                this.email = email;
                this.phone = phone;
                this.content = content;
                this.recentTime = recentTime;
            }

            public void Get(
                out int userCode,
                out string name,
                out string nickname,
                out string email,
                out string phone,
                out string content,
                out DateTime recentTime
                )
            {
                userCode = this.userCode;
                name = this.name;
                nickname = this.nickname;
                email = this.email;
                phone = this.phone;
                content = this.content;
                recentTime = this.recentTime;
            }
        }

        // byte 데이터를 생성
        static public void Generate(
            USER target,
            ref ByteList destination
            )
        {
            destination.Add(DataType.USER);
            Generater.Generate(target.userCode, ref destination);
            Generater.Generate(target.name, ref destination);
            Generater.Generate(target.nickname, ref destination);
            Generater.Generate(target.email, ref destination);
            Generater.Generate(target.phone, ref destination);
            Generater.Generate(target.content, ref destination);
            Generater.Generate(target.recentTime, ref destination);
            return;
        }

        static public RcdResult Convert(ByteList target)
        {
            RcdResult temp;
            USER result = new();

            // code 값 입력 받음
            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.userCode = (int)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.name = (string)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.nickname = (string)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.email = (string)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.phone = (string)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.content = (string)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.recentTime = (DateTime)temp.Value;

            return new(DataType.USER, result);
        }
    }
}