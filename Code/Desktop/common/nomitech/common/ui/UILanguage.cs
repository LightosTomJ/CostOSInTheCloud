using System;
using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.ui
{
	using DBFieldFormatUtil = nomitech.common.util.DBFieldFormatUtil;
	using NamingUtil = nomitech.common.util.NamingUtil;
	using StringUtils = nomitech.common.util.StringUtils;

	public class UILanguage
	{
	  private static UILanguage s_uiLanguage = null;

	  private const string s_RESOURCE_BUNDLE = "lang";

	  private Properties o_rb = new Properties();

	  private KeyComparator o_keyComparator = null;

	  private Locale locale;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private UILanguage(boolean paramBoolean) throws Exception
	  private UILanguage(bool paramBoolean)
	  {
		if (paramBoolean)
		{
		  return;
		}
		Stream inputStream = null;
		try
		{
		  inputStream = ClassLoader.getSystemResource("lang.properties").openStream();
		}
		catch (Exception)
		{
		  File file = new File(NamingUtil.Instance.getSarPath("lang.properties"));
		  inputStream = new FileStream(file, FileMode.Open, FileAccess.Read);
		}
		this.o_rb.load(inputStream);
		inputStream.Close();
		this.o_keyComparator = new KeyComparator(this, null);
		string str1 = getString("enum.fueltype.diesel");
		string str2 = getString("enum.fueltype.petrol");
		string str3 = getString("enum.fueltype.electric");
		string str4 = getString("enum.fueltype.other");
		BothDBPreferences.Instance.setFuelPriceKeys(str1, str2, str4, str3);
		DBFieldFormatUtil.Locale = getString("language.iso639.1");
		this.locale = new Locale(getString("language.iso639.1"));
	  }

	  public static void applyFlavorFromPropertiesFile(string paramString)
	  {
		try
		{
		  Stream inputStream = ClassLoader.getSystemResource(paramString + ".properties").openStream();
		  Properties properties = new Properties();
		  properties.load(inputStream);
		  foreach (string str in properties.Keys)
		  {
			(Instance).o_rb.setProperty(str, properties.getProperty(str));
		  }
		  inputStream.Close();
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
	  }

	  private string getString(string paramString)
	  {
		if (this.o_rb == null)
		{
		  return "";
		}
		try
		{
		  return this.o_rb.getProperty(paramString);
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  return paramString;
		}
	  }

	  public static Locale Locale
	  {
		  get
		  {
			  return (Instance).locale;
		  }
	  }

	  private string getKeyForValueInPath(string paramString1, string paramString2)
	  {
		System.Collections.IEnumerator enumeration = this.o_rb.keys();
		string str = null;
		while (enumeration.MoveNext())
		{
		  string str1 = (string)enumeration.Current;
		  if (getString(str1).Equals(paramString1) && str1.StartsWith(paramString2, StringComparison.Ordinal))
		  {
			str = str1;
			break;
		  }
		}
		return str;
	  }

	  private static UILanguage Instance
	  {
		  get
		  {
			if (s_uiLanguage == null)
			{
			  try
			  {
				s_uiLanguage = new UILanguage(false);
			  }
			  catch (Exception)
			  {
				try
				{
				  s_uiLanguage = new UILanguage(true);
				}
				catch (Exception exception1)
				{
				  Console.WriteLine(exception1.ToString());
				  Console.Write(exception1.StackTrace);
				}
			  }
			}
			return s_uiLanguage;
		  }
	  }

	  private IList<string> getKeysInPath(string paramString)
	  {
		System.Collections.IEnumerator enumeration = this.o_rb.keys();
		List<object> vector = new List<object>(10);
		while (enumeration.MoveNext())
		{
		  string str = (string)enumeration.Current;
		  if (str.StartsWith(paramString, StringComparison.Ordinal))
		  {
			vector.Add(str);
		  }
		}
		return vector;
	  }

	  public static IList<string> keysInPath(string paramString)
	  {
		  return Instance.getKeysInPath(paramString);
	  }

	  public virtual System.Collections.IList getValueListInPath(string paramString)
	  {
		System.Collections.IEnumerator enumeration = this.o_rb.keys();
		List<object> vector = new List<object>(10);
		while (enumeration.MoveNext())
		{
		  string str = (string)enumeration.Current;
		  if (str.StartsWith(paramString, StringComparison.Ordinal))
		  {
			vector.Add(getString(str));
		  }
		}
		object[] arrayOfObject = vector.ToArray();
		Arrays.sort(arrayOfObject, this.o_keyComparator);
		vector = new List<object>(arrayOfObject.Length);
		for (sbyte b = 0; b < arrayOfObject.Length; b++)
		{
		  vector.Add(arrayOfObject[b]);
		}
		return vector;
	  }

	  public static System.Collections.IList valueListInPath(string paramString)
	  {
		  return Instance.getValueListInPath(paramString);
	  }

	  public static string get(string paramString)
	  {
		string str = Instance.getString(paramString);
		return (string.ReferenceEquals(str, null)) ? paramString : str;
	  }

	  public static void put(string paramString1, string paramString2)
	  {
		  (Instance).o_rb.put(paramString1, paramString2);
	  }

	  public static void remove(string paramString)
	  {
		  (Instance).o_rb.remove(paramString);
	  }

	  public static string get(string paramString1, string paramString2)
	  {
		string str = Instance.getString(paramString1);
		if (string.ReferenceEquals(str, null))
		{
		  return paramString1;
		}
		try
		{
		  str = StringUtils.replace(str, "{1}", paramString2);
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		}
		return str;
	  }

	  public static string keyForValueInPath(string paramString1, string paramString2)
	  {
		  return Instance.getKeyForValueInPath(paramString1, paramString2);
	  }

	  private class KeyComparator : System.Collections.IComparer
	  {
		  private readonly UILanguage outerInstance;

		internal KeyComparator(UILanguage outerInstance)
		{
			this.outerInstance = outerInstance;
		}

		public virtual int Compare(object param1Object1, object param1Object2)
		{
		  string str1 = (string)param1Object1;
		  string str2 = (string)param1Object2;
		  return str1.CompareTo(str2);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\ui\UILanguage.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}