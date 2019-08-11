using System;

namespace Desktop.common.nomitech.common.util
{
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using HSSFCell = org.apache.poi.hssf.usermodel.HSSFCell;
	using Cell = org.apache.poi.ss.usermodel.Cell;

	public class ExcelParsingUtil
	{
	  private Timestamp lastUpdate;

	  private static bool isStringCell(Cell paramCell)
	  {
		  return (paramCell.CellType == 1);
	  }

	  private static bool isNumericCell(Cell paramCell)
	  {
		  return (paramCell.CellType == 1);
	  }

	  private static bool isBlank(Cell paramCell)
	  {
		  return (paramCell.CellType == 1);
	  }

	  private DateTime notNullDate(HSSFCell paramHSSFCell)
	  {
		Timestamp timestamp = new Timestamp(DateTimeHelper.CurrentUnixTimeMillis());
		if (paramHSSFCell == null)
		{
		  return timestamp;
		}
		if (paramHSSFCell.CellType == 0)
		{
		  try
		  {
			return paramHSSFCell.DateCellValue;
		  }
		  catch (Exception)
		  {
			return null;
		  }
		}
		return timestamp;
	  }

	  private string notNull(HSSFCell paramHSSFCell)
	  {
		string str = "";
		if (paramHSSFCell == null)
		{
		  return "";
		}
		if (paramHSSFCell != null && paramHSSFCell.CellType == 0)
		{
		  str = "" + paramHSSFCell.NumericCellValue;
		  if (str.EndsWith(".0", StringComparison.Ordinal))
		  {
			str = "" + (long)paramHSSFCell.NumericCellValue;
		  }
		}
		else
		{
		  str = paramHSSFCell.RichStringCellValue.String;
		}
		return (string.ReferenceEquals(str, null)) ? "" : str;
	  }

	  private string notNullGeolocation(HSSFCell paramHSSFCell)
	  {
		string str = notNull(paramHSSFCell);
		if (str.IndexOf(",", StringComparison.Ordinal) != -1)
		{
		  return "";
		}
		try
		{
		  double[] arrayOfDouble = StringUtils.extractDoubles(str);
		  if (arrayOfDouble.Length != 2)
		  {
			return "";
		  }
		}
		catch (Exception)
		{
		  return "";
		}
		return str;
	  }

	  private decimal notNullBigDecimal(HSSFCell paramHSSFCell, double paramDouble)
	  {
		BigDecimalFixed bigDecimalFixed = new BigDecimalFixed("" + paramDouble);
		if (paramHSSFCell == null)
		{
		  return bigDecimalFixed;
		}
		if (paramHSSFCell.CellType == 0)
		{
		  bigDecimalFixed = new BigDecimalFixed("" + paramHSSFCell.NumericCellValue);
		}
		return bigDecimalFixed;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\ExcelParsingUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}