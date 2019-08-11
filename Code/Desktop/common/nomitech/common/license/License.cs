using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.license
{

	[Serializable]
	public class License
	{
	  private ISet<LicenseRowItem> rowItems;

	  public virtual ISet<LicenseRowItem> RowItems
	  {
		  get
		  {
			  return this.rowItems;
		  }
		  set
		  {
			  this.rowItems = value;
		  }
	  }


	  public virtual void addRowItemToSet(LicenseRowItem paramLicenseRowItem)
	  {
		if (this.rowItems == null)
		{
		  this.rowItems = new HashSet<object>();
		}
		this.rowItems.Add(paramLicenseRowItem);
	  }

	  public override bool Equals(object paramObject)
	  {
		if (!(paramObject is License))
		{
		  return false;
		}
		if (paramObject == this)
		{
		  return true;
		}
		License license = (License)paramObject;
		if (RowItems.Count != license.RowItems.Count)
		{
		  return false;
		}
		foreach (LicenseRowItem licenseRowItem in license.RowItems)
		{
		  if (!this.rowItems.Contains(licenseRowItem))
		  {
			return false;
		  }
		}
		return true;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\license\License.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}