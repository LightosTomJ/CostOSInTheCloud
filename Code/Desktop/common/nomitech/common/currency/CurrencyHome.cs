using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.currency
{
	using StringUtils = nomitech.common.util.StringUtils;

	public class CurrencyHome : GlobalCurrencyIntf
	{
	  private static CurrencyHome s_instance;

	  private IList<Currency> currencyList = Collections.synchronizedList(new List<object>());

	  private IList<Currency> remainingList = Collections.synchronizedList(new List<object>());

	  private Properties currencyCodeProperties = null;

	  private CurrencyHome()
	  {
		this.currencyCodeProperties = new Properties();
		loadCurrencies();
	  }

	  public CurrencyHome(Properties paramProperties)
	  {
		this.currencyCodeProperties = paramProperties;
		loadCurrencies();
	  }

	  public virtual IList<Currency> CurrencyList
	  {
		  get
		  {
			  return this.currencyList;
		  }
		  set
		  {
			this.currencyList = value;
			loadCurrencies(saveCurrencies(false));
		  }
	  }

	  public virtual IList<Currency> RemainingList
	  {
		  get
		  {
			  return this.remainingList;
		  }
	  }


	  private void loadCurrencies()
	  {
		string[] arrayOfString = getStringArrayProperty("projectdefaults.currency.list");
		loadCurrencies(arrayOfString);
	  }

	  private void loadCurrencies(string[] paramArrayOfString)
	  {
		List<object> arrayList = new List<object>();
		foreach (string str in paramArrayOfString)
		{
		  arrayList.Add(str);
		}
		this.currencyList.Clear();
		this.remainingList.Clear();
		Currency currency = new Currency();
		if (arrayList.Contains("EUR"))
		{
		  this.currencyList.Add(SupportedCurrencies.EUR);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.EUR);
		}
		if (arrayList.Contains("USD"))
		{
		  this.currencyList.Add(SupportedCurrencies.USD);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.USD);
		}
		if (arrayList.Contains("GBP"))
		{
		  this.currencyList.Add(SupportedCurrencies.GBP);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.GBP);
		}
		if (arrayList.Contains("ARS"))
		{
		  this.currencyList.Add(SupportedCurrencies.ARS);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.ARS);
		}
		if (arrayList.Contains("AUD"))
		{
		  this.currencyList.Add(SupportedCurrencies.AUD);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.AUD);
		}
		if (arrayList.Contains("HKD"))
		{
		  this.currencyList.Add(SupportedCurrencies.HKD);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.HKD);
		}
		if (arrayList.Contains("BHD"))
		{
		  this.currencyList.Add(SupportedCurrencies.BHD);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.BHD);
		}
		if (arrayList.Contains("BWP"))
		{
		  this.currencyList.Add(SupportedCurrencies.BWP);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.BWP);
		}
		if (arrayList.Contains("BRL"))
		{
		  this.currencyList.Add(SupportedCurrencies.BRL);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.BRL);
		}
		if (arrayList.Contains("PEN"))
		{
		  this.currencyList.Add(SupportedCurrencies.PEN);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.PEN);
		}
		if (arrayList.Contains("BND"))
		{
		  this.currencyList.Add(SupportedCurrencies.BND);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.BND);
		}
		if (arrayList.Contains("CAD"))
		{
		  this.currencyList.Add(SupportedCurrencies.CAD);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.CAD);
		}
		if (arrayList.Contains("CLP"))
		{
		  this.currencyList.Add(SupportedCurrencies.CLP);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.CLP);
		}
		if (arrayList.Contains("CNY"))
		{
		  this.currencyList.Add(SupportedCurrencies.CNY);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.CNY);
		}
		if (arrayList.Contains("COP"))
		{
		  this.currencyList.Add(SupportedCurrencies.COP);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.COP);
		}
		if (arrayList.Contains("DKK"))
		{
		  this.currencyList.Add(SupportedCurrencies.DKK);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.DKK);
		}
		if (arrayList.Contains("HUF"))
		{
		  this.currencyList.Add(SupportedCurrencies.HUF);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.HUF);
		}
		if (arrayList.Contains("ISK"))
		{
		  this.currencyList.Add(SupportedCurrencies.ISK);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.ISK);
		}
		if (arrayList.Contains("INR"))
		{
		  this.currencyList.Add(SupportedCurrencies.INR);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.INR);
		}
		if (arrayList.Contains("IDR"))
		{
		  this.currencyList.Add(SupportedCurrencies.IDR);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.IDR);
		}
		if (arrayList.Contains("IRR"))
		{
		  this.currencyList.Add(SupportedCurrencies.IRR);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.IRR);
		}
		if (arrayList.Contains("ILS"))
		{
		  this.currencyList.Add(SupportedCurrencies.ILS);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.ILS);
		}
		if (arrayList.Contains("JPY"))
		{
		  this.currencyList.Add(SupportedCurrencies.JPY);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.JPY);
		}
		if (arrayList.Contains("KRW"))
		{
		  this.currencyList.Add(SupportedCurrencies.KRW);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.KRW);
		}
		if (arrayList.Contains("KWD"))
		{
		  this.currencyList.Add(SupportedCurrencies.KWD);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.KWD);
		}
		if (arrayList.Contains("SDG"))
		{
		  this.currencyList.Add(SupportedCurrencies.SDG);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.SDG);
		}
		if (arrayList.Contains("LYD"))
		{
		  this.currencyList.Add(SupportedCurrencies.LYD);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.LYD);
		}
		if (arrayList.Contains("MYR"))
		{
		  this.currencyList.Add(SupportedCurrencies.MYR);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.MYR);
		}
		if (arrayList.Contains("MUR"))
		{
		  this.currencyList.Add(SupportedCurrencies.MUR);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.MUR);
		}
		if (arrayList.Contains("MXN"))
		{
		  this.currencyList.Add(SupportedCurrencies.MXN);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.MXN);
		}
		if (arrayList.Contains("NPR"))
		{
		  this.currencyList.Add(SupportedCurrencies.NPR);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.NPR);
		}
		if (arrayList.Contains("NZD"))
		{
		  this.currencyList.Add(SupportedCurrencies.NZD);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.NZD);
		}
		if (arrayList.Contains("NOK"))
		{
		  this.currencyList.Add(SupportedCurrencies.NOK);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.NOK);
		}
		if (arrayList.Contains("RON"))
		{
		  this.currencyList.Add(SupportedCurrencies.RON);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.RON);
		}
		if (arrayList.Contains("OMR"))
		{
		  this.currencyList.Add(SupportedCurrencies.OMR);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.OMR);
		}
		if (arrayList.Contains("EGP"))
		{
		  this.currencyList.Add(SupportedCurrencies.EGP);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.EGP);
		}
		if (arrayList.Contains("PKR"))
		{
		  this.currencyList.Add(SupportedCurrencies.PKR);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.PKR);
		}
		if (arrayList.Contains("PLN"))
		{
		  this.currencyList.Add(SupportedCurrencies.PLN);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.PLN);
		}
		if (arrayList.Contains("QAR"))
		{
		  this.currencyList.Add(SupportedCurrencies.QAR);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.QAR);
		}
		if (arrayList.Contains("SAR"))
		{
		  this.currencyList.Add(SupportedCurrencies.SAR);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.SAR);
		}
		if (arrayList.Contains("SGD"))
		{
		  this.currencyList.Add(SupportedCurrencies.SGD);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.SGD);
		}
		if (arrayList.Contains("ZAR"))
		{
		  this.currencyList.Add(SupportedCurrencies.ZAR);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.ZAR);
		}
		if (arrayList.Contains("LKR"))
		{
		  this.currencyList.Add(SupportedCurrencies.LKR);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.LKR);
		}
		if (arrayList.Contains("SEK"))
		{
		  this.currencyList.Add(SupportedCurrencies.SEK);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.SEK);
		}
		if (arrayList.Contains("CHF"))
		{
		  this.currencyList.Add(SupportedCurrencies.CHF);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.CHF);
		}
		if (arrayList.Contains("THB"))
		{
		  this.currencyList.Add(SupportedCurrencies.THB);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.THB);
		}
		if (arrayList.Contains("TTD"))
		{
		  this.currencyList.Add(SupportedCurrencies.TTD);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.TTD);
		}
		if (arrayList.Contains("AED"))
		{
		  this.currencyList.Add(SupportedCurrencies.AED);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.AED);
		}
		if (arrayList.Contains("VEB"))
		{
		  this.currencyList.Add(SupportedCurrencies.VEB);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.VEB);
		}
		if (arrayList.Contains("DOP"))
		{
		  this.currencyList.Add(SupportedCurrencies.DOP);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.DOP);
		}
		if (arrayList.Contains("TRY"))
		{
		  this.currencyList.Add(SupportedCurrencies.TRY);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.TRY);
		}
		if (arrayList.Contains("DZD"))
		{
		  this.currencyList.Add(SupportedCurrencies.DZD);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.DZD);
		}
		if (arrayList.Contains("VND"))
		{
		  this.currencyList.Add(SupportedCurrencies.VND);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.VND);
		}
		if (arrayList.Contains("NAD"))
		{
		  this.currencyList.Add(SupportedCurrencies.NAD);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.NAD);
		}
		if (arrayList.Contains("RUB"))
		{
		  this.currencyList.Add(SupportedCurrencies.RUB);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.RUB);
		}
		if (arrayList.Contains("GTQ"))
		{
		  this.currencyList.Add(SupportedCurrencies.GTQ);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.GTQ);
		}
		if (arrayList.Contains("PHP"))
		{
		  this.currencyList.Add(SupportedCurrencies.PHP);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.PHP);
		}
		if (arrayList.Contains("NGN"))
		{
		  this.currencyList.Add(SupportedCurrencies.NGN);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.NGN);
		}
		if (arrayList.Contains("GHS"))
		{
		  this.currencyList.Add(SupportedCurrencies.GHS);
		}
		else
		{
		  this.remainingList.Add(SupportedCurrencies.GHS);
		}
	  }

	  public virtual void reloadCurrencies()
	  {
		  loadCurrencies();
	  }

	  private string[] saveCurrencies(bool paramBoolean)
	  {
		System.Collections.IEnumerator iterator = this.currencyList.GetEnumerator();
		List<object> arrayList = new List<object>(this.currencyList.Count);
		while (iterator.MoveNext())
		{
		  arrayList.Add(((Currency)iterator.Current).Code);
		}
		string[] arrayOfString = (string[])arrayList.ToArray(typeof(string));
		if (paramBoolean)
		{
		  setStringArrayProperty("projectdefaults.currency.list", arrayOfString);
		}
		return arrayOfString;
	  }

	  public static CurrencyHome initialize(Properties paramProperties)
	  {
		s_instance = new CurrencyHome(paramProperties);
		return s_instance;
	  }

	  public static CurrencyHome Instance
	  {
		  get
		  {
			if (s_instance == null)
			{
			  s_instance = new CurrencyHome();
			}
			return s_instance;
		  }
	  }

	  public static IList<Currency> Currencies
	  {
		  get
		  {
			  return (Instance).currencyList;
		  }
	  }

	  public static IList<string> CurrencyCodes
	  {
		  get
		  {
			List<object> arrayList = new List<object>((Instance).currencyList.Count);
			foreach (Currency currency in (Instance).currencyList)
			{
			  arrayList.Add(currency.Code);
			}
			return arrayList;
		  }
	  }

	  public static void saveCurrencies(IList<Currency> paramList)
	  {
		(Instance).currencyList = paramList;
		Instance.saveCurrencies(true);
		Instance.loadCurrencies();
	  }

	  public static IList<Currency> RemainingCurrencies
	  {
		  get
		  {
			  return (Instance).remainingList;
		  }
	  }

	  public static Currency findByName(string paramString)
	  {
		foreach (Currency currency in (Instance).currencyList)
		{
		  if (currency.Name.Equals(paramString))
		  {
			return currency;
		  }
		}
		return null;
	  }

	  public virtual Currency _findBySymbol(string paramString)
	  {
		foreach (Currency currency in this.currencyList)
		{
		  if (currency.Symbol.Equals(paramString))
		  {
			return currency;
		  }
		}
		return null;
	  }

	  public static Currency findBySymbol(string paramString)
	  {
		  return Instance._findBySymbol(paramString);
	  }

	  public static Currency findRemainingBySymbol(string paramString)
	  {
		foreach (Currency currency in (Instance).remainingList)
		{
		  if (currency.Symbol.Equals(paramString))
		  {
			return currency;
		  }
		}
		return null;
	  }

	  public static Currency findRemainingCode(string paramString)
	  {
		foreach (Currency currency in (Instance).remainingList)
		{
		  if (currency.Code.Equals(paramString))
		  {
			return currency;
		  }
		}
		return null;
	  }

	  public static Currency findByCode(string paramString)
	  {
		foreach (Currency currency in (Instance).currencyList)
		{
		  if (currency.Code.Equals(paramString))
		  {
			return currency;
		  }
		}
		return null;
	  }

	  public static string findSymbolByCode(string paramString)
	  {
		Currency currency = findByCode(paramString);
		return (currency != null) ? currency.Symbol : paramString;
	  }

	  public virtual Currency findCurrencyBySymbol(string paramString)
	  {
		  return findBySymbol(paramString);
	  }

	  public virtual void setStringArrayProperty(string paramString, string[] paramArrayOfString)
	  {
		string str = "";
		for (sbyte b = 0; b < paramArrayOfString.Length; b++)
		{
		  string str1 = StringUtils.replaceAll(paramArrayOfString[b], ";", "{#}");
		  str = str + str1 + ";";
		}
		this.currencyCodeProperties.setProperty(paramString, str);
	  }

	  public virtual string[] getStringArrayProperty(string paramString)
	  {
		List<object> vector = new List<object>();
		string str = this.currencyCodeProperties.getProperty(paramString);
		if (string.ReferenceEquals(str, null))
		{
		  return new string[0];
		}
		for (sbyte b = 0; b < str.Length; b++)
		{
		  for (int i = b + true; i <= str.Length; i++)
		  {
			string str1 = str.Substring(b, i - b);
			if (str1.EndsWith(";", StringComparison.Ordinal))
			{
			  string str2 = StringUtils.replaceAll(str.Substring(b, (i - 1) - b), "{#}", ";");
			  vector.Add(str2);
			  b = i - 1;
			  i = str.Length;
			}
		  }
		}
		return (string[])vector.ToArray(typeof(string));
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\currency\CurrencyHome.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}