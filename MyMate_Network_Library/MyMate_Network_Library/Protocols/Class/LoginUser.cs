﻿using Protocol;

namespace Protocol
{
    public class LoginUserProtocol
    {
        public class LOGINUSER : UserProtocol.USER
        { }

        // byte 데이터를 생성
        static public void Generate(
            LOGINUSER target,
            ref ByteList destination
            )
        {
            destination.Add(DataType.LOGINUSER);
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
            LOGINUSER result = new();

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

            return new(DataType.LOGINUSER, result);
        }
    }
}