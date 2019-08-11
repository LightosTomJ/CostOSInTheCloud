using System;

namespace Desktop.common.nomitech.common.migration.rsmeans
{
	using BaseTableItem = nomitech.common.@base.BaseTableItem;
	using StringUtils = nomitech.common.util.StringUtils;

	public class FactorData
	{
	  private string assemblyNumber;

	  private double quantity;

	  private double conversionFactor;

	  private string mf04LineNumber;

	  private string mf95LineNumber;

	  private BaseTableItem baseTableItem;

	  public FactorData(string paramString)
	  {
		this.assemblyNumber = paramString.Substring(0, 12);
		this.mf95LineNumber = paramString.Substring(12, 12);
		this.mf04LineNumber = paramString.Substring(24, 12);
		this.quantity = (Convert.ToDouble(StringUtils.removeAllSpaces(paramString.Substring(36, 14))));
		this.conversionFactor = (Convert.ToDouble(StringUtils.removeAllSpaces(paramString.Substring(50, 12))));
	  }

	  public virtual BaseTableItem BaseTableItem
	  {
		  get
		  {
			  return this.baseTableItem;
		  }
		  set
		  {
			  this.baseTableItem = value;
		  }
	  }


	  public virtual string AssemblyNumber
	  {
		  get
		  {
			  return this.assemblyNumber;
		  }
		  set
		  {
			  this.assemblyNumber = value;
		  }
	  }


	  public virtual double Quantity
	  {
		  get
		  {
			  return this.quantity;
		  }
		  set
		  {
			  this.quantity = value;
		  }
	  }


	  public virtual double ConversionFactor
	  {
		  get
		  {
			  return this.conversionFactor;
		  }
		  set
		  {
			  this.conversionFactor = value;
		  }
	  }


	  public virtual string Mf04LineNumber
	  {
		  get
		  {
			  return this.mf04LineNumber;
		  }
		  set
		  {
			  this.mf04LineNumber = value;
		  }
	  }


	  public virtual string Mf95LineNumber
	  {
		  get
		  {
			  return this.mf95LineNumber;
		  }
		  set
		  {
			  this.mf95LineNumber = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\rsmeans\FactorData.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}