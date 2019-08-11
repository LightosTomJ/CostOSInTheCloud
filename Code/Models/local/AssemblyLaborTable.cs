using System;

namespace Models.local
{


	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceWithAssignmentsTable = nomitech.common.@base.ResourceWithAssignmentsTable;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using UIPropertiesUtil = nomitech.common.util.UIPropertiesUtil;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="ASSEMBLY_LABOR"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class AssemblyLaborTable : ResourceToAssignmentTable, ProjectIdEntity
	{

		public static readonly string[] FIELDS = new string[] {"factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "finalRate", "fixedCost", "finalFixedCost", "comment"};

		private long? assemblyLaborId = null;
		private DateTime lastUpdate = null;
		private decimal factor1 = null;
		private decimal factor2 = null;
		private decimal factor3 = null;
		private decimal quantityPerUnit = null;
		private string quantityPerUnitFormula;
		private sbyte? quantityPerUnitFormulaState;
		private decimal localFactor;
		private string localCountry;
		private string localStateProvince;
		private decimal exchangeRate = null;
		private long? laborTableId = null;
		private decimal finalRate;
		private decimal finalIKARate;
		private decimal fixedCost = decimal.Zero;
		private decimal finalFixedCost = decimal.Zero;
		private string comment;
		/// <summary>
		/// This String declares which SQL COLUMN contains which PV Variables
		/// 	e.g. <code>CUSRATE1FORM:var1,var2;CUSTXT1FORM:mitsos,george;MARKUPFORM:var2,mitsos</code>
		/// </summary>
		private string pvVars;

		/// <summary>
		/// This decimal declares the number of hours for this resource unit e.g. HOUR: 1h, DAY1: 4h, MONTH1: 160h
		/// This number is also in ProjectDBProperties [PRJPROP] for ProjectDB and UIProperties (UnitAliasUtil) [GLBPROP] for MasterDB
		/// </summary>
		private decimal unitHours;

		private LaborTable laborTable = null;
		private AssemblyTable assemblyTable;

		public AssemblyLaborTable()
		{

		}

		public virtual object valueForField(string field)
		{
			return null;
		}

		public virtual object scaledValueForField(string field)
		{
			return null;
		}

		public virtual object clone(bool cloneAssembly, bool cloneLabor)
		{
			AssemblyLaborTable obj = new AssemblyLaborTable();

			obj.AssemblyLaborId = AssemblyLaborId;
			obj.LastUpdate = LastUpdate;

			obj.Factor1 = Factor1;
			obj.Factor2 = Factor2;
			obj.Factor3 = Factor3;

			obj.QuantityPerUnit = QuantityPerUnit;
			obj.QuantityPerUnitFormula = QuantityPerUnitFormula;
			obj.QuantityPerUnitFormulaState = QuantityPerUnitFormulaState;

			obj.LocalFactor = LocalFactor;
			obj.LocalCountry = LocalCountry;
			obj.LocalStateProvince = LocalStateProvince;
			obj.ExchangeRate = ExchangeRate;
			obj.LaborTableId = LaborTableId;
			obj.ProjectId = ProjectId;
			obj.FixedCost = FixedCost;
			obj.Comment = Comment;
			obj.PvVars = PvVars;

			obj.UnitHours = UnitHours;

			try
			{
				obj.FinalRate = calculateFinalRate();
				obj.FinalFixedCost = calculateFinalFixedCost();
			}
			catch (System.NullReferenceException)
			{
				// ignore!
			}

			try
			{
				obj.FinalIKARate = calculateFinalIKARate();
			}
			catch (System.NullReferenceException)
			{
				// ignore!
			}

			if (AssemblyTable != null && cloneAssembly)
			{
			   obj.AssemblyTable = (AssemblyTable)AssemblyTable.clone();
			}

			if (LaborTable != null && cloneLabor)
			{
			   obj.LaborTable = (LaborTable)LaborTable.clone();
			}

			return obj;
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="ASSEMBLYLABORID" </summary>
		/// <returns> Long </returns>
		public virtual long? AssemblyLaborId
		{
			get
			{
				return assemblyLaborId;
			}
			set
			{
				assemblyLaborId = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LASTUPDATE" type="timestamp" </summary>
		/// <returns> lastUpdate </returns>
		public virtual DateTime LastUpdate
		{
			get
			{
				return lastUpdate;
			}
			set
			{
				lastUpdate = value;
			}
		}

		public virtual decimal calculateFinalRate()
		{

			if (AssemblyTable != null && LaborTable != null)
			{
				finalRate = LaborTable.RateForCalculation * Factor1;
				finalRate = finalRate * Factor2;
				finalRate = finalRate * Factor3;
				finalRate = finalRate * LocalFactor;
				finalRate = finalRate * ExchangeRate;

				if (AssemblyTable.ActivityBased != null && AssemblyTable.ActivityBased.Equals(false))
				{
					finalRate = finalRate * QuantityPerUnit;
					finalRate = BigDecimalMath.div(finalRate, UnitHours);
				}
				else
				{
					try
					{
						decimal fDiv = BigDecimalMath.mult(AssemblyTable.Productivity, UnitHours);
						finalRate = BigDecimalMath.div(finalRate, fDiv);
					}
					catch (ArithmeticException)
					{
						finalRate = BigDecimalMath.ZERO;
					}
				}
				finalRate = finalRate.setScale(10,decimal.ROUND_HALF_UP);
			}

			return finalRate;
		}

		/// <summary>
		/// @hibernate.property column="FRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalRate
		{
			get
			{
				if (AssemblyTable != null && LaborTable != null)
				{
					return calculateFinalRate();
				}
				return finalRate;
			}
			set
			{
				finalRate = value;
			}
		}


		public virtual decimal calculateFinalIKARate()
		{
			if (AssemblyTable != null && LaborTable != null)
			{
				finalIKARate = LaborTable.IKA * Factor1;
				finalIKARate = finalIKARate * Factor2;
				finalIKARate = finalIKARate * Factor3;
				finalIKARate = finalIKARate * LocalFactor;
				finalIKARate = finalIKARate * ExchangeRate;

				if (AssemblyTable.ActivityBased != null && AssemblyTable.ActivityBased.Equals(false))
				{
					finalRate = finalRate * QuantityPerUnit;
				}
				else
				{
					try
					{
						finalIKARate = BigDecimalMath.div(finalIKARate, BigDecimalMath.mult(AssemblyTable.Productivity, UnitHours));
					}
					catch (ArithmeticException)
					{
						finalIKARate = BigDecimalMath.ZERO;
					}
				}

				finalIKARate = finalIKARate.setScale(10,decimal.ROUND_HALF_UP);
			}

			return finalIKARate;
		}

		/// <summary>
		/// @hibernate.property column="FIKARATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalIKARate
		{
			get
			{
				if (AssemblyTable != null && LaborTable != null)
				{
					return calculateFinalRate();
				}
				return finalRate;
			}
			set
			{
				finalIKARate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FACTOR1" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Factor1
		{
			get
			{
				return factor1;
			}
			set
			{
				//value = value.setScale(DBPreferences.getInstance().getBigDecimalScale());		
				factor1 = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FACTOR2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Factor2
		{
			get
			{
				return factor2;
			}
			set
			{
				//value = value.setScale(DBPreferences.getInstance().getBigDecimalScale());		
				factor2 = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FACTOR3" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Factor3
		{
			get
			{
				return factor3;
			}
			set
			{
				//value = value.setScale(DBPreferences.getInstance().getBigDecimalScale());
				factor3 = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="QTYPUNIT" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> quantityPerUnit </returns>
		public virtual decimal QuantityPerUnit
		{
			get
			{
				return quantityPerUnit;
			}
			set
			{
				this.quantityPerUnit = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="QTYPUNITFORM" type="costos_text" </summary>
		/// <returns> quantityPerUnitFormula </returns>
		public virtual string QuantityPerUnitFormula
		{
			get
			{
				return quantityPerUnitFormula;
			}
			set
			{
				this.quantityPerUnitFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="QTYPUFORMSTATE" type="byte" </summary>
		/// <returns> quantityPerUnitFormulaState </returns>
		public virtual sbyte? QuantityPerUnitFormulaState
		{
			get
			{
				return quantityPerUnitFormulaState;
			}
			set
			{
				this.quantityPerUnitFormulaState = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LOCALFACTOR" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal LocalFactor
		{
			get
			{
				return localFactor;
			}
			set
			{
				this.localFactor = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LOCALCOUNTRY" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string LocalCountry
		{
			get
			{
				return localCountry;
			}
			set
			{
				this.localCountry = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LOCALSTATE"  type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string LocalStateProvince
		{
			get
			{
				return localStateProvince;
			}
			set
			{
				this.localStateProvince = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EXCHANGERATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal ExchangeRate
		{
			get
			{
				if (exchangeRate == null)
				{
					exchangeRate = decimal.One;
				}
				return exchangeRate;
			}
			set
			{
				if (value == null)
				{
					value = decimal.One;
				}
				this.exchangeRate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FIXEDCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> fixedCost </returns>
		public virtual decimal FixedCost
		{
			get
			{
				return fixedCost;
			}
			set
			{
				this.fixedCost = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FINALFIXEDCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> finalFixedCost </returns>
		public virtual decimal FinalFixedCost
		{
			get
			{
				finalFixedCost = calculateFinalFixedCost();
				return finalFixedCost;
			}
			set
			{
				this.finalFixedCost = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="UNITHOURS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> unitHours </returns>
		public virtual decimal UnitHours
		{
			get
			{
				if (LaborTable != null && !LaborTable.Unit.Equals("HOUR"))
				{
					if (ProjectDBUtil.currentProjectDBUtil() == null)
					{
						unitHours = UIPropertiesUtil.getHoursFromUnit(LaborTable.Unit);
					}
					else
					{
						unitHours = ProjectDBUtil.currentProjectDBUtil().Properties.getHoursFromUnit(LaborTable.Unit);
					}
				}
				else
				{
					unitHours = decimal.One;
				}
				return unitHours;
			}
			set
			{
				this.unitHours = value;
			}
		}


		/// <summary>
		/// This String declares which SQL COLUMN contains which PV Variables
		/// e.g. <code>CUSRATE1FORM:var1,var2;CUSTXT1FORM:mitsos,george;MARKUPFORM:var2,mitsos</code>
		/// 
		/// @hibernate.property column="PV_VARS" type="costos_text" </summary>
		/// <returns> pvVars </returns>
		public virtual string PvVars
		{
			get
			{
				return pvVars;
			}
			set
			{
				this.pvVars = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="LABORID" </summary>
		/// <returns> LaborTable </returns>
		public virtual LaborTable LaborTable
		{
			get
			{
				return laborTable;
			}
			set
			{
				this.laborTable = value;
				if (value != null)
				{
					LaborTableId = value.LaborId;
				}
			}
		}

		public virtual long? LaborTableId
		{
			get
			{
				return laborTableId;
			}
			set
			{
				this.laborTableId = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="ASSEMBLYID" </summary>
		/// <returns> AssemblyTable </returns>
		public virtual AssemblyTable AssemblyTable
		{
			get
			{
				return assemblyTable;
			}
			set
			{
				assemblyTable = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COMMENT" type="costos_text" </summary>
		/// <returns> comment </returns>
		public virtual string Comment
		{
			get
			{
				return comment;
			}
			set
			{
				this.comment = value;
			}
		}


		public virtual AssemblyLaborTable Data
		{
			set
			{
				AssemblyLaborId = value.AssemblyLaborId;
				LastUpdate = value.LastUpdate;
				//obj.setFinalRate(getFinalRate());
				Factor1 = value.Factor1;
				Factor2 = value.Factor2;
				Factor3 = value.Factor3;
    
				QuantityPerUnit = value.QuantityPerUnit;
				QuantityPerUnitFormula = value.QuantityPerUnitFormula;
				QuantityPerUnitFormulaState = value.QuantityPerUnitFormulaState;
    
				LocalFactor = value.LocalFactor;
				LocalCountry = value.LocalCountry;
				LocalStateProvince = value.LocalStateProvince;
				ExchangeRate = value.ExchangeRate;
				FixedCost = value.FixedCost;
				Comment = value.Comment;
				PvVars = value.PvVars;
    
				UnitHours = value.UnitHours;
    
				try
				{
					FinalRate = value.calculateFinalRate();
					FinalFixedCost = value.calculateFinalFixedCost();
				}
				catch (System.NullReferenceException)
				{
					// ignore!
				}
    
				try
				{
					FinalIKARate = value.calculateFinalIKARate();
				}
				catch (System.NullReferenceException)
				{
					// ignore!
				}
			}
		}

		public override long? Id
		{
			get
			{
				return AssemblyLaborId;
			}
		}

		public override ResourceWithAssignmentsTable getResourceTable()
		{
			return AssemblyTable;
		}

		public override ResourceTable AssignmentResourceTable
		{
			get
			{
				return LaborTable;
			}
			set
			{
				LaborTable = (LaborTable) value;
			}
		}

		public override ResourceToAssignmentTable Data
		{
			set
			{
				Data = (AssemblyLaborTable)value;
			}
		}

		public override void setResourceTable(ResourceTable resourceTable)
		{
			AssemblyTable = (AssemblyTable) resourceTable;
		}


		private long? projectId;
		//#RXL_START
		/// <summary>
		/// @hibernate.property column="PRJID" type="long" index="IDX_PRJID" </summary>
		/// <returns> BigDecimal </returns>
		//#RXL_END
		public override long? ProjectId
		{
			get
			{
				return projectId;
			}
			set
			{
				this.projectId = value;
			}
		}


	}
}