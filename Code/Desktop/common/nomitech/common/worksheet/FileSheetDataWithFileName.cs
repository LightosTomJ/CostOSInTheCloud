using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.worksheet
{
	using StringUtils = nomitech.common.util.StringUtils;

	public class FileSheetDataWithFileName : FileSheetData
	{
	  private string fileName;

	  private long? fileId;

	  public FileSheetDataWithFileName(long? paramLong, string paramString1, int paramInt1, int paramInt2, string paramString2) : base(paramInt1, paramInt2, paramString2)
	  {
		this.fileName = paramString1;
		this.fileId = paramLong;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected FileSheetDataWithFileName(System.Nullable<long> paramLong, String paramString1, String paramString2) throws Exception
	  protected internal FileSheetDataWithFileName(long? paramLong, string paramString1, string paramString2) : base(paramString2)
	  {
		this.fileId = paramLong;
	  }

	  public virtual string FileName
	  {
		  get
		  {
			  return this.fileName;
		  }
		  set
		  {
			  this.fileName = value;
		  }
	  }


	  public virtual long? FileId
	  {
		  get
		  {
			  return this.fileId;
		  }
		  set
		  {
			  this.fileId = value;
		  }
	  }


	  public static IList<FileSheetDataWithFileName> cellsFromLines(long? paramLong, string paramString1, string paramString2)
	  {
		if (StringUtils.isNullOrBlank(paramString2))
		{
		  return new List<object>(0);
		}
		try
		{
		  string[] arrayOfString = paramString2.Split("<l>", true);
		  List<object> arrayList = new List<object>(arrayOfString.Length);
		  foreach (string str in arrayOfString)
		  {
			FileSheetDataWithFileName fileSheetDataWithFileName = new FileSheetDataWithFileName(paramLong, paramString1, str);
			fileSheetDataWithFileName.FileName = paramString1;
			arrayList.Add(fileSheetDataWithFileName);
		  }
		  return arrayList;
		}
		catch (Exception exception)
		{
		  Console.WriteLine(exception.ToString());
		  Console.Write(exception.StackTrace);
		  return new List<object>(0);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\worksheet\FileSheetDataWithFileName.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}