using System.Collections.Generic;

namespace Desktop.common.nomitech.common.expr
{
	using LocalizationFactorTable = nomitech.common.db.local.LocalizationFactorTable;
	using ExprString = org.boris.expr.ExprString;

	public class ExprLocation : ExprString
	{
	  private IList<LocalizationFactorTable> factors = new List<object>(0);

	  public ExprLocation(string paramString) : base(paramString)
	  {
	  }

	  public ExprLocation(string paramString, IList<LocalizationFactorTable> paramList) : base(paramString)
	  {
	  }

	  public virtual IList<LocalizationFactorTable> Factors
	  {
		  get
		  {
			  return this.factors;
		  }
	  }

	  public virtual LocalizationFactorTable FirstFactor
	  {
		  get
		  {
			  return (this.factors.Count == 0) ? null : (LocalizationFactorTable)this.factors[0];
		  }
	  }

	  public virtual string Country
	  {
		  get
		  {
			  return (FirstFactor == null) ? "US" : FirstFactor.ToCountry;
		  }
	  }

	  public virtual string City
	  {
		  get
		  {
			  return (FirstFactor == null) ? "" : FirstFactor.ToCity;
		  }
	  }

	  public virtual string State
	  {
		  get
		  {
			  return (FirstFactor == null) ? "" : FirstFactor.ToState;
		  }
	  }

	  public virtual string ZipCode
	  {
		  get
		  {
			  return (FirstFactor == null) ? "" : FirstFactor.ToZipCode;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\ExprLocation.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}