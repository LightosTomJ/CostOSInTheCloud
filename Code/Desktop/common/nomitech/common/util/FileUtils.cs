using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Desktop.common.nomitech.common.util
{

	public class FileUtils
	{
	  public static bool isFilenameValid(string paramString)
	  {
		File file = new File(paramString);
		try
		{
		  file.CanonicalPath;
		  return true;
		}
		catch (IOException)
		{
		  return false;
		}
	  }

	  public static string fixFileName(string paramString)
	  {
		paramString = StringUtils.removeSpaces(paramString);
		return paramString.replaceAll("[^A-Za-z]+", "");
	  }

	  public static IList<File> getFilesOnlyForCurrentFolder(params string[] paramVarArgs)
	  {
		List<object> arrayList = null;
		foreach (string str in paramVarArgs)
		{
		  File file = new File(str);
		  arrayList = new List<object>();
		  if (file != null && file.Directory)
		  {
			foreach (File file1 in file.listFiles())
			{
			  if (!file1.Directory)
			  {
				arrayList.Add(file1);
			  }
			}
		  }
		}
		return arrayList;
	  }

	  public static IList<File> getFilesCurrentFolderSpecificExtention(string paramString1, string paramString2)
	  {
		List<object> arrayList = new List<object>();
		if (string.ReferenceEquals(paramString2, null))
		{
		  return arrayList;
		}
		File file = new File(paramString2);
		if (file.Directory)
		{
		  foreach (File file1 in file.listFiles())
		  {
			if (!file1.Directory && getExtensionFromFile(file1.Name).Equals(paramString1, StringComparison.OrdinalIgnoreCase))
			{
			  arrayList.Add(file1);
			}
		  }
		}
		return arrayList;
	  }

	  public static IList<File> getFilesNotRecursiveSpecificExtentionOrder(string paramString1, string paramString2, bool paramBoolean)
	  {
		System.Collections.IList list = getFilesCurrentFolderSpecificExtention(paramString2, paramString1);
		if (paramBoolean)
		{
		  list.Sort(fileComparatorByNameAscending());
		}
		else
		{
		  list.Sort(fileComparatorByNameDescenting());
		}
		return list;
	  }

	  public static IList<File> getFilesOnlyForCurrentFolderOrderByName(string paramString, bool paramBoolean)
	  {
		File file = new File(paramString);
		List<object> arrayList = new List<object>();
		if (file != null && file.Directory)
		{
		  foreach (File file1 in file.listFiles())
		  {
			if (!file1.Directory)
			{
			  arrayList.Add(file1);
			}
		  }
		}
		if (paramBoolean)
		{
		  arrayList.Sort(fileComparatorByNameAscending());
		}
		else
		{
		  arrayList.Sort(fileComparatorByNameDescenting());
		}
		return arrayList;
	  }

	  public static IList<File> getFilesForFolderRecursive(string paramString)
	  {
		File file = new File(paramString);
		List<object> arrayList = new List<object>();
		foreach (File file1 in file.listFiles())
		{
		  if (file1.Directory)
		  {
			arrayList.AddRange(getFilesForFolderRecursive(file1.AbsolutePath));
		  }
		  else
		  {
			arrayList.Add(file1);
		  }
		}
		return arrayList;
	  }

	  public static IComparer<File> fileComparatorByNameAscending()
	  {
		  return new ComparatorAnonymousInnerClass();
	  }

	  private class ComparatorAnonymousInnerClass : IComparer<File>
	  {
		  public int compare(File param1File1, File param1File2)
		  {
			  return param1File1.Name.compareTo(param1File2.Name);
		  }
	  }

	  public static IComparer<File> fileComparatorByNameDescenting()
	  {
		  return Collections.reverseOrder(fileComparatorByNameAscending());
	  }

	  public static string getExtensionFromFile(string paramString)
	  {
		  return (paramString.IndexOf(".", StringComparison.Ordinal) == -1) ? paramString : paramString.Substring(paramString.LastIndexOf(".", StringComparison.Ordinal) + 1);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static String getFileContents(java.io.File paramFile) throws java.io.IOException
	  public static string getFileContents(File paramFile)
	  {
		bufferedReader = new StreamReader(paramFile);
		string str = null;
		try
		{
		  StringBuilder stringBuilder = new StringBuilder();
		  for (string str1 = bufferedReader.readLine(); !string.ReferenceEquals(str1, null); str1 = bufferedReader.readLine())
		  {
			stringBuilder.Append(str1);
			stringBuilder.Append(System.getProperty("line.separator"));
		  }
		  str = stringBuilder.ToString();
		}
		finally
		{
		  bufferedReader.close();
		}
		return str;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void moveFilesToZip(java.io.File paramFile, java.io.File[] paramArrayOfFile) throws java.io.IOException
	  public static void moveFilesToZip(File paramFile, File[] paramArrayOfFile)
	  {
		  moveFilesToZip(paramFile, Arrays.asList(paramArrayOfFile));
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public static void moveFilesToZip(java.io.File paramFile, java.util.List<java.io.File> paramList) throws java.io.IOException
	  public static void moveFilesToZip(File paramFile, IList<File> paramList)
	  {
		ZipOutputStream zipOutputStream = new ZipOutputStream(new FileStream(paramFile, FileMode.Create, FileAccess.Write));
		foreach (File file in paramList)
		{
		  ZipEntry zipEntry = new ZipEntry(file.Name);
		  zipOutputStream.putNextEntry(zipEntry);
		  FileStream fileInputStream = new FileStream(file, FileMode.Open, FileAccess.Read);
		  sbyte[] arrayOfByte = new sbyte[1024];
		  int i;
		  while ((i = fileInputStream.Read(arrayOfByte, 0, arrayOfByte.Length)) >= 0)
		  {
			zipOutputStream.write(arrayOfByte, 0, i);
		  }
		  fileInputStream.Close();
		  file.delete();
		}
		zipOutputStream.close();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\FileUtils.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}