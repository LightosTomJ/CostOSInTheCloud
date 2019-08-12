using System;

namespace Model.util
{

	[Serializable]
	public class HqlResultValue
	{

		private long? longValue;
		private string stringValue;
		private DateTime dateValue;
		private decimal decimalValue;
		private bool? booleanValue;

		public HqlResultValue() : base()
		{
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
		public virtual DateTime DateValue
		{
			get
			{
				return dateValue;
			}
			set
			{
				this.dateValue = value;
			}
		}
		public virtual decimal DecimalValue
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
		public virtual bool? BooleanValue
		{
			get
			{
				return booleanValue;
			}
			set
			{
				this.booleanValue = value;
			}
		}
	}

}