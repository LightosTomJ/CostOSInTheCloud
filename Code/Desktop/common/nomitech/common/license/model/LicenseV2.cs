using System.Collections.Generic;

namespace Desktop.common.nomitech.common.license.model
{

	public class LicenseV2
	{
//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private string Ip_Conflict;

	  private string companyName;

	  private bool notForResale;

	  private string id;

	  private IList<LicenseSerialNumberDataV2> licenseSerialNumberDatas = new List<object>();

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


	  public virtual IList<LicenseSerialNumberDataV2> LicenseSerialNumberDatas
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


	  public virtual bool NotForResale
	  {
		  get
		  {
			  return this.notForResale;
		  }
		  set
		  {
			  this.notForResale = value;
		  }
	  }


	  public virtual string Id
	  {
		  get
		  {
			  return this.id;
		  }
		  set
		  {
			  this.id = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\license\model\LicenseV2.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}