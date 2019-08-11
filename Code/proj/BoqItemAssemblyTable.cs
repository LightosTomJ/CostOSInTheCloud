using System;

namespace Models.proj
{


	using BoqItemToAssignmentTable = nomitech.common.@base.BoqItemToAssignmentTable;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceWithAssignmentsTable = nomitech.common.@base.ResourceWithAssignmentsTable;
	using AssemblyTable = nomitech.common.db.local.AssemblyTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	//#RXL_START 
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="BOQITEM_ASSEMBLY" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	[Serializable]
	public class BoqItemAssemblyTable : BoqItemToAssignmentTable, ProjectIdEntity
	{

		private const long serialVersionUID = 1L;

		public static readonly string[] FIELDS = new string[] {"factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "totalUnits", "finalRate", "totalCost", "fixedCost", "finalFixedCost", "variableCost", "comment"};

		private long? boqItemAssemblyId = null;
		private decimal factor1 = null;
		private decimal factor2 = null;
		private decimal factor3 = null;
		private decimal exchangeRate = null;
		private decimal totalUnits = null;
		private decimal finalRate = null;
		private decimal finalLaborRate = null;
		private decimal finalLaborManhours = null;
		private decimal finalEquipmentHours = null;
		private decimal finalMaterialRate = null;
		private decimal finalShipmentRate = null;
		private decimal finalFabricationRate = null;

		private decimal finalSubcontractorRate = null;

		private decimal finalEquipmentRate = null;
		private decimal finalConsumableRate = null;

		private decimal totalCost = null;
		private decimal laborCost = null;
		private decimal equipmentCost = null;
		private decimal subcontractorCost = null;
		private decimal materialTotalCost = null;
		private decimal consumableCost = null;

		private decimal quantityPerUnit = null;
		private string quantityPerUnitFormula;
		private sbyte? quantityPerUnitFormulaState;

		// FIXED COST:
		private decimal fixedCost = null;
		private decimal finalFixedCost = decimal.Zero;
		private decimal variableCost = decimal.Zero;


		private decimal localFactor;
		private string localCountry;
		private string localStateProvince;

		private bool? hasUserTotalUnits = null;
		private DateTime lastUpdate = null;
		private BoqItemTable boqItemTable;

		private long? paramItemId;

		private AssemblyTable assemblyTable;
		private ParamItemTable paramItemTable;
		private string comment;
		/// <summary>
		/// This String declares which SQL COLUMN contains which PV Variables
		/// 	e.g. <code>CUSRATE1FORM:var1,var2;CUSTXT1FORM:mitsos,george;MARKUPFORM:var2,mitsos</code>
		/// </summary>
		private string pvVars;

		public BoqItemAssemblyTable()
		{
		}

		public virtual object clone()
		{

			BoqItemAssemblyTable obj = new BoqItemAssemblyTable();

			obj.ParamItemId = ParamItemId;

			obj.BoqItemAssemblyId = BoqItemAssemblyId;
			obj.FinalRate = FinalRate;
			obj.FinalLaborRate = FinalLaborRate;
			obj.FinalMaterialRate = FinalMaterialRate;
			obj.FinalShipmentRate = FinalShipmentRate;
			obj.FinalFabricationRate = FinalFabricationRate;

			obj.FinalConsumableRate = FinalConsumableRate;
			obj.FinalSubcontractorRate = FinalSubcontractorRate;
			obj.FinalEquipmentRate = FinalEquipmentRate;

			obj.FixedCost = FixedCost;
			obj.FinalFixedCost = FinalFixedCost;
			obj.VariableCost = VariableCost;
			obj.Comment = Comment;

			obj.TotalCost = TotalCost;
			obj.LaborCost = LaborCost;
			obj.MaterialCost = MaterialCost;
			obj.ConsumableCost = ConsumableCost;
			obj.SubcontractorCost = SubcontractorCost;
			obj.EquipmentCost = EquipmentCost;

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

			obj.PvVars = PvVars;

			obj.ProjectId = ProjectId;

			if (BoqItemTable != null)
			{
				obj.BoqItemTable = (BoqItemTable)BoqItemTable.clone();
			}

			if (AssemblyTable != null)
			{
				obj.AssemblyTable = (AssemblyTable)AssemblyTable.clone();
			}

			return obj;
		}

		public virtual object clone(bool relations)
		{
			if (relations)
			{
				return clone();
			}

			BoqItemAssemblyTable obj = new BoqItemAssemblyTable();

			obj.ParamItemId = ParamItemId;
			obj.BoqItemAssemblyId = BoqItemAssemblyId;
			obj.FinalRate = FinalRate;
			obj.FinalLaborRate = FinalLaborRate;
			obj.FinalMaterialRate = FinalMaterialRate;
			obj.FinalShipmentRate = FinalShipmentRate;
			obj.FinalFabricationRate = FinalFabricationRate;
			obj.FinalConsumableRate = FinalConsumableRate;
			obj.FinalSubcontractorRate = FinalSubcontractorRate;
			obj.FinalEquipmentRate = FinalEquipmentRate;

			obj.FixedCost = FixedCost;
			obj.FinalFixedCost = FinalFixedCost;
			obj.VariableCost = VariableCost;
			obj.Comment = Comment;

			obj.TotalCost = TotalCost;
			obj.LaborCost = LaborCost;
			obj.MaterialCost = MaterialCost;
			obj.ConsumableCost = ConsumableCost;
			obj.SubcontractorCost = SubcontractorCost;
			obj.EquipmentCost = EquipmentCost;

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

			obj.PvVars = PvVars;

			obj.ProjectId = ProjectId;

			return obj;
		}

		public virtual BoqItemAssemblyTable Data
		{
			set
			{
				BoqItemAssemblyId = value.BoqItemAssemblyId;
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
    
				FixedCost = value.FixedCost;
				FinalFixedCost = value.FinalFixedCost;
				VariableCost = value.VariableCost;
				Comment = value.Comment;
    
				FinalRate = value.FinalRate;
				FinalLaborRate = value.FinalLaborRate;
				FinalMaterialRate = value.FinalMaterialRate;
				FinalShipmentRate = value.FinalShipmentRate;
				FinalFabricationRate = value.FinalFabricationRate;
				FinalConsumableRate = value.FinalConsumableRate;
				FinalSubcontractorRate = value.FinalSubcontractorRate;
				FinalEquipmentRate = value.FinalEquipmentRate;
    
				PvVars = value.PvVars;
    
				ParamItemId = value.ParamItemId;
			}
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="BOQITEMASSEMBLYID" </summary>
		/// <returns> Long </returns>
		public virtual long? BoqItemAssemblyId
		{
			get
			{
				return boqItemAssemblyId;
			}
			set
			{
				boqItemAssemblyId = value;
			}
		}


		public virtual decimal calculateFinalFixedCost()
		{

			if (BoqItemTable != null && AssemblyTable != null)
			{
				finalFixedCost = AssemblyTable.calculateFinalFixedCost();
				finalFixedCost = BigDecimalMath.mult(finalFixedCost, ExchangeRate);
				finalFixedCost = BigDecimalMath.mult(finalFixedCost, Factor1);
				finalFixedCost = BigDecimalMath.mult(finalFixedCost, Factor2);
				finalFixedCost = BigDecimalMath.mult(finalFixedCost, Factor3);
				finalFixedCost = BigDecimalMath.mult(finalFixedCost, LocalFactor);
			}

			finalFixedCost.setScale(10,decimal.ROUND_HALF_UP);

			return finalFixedCost;
		}

		public virtual decimal calculateFinalRate()
		{
			return calculateFinalRate(false);
		}

		public virtual decimal calculateFinalRate(bool deepRecalc)
		{

			decimal fRate = finalRate;

			if (BoqItemTable != null && AssemblyTable != null)
			{
				if (deepRecalc)
				{
					AssemblyTable.calculateRate();
				}
				decimal assemblyRate = AssemblyTable.Rate * ExchangeRate;
				assemblyRate = assemblyRate * LocalFactor;

				fRate = assemblyRate * Factor1;
				fRate = fRate * Factor2;
				fRate = fRate * Factor3;
				fRate = fRate * QuantityPerUnit;

				//if ( getBoqItemTable().getHasProductivity() || getBoqItemTable().getQuantity().compareTo(BigDecimalMath.ZERO) <= 0 ) {
				//			}
				//			else { // Total Units Method:				
				//				fRate = assemblyRate.multiply(getTotalUnits());
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


				fRate = fRate.setScale(10,decimal.ROUND_HALF_DOWN);
				variableCost = variableCost.setScale(10,decimal.ROUND_HALF_DOWN);
				totalCost = totalCost.setScale(10,decimal.ROUND_HALF_DOWN);

			}

			finalRate = fRate;
			return fRate;
		}

		public virtual decimal calculateFinalLaborRate()
		{

			decimal fRate = finalLaborRate;


			if (BoqItemTable != null && AssemblyTable != null)
			{
				decimal assemblyRate = AssemblyTable.LaborRate * ExchangeRate;
				assemblyRate = assemblyRate * LocalFactor;

				//			if ( getBoqItemTable().getHasProductivity() || getBoqItemTable().getQuantity().compareTo(BigDecimalMath.ZERO) <= 0 ) {
				fRate = assemblyRate * Factor1;
				fRate = fRate * Factor2;
				fRate = fRate * Factor3;
				fRate = fRate * QuantityPerUnit;

				//			}
				//			else { // Total Units Method:				
				//				fRate = assemblyRate.multiply(getTotalUnits());
				//				try {
				//					fRate = BigDecimalMath.div(fRate,getBoqItemTable().getQuantity());
				//				} catch(ArithmeticException ex) {
				//					fRate = BigDecimalMath.ZERO;
				//				}
				//			}

				laborCost = fRate * (BoqItemTable.Quantity);

				fRate = fRate.setScale(10,decimal.ROUND_HALF_DOWN);
				laborCost = laborCost.setScale(10,decimal.ROUND_HALF_DOWN);
			}

			finalLaborRate = fRate;
			return fRate;
		}

		public virtual decimal calculateFinalLaborManhours()
		{ // NOT TOTAL YOU NEED TO MULT * QTY
			decimal fRate = finalLaborManhours;

			if (BoqItemTable != null && AssemblyTable != null)
			{
				if (AssemblyTable.ActivityBased.Equals(false))
				{
					decimal assemblyRate = AssemblyTable.UnitManhours; // getAssemblyTable().calculateFinalLaborHours(); //
					fRate = assemblyRate * Factor1;
					fRate = fRate * Factor2;
					fRate = fRate * Factor3;
					fRate = fRate * QuantityPerUnit;
				}
				else
				{
					fRate = AssemblyTable.calculateFinalLaborHoursActivityBased();
					fRate = fRate * Factor1;
					fRate = fRate * Factor2;
					fRate = fRate * Factor3;
					fRate = fRate * QuantityPerUnit;
				}

				fRate = fRate.setScale(10,decimal.ROUND_HALF_UP);
			}

			finalLaborManhours = fRate;
			return fRate;
		}

		public virtual decimal calculateFinalEquipmentHours()
		{ // NOT TOTAL YOU NEED TO MULT * QTY
			decimal fRate = finalEquipmentHours;

			if ((BoqItemTable != null) && AssemblyTable != null)
			{
				if (AssemblyTable.ActivityBased.Equals(false))
				{
					decimal assemblyRate = AssemblyTable.UnitEquipmentHours; // getAssemblyTable().calculateFinalEquipmentHours();
					fRate = assemblyRate * Factor1;
					fRate = fRate * Factor2;
					fRate = fRate * Factor3;
					fRate = fRate * QuantityPerUnit;
				}
				else
				{
					fRate = AssemblyTable.calculateFinalEquipmentHoursActivityBased();
					fRate = fRate * Factor1;
					fRate = fRate * Factor2;
					fRate = fRate * Factor3;
					fRate = fRate * QuantityPerUnit;
				}

				fRate = fRate.setScale(10,decimal.ROUND_HALF_UP);
			}

			finalEquipmentHours = fRate;
			return fRate;
		}

		public virtual decimal calculateFinalEquipmentRate()
		{

			decimal fRate = finalEquipmentRate;

			if (BoqItemTable != null && AssemblyTable != null)
			{
				decimal assemblyRate = AssemblyTable.EquipmentRate * ExchangeRate;
				assemblyRate = assemblyRate * LocalFactor;

				//			if ( getBoqItemTable().getHasProductivity() || getBoqItemTable().getQuantity().compareTo(BigDecimalMath.ZERO) <= 0 ) {
				fRate = assemblyRate * Factor1;
				fRate = fRate * Factor2;
				fRate = fRate * Factor3;
				fRate = fRate * QuantityPerUnit;
				//			}
				//			else { // Total Units Method:				
				//				fRate = assemblyRate.multiply(getTotalUnits());
				//				try {
				//					fRate = BigDecimalMath.div(fRate,getBoqItemTable().getQuantity());
				//				} catch(ArithmeticException ex) {
				//					fRate = BigDecimalMath.ZERO;
				//				}
				//			}			
				equipmentCost = fRate * (BoqItemTable.Quantity);

				fRate = fRate.setScale(10,decimal.ROUND_HALF_DOWN);
				equipmentCost = equipmentCost.setScale(10,decimal.ROUND_HALF_DOWN);
			}

			finalEquipmentRate = fRate;
			return fRate;
		}

		public virtual decimal calculateFinalSubcontractorRate()
		{

			decimal fRate = finalSubcontractorRate;


			if (BoqItemTable != null && AssemblyTable != null)
			{
				decimal assemblyRate = AssemblyTable.SubcontractorRate * ExchangeRate;
				assemblyRate = assemblyRate * LocalFactor;

				//			if ( getBoqItemTable().getHasProductivity() || getBoqItemTable().getQuantity().compareTo(BigDecimalMath.ZERO) <= 0 ) {
				fRate = assemblyRate * Factor1;
				fRate = fRate * Factor2;
				fRate = fRate * Factor3;
				fRate = fRate * QuantityPerUnit;
				//			}
				//			else { // Total Units Method:				
				//				fRate = assemblyRate.multiply(getTotalUnits());
				//				try {
				//					fRate = BigDecimalMath.div(fRate,getBoqItemTable().getQuantity());
				//				} catch(ArithmeticException ex) {
				//					fRate = BigDecimalMath.ZERO;
				//				}
				//			}

				subcontractorCost = fRate * (BoqItemTable.Quantity);

				fRate = fRate.setScale(10,decimal.ROUND_HALF_DOWN);
				subcontractorCost = subcontractorCost.setScale(10,decimal.ROUND_HALF_DOWN);
			}

			finalSubcontractorRate = fRate;
			return fRate;
		}


		public virtual decimal calculateFinalMaterialResourceRate()
		{

			decimal fRate = finalMaterialRate;


			if (BoqItemTable != null && AssemblyTable != null)
			{
				decimal assemblyRate = AssemblyTable.MaterialRate * ExchangeRate;
				assemblyRate = assemblyRate * LocalFactor;

				//			if ( getBoqItemTable().getHasProductivity() || getBoqItemTable().getQuantity().compareTo(BigDecimalMath.ZERO) <= 0 ) {
				fRate = assemblyRate * Factor1;
				fRate = fRate * Factor2;
				fRate = fRate * Factor3;
				fRate = fRate * QuantityPerUnit;
				//			}
				//			else { // Total Units Method:
				//				fRate = assemblyRate.multiply(getTotalUnits());
				//				try {
				//					fRate = BigDecimalMath.div(fRate,getBoqItemTable().getQuantity());
				//				} catch(ArithmeticException ex) {
				//					fRate = BigDecimalMath.ZERO;
				//				}
				//			}
				fRate = fRate.setScale(10,decimal.ROUND_HALF_UP);

				materialTotalCost = fRate * (BoqItemTable.Quantity);

				fRate = fRate.setScale(10,decimal.ROUND_HALF_DOWN);
				materialTotalCost = materialTotalCost.setScale(10,decimal.ROUND_HALF_DOWN);
			}

			finalMaterialRate = fRate;
			return fRate;
		}


		public virtual decimal calculateFinalShipmentRate()
		{

			decimal fRate = finalShipmentRate;


			if (BoqItemTable != null && AssemblyTable != null)
			{
				decimal assemblyRate = AssemblyTable.AssemblyShipmentRate * ExchangeRate;
				assemblyRate = assemblyRate * LocalFactor;

				//			if ( getBoqItemTable().getHasProductivity() || getBoqItemTable().getQuantity().compareTo(BigDecimalMath.ZERO) <= 0 ) {
				fRate = assemblyRate * Factor1;
				fRate = fRate * Factor2;
				fRate = fRate * Factor3;
				fRate = fRate * QuantityPerUnit;
				//			}
				//			else { // Total Units Method:				
				//				fRate = assemblyRate.multiply(getTotalUnits());
				//				try {
				//					fRate = BigDecimalMath.div(fRate,getBoqItemTable().getQuantity());
				//				} catch(ArithmeticException ex) {
				//					fRate = BigDecimalMath.ZERO;
				//				}
				//			}

				fRate = fRate.setScale(10,decimal.ROUND_HALF_DOWN);
			}

			finalShipmentRate = fRate;
			return fRate;
		}

		public virtual decimal calculateFinalFabricationRate()
		{

			decimal fRate = finalFabricationRate;


			if (BoqItemTable != null && AssemblyTable != null)
			{
				decimal assemblyRate = AssemblyTable.AssemblyFabricationRate * ExchangeRate;
				assemblyRate = assemblyRate * LocalFactor;

				//			if ( getBoqItemTable().getHasProductivity() || getBoqItemTable().getQuantity().compareTo(BigDecimalMath.ZERO) <= 0 ) {
				fRate = assemblyRate * Factor1;
				fRate = fRate * Factor2;
				fRate = fRate * Factor3;
				fRate = fRate * QuantityPerUnit;
				//			}
				//			else { // Total Units Method:				
				//				fRate = assemblyRate.multiply(getTotalUnits());
				//				try {
				//					fRate = BigDecimalMath.div(fRate,getBoqItemTable().getQuantity());
				//				} catch(ArithmeticException ex) {
				//					fRate = BigDecimalMath.ZERO;
				//				}
				//			}

				fRate = fRate.setScale(10,decimal.ROUND_HALF_DOWN);
			}

			finalFabricationRate = fRate;
			return fRate;
		}

		public virtual decimal calculateFinalConsumableRate()
		{

			decimal fRate = finalConsumableRate;


			if (BoqItemTable != null && AssemblyTable != null)
			{
				decimal assemblyRate = AssemblyTable.ConsumableRate * ExchangeRate;
				assemblyRate = assemblyRate * LocalFactor;

				//			if ( getBoqItemTable().getHasProductivity() || getBoqItemTable().getQuantity().compareTo(BigDecimalMath.ZERO) <= 0 ) {
				fRate = assemblyRate * Factor1;
				fRate = fRate * Factor2;
				fRate = fRate * Factor3;
				fRate = fRate * QuantityPerUnit;
				//			}
				//			else { // Total Units Method:				
				//				fRate = assemblyRate.multiply(getTotalUnits());
				//				try {
				//					fRate = BigDecimalMath.div(fRate,getBoqItemTable().getQuantity());
				//				} catch(ArithmeticException ex) {
				//					fRate = BigDecimalMath.ZERO;
				//				}
				//			}
				consumableCost = fRate * (BoqItemTable.Quantity);

				fRate = fRate.setScale(10,decimal.ROUND_HALF_DOWN);
				consumableCost = consumableCost.setScale(10,decimal.ROUND_HALF_DOWN);
			}

			finalConsumableRate = fRate;
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
		/// @hibernate.property column="FEQURATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalEquipmentRate
		{
			get
			{
				return finalEquipmentRate;
			}
			set
			{
				finalEquipmentRate = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FLABRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalLaborRate
		{
			get
			{
				return finalLaborRate;
			}
			set
			{
				finalLaborRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FMATRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalMaterialRate
		{
			get
			{ // Includes Fab+Shipment
				return finalMaterialRate;
			}
			set
			{
				finalMaterialRate = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FSHPRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalShipmentRate
		{
			get
			{
				return finalShipmentRate;
			}
			set
			{
				finalShipmentRate = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FFABRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalFabricationRate
		{
			get
			{
				return finalFabricationRate;
			}
			set
			{
				finalFabricationRate = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FSUBRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalSubcontractorRate
		{
			get
			{
				return finalSubcontractorRate;
			}
			set
			{
				finalSubcontractorRate = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FCONRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalConsumableRate
		{
			get
			{
				return finalConsumableRate;
			}
			set
			{
				finalConsumableRate = value;
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
		/// Description Here
		/// 
		/// @hibernate.property column="LABCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal LaborCost
		{
			get
			{
				return laborCost;
			}
			set
			{
				laborCost = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EQUCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal EquipmentCost
		{
			get
			{
				return equipmentCost;
			}
			set
			{
				equipmentCost = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SUBCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal SubcontractorCost
		{
			get
			{
				return subcontractorCost;
			}
			set
			{
				subcontractorCost = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MATTOTCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal MaterialCost
		{
			get
			{
				return materialTotalCost;
			}
			set
			{
				materialTotalCost = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CONCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal ConsumableCost
		{
			get
			{
				return consumableCost;
			}
			set
			{
				consumableCost = value;
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
		/// @hibernate.property column="TOTALUNITS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal TotalUnits
		{
			get
			{
				if (!HasUserTotalUnits.Value && BoqItemTable != null)
				{
					totalUnits = calculateTotalUnits();
				}
    
				return totalUnits;
			}
			set
			{
				//value = value.setScale(DBPreferences.getInstance().getBigDecimalScale());		
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

		public virtual decimal calculateTotalUnits()
		{
			decimal tUnits = BigDecimalMath.ONE;
			BoqItemTable boqItemTable = BoqItemTable;

			if (boqItemTable != null)
			{

				//AssemblyTable assTable = getAssemblyTable();

				//if ( assTable.getUnit().equals(boqItemTable.getUnit()) ) {
				tUnits = boqItemTable.Quantity;
				//}

				tUnits = tUnits * Factor1;
				tUnits = tUnits * Factor2;
				tUnits = tUnits * Factor3;
				tUnits = tUnits * QuantityPerUnit;

				//tUnits = tUnits.multiply(getBoqItemTable().getDuration());
				TotalUnits = tUnits;
			}

			return tUnits;
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
		///  column="ASSEMBLYID"
		///  cascade="none" </summary>
		/// <returns> AssemblyTable </returns>
		public virtual AssemblyTable AssemblyTable
		{
			get
			{
				return assemblyTable;
			}
			set
			{
				this.assemblyTable = value;
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
				return BoqItemAssemblyId;
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
				return AssemblyTable;
			}
			set
			{
				AssemblyTable = (AssemblyTable) value;
			}
		}

		public override ResourceToAssignmentTable Data
		{
			set
			{
				Data = (BoqItemAssemblyTable)value;
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