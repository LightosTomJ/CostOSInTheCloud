using System;

namespace Desktop.common.nomitech.common.expr
{

	[Serializable]
	public class ExprDefinition
	{
	  protected internal string name;

	  protected internal string returnType;

	  protected internal string shortDescription;

	  public ExprDefinition(string paramString1, string paramString2, string paramString3)
	  {
		this.name = paramString1;
		this.returnType = paramString2;
		this.shortDescription = paramString3;
	  }

	  public virtual string ReturnType
	  {
		  get
		  {
			  return this.returnType;
		  }
		  set
		  {
			  this.returnType = value;
		  }
	  }


	  public virtual string ShortDescription
	  {
		  get
		  {
			  return this.shortDescription;
		  }
		  set
		  {
			  this.shortDescription = value;
		  }
	  }


	  public virtual string Name
	  {
		  get
		  {
			  return this.name;
		  }
		  set
		  {
			  this.name = value;
		  }
	  }


	  public virtual string Definition
	  {
		  get
		  {
			  return Usage + " : " + ReturnType;
		  }
	  }

	  public virtual string Usage
	  {
		  get
		  {
			  return this.name;
		  }
	  }

	  public override string ToString()
	  {
		  return Definition;
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\expr\ExprDefinition.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}