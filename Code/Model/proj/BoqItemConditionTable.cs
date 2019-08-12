using System;

namespace Model.proj
{


	using StringUtils = nomitech.bimengine.core.util.StringUtils;
	using BoqItemToAssignmentTable = nomitech.common.@base.BoqItemToAssignmentTable;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceToAssignmentTable = nomitech.common.@base.ResourceToAssignmentTable;
	using ResourceWithAssignmentsTable = nomitech.common.@base.ResourceWithAssignmentsTable;
	using ParamItemTable = nomitech.common.db.local.ParamItemTable;
	//#RXL_START 
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="BOQITEM_CONDITION" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	[Serializable]
	public class BoqItemConditionTable : BoqItemToAssignmentTable, ProjectIdEntity
	{

		public const string SELECTED_UNIT1 = "selectedQty.1";
		public const string SELECTED_UNIT2 = "selectedQty.2";
		public const string SELECTED_UNIT3 = "selectedQty.3";
		public const string SELECTED_UNITF = "selectedQty.F";
		public const string OVERRIDEN_UNIT = "selectedQty.O";
		/// 
		private const long serialVersionUID = 1L;

		public static readonly string[] FIELDS = new string[] {"selectedUnit", "factor1", "factor2", "sumup", "finalQuantity"};

		private long? boqItemConditionId = null;
		private string selectedUnit = null;
		private decimal factor1 = null;
		private decimal factor2 = null;
		private decimal sumup = null;
		private decimal finalQuantity = null;
		private string finalUnit;
		private string selectedQuantityName;
		private decimal selectedQuantity;
		private decimal overridenQty;
		private string overridenUnit;

		private DateTime lastUpdate = null;
	//	private String formula;

		private BoqItemTable boqItemTable;

		private ConditionTable conditionTable;
		private long? paramItemId;
		private ParamItemTable paramItemTable;

		//private transient HashMap o_map = new HashMap();

		public BoqItemConditionTable()
		{
			//o_map = new HashMap();
		}

		/*public Object valueForField(String field) {
			if ( field.equals("finalQuantity") ) {
				return DBFieldFormatUtil.formatObject(getFinalQuantity());
			}
			return DBFieldFormatUtil.formatObject(o_map.get(field));
		}
		
		public Object scaledValueForField(String field) {
			if ( field.equals("finalQuantity") ) {
				return DBFieldFormatUtil.scaleAndFormatObject(getFinalQuantity());
			}
			
			return DBFieldFormatUtil.scaleAndFormatObject(o_map.get(field));
		}*/

		public virtual object clone(bool relations)
		{
			if (relations)
			{
				return clone();
			}
			//if ( o_map == null ) o_map = new HashMap();

			BoqItemConditionTable obj = new BoqItemConditionTable();

			obj.ParamItemId = ParamItemId;
			obj.BoqItemConditionId = BoqItemConditionId;
			obj.SelectedUnit = SelectedUnit;
			obj.FinalQuantity = FinalQuantity;
			obj.Factor1 = Factor1;
			obj.Factor2 = Factor2;
			obj.Sumup = Sumup;
			obj.OverridenQuantity = OverridenQuantity;
			obj.OverridenUnit = OverridenUnit;
			obj.LastUpdate = LastUpdate;
			obj.ProjectId = ProjectId;

			return obj;
		}

		public virtual object clone()
		{
			//if ( o_map == null ) o_map = new HashMap();

			BoqItemConditionTable obj = new BoqItemConditionTable();

			obj.ParamItemId = ParamItemId;
			obj.BoqItemConditionId = BoqItemConditionId;
			obj.SelectedUnit = SelectedUnit;
			obj.FinalQuantity = FinalQuantity;
			obj.Factor1 = Factor1;
			obj.Factor2 = Factor2;
			obj.Sumup = Sumup;
			obj.LastUpdate = LastUpdate;
			obj.OverridenQuantity = OverridenQuantity;
			obj.OverridenUnit = OverridenUnit;
			obj.ProjectId = ProjectId;

			if (BoqItemTable != null)
			{
				obj.BoqItemTable = (BoqItemTable)BoqItemTable.clone();
			}

			if (ConditionTable != null)
			{
				obj.ConditionTable = (ConditionTable)ConditionTable.clone();
			}

			return obj;
		}

		public virtual BoqItemConditionTable Data
		{
			set
			{
    
				ParamItemId = value.ParamItemId;
				BoqItemConditionId = value.BoqItemConditionId;
				LastUpdate = value.LastUpdate;
				Factor1 = value.Factor1;
				Factor2 = value.Factor2;
				Sumup = value.Factor3;
				OverridenQuantity = value.OverridenQuantity;
				OverridenUnit = value.OverridenUnit;
				SelectedUnit = value.SelectedUnit;
				FinalQuantity = value.FinalQuantity;
			}
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="BOQITEMCONDITIONID" </summary>
		/// <returns> Long </returns>
		public virtual long? BoqItemConditionId
		{
			get
			{
				return boqItemConditionId;
			}
			set
			{
				boqItemConditionId = value;
				//o_map.put("boqItemConditionId",value);
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FUNIT" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string FinalUnit
		{
			get
			{
				if (ConditionTable == null)
				{
					return finalUnit;
				}
    
				string selectedUnit = ConditionTable.Unit1;
    
				if (!StringUtils.isNullOrBlank(OverridenUnit))
				{
					selectedUnit = OverridenUnit;
				}
				else if (SelectedUnit.Equals(SELECTED_UNIT2))
				{
					selectedUnit = ConditionTable.Unit2;
				}
				else if (SelectedUnit.Equals(SELECTED_UNIT3))
				{
					selectedUnit = ConditionTable.Unit3;
				}
				else if (SelectedUnit.Equals(SELECTED_UNITF))
				{
					selectedUnit = ConditionTable.UnitF;
				}
    
				return selectedUnit;
			}
			set
			{
				finalUnit = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SELQTYNAME" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string SelectedQuantityName
		{
			get
			{
				if (ConditionTable == null)
				{
					return selectedQuantityName;
				}
				string selectedUnit = ConditionTable.Quantity1Name;
    
				if (!StringUtils.isNullOrBlank(OverridenUnit))
				{
					selectedUnit = OVERRIDEN_UNIT;
				}
				else if (SelectedUnit.Equals(SELECTED_UNIT2))
				{
					selectedUnit = ConditionTable.Quantity2Name;
				}
				else if (SelectedUnit.Equals(SELECTED_UNIT3))
				{
					selectedUnit = ConditionTable.Quantity3Name;
				}
				else if (SelectedUnit.Equals(SELECTED_UNITF))
				{
					selectedUnit = ConditionTable.QuantityFName;
				}
    
				return selectedUnit;
			}
			set
			{
				selectedQuantityName = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SELQTY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal SelectedQuantity
		{
			get
			{
				if (ConditionTable == null)
				{
					return selectedQuantity;
				}
				decimal selectedQty = ConditionTable.Quantity1;
    
				if (!StringUtils.isNullOrBlank(OverridenUnit))
				{
					selectedQty = OverridenQuantity;
				}
				else if (SelectedUnit.Equals(SELECTED_UNIT2))
				{
					selectedQty = ConditionTable.Quantity2;
				}
				else if (SelectedUnit.Equals(SELECTED_UNIT3))
				{
					selectedQty = ConditionTable.Quantity3;
				}
				else if (SelectedUnit.Equals(SELECTED_UNITF))
				{
					selectedQty = ConditionTable.QuantityF;
				}
    
				return selectedQty;
			}
			set
			{
				selectedQuantity = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="OVERUNIT" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string OverridenUnit
		{
			get
			{
				return overridenUnit;
			}
			set
			{
				this.overridenUnit = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="OVERQTY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal OverridenQuantity
		{
			get
			{
				return overridenQty;
			}
			set
			{
				this.overridenQty = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FQTY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalQuantity
		{
			get
			{
    
				decimal fQty = finalQuantity;
    
    
				//if ( fQty == null )
					//fQty = (BigDecimal)o_map.get("finalQuantity");
    
				if (BoqItemTable != null && ConditionTable != null)
				{
					decimal conditionQuantity = ConditionTable.Quantity1;
    
					if (OverridenQuantity != null)
					{
						conditionQuantity = OverridenQuantity;
					}
					else if (SelectedUnit.Equals(SELECTED_UNIT2))
					{
						conditionQuantity = ConditionTable.Quantity2;
					}
					else if (SelectedUnit.Equals(SELECTED_UNIT3))
					{
						conditionQuantity = ConditionTable.Quantity3;
					}
					else if (SelectedUnit.Equals(SELECTED_UNITF))
					{
						conditionQuantity = ConditionTable.QuantityF;
					}
    
					fQty = conditionQuantity * Factor1;
					fQty = fQty * Factor2;
					fQty = fQty + Sumup;
    
					fQty = fQty.setScale(10,decimal.ROUND_HALF_UP);
				}
    
				finalQuantity = fQty;
				//o_map.put("finalQuantity",fQty);
				return fQty;
			}
			set
			{
				finalQuantity = value;
				//o_map.put("finalQuantity",value);                
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
				//value = value.setScale(DBPreferences.getInstance().getBigDecimalScale());		
				factor2 = value;
				//o_map.put("factor2",value);                
			}
		}

		/// <summary>
		/// @hibernate.property column="SUMUP" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Sumup
		{
			get
			{
				return sumup;
			}
			set
			{
				//value = value.setScale(DBPreferences.getInstance().getBigDecimalScale());
				sumup = value;
				//o_map.put("sumup",value);                
			}
		}

		/// <summary>
		/// @hibernate.property column="SELUNIT" type="costos_string" </summary>
		/// <returns> groupCode </returns>
		public virtual string SelectedUnit
		{
			get
			{
				return selectedUnit;
			}
			set
			{
				this.selectedUnit = value;
				//o_map.put("selectedUnit",value);   
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
				//o_map.put("lastUpdate",value);                
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="CONDITIONID"
		///  cascade="none" </summary>
		/// <returns> ConditionTable </returns>
		public virtual ConditionTable ConditionTable
		{
			get
			{
				return conditionTable;
			}
			set
			{
				this.conditionTable = value;
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
				return BoqItemConditionId;
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
				return ConditionTable;
			}
			set
			{
				ConditionTable = (ConditionTable) value;
			}
		}

		public override ResourceToAssignmentTable Data
		{
			set
			{
				Data = (BoqItemConditionTable)value;
			}
		}

		public override void setResourceTable(ResourceTable resourceTable)
		{
			BoqItemTable = (BoqItemTable) resourceTable;
		}


		public override decimal Factor3
		{
			get
			{
				return Sumup;
			}
		}

		public override decimal ExchangeRate
		{
			get
			{
				return null;
			}
		}

		public override decimal calculateFinalRate()
		{
			return FinalQuantity;
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


		public virtual int? SelectedQuantityIndex
		{
			get
			{
				if (ConditionTable == null)
				{
					return 1;
				}
    
				int? selectedUnit = 1;
    
				if (SelectedUnit.Equals(SELECTED_UNIT2))
				{
					selectedUnit = 2;
				}
				else if (SelectedUnit.Equals(SELECTED_UNIT3))
				{
					selectedUnit = 3;
				}
				else if (SelectedUnit.Equals(SELECTED_UNITF))
				{
					selectedUnit = 4;
				}
    
				return selectedUnit;
			}
		}
	}
}