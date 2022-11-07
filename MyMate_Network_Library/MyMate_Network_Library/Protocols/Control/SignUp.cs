namespace Protocol
{
    public class SignUpProtocol
    {
        public class SiginUp
        {
            public string id;
            public string password;
            public string name;
            public string nickname;
            public string email;
            public string phone;

            public SiginUp()
            {
                id = "";
                password = "";
                name = "";
                nickname = "";
                email = "";
                phone = "";
            }

            public SiginUp(
                string id = "",
                string password = "",
                string name = "",
                string nickname = "",
                string email = "",
                string phone = ""
                )
            {
                this.id = id;
                this.password = password;
                this.name = name;
                this.nickname = nickname;
                this.email = email;
                this.phone = phone;
            }
            public void Set(
                string id,
                string password,
                string name,
                string nickname,
                string email,
                string phone
                )
            {
                this.id = id;
                this.password = password;
                this.name = name;
                this.nickname = nickname;
                this.email = email;
                this.phone = phone;
            }

            public void Get(
                out string id,
                out string password,
                out string name,
                out string nickname,
                out string email,
                out string phone
                )
            {
                id = this.id;
                password = this.password;
                name = this.name;
                nickname = this.nickname;
                email = this.email;
                phone = this.phone;
            }
        }

        // byte 데이터를 생성
        static public void Generate(
            SiginUp target,
            ref ByteList destination
            )
        {
            destination.Add(DataType.USER);
            Generater.Generate(target.id, ref destination);
            Generater.Generate(target.password, ref destination);
            Generater.Generate(target.name, ref destination);
            Generater.Generate(target.nickname, ref destination);
            Generater.Generate(target.email, ref destination);
            Generater.Generate(target.phone, ref destination);
            return;
        }

        static public RcdResult Convert(ByteList target)
        {
            RcdResult temp;
            SiginUp result = new();

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.id = (string)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.password = (string)temp.Value;

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

            return new(DataType.USER, result);
        }
    }
}