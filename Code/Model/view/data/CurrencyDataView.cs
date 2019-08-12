namespace Model.view.data
{
	public class CurrencyDataView
	{
		private string displayName;
		private string threeDigitCode;
		private string currencySymbol;
		private string code;

		public virtual string DisplayName
		{
			get
			{
				return displayName;
			}
			set
			{
				this.displayName = value;
			}
		}
		public virtual string ThreeDigitCode
		{
			get
			{
				return threeDigitCode;
			}
			set
			{
				this.threeDigitCode = value;
			}
		}
		public virtual string CurrencySymbol
		{
			get
			{
				return currencySymbol;
			}
			set
			{
				this.currencySymbol = value;
			}
		}
		public virtual string Code
		{
			get
			{
				return code;
			}
			set
			{
				this.code = value;
			}
		}
	}

}