using System;

namespace Desktop.common.nomitech.common.util
{
	public sealed class Classes
	{
	  public const string PACKAGE_SEPARATOR = ".";

	  public const char PACKAGE_SEPARATOR_CHAR = '.';

	  public const string DEFAULT_PACKAGE_NAME = "<default>";

	  public static string stripPackageName(string paramString)
	  {
		int i = paramString.LastIndexOf(".", StringComparison.Ordinal);
		return (i != -1) ? paramString.Substring(i + 1, paramString.Length - (i + 1)) : paramString;
	  }

	  public static string stripPackageName(Type paramClass)
	  {
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		  return stripPackageName(paramClass.FullName);
	  }

	  public static string getPackageName(string paramString)
	  {
		if (paramString.Length == 0)
		{
		  throw new System.ArgumentException("empty string");
		}
		int i = paramString.LastIndexOf(".", StringComparison.Ordinal);
		return (i != -1) ? paramString.Substring(0, i) : "";
	  }

	  public static string getPackageName(Type paramClass)
	  {
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		  return getPackageName(paramClass.FullName);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\Classes.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}