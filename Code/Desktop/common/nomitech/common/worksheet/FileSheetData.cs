using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop.common.nomitech.common.worksheet
{
	using StringUtils = nomitech.common.util.StringUtils;

	public class FileSheetData
	{
	  public const string DATA_SEPERATOR = "<d>";

	  public const string LINE_SEPERATOR = "<l>";

	  private string sheetName;

	  private int? lastRowNumber;

	  private int? offsetRow;

	  public FileSheetData()
	  {
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: protected FileSheetData(String paramString) throws Exception
	  protected internal FileSheetData(string paramString)
	  {
		string[] arrayOfString = paramString.Split("<d>", true);
		if (arrayOfString.Length != 3)
		{
		  throw new Exception("Invalid Data Line: " + paramString);
		}
		this.offsetRow = Convert.ToInt32((this.lastRowNumber = Convert.ToInt32(int.Parse(arrayOfString[0]))).parseInt(arrayOfString[1]));
		this.sheetName = arrayOfString[2].ToString();
	  }

	  public FileSheetData(int paramInt1, int paramInt2, string paramString)
	  {
		this.offsetRow = (this.lastRowNumber = Convert.ToInt32(paramInt1)).valueOf(paramInt2);
		this.sheetName = paramString;
	  }

	  public virtual int? OffsetRow
	  {
		  get
		  {
			  return this.offsetRow;
		  }
		  set
		  {
			  this.offsetRow = value;
		  }
	  }


	  public virtual string SheetName
	  {
		  get
		  {
			  return this.sheetName;
		  }
		  set
		  {
			  this.sheetName = value;
		  }
	  }


	  public virtual int? LastRowNumber
	  {
		  get
		  {
			  return this.lastRowNumber;
		  }
		  set
		  {
			  this.lastRowNumber = value;
		  }
	  }


	  public virtual string toLine()
	  {
		  return this.lastRowNumber + "<d>" + this.offsetRow + "<d>" + this.sheetName;
	  }

	  public static IList<FileSheetData> cellsFromLines(string paramString)
	  {
		if (StringUtils.isNullOrBlank(paramString))
		{
		  return new List<object>(0);
		}
		try
		{
		  string[] arrayOfString = paramString.Split("<l>", true);
		  List<object> arrayList = new List<object>(arrayOfString.Length);
		  foreach (string str in arrayOfString)
		  {
			arrayList.Add(new FileSheetData(str));
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

	  public override string ToString()
	  {
		  return this.sheetName;
	  }

	  public static string linesFromCells(IList<FileSheetData> paramList)
	  {
		StringBuilder stringBuffer = new StringBuilder();
		sbyte b = 0;
		foreach (FileSheetData fileSheetData in paramList)
		{
		  stringBuffer.Append(fileSheetData.toLine());
		  if (++b != paramList.Count)
		  {
			stringBuffer.Append("<l>");
		  }
		}
		return stringBuffer.ToString();
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\worksheet\FileSheetData.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}