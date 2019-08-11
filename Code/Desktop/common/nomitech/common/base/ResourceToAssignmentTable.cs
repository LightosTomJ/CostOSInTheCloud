using System;

namespace Desktop.common.nomitech.common.@base
{
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;

	[Serializable]
	public abstract class ResourceToAssignmentTable : BaseEntity, IComparable
	{
		public abstract Long Id {get;}
	  public static readonly sbyte? QTYPUFORM_NOFORMULA;

	  public static readonly sbyte? QTYPUFORM_BOQ_DEPENDENT;

	  public static readonly sbyte? QTYPUFORM_PRJVAR_DEPENDENT;

	  public static readonly sbyte? QTYPUFORM_BOQ_AND_PRJVAR_DEPENDENT;

	  public static readonly sbyte? QTYPUFORM_BOQ_AND_PRJVAR_INDEPENDENT = (QTYPUFORM_BOQ_AND_PRJVAR_DEPENDENT = (QTYPUFORM_PRJVAR_DEPENDENT = (QTYPUFORM_BOQ_DEPENDENT = (QTYPUFORM_NOFORMULA = Convert.ToSByte((sbyte)0)).valueOf((sbyte)1)).valueOf((sbyte)2)).valueOf((sbyte)3)).valueOf((sbyte)4);

	  public abstract decimal Factor1 {get;}

	  public virtual decimal Factor1
	  {
		  set
		  {
		  }
	  }

	  public abstract decimal Factor2 {get;}

	  public virtual decimal Factor2
	  {
		  set
		  {
		  }
	  }

	  public abstract decimal Factor3 {get;}

	  public virtual decimal Factor3
	  {
		  set
		  {
		  }
	  }

	  public abstract decimal QuantityPerUnit {get;}

	  public virtual decimal QuantityPerUnit
	  {
		  set
		  {
		  }
	  }

	  public virtual decimal LocalFactor
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }


	  public virtual string LocalCountry
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }


	  public virtual string LocalStateProvince
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }


	  public abstract decimal ExchangeRate {get;}

	  public virtual decimal ExchangeRate
	  {
		  set
		  {
		  }
	  }

	  public abstract decimal calculateFinalRate();

	  public virtual decimal FinalRate
	  {
		  set
		  {
		  }
	  }

	  public virtual decimal TotalCost
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }


	  public virtual decimal FixedCost
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }


	  public virtual decimal FinalFixedCost
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }


	  public virtual decimal VariableCost
	  {
		  get
		  {
			  return null;
		  }
		  set
		  {
		  }
	  }


	  public virtual string QuantityPerUnitFormula
	  {
		  get
		  {
			  return "";
		  }
		  set
		  {
		  }
	  }


	  public virtual sbyte? QuantityPerUnitFormulaState
	  {
		  get
		  {
			  return QTYPUFORM_NOFORMULA;
		  }
		  set
		  {
		  }
	  }


	  public virtual string PvVars
	  {
		  get
		  {
			  return "";
		  }
		  set
		  {
		  }
	  }


	  public virtual decimal UnitHours
	  {
		  get
		  {
			  return decimal.One;
		  }
		  set
		  {
		  }
	  }


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @XmlTransient public abstract ResourceWithAssignmentsTable getResourceTable();
	  public abstract ResourceWithAssignmentsTable getResourceTable();

	  public abstract void setResourceTable(ResourceTable paramResourceTable);

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient @XmlTransient public abstract ResourceTable getAssignmentResourceTable();
	  public abstract ResourceTable AssignmentResourceTable {get;set;}


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient public abstract Object clone(boolean paramBoolean1, boolean paramBoolean2);
	  public abstract object clone(bool paramBoolean1, bool paramBoolean2);

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Transient public abstract void setData(ResourceToAssignmentTable paramResourceToAssignmentTable);
	  public abstract ResourceToAssignmentTable Data {set;}

	  public virtual int CompareTo(object paramObject)
	  {
		  return compareLongs(Id, ((ResourceToAssignmentTable)paramObject).Id);
	  }

	  public virtual decimal calculateFinalFixedCost()
	  {
		decimal bigDecimal = decimal.Zero;
		if (FixedCost != null && BigDecimalMath.cmp(FixedCost, decimal.Zero) != 0)
		{
		  bigDecimal = BigDecimalMath.mult(FixedCost, Factor1);
		  bigDecimal = BigDecimalMath.mult(bigDecimal, Factor2);
		  bigDecimal = BigDecimalMath.mult(bigDecimal, Factor3);
		  bigDecimal = BigDecimalMath.mult(bigDecimal, LocalFactor);
		  bigDecimal = BigDecimalMath.mult(bigDecimal, ExchangeRate);
		}
		return bigDecimal;
	  }

	  private int compareLongs(long? paramLong1, long? paramLong2)
	  {
		  return (paramLong1 == null && paramLong2 != null) ? -1 : ((paramLong1 != null && paramLong2 == null) ? 1 : ((paramLong1 != null && paramLong2 != null) ? paramLong1.compareTo(paramLong2) : 0));
	  }
	}


	/* Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\common\base\ResourceToAssignmentTable.class
	 * Java compiler version: 8 (52.0)
	 * JD-Core Version:       1.0.7
	 */
}