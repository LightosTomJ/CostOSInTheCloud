namespace Desktop.common.nomitech.common.util
{
	public class GroupCodeExtractor
	{
	  private const string DOT = ".";

	  private const string NUMERIC4_GC_STYLE = "numeric";

	  private const string MASTERFORMAT_GC_STYLE = "masterformat";

	  private const string NUMERIC5_GC_STYLE = "numeric5";

	  private const string NUMERIC6_GC_STYLE = "numeric6";

	  private const string DOTTED_GC_STYLE = "dotted";

	  private const string RICHARDSON_GC_STYLE = "richardson";

	  public static string[] extractCodeLevels(string paramString1, string paramString2)
	  {
		bool bool1 = false;
		bool bool2 = false;
		bool bool3 = false;
		bool bool4 = false;
		if (paramString2.Equals("richardson"))
		{
		  bool1 = true;
		}
		if (paramString2.Equals("numeric5"))
		{
		  bool2 = true;
		}
		if (paramString2.Equals("numeric6"))
		{
		  bool3 = true;
		}
		if (paramString2.Equals("dotted"))
		{
		  bool4 = true;
		}
		string str1 = null;
		string str2 = null;
		string str3 = null;
		string str4 = null;
		string str5 = null;
		string str6 = null;
		string str7 = null;
		string str8 = null;
		string str9 = null;
		if (paramString1.Length < 4 && !bool4)
		{
		  if (paramString1.Length >= 1)
		  {
			str1 = "" + paramString1[0];
		  }
		  if (paramString1.Length >= 2)
		  {
			str2 = "" + paramString1[0] + paramString1[1];
		  }
		  if (paramString1.Length >= 3)
		  {
			str3 = "" + paramString1[0] + paramString1[1] + paramString1[2];
		  }
		  if (paramString1.Length >= 4)
		  {
			str4 = "" + paramString1[0] + paramString1[1] + paramString1[2] + paramString1[3];
		  }
		  if (paramString1.Length >= 5)
		  {
			str5 = paramString1;
		  }
		  if (paramString1.Length >= 6)
		  {
			str6 = paramString1;
		  }
		  if (paramString1.Length >= 7)
		  {
			str7 = paramString1;
		  }
		  if (paramString1.Length >= 8)
		  {
			str8 = paramString1;
		  }
		  if (paramString1.Length >= 9)
		  {
			str9 = paramString1;
		  }
		}
		else if (bool1)
		{
		  str1 = paramString1.Substring(0, 3) + "000000000";
		  str2 = paramString1.Substring(0, 6) + "000000";
		  str3 = paramString1;
		}
		else if (bool2)
		{
		  str1 = paramString1.Substring(0, 2) + "000000";
		  str2 = paramString1.Substring(0, 4) + "0000";
		  str3 = paramString1.Substring(0, 6) + "00";
		  str4 = paramString1;
		}
		else if (bool3)
		{
		  str1 = paramString1.Substring(0, 2) + "00000000";
		  str2 = paramString1.Substring(0, 4) + "000000";
		  str3 = paramString1.Substring(0, 6) + "0000";
		  str4 = paramString1.Substring(0, 8) + "00";
		  str5 = paramString1;
		}
		else if (bool4 && paramString1.Length > 0)
		{
		  string[] arrayOfString = paramString1.Split("\\.", 9);
		  if (arrayOfString.Length == 1)
		  {
			str1 = paramString1;
		  }
		  else if (arrayOfString.Length == 2)
		  {
			str1 = arrayOfString[0];
			str2 = paramString1;
		  }
		  else if (arrayOfString.Length == 3)
		  {
			str1 = arrayOfString[0];
			str2 = str1 + "." + arrayOfString[1];
			str3 = paramString1;
		  }
		  else if (arrayOfString.Length == 4)
		  {
			str1 = arrayOfString[0];
			str2 = str1 + "." + arrayOfString[1];
			str3 = str2 + "." + arrayOfString[2];
			str4 = paramString1;
		  }
		  else if (arrayOfString.Length == 5)
		  {
			str1 = arrayOfString[0];
			str2 = str1 + "." + arrayOfString[1];
			str3 = str2 + "." + arrayOfString[2];
			str4 = str3 + "." + arrayOfString[3];
			str5 = paramString1;
		  }
		  else if (arrayOfString.Length == 6)
		  {
			str1 = arrayOfString[0];
			str2 = str1 + "." + arrayOfString[1];
			str3 = str2 + "." + arrayOfString[2];
			str4 = str3 + "." + arrayOfString[3];
			str5 = str4 + "." + arrayOfString[4];
			str6 = paramString1;
		  }
		  else if (arrayOfString.Length == 7)
		  {
			str1 = arrayOfString[0];
			str2 = str1 + "." + arrayOfString[1];
			str3 = str2 + "." + arrayOfString[2];
			str4 = str3 + "." + arrayOfString[3];
			str5 = str4 + "." + arrayOfString[4];
			str6 = str5 + "." + arrayOfString[5];
			str7 = paramString1;
		  }
		  else if (arrayOfString.Length == 8)
		  {
			str1 = arrayOfString[0];
			str2 = str1 + "." + arrayOfString[1];
			str3 = str2 + "." + arrayOfString[2];
			str4 = str3 + "." + arrayOfString[3];
			str5 = str4 + "." + arrayOfString[4];
			str6 = str5 + "." + arrayOfString[5];
			str7 = str6 + "." + arrayOfString[6];
			str8 = paramString1;
		  }
		  else if (arrayOfString.Length >= 9)
		  {
			str1 = arrayOfString[0];
			str2 = str1 + "." + arrayOfString[1];
			str3 = str2 + "." + arrayOfString[2];
			str4 = str3 + "." + arrayOfString[3];
			str5 = str4 + "." + arrayOfString[4];
			str6 = str5 + "." + arrayOfString[5];
			str7 = str6 + "." + arrayOfString[6];
			str8 = str7 + "." + arrayOfString[7];
			str9 = paramString1;
		  }
		}
		else
		{
		  str1 = paramString1.Substring(0, 2) + "00";
		  str2 = paramString1.Substring(0, 3) + "0";
		  str3 = paramString1;
		}
		return new string[] {str1, str2, str3, str4, str5, str6, str7, str8, str9};
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\GroupCodeExtractor.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}