namespace Desktop.common.nomitech.common.util
{

	public class UIPropertiesUtil
	{
	  public static Properties uiProperties;

	  public static Properties UIProperties
	  {
		  get
		  {
			  return uiProperties;
		  }
		  set
		  {
			  uiProperties = value;
		  }
	  }


	  private static double getDoubleProperty(string paramString)
	  {
		try
		{
		  return double.Parse(uiProperties.getProperty(paramString));
		}
		catch (System.FormatException)
		{
		  return -1.0D;
		}
	  }

	  public static decimal getHoursFromUnit(string paramString)
	  {
		if (uiProperties == null)
		{
		  return decimal.One;
		}
		switch (paramString.ToUpper())
		{
		  case "HOUR":
			return decimal.One;
		  case "DAY":
			return new decimal(8.0D);
		  case "DAY1":
			return new decimal((uiProperties.getProperty("time.unit.day1") == null) ? 8.0D : getDoubleProperty("time.unit.day1"));
		  case "DAY2":
			return new decimal((uiProperties.getProperty("time.unit.day2") == null) ? 8.0D : getDoubleProperty("time.unit.day2"));
		  case "DAY3":
			return new decimal((uiProperties.getProperty("time.unit.day3") == null) ? 8.0D : getDoubleProperty("time.unit.day3"));
		  case "DAY4":
			return new decimal((uiProperties.getProperty("time.unit.day4") == null) ? 8.0D : getDoubleProperty("time.unit.day4"));
		  case "DAY5":
			return new decimal((uiProperties.getProperty("time.unit.day5") == null) ? 8.0D : getDoubleProperty("time.unit.day5"));
		  case "WEEK":
			return new decimal(40.0D);
		  case "WEEK1":
			return new decimal((uiProperties.getProperty("time.unit.week1") == null) ? 40.0D : getDoubleProperty("time.unit.week1"));
		  case "WEEK2":
			return new decimal((uiProperties.getProperty("time.unit.week2") == null) ? 40.0D : getDoubleProperty("time.unit.week2"));
		  case "WEEK3":
			return new decimal((uiProperties.getProperty("time.unit.week3") == null) ? 40.0D : getDoubleProperty("time.unit.week3"));
		  case "WEEK4":
			return new decimal((uiProperties.getProperty("time.unit.week4") == null) ? 40.0D : getDoubleProperty("time.unit.week4"));
		  case "WEEK5":
			return new decimal((uiProperties.getProperty("time.unit.week5") == null) ? 40.0D : getDoubleProperty("time.unit.week5"));
		  case "MONTH":
			return new decimal(160.0D);
		  case "MONTH1":
			return new decimal((uiProperties.getProperty("time.unit.month1") == null) ? 160.0D : getDoubleProperty("time.unit.month1"));
		  case "MONTH2":
			return new decimal((uiProperties.getProperty("time.unit.month2") == null) ? 160.0D : getDoubleProperty("time.unit.month2"));
		  case "MONTH3":
			return new decimal((uiProperties.getProperty("time.unit.month3") == null) ? 160.0D : getDoubleProperty("time.unit.month3"));
		  case "MONTH4":
			return new decimal((uiProperties.getProperty("time.unit.month4") == null) ? 160.0D : getDoubleProperty("time.unit.month4"));
		  case "MONTH5":
			return new decimal((uiProperties.getProperty("time.unit.month5") == null) ? 160.0D : getDoubleProperty("time.unit.month5"));
		}
		return decimal.One;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\UIPropertiesUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}