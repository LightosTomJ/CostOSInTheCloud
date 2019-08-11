using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.license
{
	using LicenseSerialNumberData = Desktop.common.nomitech.common.license.model.LicenseSerialNumberData;
	using LicenseSerialNumberDataV2 = Desktop.common.nomitech.common.license.model.LicenseSerialNumberDataV2;

	[Serializable]
	public class LicenseRowItem
	{
	  private bool checkedIn;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private string CID_Conflict;

	  private string userid;

	  private string checkedInDate;

	  private string expDate;

	  private ISet<string> plugIns;

	  private string serial;

	  private string supportExpirationDate;

	  private string companyName;

	  private string serverIP;

	  private int trialDays;

	  private bool isTrial;

	  private int version;

	  public virtual int Version
	  {
		  set
		  {
			  this.version = value;
		  }
		  get
		  {
			  return this.version;
		  }
	  }


	  public virtual bool IsTrial
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


	  public virtual int TrialDays
	  {
		  get
		  {
			  return this.trialDays;
		  }
		  set
		  {
			  this.trialDays = value;
		  }
	  }


	  public virtual string ServerIP
	  {
		  get
		  {
			  return this.serverIP;
		  }
		  set
		  {
			  this.serverIP = value;
		  }
	  }


	  public virtual string Userid
	  {
		  get
		  {
			  return this.userid;
		  }
		  set
		  {
			  this.userid = value;
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


	  public LicenseRowItem()
	  {
	  }

	  public LicenseRowItem(LicenseSerialNumberData paramLicenseSerialNumberData)
	  {
		if (this.plugIns == null)
		{
		  this.plugIns = new HashSet<object>();
		}
		this.checkedIn = false;
		this.CID_Conflict = "NULL";
		this.userid = "NULL";
		this.checkedInDate = "NULL";
		this.expDate = paramLicenseSerialNumberData.ExpirationDate;
		this.plugIns = paramLicenseSerialNumberData.Plgins;
		this.serial = paramLicenseSerialNumberData.SerialKey;
		this.supportExpirationDate = paramLicenseSerialNumberData.ExpirationDate;
		this.isTrial = false;
		this.trialDays = -1;
		if (this.plugIns != null)
		{
		  foreach (string str in this.plugIns)
		  {
			if (!string.ReferenceEquals(str, null))
			{
			  str = str.ToLower();
			  continue;
			}
			str = "-";
		  }
		}
	  }

	  public LicenseRowItem(LicenseSerialNumberDataV2 paramLicenseSerialNumberDataV2)
	  {
		if (this.plugIns == null)
		{
		  this.plugIns = new HashSet<object>();
		}
		this.checkedIn = false;
		this.CID_Conflict = "NULL";
		this.userid = "NULL";
		this.checkedInDate = "NULL";
		this.expDate = "NULL";
		this.plugIns = paramLicenseSerialNumberDataV2.Plgins;
		this.serial = paramLicenseSerialNumberDataV2.SerialKey;
		this.isTrial = paramLicenseSerialNumberDataV2.Trial;
		this.trialDays = paramLicenseSerialNumberDataV2.ExpirationDate;
		this.supportExpirationDate = paramLicenseSerialNumberDataV2.SupportExpirationDate;
		if (this.plugIns != null)
		{
		  foreach (string str in this.plugIns)
		  {
			if (!string.ReferenceEquals(str, null))
			{
			  str = str.ToLower();
			  continue;
			}
			str = "-";
		  }
		}
	  }

	  public virtual bool CheckedIn
	  {
		  get
		  {
			  return this.checkedIn;
		  }
		  set
		  {
			  this.checkedIn = value;
		  }
	  }


	  public virtual string CID
	  {
		  get
		  {
			  return this.CID_Conflict;
		  }
		  set
		  {
			  this.CID_Conflict = value;
		  }
	  }


	  public virtual string CheckedInDate
	  {
		  get
		  {
			  return this.checkedInDate;
		  }
		  set
		  {
			  this.checkedInDate = value;
		  }
	  }


	  public virtual string ExpDate
	  {
		  get
		  {
			  return (string.ReferenceEquals(this.expDate, null)) ? "NULL" : this.expDate.ToString();
		  }
		  set
		  {
			  this.expDate = value;
		  }
	  }


	  public virtual ISet<string> PlugIns
	  {
		  get
		  {
			  return this.plugIns;
		  }
		  set
		  {
			  this.plugIns = value;
		  }
	  }


	  public virtual string Serial
	  {
		  get
		  {
			  return this.serial;
		  }
		  set
		  {
			  this.serial = value;
		  }
	  }


	  public override string ToString()
	  {
		null = "" + this.checkedIn + "," + this.CID_Conflict + "," + this.userid + "," + CheckedInDate + "," + ExpDate.ToString() + ",";
		foreach (string str in this.plugIns)
		{
		  null = null + "," + str + "";
		}
		return null + "," + this.serial;
	  }

	  public override bool Equals(object paramObject)
	  {
		if (!(paramObject is LicenseRowItem))
		{
		  return false;
		}
		if (paramObject == this)
		{
		  return true;
		}
		LicenseRowItem licenseRowItem = (LicenseRowItem)paramObject;
		bool @bool = false;
		if (CheckedIn == licenseRowItem.CheckedIn && CID.Equals(licenseRowItem.CID, StringComparison.OrdinalIgnoreCase) && Userid.Equals(licenseRowItem.Userid, StringComparison.OrdinalIgnoreCase) && CheckedInDate.Equals(licenseRowItem.CheckedInDate) && ExpDate.Equals(licenseRowItem.ExpDate))
		{
		  @bool = true;
		}
		return (@bool && hasSamePlugins(licenseRowItem));
	  }

	  public virtual bool hasSamePlugins(LicenseRowItem paramLicenseRowItem)
	  {
		if (paramLicenseRowItem.PlugIns.Count != paramLicenseRowItem.PlugIns.Count)
		{
		  return false;
		}
		foreach (string str in paramLicenseRowItem.PlugIns)
		{
		  if (!this.plugIns.Contains(str.ToLower()))
		  {
			return false;
		  }
		}
		return true;
	  }

	  public virtual bool? hasSameSerial(string paramString)
	  {
		  return this.serial.Equals(paramString) ? Convert.ToBoolean(true) : Convert.ToBoolean(false);
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


	  public virtual string PluginsCommaSeperated
	  {
		  get
		  {
			string str = "";
			foreach (string str1 in PlugIns)
			{
			  str = str + str1 + ",";
			}
			return str;
		  }
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\license\LicenseRowItem.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}