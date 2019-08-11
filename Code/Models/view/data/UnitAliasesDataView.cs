namespace Models.view.data
{
	public class UnitAliasesDataView
	{
		private long? id;
		private string fromUnit;
		private string toUnit;
		public virtual long? Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}
		public virtual string FromUnit
		{
			get
			{
				return fromUnit;
			}
			set
			{
				this.fromUnit = value;
			}
		}
		public virtual string ToUnit
		{
			get
			{
				return toUnit;
			}
			set
			{
				this.toUnit = value;
			}
		}
	}

}