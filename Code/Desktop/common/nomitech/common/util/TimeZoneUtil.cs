using System;

namespace Desktop.common.nomitech.common.util
{

	public class TimeZoneUtil
	{
	  private static TimeZone s_localTimeZone;

	  public static void initialize()
	  {
		s_localTimeZone = TimeZone.Default;
		System.setProperty("user.timezone", "GMT");
		TimeZone.Default = TimeZone.getTimeZone("GMT");
	  }

	  public static void resetDefaultTimeZone()
	  {
	  }

	  public static DateTime getDateInLocalTimeZone(DateTime paramDate)
	  {
		GregorianCalendar gregorianCalendar = new GregorianCalendar();
		gregorianCalendar.Time = paramDate;
		gregorianCalendar.add(14, s_localTimeZone.getOffset(paramDate.Ticks));
		return gregorianCalendar.Time;
	  }

	  public static DateTime getDateInGMTTimeZone(DateTime paramDate)
	  {
		GregorianCalendar gregorianCalendar = new GregorianCalendar();
		gregorianCalendar.Time = paramDate;
		gregorianCalendar.add(14, -s_localTimeZone.getOffset(paramDate.Ticks));
		return gregorianCalendar.Time;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\commo\\util\TimeZoneUtil.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}