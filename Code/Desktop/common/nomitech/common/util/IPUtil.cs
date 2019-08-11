using System;

namespace Desktop.common.nomitech.common.util
{

	public class IPUtil
	{
	  private static readonly Pattern IPv4RegexPattern = Pattern.compile("^(([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\.){3}([01]?\\d\\d?|2[0-4]\\d|25[0-5])$");

	  public static string PublicIPv4
	  {
		  get
		  {
			string str = null;
			try
			{
			  System.Collections.IEnumerator enumeration = NetworkInterface.NetworkInterfaces;
			  while (enumeration.MoveNext())
			  {
				NetworkInterface networkInterface = (NetworkInterface)enumeration.Current;
				System.Collections.IEnumerator enumeration1 = networkInterface.InetAddresses;
				while (enumeration1.MoveNext())
				{
				  InetAddress inetAddress = (InetAddress)enumeration1.Current;
				  string str1 = inetAddress.HostAddress;
				  if (!inetAddress.SiteLocalAddress && !inetAddress.LoopbackAddress && validate(str1))
				  {
					str = str1;
					continue;
				  }
				  Console.WriteLine("Address " + str1 + " not validated as public IPv4");
				}
			  }
			}
			catch (Exception exception)
			{
			  Console.WriteLine(exception.ToString());
			  Console.Write(exception.StackTrace);
			}
			return str;
		  }
	  }

	  public static bool validate(string paramString)
	  {
		  return IPv4RegexPattern.matcher(paramString).matches();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\IPUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}