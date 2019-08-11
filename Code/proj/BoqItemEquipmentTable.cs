using System;

namespace Models.proj
{


	using BoqItemToAssignmentTable = nomitech.common.@base.BoqItemToAssignmentTable;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceWithAssignmentsTable = nomitech.common.@base.ResourceWithAssignmentsTable;
	using EquipmentTable = nomitech.common.db.local.EquipmentTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using UIPropertiesUtil = nomitech.common.util.UIPropertiesUtil;
	//#RXL_START 
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="BOQITEM_EQUIPMENT" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	[Serializable]
	public class BoqItemEquipmentTable : BoqItemToAssignmentTable, ProjectIdEntity
	{

		/// 
		private const long serialVersionUID = 1L;

		public static readonly string[] FIELDS = new string[] {"factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "totalUnits", "finalRate", "totalCost", "fixedCost", "finalFixedCost", "variableCost", "comment"};

		private long? boqItemEquipmentId;
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
		private decimal energyPrice;
		private decimal finalFuelRate;
		private decimal localFactor;
		private string localCountry;
		private string localStateProvince;
		private bool? hasUserTotalUnits;
		private DateTime lastUpdate;
		private long? paramItemId;
		private ParamItemTable paramItemTable;
		private decimal finalDepreciationRate;
		private string comment;

		// FIXED COST:
		private decimal fixedCost = null;
		private decimal finalFixedCost = decimal.Zero;
		private decimal variableCost = decimal.Zero;

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

		private BoqItemTable boqItemTable;
		private EquipmentTable equipmentTable;

		//	private transient HashMap o_map = new HashMap();

		public BoqItemEquipmentTable()
		{
			//		o_map = new HashMap();
		}

		//	public Object valueForField(String field) {
		//		if ( field.equals("finalRate") ) {
		//			return DBFieldFormatUtil.formatObject(calculateFinalRate());
		//		}
		//		else if ( field.equals("totalUnits") ) {
		//			return DBFieldFormatUtil.formatObject(getTotalUnits());
		//		}
		//		else if ( field.equals("totalCost") ) {
		//			return DBFieldFormatUtil.formatObject(getTotalCost());
		//		}
		//
		//		return DBFieldFormatUtil.formatObject(o_map.get(field));
		//	}
		//	
		//	public Object scaledValueForField(String field) {
		//		if ( field.equals("finalRate") ) {
		//			return DBFieldFormatUtil.scaleAndFormatObject(calculateFinalRate());
		//		}
		//		else if ( field.equals("totalUnits") ) {
		//			return DBFieldFormatUtil.scaleAndFormatObject(getTotalUnits());
		//		}
		//		else if ( field.equals("totalCost") ) {
		//			return DBFieldFormatUtil.scaleAndFormatObject(getTotalCost());
		//		}
		//		return DBFieldFormatUtil.scaleAndFormatObject(o_map.get(field));
		//	}

		public virtual object clone(bool relations)
		{
			if (relations)
			{
				return clone();
			}

			//		if ( o_map == null ) o_map = new HashMap();
			BoqItemEquipmentTable obj = new BoqItemEquipmentTable();

			obj.ParamItemId = ParamItemId;
			obj.BoqItemEquipmentId = BoqItemEquipmentId;
			obj.FinalRate = FinalRate;
			obj.TotalCost = TotalCost;
			obj.FinalDepreciationRate = FinalDepreciationRate;
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
			obj.EnergyPrice = EnergyPrice;
			obj.FinalFuelRate = FinalFuelRate;
			obj.TotalUnits = TotalUnits;
			obj.HasUserTotalUnits = HasUserTotalUnits;
			obj.LastUpdate = LastUpdate;

			obj.FixedCost = FixedCost;
			obj.FinalFixedCost = FinalFixedCost;
			obj.VariableCost = VariableCost;
			obj.Comment = Comment;

			obj.PvVars = PvVars;

			obj.UnitHours = UnitHours;

			obj.ProjectId = ProjectId;

			return obj;
		}

		public virtual object clone()
		{
			//		if ( o_map == null ) o_map = new HashMap();

			BoqItemEquipmentTable obj = new BoqItemEquipmentTable();

			obj.ParamItemId = ParamItemId;
			obj.BoqItemEquipmentId = BoqItemEquipmentId;
			obj.FinalRate = FinalRate;
			obj.TotalCost = TotalCost;
			obj.FinalDepreciationRate = FinalDepreciationRate;
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
			obj.EnergyPrice = EnergyPrice;
			obj.FinalFuelRate = FinalFuelRate;
			obj.TotalUnits = TotalUnits;
			obj.HasUserTotalUnits = HasUserTotalUnits;
			obj.LastUpdate = LastUpdate;

			obj.FixedCost = FixedCost;
			obj.FinalFixedCost = FinalFixedCost;
			obj.VariableCost = VariableCost;
			obj.Comment = Comment;

			obj.PvVars = PvVars;

			obj.UnitHours = UnitHours;

			obj.ProjectId = ProjectId;

			if (BoqItemTable != null)
			{
				obj.BoqItemTable = (BoqItemTable)BoqItemTable.clone();
			}

			if (EquipmentTable != null)
			{
				obj.EquipmentTable = (EquipmentTable)EquipmentTable.clone();
			}

			return obj;
		}

		public virtual BoqItemEquipmentTable Data
		{
			set
			{
    
				ParamItemId = value.ParamItemId;
				BoqItemEquipmentId = value.BoqItemEquipmentId;
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
				EnergyPrice = value.EnergyPrice;
				FinalFuelRate = value.FinalFuelRate;
				FinalDepreciationRate = value.FinalDepreciationRate;
				TotalUnits = value.TotalUnits;
				HasUserTotalUnits = value.HasUserTotalUnits;
    
				FinalRate = value.FinalRate;
				TotalCost = value.TotalCost;
    
				FixedCost = value.FixedCost;
				FinalFixedCost = value.FinalFixedCost;
				VariableCost = value.VariableCost;
				Comment = value.Comment;
    
				PvVars = value.PvVars;
    
				UnitHours = value.UnitHours;
			}
		}


		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="BOQITEMEQUIPMENTID" </summary>
		/// <returns> Long </returns>
		public virtual long? BoqItemEquipmentId
		{
			get
			{
				return boqItemEquipmentId;
			}
			set
			{
				boqItemEquipmentId = value;
				//		o_map.put("boqItemEquipmentId",value);
			}
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
				return finalRate; //calculateFinalRate();
			}
			set
			{
				finalRate = value;
				//		o_map.put("finalRate",value);                
			}
		}



		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FDEPRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalDepreciationRate
		{
			get
			{
				return finalDepreciationRate;
			}
			set
			{
				finalDepreciationRate = value;
			}
		}


		//  method used for topsheet calcualtion only
		/*
		public BigDecimal calculateFinalFuelRate() {
	
			BigDecimal finalRate = new BigDecimalFixed("0.0");
	
			if ( getBoqItemTable() != null && getEquipmentTable() != null ) {
				if ( getBoqItemTable().getHasProductivity() || getBoqItemTable().getQuantity().compareTo(BigDecimalMath.ZERO) <= 0 ) {
					finalRate = getEquipmentTable().getCalculatedFuelRate().multiply(getExchangeRate());
					finalRate = finalRate.multiply(getFactor1());
					finalRate = finalRate.multiply(getFactor2());
					finalRate = finalRate.multiply(getFactor3());
					finalRate = finalRate.multiply(getLocalFactor());
	
					if ( getBoqItemTable().getActivityBased() != null && getBoqItemTable().getActivityBased().equals(Boolean.FALSE) ) {
						finalRate = finalRate.multiply(getQuantityPerUnit());
					}
					else {
						try {
							finalRate = BigDecimalMath.div(finalRate,getBoqItemTable().getAdjustedProd());
						} catch(ArithmeticException ex) {
							finalRate = BigDecimalMath.ZERO;
						}
					}
				}
				else { // Total Units Method:				
					finalRate = getEquipmentTable().getCalculatedFuelRate().multiply(getExchangeRate());
					finalRate = finalRate.multiply(getTotalUnits());
					finalRate = finalRate.multiply(getLocalFactor());				
	
					try {
						finalRate = BigDecimalMath.div(finalRate,getBoqItemTable().getQuantity());
					} catch(ArithmeticException ex) {
						finalRate = BigDecimalMath.ZERO;
					}
				}
			}
	
			return finalRate;
		}*/

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



		public virtual decimal calculateFinalRate()
		{
			decimal fRate = finalRate;

			//		if ( fRate == null )
			//			fRate = (BigDecimal)o_map.get("finalRate");

			if (BoqItemTable != null)
			{
				// Calculate Total Units First:
				decimal tUnits = BigDecimalMath.ONE;
				tUnits = tUnits * Factor1;
				tUnits = tUnits * Factor2;
				tUnits = tUnits * Factor3;

				if (BoqItemTable.ActivityBased != null && BoqItemTable.ActivityBased.Equals(false))
				{
					tUnits = tUnits * QuantityPerUnit;
					tUnits = tUnits * (BoqItemTable.Quantity);
				}
				else
				{
					tUnits = BigDecimalMath.mult(tUnits, BoqItemTable.Duration);
				}
				totalUnits = tUnits;
			}

			if (BoqItemTable != null && EquipmentTable != null)
			{

				decimal equipmentRate = EquipmentTable.RateForCalculation;
				decimal fuelRate = BigDecimalMath.ZERO;

				//getEquipmentTable().getCalculatedFuelRate()

	//			if ( getEquipmentTable().getFuelConsumption().compareTo(BigDecimalMath.ZERO) > 0 && 
	//					getEnergyPrice().compareTo(BigDecimalMath.ZERO) > 0 ) {
	//				fuelRate = BigDecimalMath.mult(getEnergyPrice(), getEquipmentTable().getFuelConsumption());
	//			}
	//			else {
					fuelRate = EquipmentTable.FuelRate;
	//			}

				finalFuelRate = fuelRate;
	//			equipmentRate = equipmentRate.add(fuelRate);

				fRate = calculateFinalRateFor(equipmentRate);
				finalDepreciationRate = calculateFinalRateFor(EquipmentTable.DepreciationRate);

				// Calculate Variable, Total Cost:
				variableCost = fRate * (BoqItemTable.Quantity);

				totalCost = decimal.Zero;
				totalCost = totalCost + variableCost;
				totalCost = totalCost + FinalFixedCost;

				// Avoid precision/scale updates if data is the same:
				variableCost = variableCost.setScale(10,decimal.ROUND_HALF_UP);
				totalCost = totalCost.setScale(10,decimal.ROUND_HALF_UP);
				fRate = fRate.setScale(10,decimal.ROUND_HALF_UP);
				totalUnits = totalUnits.setScale(10,decimal.ROUND_HALF_UP);
				finalFuelRate = finalFuelRate.setScale(10,decimal.ROUND_HALF_UP);
				finalDepreciationRate = finalDepreciationRate.setScale(10,decimal.ROUND_HALF_UP);
			}

			finalRate = fRate;

			return finalRate;
		}

		private decimal calculateFinalRateFor(decimal rate)
		{
			rate = rate * ExchangeRate;
			rate = rate * LocalFactor;

			decimal fRate = null;
			if (BoqItemTable.HasProductivity.Value || BoqItemTable.Quantity.CompareTo(BigDecimalMath.ZERO) <= 0)
			{

				fRate = rate * Factor1;
				fRate = fRate * Factor2;
				fRate = fRate * Factor3;

				if (BoqItemTable.ActivityBased != null && BoqItemTable.ActivityBased.Equals(false))
				{
					fRate = fRate * QuantityPerUnit;
					fRate = BigDecimalMath.div(fRate, UnitHours);
				}
				else
				{
					try
					{
						decimal fDiv = BigDecimalMath.mult(BoqItemTable.AdjustedProd, UnitHours);
						fRate = BigDecimalMath.div(fRate, fDiv);
					}
					catch (Exception)
					{
						fRate = BigDecimalMath.ZERO;
					}
				}
			}
			else
			{ // Total Units Method:
				fRate = rate * TotalUnits;
				try
				{
					fRate = BigDecimalMath.div(fRate,BoqItemTable.Quantity);
				}
				catch (Exception)
				{
					fRate = BigDecimalMath.ZERO;
				}
			}

			return fRate;
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
				//value = value.setScale(DBPreferences.getInstance().getBigDecimalScale());		
				factor1 = value;
				//		o_map.put("factor1",value);                
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
				//		o_map.put("factor2",value);                
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
				//		o_map.put("factor3",value);                
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="QTYPUNIT" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal QuantityPerUnit
		{
			get
			{
				return quantityPerUnit;
			}
			set
			{
				this.quantityPerUnit = value;
				//		o_map.put("quantityPerUnit",value);
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
				//value = value.setScale(DBPreferences.getInstance().getBigDecimalScale());		
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
				//value = value.setScale(DBPreferences.getInstance().getBigDecimalScale());		
				totalUnits = value;
				//		o_map.put("totalUnits",value);                
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
				//		o_map.put("hasUserTotalUntis",value);                
			}
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
		/// @hibernate.property column="FUELRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalFuelRate
		{
			get
			{
				return finalFuelRate;
			}
			set
			{
				this.finalFuelRate = value;
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
				//		o_map.put("lastUpdate",value);                
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="EQUIPMENTID"
		///  cascade="none" </summary>
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
				return BoqItemEquipmentId;
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
				Data = (BoqItemEquipmentTable)value;
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