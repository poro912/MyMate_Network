namespace Protocol
{
    public class CheckListProtocol
    {
        public class CHECKLIST
        {
            // Data Declear
            public int checkListCode;
            public int serverCode;
            public int channelCode;
            public int creater;
            public DateTime startDate;
            public DateTime endDate;
            public string content;
            public bool isChecked;
            public bool isPrivate;
			public bool isDelete;

			public CHECKLIST()
            {
                checkListCode = 0;
                serverCode = 0;
                channelCode = 0;
				creater = 0;
				startDate = new();
                endDate = new();
                content = "";
                isChecked = false;
                isPrivate = false;
				isDelete = false;   
			}

            public CHECKLIST(
                int checkListCode = 0,
                int serverCode = 0,
                int channelCode = 0,
                int creater = 0,
                DateTime startDate = new(),
                DateTime endDate = new(),
                string content = "",
                bool isChecked = false,
                bool isPrivate = false,
				bool isDelete = false
                )
            {
                this.checkListCode = checkListCode;
                this.serverCode = serverCode;
                this.channelCode = channelCode;
                this.creater = creater;
                this.startDate = startDate;
                this.endDate = endDate;
                this.content = content;
                this.isChecked = isChecked;
                this.isPrivate = isPrivate;
				this.isDelete = isDelete;
			}

            public void Set(
                int checkListCode,
                int serverCode,
                int channelCode,
                int creater,
                DateTime startDate,
                DateTime endDate,
                string content,
                bool isChecked,
                bool isPrivate,
				bool isDelete = false
				)
            {
                this.checkListCode = checkListCode;
                this.serverCode = serverCode;
                this.channelCode = channelCode;
                this.creater = creater;
                this.startDate = startDate;
                this.endDate = endDate;
                this.content = content;
                this.isChecked = isChecked;
                this.isPrivate = isPrivate;
				this.isDelete = isDelete;
			}

            public void Get(
                out int checkListCode,
                out int serverCode,
                out int channelCode,
                out int creater,
                out DateTime startDate,
                out DateTime endDate,
                out string content,
                out bool isChecked,
                out bool isPrivate,
				out bool isDelete
			)
            {
                checkListCode = this.checkListCode;
                serverCode = this.serverCode;
                channelCode = this.channelCode;
                creater = this.creater;
                startDate = this.startDate;
                endDate = this.endDate;
                content = this.content;
                isChecked = this.isChecked;
                isPrivate = this.isPrivate;
				isDelete = this.isDelete;
			}
		}

        static public void Generate(
            CHECKLIST target,
            ref ByteList destination
            )
        {
            destination.Add(DataType.CHECKLIST);
            Generater.Generate(target.checkListCode, ref destination);
            Generater.Generate(target.serverCode, ref destination);
            Generater.Generate(target.channelCode, ref destination);
			Generater.Generate(target.creater, ref destination);
			Generater.Generate(target.startDate, ref destination);
            Generater.Generate(target.endDate, ref destination);
            Generater.Generate(target.content, ref destination);
            Generater.Generate(target.isChecked, ref destination);
            Generater.Generate(target.isPrivate, ref destination);
			Generater.Generate(target.isDelete, ref destination);
		}

        // List<byte>를 클래스로 변환
        static public RcdResult Convert(ByteList target)
        {
            RcdResult temp;
            CHECKLIST result = new();

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.checkListCode = (int)temp.Value;

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
                result.startDate = (DateTime)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.endDate = (DateTime)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.content = (string)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.isChecked = (bool)temp.Value;

            temp = Converter.Convert(target);
            if (temp.Value != null)
                result.isPrivate = (bool)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.isDelete = (bool)temp.Value;

			return new(DataType.CHECKLIST, result);
        }
    }

}
