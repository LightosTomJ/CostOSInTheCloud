using System;
using System.Text;

namespace Desktop.common.nomitech.common.util
{

	public class DBFieldFormatUtil
	{
	  private static Locale s_defaultLanguage = new Locale("en");

	  private static DecimalFormat decimalFormat = null;

	  private static DecimalFormat currencyDecimalFormat = null;

	  private const string ISO_EXPANDED_DATE_TIME_FORMAT = "d-MMM-yyyy  HH:mm:ss";

	  private static SimpleDateFormat DF = new SimpleDateFormat("d-MMM-yyyy  HH:mm:ss", new Locale("en"));

	  private static SimpleDateFormat DOF = new SimpleDateFormat("d-MMM-yyyy", new Locale("en"));

	  private static readonly DecimalFormat doubleFormat = new DecimalFormat("0");

	  private static int previousScale;

	  public static string Locale
	  {
		  set
		  {
			s_defaultLanguage = new Locale(value);
			DF = new SimpleDateFormat("d-MMM-yyyy  HH:mm:ss", s_defaultLanguage);
			DF.TimeZone = TimeZone.Default;
			DOF = new SimpleDateFormat("d-MMM-yyyy", s_defaultLanguage);
			DF.TimeZone = TimeZone.Default;
		  }
	  }

	  public static object formatObject(object paramObject)
	  {
		  return (paramObject is decimal) ? formatRate((decimal)paramObject).ToString() : paramObject;
	  }

	  public static object scaleAndFormatObject(object paramObject)
	  {
		  return (paramObject is decimal) ? scaleAndFormatRate((decimal)paramObject).ToString() : ((paramObject is Timestamp) ? formatTimeStamp((DateTime)paramObject) : paramObject);
	  }

	  public static DecimalFormat createLocalizedDecimalFormat(string paramString)
	  {
		DecimalFormat decimalFormat1 = (DecimalFormat)DecimalFormat.getInstance(s_defaultLanguage).clone();
		decimalFormat1.applyPattern(paramString);
		return decimalFormat1;
	  }

	  public static DecimalFormat createLocalizedDecimalFormat()
	  {
		DecimalFormat decimalFormat1 = (DecimalFormat)DecimalFormat.getInstance(s_defaultLanguage).clone();
		decimalFormat1.applyPattern(CurrentPattern);
		return decimalFormat1;
	  }

	  public static object scaleAndFormatRate(decimal paramBigDecimal)
	  {
		decimal bigDecimal = paramBigDecimal.setScale(BothDBPreferences.Instance.BigDecimalScale, BothDBPreferences.Instance.BigDecimalRoundingMode);
		return DecimalFormat.format(bigDecimal);
	  }

	  public static object scaleAndFormatRate(decimal paramBigDecimal, DecimalFormat paramDecimalFormat)
	  {
		decimal bigDecimal = paramBigDecimal.setScale(BothDBPreferences.Instance.BigDecimalScale, BothDBPreferences.Instance.BigDecimalRoundingMode);
		return DecimalFormat.format(bigDecimal);
	  }

	  public static object formatRate(decimal paramBigDecimal)
	  {
		null = DecimalFormat.format(paramBigDecimal);
		int i = paramBigDecimal.ToString().IndexOf(".", StringComparison.Ordinal);
		int j = null.IndexOf(DecimalFormat.DecimalFormatSymbols.DecimalSeparator);
		if (i != -1 && j != -1)
		{
		  string str1 = null.substring(0, j);
		  string str2 = paramBigDecimal.ToString().Substring(i + 1, (paramBigDecimal.ToString().Length) - (i + 1));
		  null = str1 + "" + DecimalFormat.DecimalFormatSymbols.DecimalSeparator + str2;
		}
		return removeZerosFromEnd(null);
	  }

	  public static bool isFormatedRate(object paramObject)
	  {
		try
		{
		  formatedRateToBigDecimal(paramObject.ToString());
		}
		catch (Exception)
		{
		  return false;
		}
		return true;
	  }

	  public static decimal formatedRateToBigDecimal(string paramString)
	  {
		paramString = removeZerosFromEnd(paramString);
		if (!s_defaultLanguage.Language.Equals("en"))
		{
		  paramString = findAndReplace(paramString, ",", "#");
		  paramString = findAndReplace(paramString, ".", "");
		  paramString = findAndReplace(paramString, "#", ".");
		  return new decimal(paramString);
		}
		return new decimal(findAndReplace(paramString, ",", ""));
	  }

	  public static decimal formatedCurrencyToBigDecimal(string paramString)
	  {
		string str = BothDBPreferences.Instance.CurrencySymbol;
		paramString = findAndReplace(paramString, str, "");
		paramString = findAndReplace(paramString, " ", "");
		paramString = removeZerosFromEnd(paramString);
		if (!s_defaultLanguage.Language.Equals("en"))
		{
		  paramString = findAndReplace(paramString, ",", "#");
		  paramString = findAndReplace(paramString, ".", "");
		  paramString = findAndReplace(paramString, "#", ".");
		  return new decimal(paramString);
		}
		return new decimal(findAndReplace(paramString, ",", ""));
	  }

	  public static string formatDouble(double paramDouble)
	  {
		  return doubleFormat.format(paramDouble);
	  }

	  public static DecimalFormat DecimalFormat
	  {
		  get
		  {
			if (decimalFormat == null)
			{
			  decimalFormat = (DecimalFormat)NumberFormat.getNumberInstance(s_defaultLanguage).clone();
			  decimalFormat.applyPattern(CurrentPattern);
			  currencyDecimalFormat = (DecimalFormat)NumberFormat.getNumberInstance(s_defaultLanguage).clone();
			  currencyDecimalFormat.applyPattern(CurrentPattern + " ¤");
			}
			else if (hasPatternChanged())
			{
			  decimalFormat.applyPattern(CurrentPattern);
			  currencyDecimalFormat.applyPattern(CurrentPattern + " ¤");
			}
			return decimalFormat;
		  }
	  }

	  public static object scaleAndFormatCurrency(decimal paramBigDecimal)
	  {
		string str = BothDBPreferences.Instance.CurrencySymbol;
		decimal bigDecimal = paramBigDecimal.setScale(BothDBPreferences.Instance.BigDecimalScale, BothDBPreferences.Instance.BigDecimalRoundingMode);
		return (str.Equals("TRls") || str.Equals("MRls")) ? DecimalFormat.format(bigDecimal).concat(" " + str) : (str + " " + DecimalFormat.format(bigDecimal));
	  }

	  public static object scaleAndFormatCurrency(decimal paramBigDecimal, string paramString)
	  {
		decimal bigDecimal = paramBigDecimal.setScale(BothDBPreferences.Instance.BigDecimalScale, BothDBPreferences.Instance.BigDecimalRoundingMode);
		if (string.ReferenceEquals(paramString, null))
		{
		  paramString = "";
		}
		return (paramString.Equals("TRls") || paramString.Equals("MRls")) ? DecimalFormat.format(bigDecimal).concat(" " + paramString) : (paramString + " " + DecimalFormat.format(bigDecimal));
	  }

	  public static object formatCurrency(decimal paramBigDecimal)
	  {
		string str = BothDBPreferences.Instance.CurrencySymbol;
		if (paramBigDecimal == null)
		{
		  return str;
		}
		null = DecimalFormat.format(paramBigDecimal);
		int i = paramBigDecimal.ToString().IndexOf(".", StringComparison.Ordinal);
		int j = null.IndexOf(DecimalFormat.DecimalFormatSymbols.DecimalSeparator);
		if (i != -1 && j != -1)
		{
		  string str1 = null.substring(0, j);
		  string str2 = paramBigDecimal.ToString().Substring(i + 1, (paramBigDecimal.ToString().Length) - (i + 1));
		  null = str1 + "" + DecimalFormat.DecimalFormatSymbols.DecimalSeparator + str2;
		}
		return str + " " + null;
	  }

	  public static object formatCurrency(decimal paramBigDecimal, string paramString)
	  {
		string str = DecimalFormat.format(paramBigDecimal);
		int i = paramBigDecimal.ToString().IndexOf(".", StringComparison.Ordinal);
		int j = str.IndexOf(DecimalFormat.DecimalFormatSymbols.DecimalSeparator);
		if (i != -1 && j != -1)
		{
		  string str1 = str.Substring(0, j);
		  string str2 = paramBigDecimal.ToString().Substring(i + 1, (paramBigDecimal.ToString().Length) - (i + 1));
		  str = str1 + "" + DecimalFormat.DecimalFormatSymbols.DecimalSeparator + str2;
		}
		if (paramString.Equals("€"))
		{
		  str = str + " " + paramString;
		}
		else
		{
		  str = paramString + " " + str;
		}
		return str;
	  }

	  public static DecimalFormat getCurrencyDecimalFormat(bool paramBoolean)
	  {
		if (currencyDecimalFormat == null || paramBoolean == true)
		{
		  currencyDecimalFormat = (DecimalFormat)NumberFormat.getNumberInstance(s_defaultLanguage).clone();
		  currencyDecimalFormat.applyPattern(CurrentPattern + " ¤");
		  decimalFormat = (DecimalFormat)NumberFormat.getNumberInstance(s_defaultLanguage).clone();
		  decimalFormat.applyPattern(CurrentPattern);
		}
		else if (hasPatternChanged())
		{
		  currencyDecimalFormat.applyPattern(CurrentPattern + " ¤");
		  decimalFormat.applyPattern(CurrentPattern);
		}
		return currencyDecimalFormat;
	  }

	  public static Timestamp convertDateToTimestamp(DateTime paramDate)
	  {
		  return (paramDate is Timestamp) ? (Timestamp)paramDate : new Timestamp(paramDate.Ticks);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.sql.Timestamp parseTimeStamp(String paramString) throws Exception
	  public static Timestamp parseTimeStamp(string paramString)
	  {
		try
		{
		  return convertDateToTimestamp(DateAndTimeFormatter.parse(paramString));
		}
		catch (ParseException parseException)
		{
		  throw new Exception(parseException);
		}
	  }

	  public static string formatDate(DateTime paramDate)
	  {
		  return DOF.format(paramDate);
	  }

	  public static string formatTimeStamp(DateTime paramDate)
	  {
		  return DateAndTimeFormatter.format(paramDate);
	  }

	  public static SimpleDateFormat DateAndTimeFormatter
	  {
		  get
		  {
			  return DF;
		  }
	  }

	  public static SimpleDateFormat DateFormatter
	  {
		  get
		  {
			  return DOF;
		  }
	  }

	  private static bool hasPatternChanged()
	  {
		  return !(previousScale == BothDBPreferences.Instance.BigDecimalScale);
	  }

	  public static string CurrentPattern
	  {
		  get
		  {
			int i = BothDBPreferences.Instance.BigDecimalScale;
			string str = "";
			for (sbyte b = 0; b < i; b++)
			{
			  str = str + "0";
			}
			previousScale = i;
			return "##,###,##0." + str + "##########";
		  }
	  }

	  public static string CurrentScaledPattern
	  {
		  get
		  {
			int i = BothDBPreferences.Instance.BigDecimalScale;
			string str = "";
			for (sbyte b = 0; b < i; b++)
			{
			  str = str + "0";
			}
			previousScale = i;
			return "##,###,##0." + str;
		  }
	  }

	  private static string removeZerosFromEnd(string paramString)
	  {
		string str1 = paramString;
		if (paramString[paramString.Length - 1] != '0')
		{
		  return str1;
		}
		char c = DecimalFormat.DecimalFormatSymbols.DecimalSeparator;
		int i = paramString.IndexOf(c);
		if (i == -1)
		{
		  return str1;
		}
		str1 = paramString.Substring(0, i);
		paramString = paramString.Substring(i + 1, paramString.Length - (i + 1));
		int j = paramString.Length;
		for (int k = paramString.Length - 1; k >= 0 && paramString[k] == '0'; k--)
		{
		  j--;
		}
		string str2 = paramString.Substring(0, j);
		if (str2.Length != 0)
		{
		  str1 = str1 + c + str2;
		}
		return str1;
	  }

	  private static string findAndReplace(string paramString1, string paramString2, string paramString3)
	  {
		if (string.ReferenceEquals(paramString1, null) || string.ReferenceEquals(paramString2, null) || string.ReferenceEquals(paramString3, null))
		{
		  throw new System.NullReferenceException("findAndReplace doesn't work on nulls.");
		}
		int i = paramString1.IndexOf(paramString2, StringComparison.Ordinal);
		if (i == -1)
		{
		  return paramString1;
		}
		int j = paramString2.Length;
		StringBuilder stringBuffer = new StringBuilder();
		while (i != -1)
		{
		  stringBuffer.Append(paramString1.Substring(0, i)).Append(paramString3);
		  paramString1 = paramString1.Substring(i + j);
		  i = paramString1.IndexOf(paramString2, StringComparison.Ordinal);
		}
		stringBuffer.Append(paramString1);
		return stringBuffer.ToString();
	  }

	  static DBFieldFormatUtil()
	  {
		doubleFormat.DecimalFormatSymbols = new DecimalFormatSymbols(Locale.ENGLISH);
		doubleFormat.MaximumFractionDigits = 340;
		previousScale = -1;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\DBFieldFormatUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}