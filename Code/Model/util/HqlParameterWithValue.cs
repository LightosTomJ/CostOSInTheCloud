using System;

namespace Model.util
{

	[Serializable]
	public class HqlParameterWithValue
	{

		private string paramName;
		private int? index;
		private double? decimalValue;
		private long? longValue;
		private string stringValue;

		public HqlParameterWithValue() : base()
		{
		}

		public HqlParameterWithValue(int index, double? decimalValue) : base()
		{
			this.index = index;
			this.decimalValue = decimalValue;
		}

		public HqlParameterWithValue(int index, long? longValue) : base()
		{
			this.index = index;
			this.longValue = longValue;
		}

		public HqlParameterWithValue(int index, string stringValue) : base()
		{
			this.index = index;
			this.stringValue = stringValue;
		}

		public HqlParameterWithValue(string paramName, double? decimalValue) : base()
		{
			this.paramName = paramName;
			this.decimalValue = decimalValue;
		}

		public HqlParameterWithValue(string paramName, long? longValue) : base()
		{
			this.paramName = paramName;
			this.longValue = longValue;
		}

		public HqlParameterWithValue(string paramName, string stringValue) : base()
		{
			this.paramName = paramName;
			this.stringValue = stringValue;
		}

		public virtual int? Index
		{
			get
			{
				return index;
			}
			set
			{
				this.index = value;
			}
		}
		public virtual string ParamName
		{
			get
			{
				return paramName;
			}
			set
			{
				this.paramName = value;
			}
		}

		public virtual double? DecimalValue
		{
			get
			{
				return decimalValue;
			}
			set
			{
				this.decimalValue = value;
			}
		}

		public virtual long? LongValue
		{
			get
			{
				return longValue;
			}
			set
			{
				this.longValue = value;
			}
		}
		public virtual string StringValue
		{
			get
			{
				return stringValue;
			}
			set
			{
				this.stringValue = value;
			}
		}
	}
}