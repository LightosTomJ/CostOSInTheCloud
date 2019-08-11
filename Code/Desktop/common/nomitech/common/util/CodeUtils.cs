using System;

namespace Desktop.common.nomitech.common.util
{
	public class CodeUtils
	{
	  private static readonly string[] ALPHABET = new string[] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

	  private const string regex = "\\.";

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static int getNextNumberFromCode(String paramString) throws Exception
	  public static int getNextNumberFromCode(string paramString)
	  {
		  return (Convert.ToInt32(paramString)) + 1;
	  }

	  public static string getNextCodeForCode(string paramString1, string paramString2)
	  {
		if (string.ReferenceEquals(paramString2, null) || paramString2.Length == 0 || paramString2.StartsWith(" ", StringComparison.Ordinal))
		{
		  return paramString1.Equals("dotted") ? "10" : (paramString1.Equals("numeric5") ? "01000000" : (paramString1.Equals("numeric6") ? "0100000000" : (paramString1.Equals("richardson") ? "010000000000" : "10")));
		}
		string str = paramString2;
		if (paramString2.IndexOf(" - ", StringComparison.Ordinal) != -1)
		{
		  paramString2 = paramString2.Substring(0, paramString2.IndexOf(" - ", StringComparison.Ordinal));
		}
		if (paramString1.Equals("dotted"))
		{
		  string[] arrayOfString = paramString2.Split("\\.", 9);
		  string str1 = arrayOfString[arrayOfString.Length - 1];
		  try
		  {
			str1 = "" + getNextNumberFromCode(str1);
			str = "";
			for (sbyte b = 0; b < arrayOfString.Length - 1; b++)
			{
			  str = str + arrayOfString[b] + ".";
			}
			str = str + str1;
		  }
		  catch (Exception)
		  {
			try
			{
			  str1 = getNextStringFromCode(str1);
			  str = "";
			  for (sbyte b = 0; b < arrayOfString.Length - 1; b++)
			  {
				str = str + arrayOfString[b] + ".";
			  }
			  str = str + str1;
			}
			catch (Exception)
			{
			  str = paramString2;
			}
		  }
		}
		else if (paramString1.Equals("numeric5") && paramString2.Length == 8)
		{
		  if (paramString2.EndsWith("000000", StringComparison.Ordinal))
		  {
			str = getNextNumberFromCode2Digits(paramString2.Substring(0, 2)) + "000000";
		  }
		  else if (paramString2.EndsWith("0000", StringComparison.Ordinal))
		  {
			str = paramString2.Substring(0, 2) + getNextNumberFromCode2Digits(paramString2.Substring(2, 2)) + "0000";
		  }
		  else if (paramString2.EndsWith("00", StringComparison.Ordinal))
		  {
			str = paramString2.Substring(0, 4) + getNextNumberFromCode2Digits(paramString2.Substring(4, 2)) + "00";
		  }
		  else
		  {
			str = paramString2.Substring(0, 6) + getNextNumberFromCode2Digits(paramString2.Substring(6, 2));
		  }
		}
		else if (paramString1.Equals("numeric6") && paramString2.Length == 10)
		{
		  if (paramString2.EndsWith("00000000", StringComparison.Ordinal))
		  {
			str = getNextNumberFromCode2Digits(paramString2.Substring(0, 2)) + "00000000";
		  }
		  else if (paramString2.EndsWith("000000", StringComparison.Ordinal))
		  {
			str = paramString2.Substring(0, 2) + getNextNumberFromCode2Digits(paramString2.Substring(2, 2)) + "000000";
		  }
		  else if (paramString2.EndsWith("0000", StringComparison.Ordinal))
		  {
			str = paramString2.Substring(0, 4) + getNextNumberFromCode2Digits(paramString2.Substring(4, 2)) + "0000";
		  }
		  else if (paramString2.EndsWith("00", StringComparison.Ordinal))
		  {
			str = paramString2.Substring(0, 6) + getNextNumberFromCode2Digits(paramString2.Substring(6, 2)) + "00";
		  }
		  else
		  {
			str = paramString2.Substring(0, 8) + getNextNumberFromCode2Digits(paramString2.Substring(8, 2));
		  }
		}
		return str;
	  }

	  public static string getParentCodeOfCode(string paramString1, string paramString2)
	  {
		if (string.ReferenceEquals(paramString2, null) || paramString2.Length == 0 || paramString2.StartsWith(" ", StringComparison.Ordinal))
		{
		  return null;
		}
		string str = null;
		if (paramString1.Equals("dotted"))
		{
		  string[] arrayOfString = paramString2.Split("\\.", 10);
		  if (arrayOfString.Length == 1)
		  {
			return null;
		  }
		  str = "";
		  for (sbyte b = 0; b < arrayOfString.Length - 1; b++)
		  {
			if (!str.Equals(""))
			{
			  str = str + ".";
			}
			str = str + arrayOfString[b];
		  }
		}
		else if (paramString1.Equals("numeric5") && paramString2.Length == 8)
		{
		  if (paramString2.EndsWith("000000", StringComparison.Ordinal))
		  {
			str = null;
		  }
		  else if (paramString2.EndsWith("0000", StringComparison.Ordinal))
		  {
			str = paramString2.Substring(0, 2) + "000000";
		  }
		  else if (paramString2.EndsWith("00", StringComparison.Ordinal))
		  {
			str = paramString2.Substring(0, 4) + "0000";
		  }
		  else
		  {
			str = paramString2.Substring(0, 6) + "00";
		  }
		}
		else if (paramString1.Equals("numeric6") && paramString2.Length == 10)
		{
		  if (paramString2.EndsWith("00000000", StringComparison.Ordinal))
		  {
			str = null;
		  }
		  else if (paramString2.EndsWith("000000", StringComparison.Ordinal))
		  {
			str = paramString2.Substring(0, 2) + "00000000";
		  }
		  else if (paramString2.EndsWith("0000", StringComparison.Ordinal))
		  {
			str = paramString2.Substring(0, 4) + "000000";
		  }
		  else if (paramString2.EndsWith("00", StringComparison.Ordinal))
		  {
			str = paramString2.Substring(0, 6) + "0000";
		  }
		  else
		  {
			str = paramString2.Substring(0, 8) + "00";
		  }
		}
		else if (paramString1.Equals("richardson"))
		{
		  if (paramString2.EndsWith("000000000", StringComparison.Ordinal))
		  {
			str = null;
		  }
		  else if (paramString2.EndsWith("000000", StringComparison.Ordinal))
		  {
			str = paramString2.Substring(0, 3) + "000000000";
		  }
		  else
		  {
			str = paramString2.Substring(0, 6) + "000000";
		  }
		}
		return str;
	  }

	  public static string getNextNumberFromCode2Digits(string paramString)
	  {
		string str = "00";
		try
		{
		  str = "" + ((Convert.ToInt32(paramString)) + 1);
		}
		catch (Exception)
		{
		}
		if (str.Length >= 3)
		{
		  str = "00";
		}
		else if (str.Length == 1)
		{
		  str = "0" + str;
		}
		return str;
	  }

	  public static bool checkCodeIsValid(string paramString1, string paramString2)
	  {
		if (string.ReferenceEquals(paramString2, null) || paramString2.Length == 0 || paramString2.StartsWith(" ", StringComparison.Ordinal))
		{
		  return false;
		}
		if (paramString1.Equals("dotted"))
		{
		  return true;
		}
		if (paramString1.Equals("numeric6"))
		{
		  if (paramString2.Length == 10 && StringUtils.isInteger(paramString2))
		  {
			return true;
		  }
		}
		else if (paramString1.Equals("numeric5"))
		{
		  if (paramString2.Length == 8 && StringUtils.isInteger(paramString2))
		  {
			return true;
		  }
		}
		else if (paramString1.Equals("numeric"))
		{
		  if (paramString2.Length == 6 && StringUtils.isInteger(paramString2))
		  {
			return true;
		  }
		}
		else if (paramString1.Equals("richardson") && paramString2.Length == 12 && StringUtils.isInteger(paramString2))
		{
		  return true;
		}
		return false;
	  }

	  private static string getNextStringFromCode(string paramString)
	  {
		if (paramString.Length == 0)
		{
		  return paramString;
		}
		int i = paramString.IndexOf(" - ", StringComparison.Ordinal);
		if (i != -1)
		{
		  paramString = paramString.Substring(0, i);
		}
		string str1 = paramString.Substring(0, paramString.Length - 1);
		string str2 = StringHelper.SubstringSpecial(paramString, paramString.Length - 1, paramString.Length);
		bool @bool = char.IsLower(str2[0]);
		bool bool1 = false;
		for (sbyte b = 0; b < ALPHABET.Length; b++)
		{
		  if (@bool)
		  {
			str2 = str2.ToUpper();
		  }
		  if (str2.Equals(ALPHABET[b]))
		  {
			bool1 = true;
			if (b == ALPHABET.Length - 1)
			{
			  str2 = str2 + ALPHABET[0];
			  break;
			}
			str2 = ALPHABET[b + true];
			break;
		  }
		}
		if (!bool1)
		{
		  return paramString;
		}
		if (@bool)
		{
		  str2 = str2.ToLower();
		}
		return str1 + str2;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\CodeUtils.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}