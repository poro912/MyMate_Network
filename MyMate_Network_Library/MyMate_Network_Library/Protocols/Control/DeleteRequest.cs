﻿namespace Protocol
{
	public class DeleteRequestProtocol
	{
		public class DELETE_REQUEST
		{
			public byte dataType;
			public int userCode;
			public int serverCode;
			public int channelCode;
			public int targetCode;
			public DateTime startTime;
			public DateTime endTime;

			public DELETE_REQUEST()
			{
				dataType = 0;
				userCode = 0;
				serverCode = 0;
				channelCode = 0;
				targetCode = 0;
				startTime = new();
				endTime = new();
			}

			public DELETE_REQUEST(
				byte dataType = 0,
				int userCode = 0,
				int serverCode = 0,
				int channelCode = 0,
				int targetCode = 0,
				DateTime startTime = new(),
				DateTime endTime = new()
				)
			{
				this.dataType = dataType;
				this.userCode = userCode;
				this.serverCode = serverCode;
				this.channelCode = channelCode;
				this.targetCode = targetCode;
				this.startTime = startTime;
				this.endTime = endTime;
			}

			public void Set(
				byte dataType,
				int userCode,
				int serverCode,
				int channelCode,
				int targetCode,
				DateTime startTime,
				DateTime endTime
				)
			{
				this.dataType = dataType;
				this.userCode = userCode;
				this.serverCode = serverCode;
				this.channelCode = channelCode;
				this.targetCode = targetCode;
				this.startTime = startTime;
				this.endTime = endTime;
			}

			public void Get(
				out byte dataType,
				out int userCode,
				out int serverCode,
				out int channelCode,
				out int targetCode,
				out DateTime startTime,
				out DateTime endTime
				)
			{
				dataType = this.dataType;
				userCode = this.userCode;
				serverCode = this.serverCode;
				channelCode = this.channelCode;
				targetCode = this.targetCode;
				startTime = this.startTime;
				endTime = this.endTime;
			}
		}
		static public void Generate(
			   DELETE_REQUEST target,
			   ref ByteList destination
			   )
		{
			destination.Add(DataType.DELIVER);
			Generater.Generate(target.dataType, ref destination);
			Generater.Generate(target.userCode, ref destination);
			Generater.Generate(target.serverCode, ref destination);
			Generater.Generate(target.channelCode, ref destination);
			Generater.Generate(target.targetCode, ref destination);
			Generater.Generate(target.startTime, ref destination);
			Generater.Generate(target.endTime, ref destination);
		}
		static public RcdResult Convert(ByteList target)
		{
			RcdResult temp;
			DELETE_REQUEST result = new();

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.dataType = (byte)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.userCode = (int)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.serverCode = (int)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.channelCode = (int)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.targetCode = (int)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.startTime = (DateTime)temp.Value;

			temp = Converter.Convert(target);
			if (temp.Value != null)
				result.endTime = (DateTime)temp.Value;

			return new(DataType.DELETE_REQUEST, result);
		}
	}
}
