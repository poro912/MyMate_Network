﻿namespace Protocol
{
    public class FriendProtocol
    {
        public class FRIEND
        {
            // Data Declear
            public int userCode;
            public int friendCode;
            public string nickname;
            public bool isHide;
            public bool isBlock;
			public string friendId;

			public FRIEND()
            {
                userCode = 0;
                friendCode = 0;
                nickname = "";
                isHide = false;
                isBlock = false;
				friendId = "";
			}
            public FRIEND(
                int userCode = 0,
                int frendCode = 0,
                string nickname = "",
                bool isHide = false,
                bool isBlock = false,
				string friendId = ""
				)
            {
                this.userCode = userCode;
                this.friendCode = frendCode;
                this.nickname = nickname;
                this.isHide = isHide;
                this.isBlock = isBlock;
				this.friendId = friendId;
			}

            public void Set(
                int userCode,
                int friendCode,
                string nickname,
                bool isHide,
                bool isBlock,
                string friendId = ""
				)
            {
                this.userCode = userCode;
                this.friendCode = friendCode;
                this.nickname = nickname;
                this.isHide = isHide;
                this.isBlock = isBlock;
				this.friendId = "";
			}

            public void Get(
                out int userCode,
                out int friendCode,
                out string nickname,
                out bool isHide,
                out bool isBlock,
				out string friendId
			)
            {
                userCode = this.userCode;
                friendCode = this.friendCode;
                nickname = this.nickname;
                isHide = this.isBlock;
                isBlock = this.isBlock;
                friendId = this.friendId;
			}
        }

        static public void Generate(
            FRIEND target,
            ref ByteList destination
            )
        {
            destination.Add(DataType.FRIEND);
            Generater.Generate(target.userCode, ref destination);
            Generater.Generate(target.friendCode, ref destination);
            Generater.Generate(target.nickname, ref destination);
            Generater.Generate(target.isHide, ref destination);
            Generater.Generate(target.isBlock, ref destination);
			Generater.Generate(target.friendId, ref destination);
		}

        // List<byte>를 클래스로 변환
        static public RcdResult Convert(ByteList target)
        {
            RcdResult temp;
            FRIEND result = new();

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.userCode = (int)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.friendCode = (int)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.nickname = (string)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.isHide = (bool)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.isBlock = (bool)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.friendId = (string)temp.Value;

			return new(DataType.FRIEND, result);
        }
    }
}
