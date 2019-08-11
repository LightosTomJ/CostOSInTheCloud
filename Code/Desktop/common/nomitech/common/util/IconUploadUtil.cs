using System;
using System.IO;

namespace Desktop.common.nomitech.common.util
{
	using Session = org.hibernate.Session;

	public class IconUploadUtil
	{
	  private const string LOCAL_ICON_DB_FOLDER = "data/icons/";

	  private const string LOCAL_IMAGE_DB_FOLDER = "data/images/";

	  private const string LOCAL_JRXML_DB_FOLDER = "data/jrxml/";

	  private static readonly string SERVER_ICON_DB_FOLDER = NamingUtil.Instance.getWarPath("db_icons/");

	  private static readonly string SERVER_IMAGE_DB_FOLDER = NamingUtil.Instance.getWarPath("db_images/");

	  private static readonly string SERVER_JRXML_DB_FOLDER = NamingUtil.Instance.getWarPath("db_jrxml/");

	  public static readonly string SERVER_PICTURE_DB_FOLDER = NamingUtil.Instance.getWarPath("pictures/");

	  public static string getLocalPathOfIcon(string paramString, Type paramClass, int paramInt)
	  {
		  return "data/icons/" + paramClass.Name.ToLower() + "/" + paramString + "_" + paramInt + ".png";
	  }

	  public static string getLocalPathOfImage(string paramString, Type paramClass, long? paramLong)
	  {
		  return "data/images/" + paramClass.Name.ToLower() + "/" + paramString + "_" + paramLong + ".png";
	  }

	  public static string getLocalPathOfJrxml(string paramString, Type paramClass, long? paramLong)
	  {
		  return "data/jrxml/" + paramClass.Name.ToLower() + "/" + paramString + "_" + paramLong + ".jrxml";
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static String uploadLocalIcon(String paramString, Class paramClass) throws Exception
	  public static string uploadLocalIcon(string paramString, Type paramClass)
	  {
		File file1 = new File("data/icons/" + paramClass.Name.ToLower());
		if (!file1.exists())
		{
		  file1.mkdirs();
		}
		File file2 = new File(paramString);
		string str1 = file2.Name.substring(0, file2.Name.LastIndexOf("."));
		string str2 = getLocalPathOfIcon(str1, paramClass, 16);
		File file3 = new File(str2);
		ImageUtils.resizeImageAndSave(file2.AbsolutePath, file3.AbsolutePath, 16, 16);
		str2 = getLocalPathOfIcon(str1, paramClass, 24);
		file3 = new File(str2);
		ImageUtils.resizeImageAndSave(file2.AbsolutePath, file3.AbsolutePath, 24, 24);
		str2 = getLocalPathOfIcon(str1, paramClass, 32);
		file3 = new File(str2);
		ImageUtils.resizeImageAndSave(file2.AbsolutePath, file3.AbsolutePath, 32, 32);
		return str1;
	  }

	  public static string uploadLocalImage(string paramString, Type paramClass, long? paramLong)
	  {
		File file1 = new File("data/images/" + paramClass.Name.ToLower());
		if (!file1.exists())
		{
		  file1.mkdirs();
		}
		File file2 = new File(paramString);
		string str1 = file2.Name.substring(0, file2.Name.LastIndexOf("."));
		string str2 = getLocalPathOfImage(str1, paramClass, paramLong);
		File file3 = new File(str2);
		ImageUtils.saveImage(ImageIO.read(file2), file3.AbsolutePath, 1);
		return str1;
	  }

	  public static string uploadLocalJrxml(string paramString, Type paramClass, long? paramLong)
	  {
		File file1 = new File("data/jrxml/" + paramClass.Name.ToLower());
		if (!file1.exists())
		{
		  file1.mkdirs();
		}
		File file2 = new File(paramString);
		string str1 = file2.Name.substring(0, file2.Name.LastIndexOf("."));
		string str2 = getLocalPathOfJrxml(str1, paramClass, paramLong);
		File file3 = new File(str2);
		copyFile(file2, file3);
		return str1;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean deleteLocalIcon(String paramString, Class paramClass) throws Exception
	  public static bool deleteLocalIcon(string paramString, Type paramClass)
	  {
		bool @bool = !DatabaseDBUtil.hasOpenedSession() ? 1 : 0;
		int i = ((Number)DatabaseDBUtil.currentSession().createQuery("select count(o.icon) from " + paramClass.Name + " o where o.icon = '" + paramString + "'").iterate().next()).intValue();
		if (i > 1)
		{
		  return false;
		}
		if (@bool)
		{
		  DatabaseDBUtil.closeSession();
		}
		File file1 = new File(getLocalPathOfIcon(paramString, paramClass, 16));
		File file2 = new File(getLocalPathOfIcon(paramString, paramClass, 24));
		File file3 = new File(getLocalPathOfIcon(paramString, paramClass, 32));
		if (file1.exists())
		{
		  file1.delete();
		}
		if (file2.exists())
		{
		  file2.delete();
		}
		if (file3.exists())
		{
		  file3.delete();
		}
		return true;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean deleteLocalImage(String paramString, Class paramClass, System.Nullable<long> paramLong) throws Exception
	  public static bool deleteLocalImage(string paramString, Type paramClass, long? paramLong)
	  {
		File file = new File(getLocalPathOfImage(paramString, paramClass, paramLong));
		if (file.exists())
		{
		  file.delete();
		}
		return true;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean deleteLocalJrxml(String paramString, Class paramClass, System.Nullable<long> paramLong) throws Exception
	  public static bool deleteLocalJrxml(string paramString, Type paramClass, long? paramLong)
	  {
		File file = new File(getLocalPathOfJrxml(paramString, paramClass, paramLong));
		if (file.exists())
		{
		  file.delete();
		}
		return true;
	  }

	  public static string getServerPathOfIcon(string paramString, Type paramClass, int paramInt)
	  {
		  return SERVER_ICON_DB_FOLDER + paramClass.Name.ToLower() + "/" + paramString + "_" + paramInt + ".png";
	  }

	  public static string getServerPathOfImage(string paramString, Type paramClass, long? paramLong)
	  {
		  return SERVER_IMAGE_DB_FOLDER + paramClass.Name.ToLower() + "/" + paramString + "_" + paramLong + ".png";
	  }

	  public static string getServerPathOfJrxml(string paramString, Type paramClass, long? paramLong)
	  {
		  return SERVER_JRXML_DB_FOLDER + paramClass.Name.ToLower() + "/" + paramString + "_" + paramLong + ".jrxml";
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static String uploadServerPicture(byte[] paramArrayOfByte, String paramString) throws Exception
	  public static string uploadServerPicture(sbyte[] paramArrayOfByte, string paramString)
	  {
		File file1 = new File(SERVER_PICTURE_DB_FOLDER);
		if (!file1.exists())
		{
		  file1.mkdirs();
		}
		string str = paramString + ".png";
		File file2 = new File(file1 + File.separator + str);
		ImageIcon imageIcon = ImageUtils.base64ToImage(paramArrayOfByte);
		ImageUtils.saveImage(ImageUtils.toBufferedImage(imageIcon.Image), file2.AbsolutePath, 1);
		return str;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static String uploadServerIcon(byte[] paramArrayOfByte, String paramString, Class paramClass) throws Exception
	  public static string uploadServerIcon(sbyte[] paramArrayOfByte, string paramString, Type paramClass)
	  {
		if (paramString.IndexOf(".", StringComparison.Ordinal) == -1)
		{
		  throw new System.ArgumentException("Invalid image file name: " + paramString);
		}
		File file1 = new File(SERVER_ICON_DB_FOLDER + paramClass.Name.ToLower());
		if (!file1.exists())
		{
		  file1.mkdirs();
		}
		sbyte b = 1;
		if (paramString.ToLower().EndsWith(".png", StringComparison.Ordinal))
		{
		  b = 1;
		}
		else if (paramString.ToLower().EndsWith(".gif", StringComparison.Ordinal))
		{
		  b = 3;
		}
		else
		{
		  b = 0;
		}
		BufferedImage bufferedImage = ImageUtils.imageFromBytes(b, paramArrayOfByte);
		string str1 = paramString.Substring(0, paramString.LastIndexOf(".", StringComparison.Ordinal));
		string str2 = getServerPathOfIcon(str1, paramClass, 16);
		File file2 = new File(str2);
		ImageUtils.resizeImageAndSave(bufferedImage, b, file2.AbsolutePath, 16, 16);
		str2 = getServerPathOfIcon(str1, paramClass, 24);
		file2 = new File(str2);
		ImageUtils.resizeImageAndSave(bufferedImage, b, file2.AbsolutePath, 24, 24);
		str2 = getServerPathOfIcon(str1, paramClass, 32);
		file2 = new File(str2);
		ImageUtils.resizeImageAndSave(bufferedImage, b, file2.AbsolutePath, 32, 32);
		return str1;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static String uploadServerImage(byte[] paramArrayOfByte, String paramString, Class paramClass, System.Nullable<long> paramLong) throws Exception
	  public static string uploadServerImage(sbyte[] paramArrayOfByte, string paramString, Type paramClass, long? paramLong)
	  {
		if (paramString.IndexOf(".", StringComparison.Ordinal) == -1)
		{
		  throw new System.ArgumentException("Invalid image file name: " + paramString);
		}
		File file1 = new File(SERVER_IMAGE_DB_FOLDER + paramClass.Name.ToLower());
		if (!file1.exists())
		{
		  file1.mkdirs();
		}
		sbyte b = 1;
		if (paramString.ToLower().EndsWith(".png", StringComparison.Ordinal))
		{
		  b = 1;
		}
		else if (paramString.ToLower().EndsWith(".gif", StringComparison.Ordinal))
		{
		  b = 3;
		}
		else
		{
		  b = 0;
		}
		BufferedImage bufferedImage = ImageUtils.imageFromBytes(b, paramArrayOfByte);
		string str1 = paramString.Substring(0, paramString.LastIndexOf(".", StringComparison.Ordinal));
		string str2 = getServerPathOfImage(str1, paramClass, paramLong);
		File file2 = new File(str2);
		ImageUtils.saveImage(bufferedImage, file2.AbsolutePath, b);
		return str1;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static String uploadServerJrxml(byte[] paramArrayOfByte, String paramString, Class paramClass, System.Nullable<long> paramLong) throws Exception
	  public static string uploadServerJrxml(sbyte[] paramArrayOfByte, string paramString, Type paramClass, long? paramLong)
	  {
		if (paramString.IndexOf(".", StringComparison.Ordinal) == -1)
		{
		  throw new System.ArgumentException("Invalid jrxml file name: " + paramString);
		}
		File file = new File(SERVER_JRXML_DB_FOLDER + paramClass.Name.ToLower());
		if (!file.exists())
		{
		  file.mkdirs();
		}
		sbyte b = 1;
		if (paramString.ToLower().EndsWith(".png", StringComparison.Ordinal))
		{
		  b = 1;
		}
		else if (paramString.ToLower().EndsWith(".gif", StringComparison.Ordinal))
		{
		  b = 3;
		}
		else
		{
		  b = 0;
		}
		string str = paramString.Substring(0, paramString.LastIndexOf(".", StringComparison.Ordinal));
		FileStream fileOutputStream = new FileStream(getServerPathOfJrxml(str, paramClass, paramLong), FileMode.Create, FileAccess.Write);
		fileOutputStream.Write(paramArrayOfByte, 0, paramArrayOfByte.Length);
		fileOutputStream.Close();
		return str;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean deleteServerIcon(org.hibernate.Session paramSession, String paramString, Class paramClass) throws Exception
	  public static bool deleteServerIcon(Session paramSession, string paramString, Type paramClass)
	  {
		bool @bool = !DatabaseDBUtil.hasOpenedSession() ? 1 : 0;
		int i = ((Number)paramSession.createQuery("select count(o.icon) from " + paramClass.Name + " o where o.icon = '" + paramString + "'").iterate().next()).intValue();
		if (i >= 1)
		{
		  return false;
		}
		if (@bool)
		{
		  DatabaseDBUtil.closeSession();
		}
		File file1 = new File(getServerPathOfIcon(paramString, paramClass, 16));
		File file2 = new File(getServerPathOfIcon(paramString, paramClass, 24));
		File file3 = new File(getServerPathOfIcon(paramString, paramClass, 32));
		if (file1.exists())
		{
		  file1.delete();
		}
		if (file2.exists())
		{
		  file2.delete();
		}
		if (file3.exists())
		{
		  file3.delete();
		}
		return true;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean deleteServerImage(String paramString, Class paramClass, System.Nullable<long> paramLong) throws Exception
	  public static bool deleteServerImage(string paramString, Type paramClass, long? paramLong)
	  {
		File file = new File(getServerPathOfImage(paramString, paramClass, paramLong));
		if (file.exists())
		{
		  file.delete();
		}
		return true;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static boolean deleteServerJrxml(String paramString, Class paramClass, System.Nullable<long> paramLong) throws Exception
	  public static bool deleteServerJrxml(string paramString, Type paramClass, long? paramLong)
	  {
		File file = new File(getServerPathOfJrxml(paramString, paramClass, paramLong));
		if (file.exists())
		{
		  file.delete();
		}
		return true;
	  }

	  private static void copyFile(File paramFile1, File paramFile2)
	  {
		try
		{
		  FileStream fileInputStream = new FileStream(paramFile1, FileMode.Open, FileAccess.Read);
		  if (!paramFile2.exists())
		  {
			paramFile2.createNewFile();
		  }
		  FileStream fileOutputStream = new FileStream(paramFile2, FileMode.Create, FileAccess.Write);
		  sbyte[] arrayOfByte = new sbyte[1024];
		  int i;
		  while ((i = fileInputStream.Read(arrayOfByte, 0, arrayOfByte.Length)) > 0)
		  {
			fileOutputStream.Write(arrayOfByte, 0, i);
		  }
		  fileInputStream.Close();
		  fileOutputStream.Close();
		}
		catch (FileNotFoundException fileNotFoundException)
		{
		  Console.WriteLine(fileNotFoundException.Message + " in the specified directory.");
		  Environment.Exit(0);
		}
		catch (IOException iOException)
		{
		  Console.WriteLine(iOException.Message);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\IconUploadUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}