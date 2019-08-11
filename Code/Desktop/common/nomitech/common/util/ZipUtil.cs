using System.Collections.Generic;
using System.IO;

namespace Desktop.common.nomitech.common.util
{

	public class ZipUtil
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void unzip(java.io.File paramFile1, java.io.File paramFile2, ProgressCallback paramProgressCallback) throws java.io.IOException
	  public static void unzip(File paramFile1, File paramFile2, ProgressCallback paramProgressCallback)
	  {
		if (!paramFile2.Directory)
		{
		  return;
		}
		ZipFile zipFile = new ZipFile(paramFile1);
		unzipFiles(zipFile, paramFile2, paramProgressCallback);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void unzip(java.io.File paramFile1, java.io.File paramFile2) throws java.io.IOException
	  public static void unzip(File paramFile1, File paramFile2)
	  {
		if (!paramFile2.Directory)
		{
		  return;
		}
		ZipFile zipFile = new ZipFile(paramFile1);
		unzipFiles(zipFile, paramFile2, new ProgressCallbackAnonymousInnerClass());
	  }

	  private class ProgressCallbackAnonymousInnerClass : ProgressCallback
	  {
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static void unzipFiles(java.util.zip.ZipFile paramZipFile, java.io.File paramFile, ProgressCallback paramProgressCallback) throws java.io.IOException
	  private static void unzipFiles(ZipFile paramZipFile, File paramFile, ProgressCallback paramProgressCallback)
	  {
		LinkedList linkedList = new LinkedList();
		System.Collections.IEnumerator enumeration = paramZipFile.entries();
		sbyte b;
		for (b = 0; enumeration.MoveNext(); b++)
		{
		  linkedList.AddLast((ZipEntry)enumeration.Current);
		}
		paramProgressCallback.NumProgressSteps = b;
		sbyte[] arrayOfByte = new sbyte[2156];
		File file = paramFile;
		foreach (ZipEntry zipEntry in linkedList)
		{
		  paramProgressCallback.progressStep("[" + zipEntry.Name + "]");
		  if (zipEntry.Directory)
		  {
			File file2 = new File(paramFile.AbsoluteFile + File.separator + zipEntry.Name);
			file2.mkdirs();
			continue;
		  }
		  File file1 = new File(file.AbsolutePath + File.separator + zipEntry.Name);
		  if (file1.ParentFile != null)
		  {
			file1.ParentFile.mkdirs();
		  }
		  file1.createNewFile();
		  FileStream fileOutputStream = new FileStream(file1, FileMode.Create, FileAccess.Write);
		  Stream inputStream = paramZipFile.getInputStream(zipEntry);
		  int i;
		  while ((i = inputStream.Read(arrayOfByte, 0, arrayOfByte.Length)) > 0)
		  {
			fileOutputStream.Write(arrayOfByte, 0, i);
		  }
		  fileOutputStream.Flush();
		  fileOutputStream.Close();
		  inputStream.Close();
		}
	  }

	  private static int getNumFiles(File paramFile, int paramInt)
	  {
		if (!paramFile.Directory)
		{
		  return paramInt + 1;
		}
		File[] arrayOfFile = paramFile.listFiles();
		foreach (File file in arrayOfFile)
		{
		  if (file.File)
		  {
			paramInt++;
		  }
		  else if (file.Directory)
		  {
			paramInt = getNumFiles(file, paramInt);
		  }
		}
		return paramInt;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void zip(java.io.File paramFile, java.io.OutputStream paramOutputStream, ProgressCallback paramProgressCallback) throws java.io.IOException
	  public static void zip(File paramFile, Stream paramOutputStream, ProgressCallback paramProgressCallback)
	  {
		if (!paramFile.File && !paramFile.Directory)
		{
		  return;
		}
		paramProgressCallback.NumProgressSteps = getNumFiles(paramFile, 0);
		ZipOutputStream zipOutputStream = new ZipOutputStream(paramOutputStream);
		zipOutputStream.Level = 9;
		zipFiles(paramFile, paramFile, zipOutputStream, paramProgressCallback);
		paramProgressCallback.NumProgressSteps = -1;
		zipOutputStream.finish();
		zipOutputStream.close();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static void zipFiles(java.io.File paramFile1, java.io.File paramFile2, java.util.zip.ZipOutputStream paramZipOutputStream, ProgressCallback paramProgressCallback) throws java.io.IOException
	  private static void zipFiles(File paramFile1, File paramFile2, ZipOutputStream paramZipOutputStream, ProgressCallback paramProgressCallback)
	  {
		sbyte[] arrayOfByte = new sbyte[2156];
		if (paramFile2.Directory)
		{
		  File[] arrayOfFile = paramFile2.listFiles();
		  for (sbyte b = 0; b < arrayOfFile.Length; b++)
		  {
			zipFiles(paramFile1, arrayOfFile[b], paramZipOutputStream, paramProgressCallback);
		  }
		}
		else
		{
		  string str1 = paramFile2.Path;
		  string str2 = StringHelper.SubstringSpecial(str1, paramFile1.Path.length() + 1, str1.Length);
		  paramProgressCallback.progressStep("[" + str2 + "]");
		  FileStream fileInputStream = new FileStream(paramFile2, FileMode.Open, FileAccess.Read);
		  ZipEntry zipEntry = new ZipEntry(str2);
		  paramZipOutputStream.putNextEntry(zipEntry);
		  int i;
		  while ((i = fileInputStream.Read(arrayOfByte, 0, arrayOfByte.Length)) != -1)
		  {
			paramZipOutputStream.write(arrayOfByte, 0, i);
		  }
		  fileInputStream.Close();
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void copyInputStream(java.io.InputStream paramInputStream, java.io.OutputStream paramOutputStream) throws java.io.IOException
	  public static void copyInputStream(Stream paramInputStream, Stream paramOutputStream)
	  {
		  fastCopy(paramInputStream, paramOutputStream);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static java.io.File unpackArchive(java.io.File paramFile1, java.io.File paramFile2) throws java.io.IOException
	  public static File unpackArchive(File paramFile1, File paramFile2)
	  {
		if (!paramFile1.exists())
		{
		  throw new IOException(paramFile1.AbsolutePath + " does not exist");
		}
		if (!buildDirectory(paramFile2))
		{
		  throw new IOException("Could not create directory: " + paramFile2);
		}
		ZipFile zipFile = new ZipFile(paramFile1);
		System.Collections.IEnumerator enumeration = zipFile.entries();
		while (enumeration.MoveNext())
		{
		  ZipEntry zipEntry = (ZipEntry)enumeration.Current;
		  File file = new File(paramFile2, File.separator + zipEntry.Name);
		  if (!buildDirectory(file.ParentFile))
		  {
			if (zipFile != null)
			{
			  zipFile.close();
			}
			throw new IOException("Could not create directory: " + file.ParentFile);
		  }
		  if (!zipEntry.Directory)
		  {
			copyInputStream(zipFile.getInputStream(zipEntry), new BufferedOutputStream(new FileStream(file, FileMode.Create, FileAccess.Write)));
			continue;
		  }
		  if (!buildDirectory(file))
		  {
			if (zipFile != null)
			{
			  zipFile.close();
			}
			throw new IOException("Could not create directory: " + file);
		  }
		}
		zipFile.close();
		return paramFile1;
	  }

	  public static bool buildDirectory(File paramFile)
	  {
		  return (paramFile.exists() || paramFile.mkdirs());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void fastCopy(java.io.InputStream paramInputStream, java.io.OutputStream paramOutputStream) throws java.io.IOException
	  public static void fastCopy(Stream paramInputStream, Stream paramOutputStream)
	  {
		ReadableByteChannel readableByteChannel = Channels.newChannel(paramInputStream);
		WritableByteChannel writableByteChannel = Channels.newChannel(paramOutputStream);
		ByteBuffer byteBuffer = ByteBuffer.allocateDirect(16384);
		while (readableByteChannel.read(byteBuffer) != -1)
		{
		  byteBuffer.flip();
		  writableByteChannel.write(byteBuffer);
		  byteBuffer.compact();
		}
		byteBuffer.flip();
		while (byteBuffer.hasRemaining())
		{
		  writableByteChannel.write(byteBuffer);
		}
		readableByteChannel.close();
		writableByteChannel.close();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\ZipUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}