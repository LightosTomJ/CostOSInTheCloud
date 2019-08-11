using System;

namespace Desktop.common.nomitech.common.util
{
	public class GGDEUtil
	{
	  private static string GGDE_TIMOLOGIA_URL = "http://www.ggde.gr/ggde/el/analitika_timologia.jsp?cat=35";

	  private static string GGDE_GET_TIMOLOGIA_URL = "http://www.ggde.gr/ggde/el/analytika_printpage.jsp?cat=35";

	  public static string[] AvailableTimologia
	  {
		  get
		  {
			string[] arrayOfString = null;
			string str = HTTPUtil.getURL(GGDE_TIMOLOGIA_URL, null, null);
			str = StringUtils.textBetween(str, "<select name=\"work\">", "</select>");
			Console.WriteLine("RES IS " + str);
			return arrayOfString;
		  }
	  }

	  public static string rateForCode(string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		string str1 = GGDE_GET_TIMOLOGIA_URL + "&work=" + paramString2 + "&year=" + paramString3 + "&quarter1=" + paramString4 + "&code=" + paramString1 + "&allartha=0";
		string str2 = HTTPUtil.getURL(str1, null, null);
		str2 = StringUtils.textBetween(str2, "<td width=\"73\" align=\"right\" bgcolor=\"#99CCCC\" class=\"input\">", "&#8364;");
		return (str2.Length > 50) ? null : str2;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void main(String[] paramArrayOfString) throws Exception
	  public static void Main(string[] paramArrayOfString)
	  {
		  Console.WriteLine("and the code is: " + rateForCode(paramArrayOfString[0], "1", "2005", "01"));
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\GGDEUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}