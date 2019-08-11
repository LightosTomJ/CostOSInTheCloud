namespace Models.view.data
{
	using UILanguage = nomitech.common.ui.UILanguage;

	public class LocalizedPropertyDataView
	{
		private string key;
		private string value;

		public LocalizedPropertyDataView()
		{
		}

		public LocalizedPropertyDataView(string key)
		{
			this.key = key;
			this.value = UILanguage.get(key);
		}

		public LocalizedPropertyDataView(string key, string value)
		{
			this.key = key;
			this.value = value;
		}

		public virtual string Key
		{
			get
			{
				return key;
			}
			set
			{
				this.key = value;
			}
		}
		public virtual string Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
			}
		}
	}

}