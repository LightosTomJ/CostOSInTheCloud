using System.Collections.Generic;

namespace Desktop.common.nomitech.common.countries
{

	public class CountryUtil
	{
	  private Locale locale = null;

	  private System.Collections.IList countriesList = null;

	  private CountryUtil(Locale paramLocale)
	  {
		this.locale = paramLocale;
		this.countriesList = buildCountryList(this.locale);
	  }

	  public virtual System.Collections.IList CountryList
	  {
		  get
		  {
			  return this.countriesList;
		  }
	  }

	  private System.Collections.IList buildCountryList(Locale paramLocale)
	  {
		Locale[] arrayOfLocale = Locale.AvailableLocales;
		List<object> arrayList = new List<object>();
		for (sbyte b = 0; b < arrayOfLocale.Length; b++)
		{
		  string str1 = arrayOfLocale[b].Country;
		  string str2 = arrayOfLocale[b].getDisplayCountry(paramLocale);
		  if (!"".Equals(str1) && !"".Equals(str2))
		  {
			Country country = new Country(str2, str1);
			if (!arrayList.Contains(country))
			{
			  arrayList.Add(new Country(str2, str1));
			}
		  }
		}
		arrayList.Sort(new LabelValueComparator(this, paramLocale));
		return arrayList;
	  }

	  public static CountryUtil newInstance(Locale paramLocale)
	  {
		  return new CountryUtil(paramLocale);
	  }

	  private class LabelValueComparator : System.Collections.IComparer
	  {
		  private readonly CountryUtil outerInstance;

		internal System.Collections.IComparer c;

		public LabelValueComparator(CountryUtil outerInstance, Locale param1Locale)
		{
			this.outerInstance = outerInstance;
			this.c = Collator.getInstance(param1Locale);
		}

		public int Compare(object param1Object1, object param1Object2)
		{
		  Country country1 = (Country)param1Object1;
		  Country country2 = (Country)param1Object2;
		  return this.c.Compare(country1.Label, country2.Label);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\countries\CountryUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}