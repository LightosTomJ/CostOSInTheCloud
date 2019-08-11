using System;

namespace Desktop.common.nomitech.common.currency
{
	public class InvalidCurrencyException : Exception
	{
	  public InvalidCurrencyException()
	  {
	  }

	  public InvalidCurrencyException(string paramString, Exception paramThrowable) : base(paramString, paramThrowable)
	  {
	  }

	  public InvalidCurrencyException(string paramString) : base(paramString)
	  {
	  }

	  public InvalidCurrencyException(Exception paramThrowable) : base(paramThrowable)
	  {
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\currency\InvalidCurrencyException.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}