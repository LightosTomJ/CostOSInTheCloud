using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.license.model
{

	[Serializable]
	public class LicenseFromGenerator
	{
//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  internal string Ip_Conflict;

	  internal string companyName;

	  private IList<LicenseSerialNumberData> licenseSerialNumberDatas = new List<object>();

	  public virtual string Ip
	  {
		  get
		  {
			  return this.Ip_Conflict;
		  }
		  set
		  {
			  this.Ip_Conflict = value;
		  }
	  }


	  public virtual string CompanyName
	  {
		  get
		  {
			  return this.companyName;
		  }
		  set
		  {
			  this.companyName = value;
		  }
	  }


	  public virtual IList<LicenseSerialNumberData> LicenseSerialNumberDatas
	  {
		  get
		  {
			  return this.licenseSerialNumberDatas;
		  }
		  set
		  {
			  this.licenseSerialNumberDatas = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\license\model\LicenseFromGenerator.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}