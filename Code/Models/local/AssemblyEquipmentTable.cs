using System;

namespace Models.local
{

	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;
	using ResourceTable = Desktop.common.nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = Desktop.common.nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceWithAssignmentsTable = Desktop.common.nomitech.common.@base.ResourceWithAssignmentsTable;
	using BigDecimalMath = Desktop.common.nomitech.common.util.BigDecimalMath;
	using UIPropertiesUtil = Desktop.common.nomitech.common.util.UIPropertiesUtil;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="ASSEMBLY_EQUIPMENT"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class AssemblyEquipmentTable : ResourceToAssignmentTable, ProjectIdEntity
	{
		private static readonly decimal ONE = BigDecimalMath.ONE;

		public static readonly string[] FIELDS = new string[] {"factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "finalRate", "fixedCost", "finalFixedCost", "comment"};

		private long? assemblyEquipmentId = null;
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
		private decimal energyPrice;
		private decimal fuelRate;
		private decimal exchangeRate = null;
		private long? equipmentTableId = null;
		private decimal finalRate = null;
		private decimal finalDepreciationRate;
		private decimal finalFuelRate;
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

		private EquipmentTable equipmentTable = null;
		private AssemblyTable assemblyTable;

		public AssemblyEquipmentTable()
		{

		}

		public virtual object clone(bool cloneAssembly, bool cloneEquipment)
		{
			AssemblyEquipmentTable obj = new AssemblyEquipmentTable();

			obj.AssemblyEquipmentId = AssemblyEquipmentId;
			obj.LastUpdate = LastUpdate;
			//obj.setFinalRate(getFinalRate());
			obj.Factor1 = Factor1;
			obj.Factor2 = Factor2;
			obj.Factor3 = Factor3;

			obj.QuantityPerUnit = QuantityPerUnit;
			obj.QuantityPerUnitFormula = QuantityPerUnitFormula;
			obj.QuantityPerUnitFormulaState = QuantityPerUnitFormulaState;

			obj.LocalFactor = LocalFactor;
			obj.LocalCountry = LocalCountry;
			obj.LocalStateProvince = LocalStateProvince;
			obj.EnergyPrice = EnergyPrice;
			obj.ExchangeRate = ExchangeRate;
			obj.FuelRate = FuelRate;
			obj.EquipmentTableId = EquipmentTableId;
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
				obj.FinalFuelRate = calculateFinalFuelRate();
			}
			catch (System.NullReferenceException)
			{
				// ignore!
			}

			try
			{
				obj.FinalDepreciationRate = calculateFinalDepreciationRate();
			}
			catch (System.NullReferenceException)
			{
				// ignore!
			}

			if (AssemblyTable != null && cloneAssembly)
			{
				obj.AssemblyTable = (AssemblyTable) AssemblyTable.clone();
			}

			if (EquipmentTable != null && cloneEquipment)
			{
				obj.EquipmentTable = (EquipmentTable) EquipmentTable.Clone();
			}

			return obj;
		}

		public virtual object clone(bool relations)
		{
			if (relations)
			{
				return clone(true, true);
			}
			AssemblyEquipmentTable obj = new AssemblyEquipmentTable();

			obj.AssemblyEquipmentId = AssemblyEquipmentId;
			obj.LastUpdate = LastUpdate;
			//obj.setFinalRate(getFinalRate());
			obj.Factor1 = Factor1;
			obj.Factor2 = Factor2;
			obj.Factor3 = Factor3;

			obj.QuantityPerUnit = QuantityPerUnit;
			obj.QuantityPerUnitFormula = QuantityPerUnitFormula;
			obj.QuantityPerUnitFormulaState = QuantityPerUnitFormulaState;

			obj.LocalFactor = LocalFactor;
			obj.LocalCountry = LocalCountry;
			obj.LocalStateProvince = LocalStateProvince;
			obj.EnergyPrice = EnergyPrice;
			obj.ExchangeRate = ExchangeRate;
			obj.FuelRate = FuelRate;
			obj.EquipmentTableId = EquipmentTableId;
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
				obj.FinalFuelRate = calculateFinalFuelRate();
			}
			catch (System.NullReferenceException)
			{
				// ignore!
			}

			try
			{
				obj.FinalDepreciationRate = calculateFinalDepreciationRate();
			}
			catch (System.NullReferenceException)
			{
				// ignore!
			}

			return obj;
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="ASSEMBLYEQUIPMENTID" </summary>
		/// <returns> Long </returns>
		public virtual long? AssemblyEquipmentId
		{
			get
			{
				return assemblyEquipmentId;
			}
			set
			{
				assemblyEquipmentId = value;
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

			if (AssemblyTable != null && EquipmentTable != null)
			{
				decimal equipmentRate = EquipmentTable.RateForCalculation;
				decimal fuelRate = BigDecimalMath.ZERO;

				if (EquipmentTable.FuelConsumption.CompareTo(BigDecimalMath.ZERO) > 0 && EnergyPrice.CompareTo(BigDecimalMath.ZERO) > 0)
				{
					fuelRate = BigDecimalMath.mult(EnergyPrice, EquipmentTable.FuelConsumption);
				}
				else
				{
					fuelRate = EquipmentTable.FuelRate;
				}

				fuelRate = fuelRate.setScale(10, decimal.ROUND_HALF_UP);

				FuelRate = fuelRate;

				equipmentRate = equipmentRate + fuelRate * ExchangeRate;

				finalRate = equipmentRate * Factor1;
				finalRate = finalRate * Factor2;
				finalRate = finalRate * Factor3;
				finalRate = finalRate * LocalFactor;

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

				finalRate = finalRate.setScale(10, decimal.ROUND_HALF_UP);
			}

			return finalRate;
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
				if (AssemblyTable != null && EquipmentTable != null)
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


		// method for topsheet calculation
		public virtual decimal calculateFinalDepreciationRate()
		{

			if (AssemblyTable != null && EquipmentTable != null)
			{
				finalDepreciationRate = EquipmentTable.DepreciationRate * Factor1;
				finalDepreciationRate = finalDepreciationRate * Factor2;
				finalDepreciationRate = finalDepreciationRate * Factor3;
				finalDepreciationRate = finalDepreciationRate * LocalFactor;
				finalDepreciationRate = finalDepreciationRate * ExchangeRate;

				if (AssemblyTable.ActivityBased != null && AssemblyTable.ActivityBased.Equals(false))
				{
					finalDepreciationRate = finalDepreciationRate * QuantityPerUnit;
					finalDepreciationRate = BigDecimalMath.div(finalDepreciationRate, UnitHours);
				}
				else
				{
					try
					{
						decimal fDiv = BigDecimalMath.mult(AssemblyTable.Productivity, UnitHours);
						finalDepreciationRate = BigDecimalMath.div(finalDepreciationRate, fDiv);
					}
					catch (ArithmeticException)
					{
						finalDepreciationRate = BigDecimalMath.ZERO;
					}
				}

				finalDepreciationRate = finalDepreciationRate.setScale(10, decimal.ROUND_HALF_UP);
			}

			return finalDepreciationRate;
		}

		/// 
		/// <summary>
		/// @hibernate.property column="FDEPRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalDepreciationRate
		{
			get
			{
				if (AssemblyTable != null && EquipmentTable != null)
				{
					return calculateFinalDepreciationRate();
				}
				return finalDepreciationRate;
			}
			set
			{
				this.finalDepreciationRate = value;
			}
		}


		// method for topsheet calculation
		public virtual decimal calculateFinalFuelRate()
		{

			if (AssemblyTable != null && EquipmentTable != null)
			{
				decimal fuelRate = BigDecimalMath.ZERO;
				if (EquipmentTable.FuelConsumption.CompareTo(BigDecimalMath.ZERO) > 0 && EnergyPrice.CompareTo(BigDecimalMath.ZERO) > 0)
				{
					fuelRate = BigDecimalMath.mult(EnergyPrice, EquipmentTable.FuelConsumption);
				}
				else
				{
					fuelRate = EquipmentTable.FuelRate;
				}

				fuelRate = fuelRate.setScale(10, decimal.ROUND_HALF_UP);

				FuelRate = fuelRate;
				finalFuelRate = fuelRate * Factor1;
				finalFuelRate = finalFuelRate * Factor2;
				finalFuelRate = finalFuelRate * Factor3;
				finalFuelRate = finalFuelRate * LocalFactor;
				finalFuelRate = finalFuelRate * ExchangeRate;

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
						finalFuelRate = BigDecimalMath.div(finalFuelRate, fDiv);
					}
					catch (ArithmeticException)
					{
						finalFuelRate = BigDecimalMath.ZERO;
					}
				}

				finalFuelRate = finalFuelRate.setScale(10, decimal.ROUND_HALF_UP);
			}

			return finalFuelRate;
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ENERGYPRICE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal EnergyPrice
		{
			get
			{
				return energyPrice;
			}
			set
			{
				this.energyPrice = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FINALFUELRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalFuelRate
		{
			get
			{
				if (AssemblyTable != null && EquipmentTable != null)
				{
					return calculateFinalFuelRate();
				}
				return finalFuelRate;
			}
			set
			{
				this.finalFuelRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FUELRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FuelRate
		{
			get
			{
				return fuelRate;
			}
			set
			{
				this.fuelRate = value;
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
					exchangeRate = ONE;
				}
				return exchangeRate;
			}
			set
			{
				if (value == null)
				{
					value = ONE;
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
				if (EquipmentTable != null && !EquipmentTable.Unit.Equals("HOUR"))
				{
					if (ProjectDBUtil.currentProjectDBUtil() == null)
					{
						unitHours = UIPropertiesUtil.getHoursFromUnit(EquipmentTable.Unit);
					}
					else
					{
						unitHours = ProjectDBUtil.currentProjectDBUtil().Properties.getHoursFromUnit(EquipmentTable.Unit);
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
		///  column="EQUIPMENTID" </summary>
		/// <returns> EquipmentTable </returns>
		public virtual EquipmentTable EquipmentTable
		{
			get
			{
				return equipmentTable;
			}
			set
			{
				this.equipmentTable = value;
				if (value != null)
				{
					EquipmentTableId = value.EquipmentId;
				}
			}
		}


		public virtual long? EquipmentTableId
		{
			get
			{
				return equipmentTableId;
			}
			set
			{
				this.equipmentTableId = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="ASSEMBLYID" </summary>
		/// <returns> EquipmentTable </returns>
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


		public virtual AssemblyEquipmentTable Data
		{
			set
			{
				AssemblyEquipmentId = value.AssemblyEquipmentId;
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
				EnergyPrice = value.EnergyPrice;
				FuelRate = value.FuelRate;
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
					FinalFuelRate = value.calculateFinalFuelRate();
				}
				catch (System.NullReferenceException)
				{
					// ignore!
				}
    
				try
				{
					FinalDepreciationRate = value.calculateFinalDepreciationRate();
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
				return AssemblyEquipmentId;
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
				return EquipmentTable;
			}
			set
			{
				EquipmentTable = (EquipmentTable) value;
			}
		}

		public override ResourceToAssignmentTable Data
		{
			set
			{
				Data = (AssemblyEquipmentTable) value;
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