namespace Protocol
{
	public class RequestRecentAllProtocol
	{
		public class REQUESTRECENTALL
		{
			public DateTime recentTime;

			public REQUESTRECENTALL()
			{
				recentTime = new();
			}

			public REQUESTRECENTALL(DateTime recentTime = new())
			{
				this.recentTime = recentTime;
			}

			public void Set(DateTime recentTime)
			{
				this.recentTime = recentTime;
			}

			public void Get(out DateTime recentTime)
			{
				recentTime = this.recentTime;
			}
		}
		static public void Generate(
			   REQUESTRECENTALL target,
			   ref ByteList destination
			   )
		{
			destination.Add(DataType.REQUEST_RECENT_ALL);
			Generater.Generate(target.recentTime);
		}

		static public RcdResult Convert(ByteList target)
		{
			RcdResult temp;
			REQUESTRECENTALL result = new();

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.recentTime = (DateTime)temp.Value;

			return new(DataType.REQUEST_RECENT_ALL, result);
		}
	}
}
