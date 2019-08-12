using System;

namespace Model.proj
{


	using ar = com.jniwrapper.ar;

	using BoqItemToAssignmentTable = nomitech.common.@base.BoqItemToAssignmentTable;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceWithAssignmentsTable = nomitech.common.@base.ResourceWithAssignmentsTable;
	using MaterialTable = nomitech.common.db.local.MaterialTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	//#RXL_START 
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="BOQITEM_MATERIAL"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	[Serializable]
	public class BoqItemMaterialTable : BoqItemToAssignmentTable, ProjectIdEntity
	{

		/// 
		private const long serialVersionUID = 1L;

		public static readonly string[] FIELDS = new string[] {"factor1", "factor2", "factor3", "quantityPerUnit", "quantityPerUnitFormula", "exchangeRate", "totalUnits", "finalMaterialRate", "finalFabricationRate", "finalShipmentRate", "finalRate", "totalMaterialCost", "totalFabricationCost", "totalShipmentCost", "totalCost", "escalation", "finalEscalationRate", "totalEscalationCost", "fixedCost", "finalFixedCost", "variableCost", "comment"};

		private long? boqItemMaterialId;
		private decimal factor1;
		private decimal factor2;
		private decimal escalation;
		private decimal factor3;
		private decimal quantityPerUnit;
		private string quantityPerUnitFormula;
		private sbyte? quantityPerUnitFormulaState;
		private decimal exchangeRate;
		private decimal totalUnits;
		private decimal finalMaterialRate;
		private decimal finalFabricationRate;
		private decimal finalShipmentRate;
		private decimal finalEscalationRate;
		private decimal finalRate;
		private decimal totalMaterialCost;
		private decimal totalFabricationCost;
		private decimal totalShipmentCost;
		private decimal totalEscalationCost;
		private decimal totalCost = null;
		private decimal localFactor;
		private string localCountry;
		private string localStateProvince;
		private bool? hasUserTotalUnits;
		private DateTime lastUpdate;
		private long? paramItemId;
		private BoqItemTable boqItemTable;
		private ParamItemTable paramItemTable;
		private MaterialTable materialTable;
		private QuoteItemTable quoteItemTable;

		// FIXED COST:
		private decimal fixedCost = null;
		private decimal finalFixedCost = decimal.Zero;
		private decimal variableCost = decimal.Zero;

		private string comment;

		/// <summary>
		/// This String declares which SQL COLUMN contains which PV Variables
		/// 	e.g. <code>CUSRATE1FORM:var1,var2;CUSTXT1FORM:mitsos,george;MARKUPFORM:var2,mitsos</code>
		/// </summary>
		private string pvVars;

		public BoqItemMaterialTable()
		{
		}

		public virtual object clone(bool relations)
		{
			BoqItemMaterialTable obj = new BoqItemMaterialTable();

			obj.ParamItemId = ParamItemId;
			obj.BoqItemMaterialId = BoqItemMaterialId;
			obj.FinalRate = FinalRate;
			obj.FinalMaterialRate = FinalMaterialRate;
			obj.FinalFabricationRate = FinalFabricationRate;
			obj.FinalShipmentRate = FinalShipmentRate;
			obj.FinalEscalationRate = FinalEscalationRate;
			obj.Escalation = Escalation;
			obj.TotalMaterialCost = TotalMaterialCost;
			obj.TotalFabricationCost = TotalFabricationCost;
			obj.TotalShipmentCost = TotalShipmentCost;
			obj.TotalEscalationCost = TotalEscalationCost;
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

			if (relations)
			{
				if (BoqItemTable != null)
				{
					obj.BoqItemTable = (BoqItemTable)BoqItemTable.clone();
				}

				if (MaterialTable != null)
				{
					obj.MaterialTable = (MaterialTable)MaterialTable.clone();
				}
			}

			return obj;
		}

		public virtual object clone()
		{
			return clone(true);
		}

		public virtual BoqItemMaterialTable Data
		{
			set
			{
    
				ParamItemId = value.ParamItemId;
				BoqItemMaterialId = value.BoqItemMaterialId;
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
				Escalation = value.Escalation;
				HasUserTotalUnits = value.HasUserTotalUnits;
    
				FinalMaterialRate = value.FinalMaterialRate;
				FinalFabricationRate = value.FinalFabricationRate;
				FinalShipmentRate = value.FinalShipmentRate;
				FinalEscalationRate = value.FinalEscalationRate;
				Escalation = value.Escalation;
				TotalMaterialCost = value.TotalMaterialCost;
				TotalFabricationCost = value.TotalFabricationCost;
				TotalShipmentCost = value.TotalShipmentCost;
				TotalEscalationCost = value.TotalEscalationCost;
				TotalCost = value.TotalCost;
				FinalRate = value.FinalRate;
    
				FixedCost = value.FixedCost;
				FinalFixedCost = value.FinalFixedCost;
				VariableCost = value.VariableCost;
				Comment = value.Comment;
    
				PvVars = value.PvVars;
			}
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="BOQITEMMATERIALID" </summary>
		/// <returns> Long </returns>
		public virtual long? BoqItemMaterialId
		{
			get
			{
				return boqItemMaterialId;
			}
			set
			{
				boqItemMaterialId = value;
			}
		}


		public virtual decimal FinalMaterialRate
		{
			get
			{
				return finalMaterialRate;
			}
			set
			{
				finalMaterialRate = value;
			}
		}


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


		public virtual decimal FinalEscalationRate
		{
			get
			{
				return finalEscalationRate;
			}
			set
			{
				finalEscalationRate = value;
			}
		}


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


		public virtual decimal calculateFinalRate()
		{
			decimal fRate = finalRate;

			if (BoqItemTable != null)
			{
				decimal tUnits = BigDecimalMath.ONE;
				tUnits = boqItemTable.Quantity;

				tUnits = tUnits * Factor1;
				tUnits = tUnits * Factor2;
				tUnits = tUnits * Factor3;
				tUnits = tUnits * QuantityPerUnit;

				//tUnits = tUnits.multiply(getBoqItemTable().getDuration());
				totalUnits = tUnits;
			}

			if (MaterialTable != null)
			{
				fRate = calculateFinalRateFor(MaterialTable.RateForCalculation);
				finalShipmentRate = calculateFinalRateFor(MaterialTable.ShipmentRate);
				finalFabricationRate = calculateFinalRateFor(MaterialTable.FabricationRate);
				finalMaterialRate = calculateFinalRateFor(MaterialTable.Rate);

				// Escalation
				bool isUnspecified = MaterialTable.RawMaterial.Equals(MaterialTable.UNSPECIFIED_RAWMAT);
				if (isUnspecified)
				{
					finalEscalationRate = BigDecimalMath.ZERO;
				}
				else
				{
					decimal esc = BigDecimalMath.ONE.subtract(Escalation);
					decimal reliance = new BigDecimalFixed("" + MaterialTable.RawMaterialReliance.doubleValue() / 100D);
					decimal materialRate = fRate * reliance;
					finalEscalationRate = materialRate * esc;
					finalEscalationRate = materialRate - finalEscalationRate;
					//	          FULL FORMULA:			
					//			materialRate = materialUnitRate*factor1*factor2/divider*exchangeRate*reliance
					//			finalEscalationRate = materialRate-(materialRate*(1 - escalationFactor))
					//			totalEscalationCost = finalEscalationRate*quantity
					//			escalationCost = SUM(totalEscalationCost)
				}

				if (BoqItemTable != null)
				{

					// Calculate Variable, Total Cost:
					variableCost = fRate * (BoqItemTable.Quantity);

					totalCost = decimal.Zero;
					totalCost = totalCost + variableCost;
					totalCost = totalCost + FinalFixedCost;

					// Avoid precision/scale updates if data is the same:
					variableCost = variableCost.setScale(10,decimal.ROUND_HALF_UP);

					totalShipmentCost = finalShipmentRate * (BoqItemTable.Quantity);
					totalFabricationCost = finalFabricationRate * (BoqItemTable.Quantity);
					totalEscalationCost = finalEscalationRate * (BoqItemTable.Quantity);
					totalMaterialCost = finalMaterialRate * (BoqItemTable.Quantity);


					// Avoid precision/scale updates if data is the same:
					fRate = fRate.setScale(10,decimal.ROUND_HALF_UP);
					finalShipmentRate = finalShipmentRate.setScale(10,decimal.ROUND_HALF_UP);
					finalFabricationRate = finalFabricationRate.setScale(10,decimal.ROUND_HALF_UP);
					finalEscalationRate = finalEscalationRate.setScale(10,decimal.ROUND_HALF_UP);
					finalMaterialRate = finalMaterialRate.setScale(10,decimal.ROUND_HALF_UP);

					totalCost = totalCost.setScale(10,decimal.ROUND_HALF_UP);
					totalShipmentCost = totalShipmentCost.setScale(10,decimal.ROUND_HALF_UP);
					totalFabricationCost = totalFabricationCost.setScale(10,decimal.ROUND_HALF_UP);
					totalEscalationCost = totalEscalationCost.setScale(10,decimal.ROUND_HALF_UP);
					totalMaterialCost = totalMaterialCost.setScale(10,decimal.ROUND_HALF_UP);
					totalUnits = totalUnits.setScale(10,decimal.ROUND_HALF_UP);
				}
			}

			finalRate = fRate;
			return fRate;
		}

		private decimal calculateFinalRateFor(decimal rate)
		{
			rate = rate * ExchangeRate;
			rate = rate * LocalFactor;

			decimal fRate = rate * Factor1;
			fRate = fRate * Factor2;
			fRate = fRate * Factor3;
			fRate = fRate * QuantityPerUnit;

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


		public virtual decimal TotalMaterialCost
		{
			get
			{
				return totalMaterialCost;
			}
			set
			{
				totalMaterialCost = value;
			}
		}

		public virtual decimal TotalEscalationCost
		{
			get
			{
				return totalEscalationCost;
			}
			set
			{
				totalEscalationCost = value;
			}
		}

		public virtual decimal TotalShipmentCost
		{
			get
			{
				return totalShipmentCost;
			}
			set
			{
				totalShipmentCost = value;
			}
		}

		public virtual decimal TotalFabricationCost
		{
			get
			{
				return totalFabricationCost;
			}
			set
			{
				totalFabricationCost = value;
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
		/// @hibernate.property column="ESCALATION" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Escalation
		{
			get
			{
				return escalation;
			}
			set
			{
				this.escalation = value;
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
				lastUpdate = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="MATERIALID"
		///  cascade="none" </summary>
		/// <returns> MaterialTable </returns>
		public virtual MaterialTable MaterialTable
		{
			get
			{
				return materialTable;
			}
			set
			{
				this.materialTable = value;
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


		//unique=true
		/// <summary>
		/// @hibernate.many-to-one
		///  column="QUOTEITEMID"
		///  cascade="none" </summary>
		/// <returns> QuoteItemTable </returns>
		public virtual QuoteItemTable QuoteItemTable
		{
			get
			{
				return quoteItemTable;
			}
			set
			{
				this.quoteItemTable = value;
			}
		}


		public override long? Id
		{
			get
			{
				return BoqItemMaterialId;
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
				return MaterialTable;
			}
			set
			{
				MaterialTable = (MaterialTable) value;
			}
		}

		public override ResourceToAssignmentTable Data
		{
			set
			{
				Data = (BoqItemMaterialTable)value;
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
				if (value == null)
				{
		//			System.out.println("To piasa");
		//			Thread.dumpStack();
				}
				this.projectId = value;
			}
		}

	}
}