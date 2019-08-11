using System.Collections.Generic;

namespace Desktop.common.nomitech.common.license
{

	public class LicenceComparator : object, IComparer<LicenseRowItem>
	{
	  public virtual int Compare(LicenseRowItem paramLicenseRowItem1, LicenseRowItem paramLicenseRowItem2)
	  {
		  return paramLicenseRowItem1.Serial.CompareTo(paramLicenseRowItem2.Serial);
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\license\LicenceComparator.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}