using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.currency
{

	public class Currency : object, IComparable<Currency>
	{
	  private string name;

	  private string symbol;

	  private string code;

	  private string flag;

	  public Currency()
	  {
	  }

	  public Currency(string paramString1, string paramString2, string paramString3, string paramString4)
	  {
		this.name = paramString1;
		this.symbol = paramString2;
		this.code = paramString4;
		this.flag = paramString3;
	  }

	  public virtual string Name
	  {
		  get
		  {
			  return this.name;
		  }
		  set
		  {
			  this.name = value;
		  }
	  }


	  public virtual string Symbol
	  {
		  get
		  {
			  return this.symbol;
		  }
		  set
		  {
			  this.symbol = value;
		  }
	  }


	  public virtual string Code
	  {
		  get
		  {
			  return this.code;
		  }
		  set
		  {
			  this.code = value;
		  }
	  }


	  public virtual string Flag
	  {
		  get
		  {
			  return this.flag;
		  }
		  set
		  {
			  this.flag = value;
		  }
	  }


	  public override string ToString()
	  {
		  return this.name;
	  }

	  public override bool Equals(object paramObject)
	  {
		if (!(paramObject is Currency))
		{
		  return false;
		}
		Currency currency = (Currency)paramObject;
		return (currency.name.Equals(this.name) && currency.symbol.Equals(this.symbol) && currency.code.Equals(this.code));
	  }

	  public virtual int CompareTo(Currency paramCurrency)
	  {
		  return paramCurrency.code.CompareTo(this.code);
	  }

	  public class CurrencyComparator : object, IComparer<Currency>
	  {
		public virtual int Compare(Currency param1Currency1, Currency param1Currency2)
		{
			return param1Currency1.name.CompareTo(param1Currency2.name);
		}
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\currency\Currency.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}