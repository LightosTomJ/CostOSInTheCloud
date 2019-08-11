using System;
using System.Text;
using System.Threading;

namespace Desktop.common.nomitech.common.logging.simple
{

	internal sealed class SimpleLogger : Logger
	{
	  private const string ERROR = "ERROR";

	  private const string WARN = "WARN ";

	  private const string INFO = "INFO ";

	  private const string DEBUG = "DEBUG";

	  private const string TRACE = "TRACE";

	  private SimpleDateFormat formatter = null;

	  private FieldPosition fieldPosition = null;

	  private string printClass = null;

	  internal SimpleLogger(string paramString, SimpleDateFormat paramSimpleDateFormat)
	  {
		this.formatter = paramSimpleDateFormat;
		this.fieldPosition = new FieldPosition(2);
		this.printClass = paramString.Substring(paramString.LastIndexOf('.') + 1);
	  }

	  public override void error(object paramObject)
	  {
		  log("ERROR", paramObject);
	  }

	  public override void warn(object paramObject)
	  {
		  log("WARN ", paramObject);
	  }

	  public override void info(object paramObject)
	  {
		  log("INFO ", paramObject);
	  }

	  public override void debug(object paramObject)
	  {
		  log("DEBUG", paramObject);
	  }

	  public override void trace(object paramObject)
	  {
		  log("TRACE", paramObject);
	  }

	  public override void error(object paramObject, Exception paramThrowable)
	  {
		  log("ERROR", paramObject, paramThrowable);
	  }

	  public override void warn(object paramObject, Exception paramThrowable)
	  {
		  log("WARN ", paramObject, paramThrowable);
	  }

	  public override void info(object paramObject, Exception paramThrowable)
	  {
		  log("INFO ", paramObject, paramThrowable);
	  }

	  public override void debug(object paramObject, Exception paramThrowable)
	  {
		  log("DEBUG", paramObject, paramThrowable);
	  }

	  public override void trace(object paramObject, Exception paramThrowable)
	  {
		  log("TRACE", paramObject, paramThrowable);
	  }

	  public override bool InfoEnabled
	  {
		  get
		  {
			  return true;
		  }
	  }

	  public override bool DebugEnabled
	  {
		  get
		  {
			  return true;
		  }
	  }

	  public override bool TraceEnabled
	  {
		  get
		  {
			  return true;
		  }
	  }

	  private void log(string paramString, object paramObject)
	  {
		if (paramObject != null)
		{
		  StringBuilder stringBuffer = new StringBuilder(120);
		  this.formatter.format(DateTime.Now, stringBuffer, this.fieldPosition);
		  stringBuffer.Append(" [").Append(Thread.CurrentThread.Name).Append("]");
		  stringBuffer.Append(" ").Append(paramString);
		  stringBuffer.Append(" ").Append(this.printClass);
		  stringBuffer.Append(" - ").Append(paramObject.ToString());
		  Console.WriteLine(stringBuffer);
		}
	  }

	  private void log(string paramString, object paramObject, Exception paramThrowable)
	  {
		log(paramString, paramObject);
		paramThrowable.printStackTrace(System.out);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\logging\simple\SimpleLogger.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}