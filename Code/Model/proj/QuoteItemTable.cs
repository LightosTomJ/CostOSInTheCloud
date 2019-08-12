using System;

namespace Model.proj
{

	using BoqItemToAssignmentTable = nomitech.common.@base.BoqItemToAssignmentTable;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceWithAssignmentsTable = nomitech.common.@base.ResourceWithAssignmentsTable;
	using MaterialTable = nomitech.common.db.local.MaterialTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	using SubcontractorTable = nomitech.common.db.local.SubcontractorTable;
	using SupplierTable = nomitech.common.db.local.SupplierTable;
	using BigDecimalFixed = nomitech.common.db.types.BigDecimalFixed;
	using BlankResourceInitializer = nomitech.common.expr.boqitem.BlankResourceInitializer;
	using BigDecimalMath = nomitech.common.util.BigDecimalMath;
	using HaversineDistanceUtil = nomitech.common.util.HaversineDistanceUtil;
	using StringUtils = nomitech.common.util.StringUtils;
	//#RXL_START
	/// <summary>
	/// @hibernate.class table="QUOTEITEM" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	[Serializable]
	public class QuoteItemTable : BoqItemToAssignmentTable, ProjectIdEntity, IComparable
	{

		public const string AWARDED_STATE = "enum.quote.status.awarded";
		public const string REJECTED_STATE = "enum.quote.status.rejected";
		public const string PENDING_STATE = "enum.quote.status.pending";
		public const string NOTAVAILABLE_STATE = "enum.quote.status.notavailable";
		public const string WORKITEM_STATE = "enum.quote.status.workitem";

		public static readonly string[] FIELDS = new string[] {"quoteItemId", "title", "state", "unit", "quantity", "manHours", "material", "rate", "insurance", "indirect", "finalRate"};

		private long? quoteItemId;
		private string title;
		private string unit;
		private decimal quantity;
		private decimal mainQuantity;
		private decimal insurance;
		private decimal manHours;
		private decimal material;
		private decimal indirectCost;
		private decimal shipmentCost;
		private decimal rate;
		private decimal totalCost;
		private decimal factor1;
		private decimal factor2;
		private string state;
		private bool? resource;
		private decimal finalRate;

		private QuotationTable quotationTable;
		private BoqItemTable boqItemTable;

		private BoqItemSubcontractorTable subcontractorTable;
		private BoqItemMaterialTable materialTable;

		private long? supplierDatabaseId;
		private long? databaseId;
		private long? databaseCreationDate;

		[NonSerialized]
		private System.Collections.IDictionary o_propertiesMap;



		public QuoteItemTable()
		{
			//o_map = new HashMap();
		}

		public QuoteItemTable(System.Collections.IDictionary propertiesMap)
		{
			o_propertiesMap = propertiesMap;
		}

		public virtual System.Collections.IDictionary PropertiesMap
		{
			set
			{
				o_propertiesMap = value;
			}
			get
			{
				return o_propertiesMap;
			}
		}


		//	public Object valueForField(String field) {
		//		if ( field.equals("finalRate") ) {
		//			return DBFieldFormatUtil.formatObject(calculateFinalRate());
		//		}
		//		else if ( field.equals("shipmentRate") ) {
		//			return DBFieldFormatUtil.formatObject(getShipmentRate());
		//		}
		//		else if ( field.equals("totalCost") ) {
		//			return DBFieldFormatUtil.formatObject(getTotalCost());
		//		}
		//		
		//		return DBFieldFormatUtil.formatObject(o_map.get(field));
		//	}
		//	public Object scaledValueForField(String field) {
		//		if ( field.equals("finalRate") ) {
		//			return DBFieldFormatUtil.scaleAndFormatObject(calculateFinalRate());
		//		}
		//		else if ( field.equals("shipmentRate") ) {
		//			return DBFieldFormatUtil.scaleAndFormatObject(getShipmentRate());
		//		}
		//		else if ( field.equals("totalCost") ) {
		//			return DBFieldFormatUtil.scaleAndFormatObject(getTotalCost());
		//		}
		//		
		//		return DBFieldFormatUtil.scaleAndFormatObject(o_map.get(field));
		//	}
		public virtual object clone(bool relations)
		{
			return clone(relations, relations?true:false);
		}

		public override object clone(bool cloneParent, bool cloneResource)
		{

			QuoteItemTable obj = (QuoteItemTable)clone();

			if (cloneResource && BoqItemTable != null)
			{
				obj.BoqItemTable = (BoqItemTable)BoqItemTable.clone();
			}
			if (cloneParent && QuotationTable != null)
			{
				obj.QuotationTable = (QuotationTable)QuotationTable.clone();
			}

			return obj;
		}

		public virtual QuoteItemTable Data
		{
			set
			{
				SupplierDatabaseId = value.SupplierDatabaseId;
				DatabaseId = value.DatabaseId;
				DatabaseCreationDate = value.DatabaseCreationDate;
				QuoteItemId = value.QuoteItemId;
				Title = value.Title;
				Resource = value.Resource;
				Unit = value.Unit;
				Quantity = value.Quantity;
				MainQuantity = value.MainQuantity;
				ManHours = value.ManHours;
				IndirectCost = value.IndirectCost;
				IndirectRate = value.IndirectRate;
				Material = value.Material;
    
				Factor1 = value.Factor1;
				Factor2 = value.Factor2;
				Insurance = value.Insurance;
				Rate = value.Rate;
				State = value.State;
				ShipmentCost = value.ShipmentCost;
				ShipmentRate = value.ShipmentRate;
				FinalRate = value.calculateFinalRate();
			}
		}

		public virtual object clone()
		{
			//		if ( o_map == null ) o_map = new HashMap();

			QuoteItemTable obj = new QuoteItemTable();

			obj.SupplierDatabaseId = SupplierDatabaseId;
			obj.DatabaseId = DatabaseId;
			obj.DatabaseCreationDate = DatabaseCreationDate;
			obj.QuoteItemId = QuoteItemId;
			obj.Title = Title;
			obj.Unit = Unit;
			obj.Resource = Resource;
			obj.State = State;
			obj.Quantity = Quantity;
			obj.ManHours = ManHours;
			obj.IndirectCost = IndirectCost;
			obj.IndirectRate = IndirectRate;
			obj.Material = Material;
			obj.MainQuantity = MainQuantity;
			obj.Factor1 = Factor1;
			obj.Factor2 = Factor2;
			obj.Insurance = Insurance;
			obj.Rate = Rate;
			obj.ShipmentCost = ShipmentCost;
			obj.ShipmentRate = ShipmentRate;
			obj.FinalRate = calculateFinalRate();
			obj.ProjectId = ProjectId;

			return obj;
		}

		//	private BoqItemTable cloneOnlyRequired(BoqItemTable obj) {
		//		BoqItemTable boqTable = new BoqItemTable();
		//		
		//		boqTable.setBoqitemId(obj.getBoqitemId());
		//		boqTable.setCode(obj.getCode());
		//		boqTable.setPublishedItemCode(obj.getPublishedItemCode());
		//		boqTable.setTitle(obj.getTitle());
		//		boqTable.setQuantity(obj.getQuantity());
		//		boqTable.setUnit(obj.getUnit());
		//		boqTable.setRate(obj.getRate());
		//		boqTable.setMaterialRate(obj.getMaterialRate());
		//		boqTable.setSubcontractorRate(obj.getSubcontractorRate());
		//		boqTable.setMaterialTotalCost(obj.getMaterialTotalCost());
		//		boqTable.setSubcontractorTotalCost(obj.getSubcontractorTotalCost());
		//		
		//		boqTable.setTotalCost(obj.getTotalCost());
		//		
		//		return boqTable;
		//	}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="QUOTEITEMID" </summary>
		/// <returns> Long </returns>
		public virtual long? QuoteItemId
		{
			get
			{
				return quoteItemId;
			}
			set
			{
				this.quoteItemId = value;
				//		o_map.put("quoteItemId",value);
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TITLE" type="costos_text" </summary>
		/// <returns> rate </returns>
		public virtual string Title
		{
			get
			{
				return title;
			}
			set
			{
				this.title = value;
				//		o_map.put("title",value);
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="UNIT" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string Unit
		{
			get
			{
				return unit;
			}
			set
			{
				this.unit = value;
				//		o_map.put("unit",value);
    
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="QUANTITY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal Quantity
		{
			get
			{
				return quantity;
			}
			set
			{
				this.quantity = value;
				//		o_map.put("quantity",value);
    
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PARQRTY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal MainQuantity
		{
			get
			{
				return mainQuantity;
			}
			set
			{
				this.mainQuantity = value;
				//		o_map.put("mainQuantity",mainQuantity);
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FACTOR1" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public override decimal Factor1
		{
			get
			{
				return factor1;
			}
			set
			{
				this.factor1 = value;
				//		o_map.put("factor1",value);
			}
		}


		/// 
		/// <summary>
		/// @hibernate.property column="MANHOURS" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal ManHours
		{
			get
			{
				return manHours;
			}
			set
			{
				this.manHours = value;
			}
		}


		/// 
		/// <summary>
		/// @hibernate.property column="MATRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal Material
		{
			get
			{
				return material;
			}
			set
			{
				this.material = value;
			}
		}


		/// 
		/// <summary>
		/// @hibernate.property column="INDIRECT" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal IndirectCost
		{
			get
			{
				return indirectCost;
			}
			set
			{
				this.indirectCost = value;
			}
		}


		public virtual BoqItemSubcontractorTable SubcontractorTable
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


		public virtual BoqItemMaterialTable MaterialTable
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
		/// Description Here
		/// 
		/// @hibernate.property column="FACTOR2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public override decimal Factor2
		{
			get
			{
				return factor2;
			}
			set
			{
				this.factor2 = value;
				//		o_map.put("factor2",value);
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="RSRC" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? Resource
		{
			get
			{
				return resource;
			}
			set
			{
				this.resource = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="STATUS" type="costos_string" index ="IDX_STATUS" </summary>
		/// <returns> String </returns>
		public virtual string State
		{
			get
			{
				return state;
			}
			set
			{
				this.state = value;
				//		o_map.put("state",value);
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="QUOTATIONID"
		///  cascade="none" </summary>
		/// <returns> QuotationTable </returns>
		public virtual QuotationTable QuotationTable
		{
			get
			{
				return quotationTable;
			}
			set
			{
				this.quotationTable = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="BOQITEMID"
		///  cascade="none" </summary>
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


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="INSURANCE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal Insurance
		{
			get
			{
				return insurance;
			}
			set
			{
				this.insurance = value;
				//		o_map.put("insurance",value);
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="RATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal Rate
		{
			get
			{
				return rate;
			}
			set
			{
				this.rate = value;
				//		o_map.put("rate",value);
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SHIPMENTCOST" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal ShipmentCost
		{
			get
			{
				return shipmentCost;
			}
			set
			{
				this.shipmentCost = value;
				//		o_map.put("shipmentCost",value);
			}
		}


		/// <summary>
		/// @hibernate.one-to-one
		///  property-ref="quoteItemTable" </summary>
		/// <returns> QuoteItemTable </returns>
		public virtual BoqItemSubcontractorTable BoqItemSubcontractorTable
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


		/// <summary>
		/// @hibernate.one-to-one
		///  property-ref="quoteItemTable" </summary>
		/// <returns> QuoteItemTable </returns>
		public virtual BoqItemMaterialTable BoqItemMaterialTable
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


		public virtual decimal calculateFinalRate()
		{
			decimal finalRate = Rate;

			if (Insurance != null && BigDecimalMath.cmp(Insurance, BigDecimalMath.ZERO) > 0)
			{
				finalRate = finalRate + Insurance;
			}

			if (Material != null && BigDecimalMath.cmp(Material, BigDecimalMath.ZERO) > 0)
			{
				finalRate = finalRate + Material;
			}
			if (IndirectCost != null && BigDecimalMath.cmp(IndirectCost, BigDecimalMath.ZERO) > 0)
			{
				finalRate = finalRate + IndirectRate;
			}

			if (ShipmentCost != null && BigDecimalMath.cmp(ShipmentCost, BigDecimalMath.ZERO) > 0)
			{
				double qty = Quantity.doubleValue();
				if (qty == 0)
				{
					qty = 1;
				}
				double fRate = ShipmentCost.doubleValue() / qty;
				finalRate = Rate + (new BigDecimalFixed("" + fRate));
			}

			if (Factor1 != null && BigDecimalMath.cmp(Factor1, BigDecimalMath.ZERO) > 0)
			{
				finalRate = BigDecimalMath.mult(finalRate, Factor1);
			}

			finalRate = finalRate.setScale(10,decimal.ROUND_HALF_UP);
			//		o_map.put("finalRate",finalRate);
			return finalRate;
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FINALRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal FinalRate
		{
			get
			{
				if (finalRate == null)
				{
					finalRate = calculateFinalRate();
				}
				return finalRate;
			}
			set
			{
				this.finalRate = value;
			}
		}


		public virtual decimal ShipmentRate
		{
			get
			{
				decimal shipmentRate = BigDecimalMath.ZERO;
    
				if (ShipmentCost != null)
				{
					double qty = Quantity.doubleValue();
					if (qty == 0)
					{
						qty = 1;
					}
					double fRate = ShipmentCost.doubleValue() / qty;
					shipmentRate = new BigDecimalFixed("" + fRate);
				}
    
				shipmentRate = shipmentRate.setScale(10,decimal.ROUND_HALF_UP);
				//		o_map.put("shipmentRate",shipmentRate);
				return shipmentRate;
			}
			set
			{
				//		o_map.put("shipmentRate",getShipmentRate());
			}
		}


		public virtual decimal IndirectRate
		{
			get
			{
				decimal indirectRate = BigDecimalMath.ZERO;
    
				if (IndirectCost != null)
				{
					decimal qty = Quantity;
					if (BigDecimalMath.cmpCheckNulls(qty, BigDecimalMath.ZERO) == 0)
					{
						qty = BigDecimalMath.ONE;
					}
    
					indirectRate = BigDecimalMath.div(IndirectCost, qty);
				}
    
				indirectRate = indirectRate.setScale(10,decimal.ROUND_HALF_UP);
				//		o_map.put("shipmentRate",shipmentRate);
				return indirectRate;
			}
			set
			{
				//		o_map.put("shipmentRate",getShipmentRate());
			}
		}



		public virtual decimal TotalCost
		{
			get
			{
    
				decimal total = totalCost;
    
				//    	if ( total == null )
				//    	    totalCost = (BigDecimal)o_map.get("totalCost");
    
    
				if (BoqItemTable != null && Resource != null && !Resource.Value)
				{
					total = calculateFinalRate() * (BoqItemTable.Quantity);
				}
				else
				{
					total = calculateFinalRate() * Quantity;
				}
    
				if (Resource != null && Resource && MainQuantity != null)
				{
					total = total * MainQuantity;
				}
    
				total = total.setScale(10,decimal.ROUND_HALF_UP);
				totalCost = total;
				//		o_map.put("totalCost",total);
				return total;
			}
			set
			{
				totalCost = value;
				//		o_map.put("totalCost",value);                
			}
		}

		/// <summary>
		/// USE BY PROJECT ONLY!
		/// 
		/// @hibernate.property column="DATABASEID" type="long" index="IDX_MDBID" </summary>
		/// <returns> lastUpdate </returns>
		public virtual long? DatabaseId
		{
			get
			{
				return databaseId;
			}
			set
			{
				this.databaseId = value;
			}
		}


		/// <summary>
		/// USE BY PROJECT ONLY!
		/// 
		/// @hibernate.property column="SUPDBID" type="long" index="IDX_SUPPLIER" </summary>
		/// <returns> lastUpdate </returns>
		public virtual long? SupplierDatabaseId
		{
			get
			{
				return supplierDatabaseId;
			}
			set
			{
				this.supplierDatabaseId = value;
			}
		}


		/// <summary>
		/// USE BY PROJECT ONLY!
		/// 
		/// @hibernate.property column="DBCREATEDATE" type="long" </summary>
		/// <returns> lastUpdate </returns>
		public virtual long? DatabaseCreationDate
		{
			get
			{
				return databaseCreationDate;
			}
			set
			{
				this.databaseCreationDate = value;
			}
		}


		public virtual int CompareTo(object b)
		{
			QuoteItemTable o = (QuoteItemTable) b;
			if (o.boqItemTable != null)
			{
				return -o.boqItemTable.BoqitemId.compareTo(boqItemTable.BoqitemId);
			}
			return o.title.CompareTo(title);
		}

		public override bool Equals(object o1)
		{
			if (!(o1 is QuoteItemTable))
			{
				return false;
			}
			QuoteItemTable o = (QuoteItemTable)o1;

			if (o.quoteItemId != null && quoteItemId != null)
			{
				return quoteItemId.Equals(o.quoteItemId);
			}
			else if (o.boqItemTable != null)
			{
				return o.boqItemTable.BoqitemId.Equals(boqItemTable.BoqitemId);
			}

			return o.title.Equals(title);
		}

		public virtual SubcontractorTable convertToSubcontractorTable(ProjectDBProperties prop)
		{
			SubcontractorTable obj = BlankResourceInitializer.createBlankSubcontractor(null);

			BoqItemTable boqItemTable = BoqItemTable;
			QuotationTable quotationTable = QuotationTable;

			if (Title.IndexOf(boqItemTable.Title, StringComparison.Ordinal) != -1 && Title.IndexOf(boqItemTable.Description, StringComparison.Ordinal) != -1)
			{
				obj.Title = StringUtils.makeShortTitle(boqItemTable.Title);
			}
			else
			{
				obj.Title = StringUtils.makeShortTitle(Title);
			}

			obj.DatabaseId = DatabaseId;
			if (DatabaseCreationDate == null)
			{
				obj.DatabaseCreationDate = 100L; //ResourceUtil.MISSING_DB_CREATE_DATE);
			}
			else
			{
				obj.DatabaseCreationDate = DatabaseCreationDate;
			}
			obj.Address = quotationTable.Address;
			obj.ContactPerson = quotationTable.ContactPerson;
			obj.GroupCode = boqItemTable.GroupCode;
			obj.GekCode = boqItemTable.GekCode;
			obj.Performance = "" + quotationTable.Performance;
			obj.Project = prop.getProperty("project.code") + " - " + prop.getProperty("project.name");
			obj.Description = boqItemTable.Description;
			obj.Notes = boqItemTable.Notes;

			obj.EditorId = DatabaseDBUtil.Properties.UserId;
			obj.PhoneNumber = quotationTable.PhoneNumber;
			obj.MobileNumber = quotationTable.MobileNumber;
			obj.Email = quotationTable.Email;
			obj.Country = quotationTable.Country;
			obj.City = quotationTable.City;
			obj.StateProvince = quotationTable.StateProvince;
			obj.SubMaterialRate = MaterialRate;
			obj.Rate = RateWithIndirect;
			obj.SubMaterialRate = MaterialRate;
			obj.IKA = Insurance;
			obj.Quantity = Quantity;
			obj.TotalRate = calculateFinalRate();
			obj.Unit = Unit;
			obj.Url = quotationTable.Url;
			obj.Company = quotationTable.CompanyName;
			obj.FaxNumber = quotationTable.FaxNumber;
			obj.Currency = quotationTable.Currency;
			obj.Accuracy = SubcontractorTable.QUOTED_ACCURACY;

			if (quotationTable.HasMaterialRate.Value)
			{
				obj.Inclusion = SubcontractorTable.MATERIAL_AND_SHIPMENT_INCLUSION;
			}
			else
			{
				obj.Inclusion = SubcontractorTable.NONE_INCLUSION;
			}

			obj.CreateUserId = quotationTable.EditorId;
			if (quotationTable.ReceivedDate != null)
			{
				obj.LastUpdate = quotationTable.ReceivedDate;
				obj.CreateDate = quotationTable.ReceivedDate;
			}
			else
			{
				obj.LastUpdate = DateTime.Now;
				obj.CreateDate = obj.LastUpdate;
			}

			obj.ExtraCode1 = boqItemTable.ExtraCode1;
			obj.ExtraCode2 = boqItemTable.ExtraCode2;
			obj.ExtraCode3 = boqItemTable.ExtraCode3;
			obj.ExtraCode4 = boqItemTable.ExtraCode4;
			obj.ExtraCode5 = boqItemTable.ExtraCode5;
			obj.ExtraCode6 = boqItemTable.ExtraCode6;
			obj.ExtraCode7 = boqItemTable.ExtraCode7;
			obj.ExtraCode8 = boqItemTable.ExtraCode8;
			obj.ExtraCode9 = boqItemTable.ExtraCode9;
			obj.ExtraCode10 = boqItemTable.ExtraCode10;
			obj.recalculate();

			return obj;
		}

		public virtual decimal RateWithIndirect
		{
			get
			{
				decimal rate = Rate;
		//		if ( getMaterial() != null ) {
		//			rate = rate.add(getMaterial());
		//		}
				if (IndirectCost != null)
				{
					rate = rate + IndirectRate;
				}
    
    
				return rate;
			}
		}


		public virtual decimal MaterialRate
		{
			get
			{
				decimal rate = decimal.Zero;
				if (Material != null)
				{
					rate = rate + Material;
				}
				return rate;
			}
		}

		public virtual SupplierTable convertToSupplierTable(ProjectDBProperties prop)
		{
			SupplierTable obj = BlankResourceInitializer.createBlankSupplier(null);

			obj.DatabaseId = SupplierDatabaseId;
			if (DatabaseCreationDate == null)
			{
				obj.DatabaseCreationDate = 100L; //ResourceUtil.MISSING_DB_CREATE_DATE);
			}
			else
			{
				obj.DatabaseCreationDate = DatabaseCreationDate;
			}
			obj.Address = quotationTable.Address;
			obj.Title = quotationTable.CompanyName;
			obj.ContactPerson = quotationTable.ContactPerson;
			obj.GroupCode = boqItemTable.GroupCode;
			obj.GekCode = boqItemTable.GekCode;
			obj.Description = boqItemTable.Description;
			obj.Notes = boqItemTable.Notes;
			obj.EditorId = DatabaseDBUtil.Properties.UserId;
			obj.PhoneNumber = quotationTable.PhoneNumber;
			obj.MobileNumber = quotationTable.MobileNumber;
			obj.Email = quotationTable.Email;
			obj.Url = quotationTable.Url;
			obj.Country = quotationTable.Country;
			obj.City = quotationTable.City;
			obj.StateProvince = quotationTable.StateProvince;
			obj.GeoLocation = quotationTable.GeoLocation;
			obj.FaxNumber = quotationTable.FaxNumber;
			obj.Performance = "" + quotationTable.Performance;
			obj.ExtraCode1 = boqItemTable.ExtraCode1;
			obj.ExtraCode2 = boqItemTable.ExtraCode2;
			obj.ExtraCode3 = boqItemTable.ExtraCode3;
			obj.ExtraCode4 = boqItemTable.ExtraCode4;
			obj.ExtraCode5 = boqItemTable.ExtraCode5;
			obj.ExtraCode6 = boqItemTable.ExtraCode6;
			obj.ExtraCode7 = boqItemTable.ExtraCode7;
			obj.ExtraCode8 = boqItemTable.ExtraCode8;
			obj.ExtraCode9 = boqItemTable.ExtraCode9;
			obj.ExtraCode10 = boqItemTable.ExtraCode10;
			obj.CreateUserId = quotationTable.EditorId;
			if (quotationTable.ReceivedDate != null)
			{
				obj.LastUpdate = quotationTable.ReceivedDate;
				obj.CreateDate = quotationTable.ReceivedDate;
			}
			else
			{
				obj.LastUpdate = DateTime.Now;
				obj.CreateDate = obj.LastUpdate;
			}
			obj.recalculate();

			return obj;
		}

		public virtual MaterialTable convertToMaterialTable(ProjectDBProperties prop)
		{
			MaterialTable obj = BlankResourceInitializer.createBlankMaterial(null);
			BoqItemTable boqItemTable = BoqItemTable;
			QuotationTable quotationTable = QuotationTable;
			double[] projectGeoPosition = StringUtils.extractDoubles(prop.getProperty("project.geolocation"));
			double[] supplierGeoPosition = StringUtils.extractDoubles(quotationTable.GeoLocation);
			double distanceKm = HaversineDistanceUtil.distance(HaversineDistanceUtil.KM_DISTANCE, projectGeoPosition, supplierGeoPosition);

			if (Title.IndexOf(boqItemTable.Title, StringComparison.Ordinal) != -1 && Title.IndexOf(boqItemTable.Description, StringComparison.Ordinal) != -1)
			{
				obj.Title = StringUtils.makeShortTitle(boqItemTable.Title);
			}
			else
			{
				obj.Title = StringUtils.makeShortTitle(Title);
			}
			obj.DatabaseId = DatabaseId;
			if (DatabaseCreationDate == null)
			{
				obj.DatabaseCreationDate = 100L; //ResourceUtil.MISSING_DB_CREATE_DATE);
			}
			else
			{
				obj.DatabaseCreationDate = DatabaseCreationDate;
			}
			obj.Weight = BigDecimalMath.ZERO;
			obj.WeightUnit = "KG";
			obj.GroupCode = boqItemTable.GroupCode;
			obj.GekCode = boqItemTable.GekCode;
			obj.Project = prop.getProperty("project.code") + " - " + prop.getProperty("project.name");
			obj.Description = boqItemTable.Description;
			obj.Notes = boqItemTable.Notes;
			obj.EditorId = DatabaseDBUtil.Properties.UserId;
			obj.Country = quotationTable.Country;
			obj.StateProvince = quotationTable.StateProvince;
			obj.Rate = Rate;

			obj.DistanceToSite = new BigDecimalFixed("" + distanceKm);
			obj.DistanceUnit = "KM";

			obj.RawMaterial = MaterialTable.UNSPECIFIED_RAWMAT;
			obj.RawMaterialReliance = BigDecimalMath.ZERO;

			obj.CreateUserId = quotationTable.EditorId;
			if (quotationTable.ReceivedDate != null)
			{
				obj.LastUpdate = quotationTable.ReceivedDate;
				obj.CreateDate = quotationTable.ReceivedDate;
			}
			else
			{
				obj.LastUpdate = DateTime.Now;
				obj.CreateDate = obj.LastUpdate;
			}

			if (quotationTable.OnSiteDelivery.Value)
			{
				if (ShipmentCost != null)
				{
					decimal indirectRate = BigDecimalMath.ZERO;

					if (IndirectCost != null)
					{
						decimal qty = Quantity;
						if (BigDecimalMath.cmpCheckNulls(qty, BigDecimalMath.ZERO) == 0)
						{
							qty = BigDecimalMath.ONE;
						}

						obj.ShipmentRate = BigDecimalMath.div(shipmentCost, qty);
					}

					//				double qty = getQuantity().doubleValue();
					//				if ( qty == 0 )
					//					qty = 1;
					//				double srate = shipmentCost.doubleValue()/getQuantity().doubleValue();
					//				obj.setShipmentRate(new BigDecimalFixed(""+srate));
				}
				else
				{
					obj.ShipmentRate = BigDecimalMath.ZERO;
				}

				obj.Inclusion = MaterialTable.SHIPMENT_INCLUSION;
			}
			else
			{
				obj.Inclusion = MaterialTable.NONE_INCLUSION;
				obj.ShipmentRate = BigDecimalMath.ZERO;
			}

			obj.FabricationRate = BigDecimalMath.ZERO;
			obj.TotalRate = obj.Rate + obj.ShipmentRate;
			obj.Quantity = Quantity;
			obj.Unit = Unit;
			obj.Currency = quotationTable.Currency;
			obj.Accuracy = MaterialTable.QUOTED_ACCURACY;

			obj.ExtraCode1 = boqItemTable.ExtraCode1;
			obj.ExtraCode2 = boqItemTable.ExtraCode2;
			obj.ExtraCode3 = boqItemTable.ExtraCode3;
			obj.ExtraCode4 = boqItemTable.ExtraCode4;
			obj.ExtraCode5 = boqItemTable.ExtraCode5;
			obj.ExtraCode6 = boqItemTable.ExtraCode6;
			obj.ExtraCode7 = boqItemTable.ExtraCode7;
			obj.ExtraCode8 = boqItemTable.ExtraCode8;
			obj.ExtraCode9 = boqItemTable.ExtraCode9;
			obj.ExtraCode10 = boqItemTable.ExtraCode10;

			boqItemTable.loadBimMaterialsAndTypes();

			obj.BimMaterial = boqItemTable.BimMaterial;
			obj.BimType = boqItemTable.BimType;
			obj.recalculate();

			return obj;
		}

		//	public boolean equals(Object o) {
		//		if ( !(o instanceof QuoteItemTable) )
		//			return false;
		//		
		//		return ((QuoteItemTable)o).getQuoteItemId().equals(getQuoteItemId());
		//	}

		public override string ToString()
		{
			return QuoteItemId + ", " + Quantity + " " + Unit + " " + Rate + " " + Insurance + " " + Material + " " + ManHours;
		}

		public override long? Id
		{
			get
			{
				return QuoteItemId;
			}
		}

		public override decimal Factor3
		{
			get
			{
				return null; // dummy
			}
		}

		public override decimal ExchangeRate
		{
			get
			{
				return null; // dummy
			}
		}

		public override ResourceWithAssignmentsTable getResourceTable()
		{
			return BoqItemTable;
		}

		public override ResourceTable AssignmentResourceTable
		{
			get
			{
				return QuotationTable;
			}
			set
			{
				QuotationTable = (QuotationTable)value;
			}
		}

		public override ResourceToAssignmentTable Data
		{
			set
			{
				Data = (QuoteItemTable)value;
			}
		}

		public override void setResourceTable(ResourceTable resourceTable)
		{
			BoqItemTable = (BoqItemTable)resourceTable;
		}


		public override decimal QuantityPerUnit
		{
			get
			{
				return null;
			}
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


		public override long? ParamItemId
		{
			get
			{
				// TODO Auto-generated method stub
				return null;
			}
			set
			{
				// TODO Auto-generated method stub
    
			}
		}


		public override ParamItemTable ParamItemTable
		{
			get
			{
				// TODO Auto-generated method stub
				return null;
			}
			set
			{
				// TODO Auto-generated method stub
    
			}
		}

	}

}