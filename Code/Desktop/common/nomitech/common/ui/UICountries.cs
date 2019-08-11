using System;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.ui
{
	using NamingUtil = nomitech.common.util.NamingUtil;

	public class UICountries
	{
	  private static UICountries s_uiLanguage = null;

	  private const string s_RESOURCE_BUNDLE = "countries";

	  private ResourceBundle o_rb = null;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private UICountries() throws Exception
	  private UICountries()
	  {
		Stream inputStream = null;
		try
		{
		  inputStream = ClassLoader.getSystemResource("countries.properties").openStream();
		  if (inputStream == null)
		  {
			throw new Exception();
		  }
		}
		catch (Exception)
		{
		  File file = new File(NamingUtil.Instance.getSarPath("countries.properties"));
		  inputStream = new FileStream(file, FileMode.Open, FileAccess.Read);
		}
		this.o_rb = new PropertyResourceBundle(inputStream);
	  }

	  private string getString(string paramString)
	  {
		try
		{
		  return this.o_rb.getString(paramString);
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  return paramString;
		}
	  }

	  private string getKeyForValue(string paramString)
	  {
		System.Collections.IEnumerator enumeration = this.o_rb.Keys;
		string str = null;
		while (enumeration.MoveNext())
		{
		  string str1 = (string)enumeration.Current;
		  if (getString(str1).Equals(paramString))
		  {
			str = str1;
			break;
		  }
		}
		return str;
	  }

	  private bool getCountryCodeExists(string paramString)
	  {
		System.Collections.IEnumerator enumeration = this.o_rb.Keys;
		while (enumeration.MoveNext())
		{
		  if (enumeration.Current.Equals(paramString))
		  {
			return true;
		  }
		}
		return false;
	  }

	  private System.Collections.IList SortedValues
	  {
		  get
		  {
			System.Collections.IEnumerator enumeration = this.o_rb.Keys;
			List<object> vector = new List<object>(100);
			while (enumeration.MoveNext())
			{
			  vector.Add(getString(enumeration.Current.ToString()));
			}
			string[] arrayOfString = (string[])vector.ToArray(typeof(string));
			Arrays.sort(arrayOfString);
			vector.Clear();
			for (sbyte b = 0; b < arrayOfString.Length; b++)
			{
			  vector.Add(arrayOfString[b]);
			}
			return vector;
		  }
	  }

	  private static UICountries Instance
	  {
		  get
		  {
			if (s_uiLanguage == null)
			{
			  try
			  {
				s_uiLanguage = new UICountries();
			  }
			  catch (Exception exception)
			  {
				Console.WriteLine(exception.ToString());
				Console.Write(exception.StackTrace);
			  }
			}
			return s_uiLanguage;
		  }
	  }

	  public static string getCountryName(string paramString)
	  {
		string str = Instance.getString(paramString);
		return (string.ReferenceEquals(str, null)) ? paramString : str;
	  }

	  public static System.Collections.IList AllCountryNames
	  {
		  get
		  {
			  return Instance.SortedValues;
		  }
	  }

	  public static string getTwoLetterCodeForCountryName(string paramString)
	  {
		  return Instance.getKeyForValue(paramString.ToUpper());
	  }

	  public static bool countryCodeExists(string paramString)
	  {
		  return Instance.getCountryCodeExists(paramString);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\UICountries.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}