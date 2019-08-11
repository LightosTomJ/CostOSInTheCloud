using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.license.model
{

	[Serializable]
	public class LicenseSerialNumberData
	{
	  private string expirationDate;

	  private string supportExpirationDate;

	  private string serialKey;

	  private ISet<string> plgins = new HashSet<object>();

	  public virtual string ExpirationDate
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


	  public virtual void clone(LicenseSerialNumberData paramLicenseSerialNumberData)
	  {
		SerialKey = paramLicenseSerialNumberData.SerialKey;
		ExpirationDate = paramLicenseSerialNumberData.ExpirationDate;
		SupportExpirationDate = paramLicenseSerialNumberData.SupportExpirationDate;
		Plgins = paramLicenseSerialNumberData.Plgins;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\license\model\LicenseSerialNumberData.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}