using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.costos.plugin.api
{

	public class ExtensionPropertyDefinition
	{
	  private string propertyName;

	  private string propertyField;

	  private Type propertyType;

	  private object defaultValue;

	  private object propertyValue;

	  private bool passwordType;

	  private bool global;

	  private string description;

	  private IList<string> selList;

	  public ExtensionPropertyDefinition(string paramString1, string paramString2, Type paramClass, object paramObject1, object paramObject2, bool paramBoolean1, bool paramBoolean2, string paramString3)
	  {
		this.propertyName = paramString1;
		this.propertyField = paramString2;
		this.propertyType = paramClass;
		this.defaultValue = paramObject1;
		this.propertyValue = paramObject2;
		this.passwordType = paramBoolean1;
		this.description = paramString3;
		this.global = paramBoolean2;
	  }

	  public virtual string PropertyField
	  {
		  get
		  {
			  return this.propertyField;
		  }
		  set
		  {
			  this.propertyField = value;
		  }
	  }


	  public virtual bool Global
	  {
		  get
		  {
			  return this.global;
		  }
		  set
		  {
			  this.global = value;
		  }
	  }


	  public virtual bool PasswordType
	  {
		  get
		  {
			  return this.passwordType;
		  }
		  set
		  {
			  this.passwordType = value;
		  }
	  }


	  public virtual string Description
	  {
		  get
		  {
			  return this.description;
		  }
		  set
		  {
			  this.description = value;
		  }
	  }


	  public virtual string PropertyName
	  {
		  get
		  {
			  return this.propertyName;
		  }
		  set
		  {
			  this.propertyName = value;
		  }
	  }


	  public virtual Type PropertyType
	  {
		  get
		  {
			  return this.propertyType;
		  }
		  set
		  {
			  this.propertyType = value;
		  }
	  }


	  public virtual object DefaultValue
	  {
		  get
		  {
			  return this.defaultValue;
		  }
		  set
		  {
			  this.defaultValue = value;
		  }
	  }


	  public virtual object PropertyValue
	  {
		  get
		  {
			  return this.propertyValue;
		  }
		  set
		  {
			  this.propertyValue = value;
		  }
	  }


	  public virtual IList<string> SelList
	  {
		  get
		  {
			  return this.selList;
		  }
		  set
		  {
			  this.selList = value;
		  }
	  }

	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\costos\plugin\api\ExtensionPropertyDefinition.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}