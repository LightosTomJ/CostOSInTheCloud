using System.Collections.Generic;

namespace Desktop.common.nomitech.common.license.model
{

	public class LicenseSerialNumberDataV2
	{
	  private bool isTrial;

	  private int expirationDate;

	  private string supportExpirationDate;

	  private string serialKey;

	  private ISet<string> plgins = new HashSet<object>();

	  public virtual bool Trial
	  {
		  get
		  {
			  return this.isTrial;
		  }
		  set
		  {
			  this.isTrial = value;
		  }
	  }


	  public virtual int ExpirationDate
	  {
		  get
		  {
			  return this.expirationDate;
		  }
		  set
		  {
			  this.expirationDate = value;
		  }
	  }


	  public virtual string SupportExpirationDate
	  {
		  get
		  {
			  return this.supportExpirationDate;
		  }
		  set
		  {
			  this.supportExpirationDate = value;
		  }
	  }


	  public virtual string SerialKey
	  {
		  get
		  {
			  return this.serialKey;
		  }
		  set
		  {
			  this.serialKey = value;
		  }
	  }


	  public virtual ISet<string> Plgins
	  {
		  get
		  {
			  return this.plgins;
		  }
		  set
		  {
			  this.plgins = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\license\model\LicenseSerialNumberDataV2.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}