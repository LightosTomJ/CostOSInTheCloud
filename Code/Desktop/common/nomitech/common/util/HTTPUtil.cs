using System;
using System.IO;

namespace Desktop.common.nomitech.common.util
{
	using BASE64Encoder = sun.misc.BASE64Encoder;

	public class HTTPUtil
	{
	  public static string encode(string paramString)
	  {
		BASE64Encoder bASE64Encoder = new BASE64Encoder();
		return bASE64Encoder.encode(paramString.GetBytes());
	  }

	  public static string getURL(string paramString1, string paramString2, string paramString3)
	  {
		  return getURL(paramString1, paramString2, paramString3, 5000, 30000);
	  }

	  public static string getURL(string paramString1, string paramString2, string paramString3, int paramInt1, int paramInt2)
	  {
		string str = "";
		try
		{
		  URL uRL = new URL(paramString1);
		  try
		  {
			URLConnection uRLConnection = uRL.openConnection();
			uRLConnection.ConnectTimeout = paramInt1;
			uRLConnection.ReadTimeout = paramInt2;
			uRLConnection.setRequestProperty("User-agent", "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.9) Gecko/20071025 Firefox/2.0.0.9");
			if (!string.ReferenceEquals(paramString2, null))
			{
			  uRLConnection.setRequestProperty("Authorization", "Basic " + encode(paramString2 + ":" + paramString3));
			}
			Stream inputStream = uRLConnection.InputStream;
			StreamReader bufferedReader = new StreamReader(inputStream);
			string str1;
			while (!string.ReferenceEquals((str1 = bufferedReader.ReadLine()), null))
			{
			  str = str + str1;
			}
			bufferedReader.Close();
			inputStream.Close();
		  }
		  catch (Exception exception)
		  {
			Console.WriteLine(exception.ToString());
			Console.Write(exception.StackTrace);
			return "";
		  }
		}
		catch (MalformedURLException)
		{
		  return paramString1 + " is not a parseable URL";
		}
		return str;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.util.Properties getPropertiesURL(String paramString1, String paramString2, String paramString3) throws Exception
	  public static Properties getPropertiesURL(string paramString1, string paramString2, string paramString3)
	  {
		Properties properties = new Properties();
		URL uRL = new URL(paramString1);
		URLConnection uRLConnection = uRL.openConnection();
		uRLConnection.ConnectTimeout = 5000;
		uRLConnection.ReadTimeout = 5000;
		uRLConnection.setRequestProperty("User-agent", "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.9) Gecko/20071025 Firefox/2.0.0.9");
		if (!string.ReferenceEquals(paramString2, null))
		{
		  uRLConnection.setRequestProperty("Authorization", "Basic " + encode(paramString2 + ":" + paramString3));
		}
		Stream inputStream = uRLConnection.InputStream;
		properties.load(inputStream);
		inputStream.Close();
		return properties;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.io.InputStream getInputStreamFromURL(String paramString1, String paramString2, String paramString3) throws Exception
	  public static Stream getInputStreamFromURL(string paramString1, string paramString2, string paramString3)
	  {
		URL uRL = new URL(paramString1);
		URLConnection uRLConnection = uRL.openConnection();
		uRLConnection.ConnectTimeout = 4000;
		uRLConnection.ReadTimeout = 30000;
		uRLConnection.setRequestProperty("User-agent", "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.9) Gecko/20071025 Firefox/2.0.0.9");
		if (!string.ReferenceEquals(paramString2, null))
		{
		  uRLConnection.setRequestProperty("Authorization", "Basic " + encode(paramString2 + ":" + paramString3));
		}
		return uRLConnection.InputStream;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.net.URLConnection getURLConnection(String paramString1, String paramString2, String paramString3) throws Exception
	  public static URLConnection getURLConnection(string paramString1, string paramString2, string paramString3)
	  {
		URL uRL = new URL(paramString1);
		URLConnection uRLConnection = uRL.openConnection();
		uRLConnection.ConnectTimeout = 4000;
		uRLConnection.ReadTimeout = 30000;
		uRLConnection.setRequestProperty("User-agent", "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.9) Gecko/20071025 Firefox/2.0.0.9");
		if (!string.ReferenceEquals(paramString2, null))
		{
		  uRLConnection.setRequestProperty("Authorization", "Basic " + encode(paramString2 + ":" + paramString3));
		}
		return uRLConnection;
	  }

	  public static string downloadTempFile(string paramString1, string paramString2, string paramString3)
	  {
		File file = File.createTempFile("down", "tmp");
		file.deleteOnExit();
		FileStream fileOutputStream = new FileStream(file, FileMode.Create, FileAccess.Write);
		Stream inputStream = getInputStreamFromURL(paramString1, paramString2, paramString3);
		sbyte[] arrayOfByte = new sbyte[4096];
		int i;
		while ((i = inputStream.Read(arrayOfByte, 0, arrayOfByte.Length)) != -1)
		{
		  fileOutputStream.Write(arrayOfByte, 0, i);
		}
		fileOutputStream.Flush();
		fileOutputStream.Close();
		return file.AbsolutePath;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\HTTPUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}