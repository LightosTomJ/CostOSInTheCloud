using System.Collections.Generic;

namespace Models.view.data
{

	using DataObjectDescriptor = nomitech.common.data.descriptor.DataObjectDescriptor;


	public class GlobalPropertiesDefaultsDataView
	{

		//"[projectdefaults.currencysymbol] AS [currencySymbol]" +
		public static readonly DataObjectDescriptor[] SQLFIELDS = new DataObjectDescriptor[]
		{
			new DataObjectDescriptor("clientName","clientName", "Client Name ", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("clientSignature","clientSignature", "Company Initials", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("clientLogo","clientLogo", "Contructors Logo", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("defaultCountry","defaultCountry", "Country", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("currencyList","currencyList", "Currency ", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("petrolPrice","petrolPrice", "Gasoline Price ", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("electricityPrice","electricityPrice", "Eletricity Price ", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("dieselPrice","dieselPrice", "Diesel Price ", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("otherEnergy","otherEnergy", "Other Energy Source", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("lubricatesPrice","lubricatesPrice", "Lubricate Price ", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("decimalScale","decimalScale", "Display Decimal Precision", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("dividerScale","dividerScale", "Divider Scale Interval", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("roundingMode","roundingMode", "Display Rounding Mode", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("currencySymbol","currencySymbol", "Currency Symbol ", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("currencySymbol","currencySymbol", "Currency Symbol ", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("defaultCurrencyName","defaultCurrencyName", "Default Currency Name ", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("defaultCountryName","defaultCountryName", "Default Country Name ", DataObjectDescriptor.TEXT_TYPE),
			new DataObjectDescriptor("defaultCurrencyCode","defaultCurrencyCode", "Default Currency Code ", DataObjectDescriptor.TEXT_TYPE)
		};

		private string clientName;
		private string clientSignature; //signature
		private string clientLogo;
		private string defaultCountry;
		private string currencyList; //this is going to be splited and create the currency list
		private string petrolPrice;
		private string electricityPrice;
		private string dieselPrice;
		private string otherEnergy;
		private string lubricatesPrice;
		//private String salariesBonus;
		private string decimalScale;
		private string dividerScale;
		private string roundingMode;
		private string currencySymbol;
		private IList<CurrencyDataView> currencyDataList; //for json plug-inme
		private string defaultCurrencyName;
		private string defaultCountryName;
		private string defaultCurrencyCode;


		public virtual string DefaultCurrencyCode
		{
			get
			{
				return defaultCurrencyCode;
			}
			set
			{
				this.defaultCurrencyCode = value;
			}
		}


		public virtual string DefaultCurrencyName
		{
			get
			{
				return defaultCurrencyName;
			}
			set
			{
				this.defaultCurrencyName = value;
			}
		}


		public virtual string DefaultCountryName
		{
			get
			{
				return defaultCountryName;
			}
			set
			{
				this.defaultCountryName = value;
			}
		}


		public virtual string ClientName
		{
			get
			{
				return clientName;
			}
			set
			{
				this.clientName = value;
			}
		}


		public virtual string ClientSignature
		{
			get
			{
				return clientSignature;
			}
			set
			{
				this.clientSignature = value;
			}
		}


		public virtual string ClientLogo
		{
			get
			{
				return clientLogo;
			}
			set
			{
				this.clientLogo = value;
			}
		}


		public virtual string DefaultCountry
		{
			get
			{
				return defaultCountry;
			}
			set
			{
				this.defaultCountry = value;
			}
		}


		public virtual string CurrencyList
		{
			get
			{
				return currencyList;
			}
			set
			{
				this.currencyList = value;
			}
		}


		public virtual string PetrolPrice
		{
			get
			{
				return petrolPrice;
			}
			set
			{
				this.petrolPrice = value;
			}
		}


		public virtual string ElectricityPrice
		{
			get
			{
				return electricityPrice;
			}
			set
			{
				this.electricityPrice = value;
			}
		}


		public virtual string DieselPrice
		{
			get
			{
				return dieselPrice;
			}
			set
			{
				this.dieselPrice = value;
			}
		}


		public virtual string OtherEnergy
		{
			get
			{
				return otherEnergy;
			}
			set
			{
				this.otherEnergy = value;
			}
		}


		public virtual string LubricatesPrice
		{
			get
			{
				return lubricatesPrice;
			}
			set
			{
				this.lubricatesPrice = value;
			}
		}


	//	public String getSalariesBonus() {
	//		return salariesBonus;
	//	}
	//
	//	public void setSalariesBonus(String salariesBonus) {
	//		this.salariesBonus = salariesBonus;
	//	}

		public virtual string DecimalScale
		{
			get
			{
				return decimalScale;
			}
			set
			{
				this.decimalScale = value;
			}
		}


		public virtual string DividerScale
		{
			get
			{
				return dividerScale;
			}
			set
			{
				this.dividerScale = value;
			}
		}


		public virtual string RoundingMode
		{
			get
			{
				return roundingMode;
			}
			set
			{
				this.roundingMode = value;
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


		public virtual IList<CurrencyDataView> CurrencyDataList
		{
			get
			{
				return currencyDataList;
			}
			set
			{
				this.currencyDataList = value;
			}
		}


		public static DataObjectDescriptor[] Sqlfields
		{
			get
			{
				return SQLFIELDS;
			}
		}


	}

}