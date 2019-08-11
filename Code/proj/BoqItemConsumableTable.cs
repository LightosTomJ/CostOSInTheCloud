using System;

namespace Models.proj
{


	using BoqItemToAssignmentTable = nomitech.common.@base.BoqItemToAssignmentTable;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceWithAssignmentsTable = nomitech.common.@base.ResourceWithAssignmentsTable;
	using ConsumableTable = nomitech.common.db.local.ConsumableTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	//#RXL_START 
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="BOQITEM_CONSUMABLE"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	[Serializable]
	public class BoqItemConsumableTable : BoqItemToAssignmentTable, ProjectIdEntity
	{

		/// 
		private const long serialVersionUID = 1L;

		public static readonly string[] FIELDS = new string[] {"factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "totalUnits", "finalRate", "totalCost", "fixedCost", "finalFixedCost", "variableCost", "comment"};

		private long? boqItemConsumableId;
		private decimal factor1;
		private decimal factor2;
		private decimal factor3;
		private decimal quantityPerUnit;
		private string quantityPerUnitFormula;
		private sbyte? quantityPerUnitFormulaState;
		private decimal exchangeRate;
		private decimal totalUnits;
		private decimal finalRate;
		private decimal totalCost = null;
		private decimal localFactor;
		private string localCountry;
		private string localStateProvince;
		private bool? hasUserTotalUnits;
		private DateTime lastUpdate;
		private long? paramItemId;
		private ParamItemTable paramItemTable;
		private BoqItemTable boqItemTable;

		// FIXED COST:
		private decimal fixedCost = null;
		private decimal finalFixedCost = decimal.Zero;
		private decimal variableCost = decimal.Zero;

		private ConsumableTable consumableTable;
		private string comment;

		/// <summary>
		/// This String declares which SQL COLUMN contains which PV Variables
		/// 	e.g. <code>CUSRATE1FORM:var1,var2;CUSTXT1FORM:mitsos,george;MARKUPFORM:var2,mitsos</code>
		/// </summary>
		private string pvVars;

		public BoqItemConsumableTable()
		{

		}

		public virtual object clone(bool relations)
		{
			if (relations)
			{
				return clone();
			}

			BoqItemConsumableTable obj = new BoqItemConsumableTable();

			obj.BoqItemConsumableId = BoqItemConsumableId;
			obj.FinalRate = FinalRate;
			obj.TotalCost = TotalCost;
			obj.Factor1 = Factor1;
			obj.Factor2 = Factor2;
			obj.Factor3 = Factor3;

			obj.QuantityPerUnit = QuantityPerUnit;
			obj.QuantityPerUnitFormula = QuantityPerUnitFormula;
			obj.QuantityPerUnitFormulaState = QuantityPerUnitFormulaState;

			obj.TotalUnits = TotalUnits;
			obj.HasUserTotalUnits = HasUserTotalUnits;
			obj.ExchangeRate = ExchangeRate;
			obj.LocalFactor = LocalFactor;
			obj.LocalCountry = LocalCountry;
			obj.LocalStateProvince = LocalStateProvince;
			obj.LastUpdate = LastUpdate;

			obj.FixedCost = FixedCost;
			obj.FinalFixedCost = FinalFixedCost;
			obj.VariableCost = VariableCost;
			obj.Comment = Comment;

			obj.PvVars = PvVars;

			obj.ProjectId = ProjectId;

			return obj;
		}

		public virtual object clone()
		{
			BoqItemConsumableTable obj = new BoqItemConsumableTable();

			obj.BoqItemConsumableId = BoqItemConsumableId;
			obj.FinalRate = FinalRate;
			obj.TotalCost = TotalCost;
			obj.Factor1 = Factor1;
			obj.Factor2 = Factor2;
			obj.Factor3 = Factor3;

			obj.QuantityPerUnit = QuantityPerUnit;
			obj.QuantityPerUnitFormula = QuantityPerUnitFormula;
			obj.QuantityPerUnitFormulaState = QuantityPerUnitFormulaState;

			obj.ExchangeRate = ExchangeRate;
			obj.LocalFactor = LocalFactor;
			obj.LocalCountry = LocalCountry;
			obj.LocalStateProvince = LocalStateProvince;
			obj.TotalUnits = TotalUnits;
			obj.HasUserTotalUnits = HasUserTotalUnits;
			obj.LastUpdate = LastUpdate;

			obj.FixedCost = FixedCost;
			obj.FinalFixedCost = FinalFixedCost;
			obj.VariableCost = VariableCost;
			obj.Comment = Comment;

			obj.PvVars = PvVars;

			obj.ProjectId = ProjectId;

			if (BoqItemTable != null)
			{
				obj.BoqItemTable = (BoqItemTable)BoqItemTable.clone();
			}

			if (ConsumableTable != null)
			{
				obj.ConsumableTable = (ConsumableTable)ConsumableTable.clone();
			}

			return obj;
		}

		public virtual BoqItemConsumableTable Data
		{
			set
			{
				BoqItemConsumableId = value.BoqItemConsumableId;
				LastUpdate = value.LastUpdate;
				Factor1 = value.Factor1;
				Factor2 = value.Factor2;
				Factor3 = value.Factor3;
    
				QuantityPerUnit = value.QuantityPerUnit;
				QuantityPerUnitFormula = value.QuantityPerUnitFormula;
				QuantityPerUnitFormulaState = value.QuantityPerUnitFormulaState;
    
				ExchangeRate = value.ExchangeRate;
				LocalFactor = value.LocalFactor;
				LocalCountry = value.LocalCountry;
				LocalStateProvince = value.LocalStateProvince;
				TotalUnits = value.TotalUnits;
				HasUserTotalUnits = value.HasUserTotalUnits;
    
				FinalRate = value.FinalRate;
				TotalCost = value.TotalCost;
    
				FixedCost = value.FixedCost;
				FinalFixedCost = value.FinalFixedCost;
				VariableCost = value.VariableCost;
				Comment = Comment;
    
				PvVars = value.PvVars;
			}
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="BOQITEMCONSUMABLEID" </summary>
		/// <returns> Long </returns>
		public virtual long? BoqItemConsumableId
		{
			get
			{
				return boqItemConsumableId;
			}
			set
			{
				boqItemConsumableId = value;
			}
		}


		public virtual decimal calculateFinalRate()
		{
			decimal fRate = finalRate;

			BoqItemTable boqItemTable = BoqItemTable;

			if (BoqItemTable != null)
			{
				decimal tUnits = BigDecimalMath.ONE;
				tUnits = boqItemTable.Quantity;

				tUnits = tUnits * Factor1;
				tUnits = tUnits * Factor2;
				tUnits = tUnits * Factor3;
				tUnits = tUnits * QuantityPerUnit;

				totalUnits = tUnits;
			}

			if (BoqItemTable != null && ConsumableTable != null)
			{
				decimal consumableRate = ConsumableTable.RateForCalculation * ExchangeRate;
				consumableRate = consumableRate * LocalFactor;
				//			if ( getBoqItemTable().getHasProductivity() || getBoqItemTable().getQuantity().compareTo(BigDecimalMath.ZERO) <= 0 ) {
				fRate = consumableRate * Factor1;
				fRate = fRate * Factor2;
				fRate = fRate * Factor3;
				fRate = fRate * QuantityPerUnit;
				fRate = fRate * LocalFactor;

				//			}
				//			else { // Total Units Method:
				//				fRate = consumableRate.multiply(getTotalUnits());
				//				try {
				//					fRate = BigDecimalMath.div(fRate,getBoqItemTable().getQuantity());
				//				} catch(ArithmeticException ex) {
				//					fRate = BigDecimalMath.ZERO;
				//				}
				//			}

				// Calculate Variable, Total Cost:
				variableCost = fRate * (BoqItemTable.Quantity);

				totalCost = decimal.Zero;
				totalCost = totalCost + variableCost;
				totalCost = totalCost + FinalFixedCost;

				// Avoid precision/scale updates if data is the same:
				variableCost = variableCost.setScale(10,decimal.ROUND_HALF_DOWN);
				totalCost = totalCost.setScale(10,decimal.ROUND_HALF_UP);
				fRate = fRate.setScale(10,decimal.ROUND_HALF_UP);
				totalUnits = totalUnits.setScale(10,decimal.ROUND_HALF_UP);
			}

			finalRate = fRate;
			return fRate;
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalRate
		{
			get
			{
				return finalRate;
			}
			set
			{
				finalRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TOTALCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal TotalCost
		{
			get
			{
				return totalCost;
			}
			set
			{
				totalCost = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PARAMITEMID" type="long" insert="false" update="false" </summary>
		/// <returns> rate </returns>
		public virtual long? ParamItemId
		{
			get
			{
				return paramItemId;
			}
			set
			{
				this.paramItemId = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="PARAMITEMID" </summary>
		/// <returns> ParamItemTable </returns>
		public virtual ParamItemTable ParamItemTable
		{
			get
			{
				return paramItemTable;
			}
			set
			{
				this.paramItemTable = value;
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
		/// @hibernate.property column="DIVIDER" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Factor3
		{
			get
			{
				return factor3;
			}
			set
			{
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
		/// @hibernate.property column="TOTALUNITS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal TotalUnits
		{
			get
			{
				return totalUnits;
			}
			set
			{
				totalUnits = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="USERTOTALUNITS" type="boolean" </summary>
		/// <returns> rate </returns>
		public virtual bool? HasUserTotalUnits
		{
			get
			{
				return hasUserTotalUnits;
			}
			set
			{
				hasUserTotalUnits = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="COSTCENTER" type="big_decimal" precision="30" scale="10" </summary>
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
				if (exchangeRate == null)
				{
					exchangeRate = decimal.One;
				}
				this.exchangeRate = value;
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
		/// @hibernate.property column="LOCALSTATE" type="costos_string" </summary>
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
		/// @hibernate.property column="LAST_UPDATE" type="timestamp" </summary>
		/// <returns> rate </returns>
		public virtual DateTime LastUpdate
		{
			get
			{
				return lastUpdate;
			}
			set
			{
				//value = value.setScale(DBPreferences.getInstance().getBigDecimalScale());
				lastUpdate = value;
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
		/// @hibernate.property column="VARIABLECOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> variableCost </returns>
		public virtual decimal VariableCost
		{
			get
			{
				return variableCost;
			}
			set
			{
				this.variableCost = value;
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
		///  column="CONSUMABLEID"
		///  cascade="none" </summary>
		/// <returns> ConsumableTable </returns>
		public virtual ConsumableTable ConsumableTable
		{
			get
			{
				return consumableTable;
			}
			set
			{
				this.consumableTable = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="BOQITEMID"
		/// </summary>
		/// <returns> BoqItemTable </returns>
		public virtual BoqItemTable BoqItemTable
		{
			get
			{
				return boqItemTable;
			}
			set
			{
				this.boqItemTable = value;
			}
		}


		public override long? Id
		{
			get
			{
				return BoqItemConsumableId;
			}
		}

		public override ResourceWithAssignmentsTable getResourceTable()
		{
			return BoqItemTable;
		}

		public override object clone(bool cloneParent, bool cloneResource)
		{
			return clone(cloneParent || cloneResource);
		}

		public override ResourceTable AssignmentResourceTable
		{
			get
			{
				return ConsumableTable;
			}
			set
			{
				ConsumableTable = (ConsumableTable) value;
			}
		}

		public override ResourceToAssignmentTable Data
		{
			set
			{
				Data = (BoqItemConsumableTable)value;
			}
		}

		public override void setResourceTable(ResourceTable resourceTable)
		{
			BoqItemTable = (BoqItemTable) resourceTable;
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