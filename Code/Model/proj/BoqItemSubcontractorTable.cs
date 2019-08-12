using System;

namespace Model.proj
{

	using BoqItemToAssignmentTable = nomitech.common.@base.BoqItemToAssignmentTable;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceWithAssignmentsTable = nomitech.common.@base.ResourceWithAssignmentsTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using SubcontractorTable = nomitech.common.db.local.SubcontractorTable;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;

	//#RXL_START 
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="BOQITEM_SUBCONTRACTOR" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	[Serializable]
	public class BoqItemSubcontractorTable : BoqItemToAssignmentTable, ProjectIdEntity
	{

		private const long serialVersionUID = 1L;

		public static readonly string[] FIELDS = new string[] {"factor1", "factor2", "factor3", "exchangeRate", "totalUnits", "finalRate", "totalCost", "fixedCost", "finalFixedCost", "variableCost", "comment"};

		private long? boqItemSubcontractorId;
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
		private BoqItemTable boqItemTable;
		private ParamItemTable paramItemTable;
		private SubcontractorTable subcontractorTable;
		//IndexedEmbedded(depth = 1, prefix = "quote")
		private QuoteItemTable quoteItemTable;
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

		public BoqItemSubcontractorTable()
		{

		}

		public virtual object clone(bool relations)
		{
			if (relations)
			{
				return clone();
			}

			BoqItemSubcontractorTable obj = new BoqItemSubcontractorTable();

			obj.ParamItemId = ParamItemId;
			obj.BoqItemSubcontractorId = BoqItemSubcontractorId;
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

			return obj;
		}

		public virtual object clone()
		{
			BoqItemSubcontractorTable obj = new BoqItemSubcontractorTable();

			obj.ParamItemId = ParamItemId;
			obj.BoqItemSubcontractorId = BoqItemSubcontractorId;
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
				obj.BoqItemTable = (BoqItemTable) BoqItemTable.clone();
			}

			if (SubcontractorTable != null)
			{
				obj.SubcontractorTable = (SubcontractorTable) SubcontractorTable.clone();
			}

			return obj;
		}

		public virtual BoqItemSubcontractorTable Data
		{
			set
			{
    
				ParamItemId = value.ParamItemId;
				BoqItemSubcontractorId = value.BoqItemSubcontractorId;
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
				Comment = value.Comment;
    
				PvVars = value.PvVars;
			}
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="BOQITEMSUBCONTRACTORID" </summary>
		/// <returns> Long </returns>
		public virtual long? BoqItemSubcontractorId
		{
			get
			{
				return boqItemSubcontractorId;
			}
			set
			{
				boqItemSubcontractorId = value;
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
				totalUnits = tUnits;
			}

			if (BoqItemTable != null && SubcontractorTable != null)
			{
				decimal subcontractorRate = SubcontractorTable.RateForCalculation * ExchangeRate;
				subcontractorRate = subcontractorRate * LocalFactor;
				//			if ( getBoqItemTable().getHasProductivity() || getBoqItemTable().getQuantity().compareTo(BigDecimalMath.ZERO) <= 0 ) {
				fRate = subcontractorRate * Factor1;
				fRate = fRate * Factor2;
				fRate = fRate * Factor3;
				fRate = fRate * QuantityPerUnit;

				//			}
				//			else { // Total Units Method:				
				//				fRate = subcontractorRate.multiply(getTotalUnits());
				//			    try {
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
				variableCost = variableCost.setScale(10, decimal.ROUND_HALF_UP);
				totalCost = totalCost.setScale(10, decimal.ROUND_HALF_UP);
				fRate = fRate.setScale(10, decimal.ROUND_HALF_UP);
				totalUnits = totalUnits.setScale(10, decimal.ROUND_HALF_UP);
			}

			finalRate = fRate;
			return fRate;
		}

		//	public BigDecimal calculateFinalQuotedRate() {
		//
		//		BigDecimal fRate = finalRate;
		//
		//		if ( getBoqItemTable() != null ) {
		//			BigDecimal tUnits = BigDecimalMath.ONE;
		//			tUnits = boqItemTable.getQuantity();		
		//			tUnits = tUnits.multiply(getFactor1());	    
		//			tUnits = tUnits.multiply(getFactor2());
		//			tUnits = tUnits.multiply(getFactor3());
		//			tUnits = tUnits.multiply(getQuantityPerUnit());
		//			totalUnits = tUnits;			
		//		}
		//
		//		if ( getBoqItemTable() != null && getSubcontractorTable() != null ) {
		//			BigDecimal subcontractorRate = getSubcontractorTable().getRateForCalculation().multiply(getExchangeRate());
		//			subcontractorRate = subcontractorRate.multiply(getLocalFactor());
		//			//			if ( getBoqItemTable().getHasProductivity() || getBoqItemTable().getQuantity().compareTo(BigDecimalMath.ZERO) <= 0 ) {
		//			fRate = subcontractorRate.multiply(getFactor1());
		//			fRate = fRate.multiply(getFactor2());
		//			fRate = fRate.multiply(getFactor3());	
		//			fRate = fRate.multiply(getQuantityPerUnit());					
		//			//			}
		//			//			else { // Total Units Method:				
		//			//				fRate = subcontractorRate.multiply(getTotalUnits());
		//			//			    try {
		//			//					fRate = BigDecimalMath.div(fRate,getBoqItemTable().getQuantity());
		//			//				} catch(ArithmeticException ex) {
		//			//					fRate = BigDecimalMath.ZERO;
		//			//				}
		//			//			}
		//			
		//			totalCost = fRate.multiply(getBoqItemTable().getQuantity());
		//			
		//			// Avoid precision/scale updates if data is the same:
		//			totalCost = totalCost.setScale(10,BigDecimal.ROUND_HALF_UP);			
		//			fRate = fRate.setScale(10,BigDecimal.ROUND_HALF_UP);	
		//			totalUnits = totalUnits.setScale(10,BigDecimal.ROUND_HALF_UP);			
		//		}
		//
		//		finalRate = fRate;
		//		return fRate;
		//	}

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


		//    public BigDecimal getFinalIKARate() {
		//		
		//		BigDecimal finalRate = new BigDecimalFixed("0.0");
		//		
		//		if ( getBoqItemTable() != null && getSubcontractorTable() != null ) {
		////			if ( getBoqItemTable().getHasProductivity() || getBoqItemTable().getQuantity().compareTo(BigDecimalMath.ZERO) <= 0) {
		//				finalRate = getSubcontractorTable().getIKA().multiply(getFactor1());
		//				finalRate = finalRate.multiply(getFactor2());
		//				finalRate = finalRate.multiply(getFactor3());
		//				finalRate = finalRate.multiply(getQuantityPerUnit());				
		//				finalRate = finalRate.multiply(getExchangeRate());
		//				finalRate = finalRate.multiply(getLocalFactor());
		////			}
		////			else { // Total Units Method:				
		////				finalRate = getSubcontractorTable().getIKA().multiply(getExchangeRate());
		////				finalRate = finalRate.multiply(getLocalFactor());
		////				finalRate = finalRate.multiply(getTotalUnits());
		////				finalRate = finalRate.divide(getBoqItemTable().getQuantity(),BothDBPreferences.getInstance().getBigDecimalDividerScale(),BigDecimal.ROUND_DOWN);
		////			}
		//		}
		//		
		//		return finalRate;
		//	}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TOTALCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal TotalCost
		{
			get
			{
    
				//        BigDecimal total = totalCost;
				//    	
				//    	if ( total == null )
				//    	    totalCost = (BigDecimal)o_map.get("totalCost");
				//
				//    	
				//    	if ( getBoqItemTable() != null && getSubcontractorTable() != null ) {
				//		   total = calculateFinalRate().multiply(getBoqItemTable().getQuantity());
				//    	}
				//    	totalCost = total;
				//		o_map.put("finalRate",total);
				return totalCost;
			}
			set
			{
				totalCost = value;
				//o_map.put("totalCost",value);                
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
				//value = value.setScale(DBPreferences.getInstance().getBigDecimalScale());		
				factor1 = value;
				//o_map.put("factor1",value);                
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
				//value = value.setScale(DBPreferences.getInstance().getBigDecimalScale());
				lastUpdate = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="SUBCONTRACTORID"
		///  cascade="none" </summary>
		/// <returns> SubcontractorTable </returns>
		public virtual SubcontractorTable SubcontractorTable
		{
			get
			{
				return subcontractorTable;
			}
			set
			{
				this.subcontractorTable = value;
			}
		}


		// unique=true
		/// <summary>
		/// @hibernate.many-to-one
		///  column="QUOTEITEMID"
		///  cascade="none"
		/// </summary>
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
				return BoqItemSubcontractorId;
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
				return SubcontractorTable;
			}
			set
			{
				SubcontractorTable = (SubcontractorTable) value;
			}
		}

		public override ResourceToAssignmentTable Data
		{
			set
			{
				Data = (BoqItemSubcontractorTable) value;
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