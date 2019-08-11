using System;
using System.Text;
using System.IO;

namespace Desktop.common.nomitech.common.auth
{

	public class InstallCert
	{
	  private static readonly char[] HEXDIGITS = "0123456789abcdef".ToCharArray();

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void main(String[] paramArrayOfString) throws Exception
	  public static void Main(string[] paramArrayOfString)
	  {
		bool @bool;
		char[] arrayOfChar;
		char c;
		string str1;
		if (paramArrayOfString.Length == 1 || paramArrayOfString.Length == 2)
		{
		  string[] arrayOfString = paramArrayOfString[0].Split(":", true);
		  str1 = arrayOfString[0];
		  c = (arrayOfString.Length == 1) ? (char)443 : (char)int.Parse(arrayOfString[1]);
		  string str = (paramArrayOfString.Length == 1) ? "changeit" : paramArrayOfString[1];
		  arrayOfChar = str.ToCharArray();
		}
		else
		{
		  Console.WriteLine("Usage: java InstallCert [:port] [passphrase]");
		  return;
		}
		File file = new File("jssecacerts");
		if (!file.File)
		{
		  char c1 = Path.DirectorySeparatorChar;
		  File file1 = new File(System.getProperty("java.home") + c1 + "lib" + c1 + "security");
		  file = new File(file1, "jssecacerts");
		  if (!file.File)
		  {
			file = new File(file1, "cacerts");
		  }
		}
		Console.WriteLine("Loading KeyStore " + file + "...");
		FileStream fileInputStream = new FileStream(file, FileMode.Open, FileAccess.Read);
		KeyStore keyStore = KeyStore.getInstance(KeyStore.DefaultType);
		keyStore.load(fileInputStream, arrayOfChar);
		fileInputStream.Close();
		SSLContext sSLContext = SSLContext.getInstance("TLS");
		TrustManagerFactory trustManagerFactory = TrustManagerFactory.getInstance(TrustManagerFactory.DefaultAlgorithm);
		trustManagerFactory.init(keyStore);
		X509TrustManager x509TrustManager = (X509TrustManager)trustManagerFactory.TrustManagers[0];
		SavingTrustManager savingTrustManager = new SavingTrustManager(x509TrustManager);
		sSLContext.init(null, new TrustManager[] {savingTrustManager}, null);
		SSLSocketFactory sSLSocketFactory = sSLContext.SocketFactory;
		Console.WriteLine("Opening connection to " + str1 + ":" + c + "...");
		SSLSocket sSLSocket = (SSLSocket)sSLSocketFactory.createSocket(str1, c);
		sSLSocket.SoTimeout = 10000;
		try
		{
		  Console.WriteLine("Starting SSL handshake...");
		  sSLSocket.startHandshake();
		  sSLSocket.close();
		  Console.WriteLine();
		  Console.WriteLine("No errors, certificate is already trusted");
		}
		catch (SSLException sSLException)
		{
		  Console.WriteLine();
		  sSLException.printStackTrace(System.out);
		}
		X509Certificate[] arrayOfX509Certificate = savingTrustManager.chain;
		if (arrayOfX509Certificate == null)
		{
		  Console.WriteLine("Could not obtain server certificate chain");
		  return;
		}
		StreamReader bufferedReader = new StreamReader(System.in);
		Console.WriteLine();
		Console.WriteLine("Server sent " + arrayOfX509Certificate.Length + " certificate(s):");
		Console.WriteLine();
		MessageDigest messageDigest1;
		MessageDigest messageDigest2 = (messageDigest1 = MessageDigest.getInstance("SHA1")).getInstance("MD5");
		for (sbyte b = 0; b < arrayOfX509Certificate.Length; b++)
		{
		  X509Certificate x509Certificate1 = arrayOfX509Certificate[b];
		  Console.WriteLine(" " + (b + true) + " Subject " + x509Certificate1.SubjectDN);
		  Console.WriteLine("   Issuer  " + x509Certificate1.IssuerDN);
		  messageDigest1.update(x509Certificate1.Encoded);
		  Console.WriteLine("   sha1    " + toHexString(messageDigest1.digest()));
		  messageDigest2.update(x509Certificate1.Encoded);
		  Console.WriteLine("   md5     " + toHexString(messageDigest2.digest()));
		  Console.WriteLine();
		}
		Console.WriteLine("Enter certificate to add to trusted keystore or 'q' to quit: [1]");
		string str2 = bufferedReader.ReadLine().Trim();
		try
		{
		  @bool = (str2.Length == 0) ? 0 : (int.Parse(str2) - 1);
		}
		catch (System.FormatException)
		{
		  Console.WriteLine("KeyStore not changed");
		  return;
		}
		X509Certificate x509Certificate = arrayOfX509Certificate[@bool];
		string str3 = str1 + "-" + (@bool + true);
		keyStore.setCertificateEntry(str3, x509Certificate);
		FileStream fileOutputStream = new FileStream("jssecacerts", FileMode.Create, FileAccess.Write);
		keyStore.store(fileOutputStream, arrayOfChar);
		fileOutputStream.Close();
		Console.WriteLine();
		Console.WriteLine(x509Certificate);
		Console.WriteLine();
		Console.WriteLine("Added certificate to keystore 'jssecacerts' using alias '" + str3 + "'");
	  }

	  private static string toHexString(sbyte[] paramArrayOfByte)
	  {
		StringBuilder stringBuilder = new StringBuilder(paramArrayOfByte.Length * 3);
		foreach (sbyte b in paramArrayOfByte)
		{
		  b &= unchecked((sbyte)0xFF);
		  stringBuilder.Append(HEXDIGITS[b >> 4]);
		  stringBuilder.Append(HEXDIGITS[b & 0xF]);
		  stringBuilder.Append(' ');
		}
		return stringBuilder.ToString();
	  }

	  private class SavingTrustManager : X509TrustManager
	  {
		internal readonly X509TrustManager tm;

		internal X509Certificate[] chain;

		internal SavingTrustManager(X509TrustManager param1X509TrustManager)
		{
			this.tm = param1X509TrustManager;
		}

		public virtual X509Certificate[] AcceptedIssuers
		{
			get
			{
				throw new System.NotSupportedException();
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void checkClientTrusted(java.security.cert.X509Certificate[] param1ArrayOfX509Certificate, String param1String) throws java.security.cert.CertificateException
		public virtual void checkClientTrusted(X509Certificate[] param1ArrayOfX509Certificate, string param1String)
		{
			throw new System.NotSupportedException();
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void checkServerTrusted(java.security.cert.X509Certificate[] param1ArrayOfX509Certificate, String param1String) throws java.security.cert.CertificateException
		public virtual void checkServerTrusted(X509Certificate[] param1ArrayOfX509Certificate, string param1String)
		{
		  this.chain = param1ArrayOfX509Certificate;
		  this.tm.checkServerTrusted(param1ArrayOfX509Certificate, param1String);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\auth\InstallCert.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}