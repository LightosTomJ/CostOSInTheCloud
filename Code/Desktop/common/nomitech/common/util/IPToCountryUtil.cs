using System;
using System.Collections;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.util
{

	public class IPToCountryUtil
	{
	  private const int CACHE_CLEAR_INTERVAL = 500;

	  private const string WIP_MANIA_URL_PREFIX = "http://api.wipmania.com/";

	  private const string WEBSITE = "in.gr";

	  private static IDictionary<string, string> s_cacheMap = new Hashtable();

	  private string ip;

	  private string countryCode = null;

	  private IPToCountryUtil(string paramString)
	  {
		this.ip = paramString;
		try
		{
		  findUsingWipMania();
		}
		catch (Exception)
		{
		  this.countryCode = null;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void findUsingWipMania() throws Exception
	  private void findUsingWipMania()
	  {
		if (string.ReferenceEquals(this.ip, null))
		{
		  this.ip = "";
		}
		string str1 = "http://api.wipmania.com/" + this.ip + "?" + "in.gr";
		string str2 = HTTPUtil.getURL(str1, null, null);
		if (!this.ip.Equals(""))
		{
		  this.countryCode = str2;
		}
		else
		{
		  this.countryCode = str2.Split("<br>", true)[1];
		}
		if (string.ReferenceEquals(this.countryCode, null) || this.countryCode.Equals("XX") || this.countryCode.Equals(""))
		{
		  throw new Exception();
		}
	  }

	  public static double[] EuropeGeoPosition
	  {
		  get
		  {
			  return new double[] {52.976181D, 7.85784D};
		  }
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static double[] getGeoPosition(String paramString) throws Exception
	  public static double[] getGeoPosition(string paramString)
	  {
		  return EuropeGeoPosition;
	  }

	  public static string getCountry(string paramString)
	  {
		string str = (string)s_cacheMap[paramString];
		if (string.ReferenceEquals(str, null))
		{
		  IPToCountryUtil iPToCountryUtil = new IPToCountryUtil(paramString);
		  str = iPToCountryUtil.countryCode;
		  s_cacheMap[paramString] = str;
		}
		if (s_cacheMap.Count >= 500)
		{
		  s_cacheMap.Clear();
		}
		return str;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\IPToCountryUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}