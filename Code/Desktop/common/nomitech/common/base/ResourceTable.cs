using System;
using System.Collections.Generic;

namespace Desktop.common.nomitech.common.@base
{

	[Serializable]
	public abstract class ResourceTable : DatabaseTable, Transferable, IComparable
	{
		public override abstract string ToString();
	  public const int OT_NONE = 0;

	  public const int OT_DATABASE_OVERRIDEN = 1;

	  public const int OT_PROJECT_OVERRIDEN = 2;

	  public const int OT_OSTRAKON = 3;

	  public virtual object clone()
	  {
		  return null;
	  }

	  public abstract ResourceTable Data {set;}

	  public abstract void setFieldData(string paramString, ResourceTable paramResourceTable);

	  public abstract string GroupCode {get;set;}

	  public abstract string GekCode {get;set;}

	  public abstract string ExtraCode1 {get;set;}

	  public abstract string ExtraCode2 {get;set;}

	  public abstract string ExtraCode3 {get;set;}

	  public abstract string ExtraCode4 {get;set;}

	  public abstract string ExtraCode5 {get;set;}

	  public abstract string ExtraCode6 {get;set;}

	  public abstract string ExtraCode7 {get;set;}

	  public abstract string ExtraCode8 {get;}

	  public abstract string ExtraCode9 {get;}

	  public abstract string ExtraCode10 {get;}










//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @XmlTransient public java.util.Set<ResourceHistoryTable> getResourceHistorySet()
	  public virtual ISet<ResourceHistoryTable> ResourceHistorySet
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }


	  public abstract string Description {get;set;}


	  public abstract string Title {get;set;}


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @XmlTransient public abstract java.math.BigDecimal getTableRate();
	  public abstract decimal TableRate {get;set;}


	  public abstract string Unit {get;set;}


	  public abstract string Notes {get;set;}


	  public abstract bool? Predicted {get;}

	  public virtual bool? Predicted
	  {
		  set
		  {
		  }
	  }

	  public abstract bool? Virtual {get;}

	  public virtual bool? Virtual
	  {
		  set
		  {
		  }
	  }

	  public virtual bool? Conceptual
	  {
		  get
		  {
			  return false;
		  }
		  set
		  {
		  }
	  }


	  public virtual bool? Quoted
	  {
		  get
		  {
			  return false;
		  }
		  set
		  {
		  }
	  }


	  public abstract decimal Quantity {get;set;}


	  public abstract string Project {get;set;}


	  public abstract string ItemCode {get;set;}


	  public virtual int? OverrideType
	  {
		  get
		  {
			  return Convert.ToInt32(0);
		  }
		  set
		  {
		  }
	  }


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient public abstract void recalculate();
	  public abstract void recalculate();

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @XmlTransient public abstract java.util.Set getAssemblyAssignments();
	  public abstract ISet<object> AssemblyAssignments {get;}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @XmlTransient public abstract java.util.Set getBoqItemAssignments();
	  public abstract ISet<object> BoqItemAssignments {get;}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @XmlTransient public void setDatabaseId(System.Nullable<long> paramLong)
	  public virtual long? DatabaseId
	  {
		  set
		  {
		  }
		  get
		  {
			  return null;
		  }
	  }


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @XmlTransient public void setDatabaseCreationDate(System.Nullable<long> paramLong)
	  public virtual long? DatabaseCreationDate
	  {
		  set
		  {
		  }
		  get
		  {
			  return null;
		  }
	  }


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @XmlTransient public java.math.BigDecimal getBuildUpRate()
	  public virtual decimal BuildUpRate
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @XmlTransient public java.math.BigDecimal getRateForCalculation()
	  public virtual decimal RateForCalculation
	  {
		  get
		  {
			  return TableRate;
		  }
	  }
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @XmlTransient public java.math.BigDecimal getTotalRate()
	  public virtual decimal TotalRate
	  {
		  get
		  {
			  return TableRate;
		  }
	  }

	  public virtual long? Id
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }


//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public Object getTransferData(java.awt.datatransfer.DataFlavor paramDataFlavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
	  public virtual object getTransferData(DataFlavor paramDataFlavor)
	  {
		  return null;
	  }

	  public virtual DataFlavor[] TransferDataFlavors
	  {
		  get
		  {
			  return new DataFlavor[0];
		  }
	  }

	  public virtual bool isDataFlavorSupported(DataFlavor paramDataFlavor)
	  {
		  return false;
	  }

	  public virtual string EditorId
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }

	  public virtual string CreateUserId
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }

	  public virtual DateTime CreateDate
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }

	  public virtual DateTime LastUpdate
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }





	  public virtual bool checkWriteProtected()
	  {
		  return false;
	  }

	  public virtual int CompareTo(object paramObject)
	  {
		  return Id.compareTo(((ResourceTable)paramObject).Id);
	  }

	  public virtual string toAddress()
	  {
//JAVA TO C# CONVERTER WARNING: The .NET Type.FullName property will not always yield results identical to the Java Class.getName method:
		  return this.GetType().FullName + "@" + GetHashCode().ToString("x");
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\ResourceTable.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}