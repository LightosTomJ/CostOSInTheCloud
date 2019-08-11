using System;

namespace Desktop.common.nomitech.common.auth
{

	[Serializable]
	public class LdapData
	{
	  private string profile;

	  private string type;

	  private string hostname;

	  private int? port;

	  private bool? isSSL;

	  private string bindDn;

	  private string statusMsg;

	  private string password;

	  private string baseDN;

	  private string searchFilter;

	  private bool? enable;

	  private decimal syncTime;

	  public virtual string Hostname
	  {
		  get
		  {
			  return this.hostname;
		  }
		  set
		  {
			  this.hostname = value;
		  }
	  }

	  public virtual string Type
	  {
		  get
		  {
			  return this.type;
		  }
		  set
		  {
			  this.type = value;
		  }
	  }


	  public virtual string BindDn
	  {
		  get
		  {
			  return this.bindDn;
		  }
		  set
		  {
			  this.bindDn = value;
		  }
	  }



	  public virtual int? Port
	  {
		  get
		  {
			  return this.port;
		  }
		  set
		  {
			  this.port = value;
		  }
	  }


	  public virtual string Password
	  {
		  get
		  {
			  return this.password;
		  }
		  set
		  {
			  this.password = value;
		  }
	  }


	  public virtual string BaseDN
	  {
		  get
		  {
			  return this.baseDN;
		  }
		  set
		  {
			  this.baseDN = value;
		  }
	  }


	  public virtual string SearchFilter
	  {
		  get
		  {
			  return this.searchFilter;
		  }
		  set
		  {
			  this.searchFilter = value;
		  }
	  }


	  public virtual decimal SyncTime
	  {
		  get
		  {
			  return this.syncTime;
		  }
		  set
		  {
			  this.syncTime = value;
		  }
	  }


	  public virtual bool? IsSSL
	  {
		  get
		  {
			  return this.isSSL;
		  }
		  set
		  {
			  this.isSSL = value;
		  }
	  }


	  public virtual bool? Enable
	  {
		  get
		  {
			  return this.enable;
		  }
		  set
		  {
			  this.enable = value;
		  }
	  }


	  public virtual string StatusMsg
	  {
		  get
		  {
			  return this.statusMsg;
		  }
		  set
		  {
			  this.statusMsg = value;
		  }
	  }


	  public virtual string Profile
	  {
		  get
		  {
			  return this.profile;
		  }
		  set
		  {
			  this.profile = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\auth\LdapData.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}