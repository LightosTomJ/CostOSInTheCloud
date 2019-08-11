using System;

namespace Desktop.common.nomitech.common.migration.richardson
{
	public class RichardsonRapidDetail
	{
	  private string itemSerial;

	  private double qty;

	  private double conversionFactor;

	  public RichardsonRapidDetail(string paramString, double paramDouble)
	  {
		this.itemSerial = paramString;
		this.conversionFactor = 1.0D;
		this.qty = paramDouble;
	  }

	  public RichardsonRapidDetail(string paramString, double paramDouble, double? paramDouble1)
	  {
		this.itemSerial = paramString;
		this.conversionFactor = paramDouble1.Value;
		this.qty = paramDouble;
	  }

	  public virtual string ItemSerial
	  {
		  get
		  {
			  return this.itemSerial;
		  }
		  set
		  {
			  this.itemSerial = value;
		  }
	  }


	  public virtual double Qty
	  {
		  get
		  {
			  return this.qty;
		  }
		  set
		  {
			  this.qty = value;
		  }
	  }


	  public virtual double? ConversionFactor
	  {
		  get
		  {
			  return Convert.ToDouble(this.conversionFactor);
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\migration\richardson\RichardsonRapidDetail.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}