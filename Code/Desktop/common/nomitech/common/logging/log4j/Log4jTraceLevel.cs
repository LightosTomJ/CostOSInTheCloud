namespace Desktop.common.nomitech.common.logging.log4j
{
	using Level = Desktop.common.org.apache.log4j.Level;

	public class Log4jTraceLevel : Level
	{
	  public const int TRACE_INT = 9900;

	  public const string TRACE_STR = "TRACE";

	  public static readonly Log4jTraceLevel TRACE = new Log4jTraceLevel(9900, "TRACE", 7);

	  public static Level toLevel(string paramString, Level paramLevel)
	  {
		if (string.ReferenceEquals(paramString, null))
		{
		  return paramLevel;
		}
		string str = paramString.ToUpper();
		return str.Equals("TRACE") ? TRACE : Level.toLevel(paramString, paramLevel);
	  }

	  public static Level toLevel(string paramString)
	  {
		  return toLevel(paramString, TRACE);
	  }

	  public static Level toLevel(int paramInt)
	  {
		Level level;
		if (paramInt == 9900)
		{
		  level = TRACE;
		}
		else
		{
		  level = Level.toLevel(paramInt);
		}
		return level;
	  }

	  protected internal Log4jTraceLevel(int paramInt1, string paramString, int paramInt2) : base(paramInt1, paramString, paramInt2)
	  {
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\logging\log4j\Log4jTraceLevel.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}