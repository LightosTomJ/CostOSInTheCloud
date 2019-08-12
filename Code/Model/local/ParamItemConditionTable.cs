using System;
using System.Collections.Generic;

namespace Model.local
{

	using BaseTable = Desktop.common.nomitech.common.@base.BaseTable;
	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;
	using BoqItemConditionTable = Desktop.common.nomitech.common.db.project.BoqItemConditionTable;
	using BoqItemTable = Desktop.common.nomitech.common.db.project.BoqItemTable;
	using ConditionTable = Desktop.common.nomitech.common.db.project.ConditionTable;
	using BlankResourceInitializer = Desktop.common.nomitech.common.expr.boqitem.BlankResourceInitializer;
	using BigDecimalMath = Desktop.common.nomitech.common.util.BigDecimalMath;
	using Unit1ToUnit2Util = Desktop.common.nomitech.common.util.Unit1ToUnit2Util;
	//#RXL_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="PARAMCONDITION"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	[Serializable]
	public class ParamItemConditionTable : BaseTable, ProjectIdEntity
	{

		private long? conditionId;
		private string databaseName;
		private string username;
		private string password;
		private string host;
		private int? bidNo;
		private int? cndNo;
		private int? cndId;
		private string cndType;
		private int? pickType;
		private string pickData;

		private string description;
		private string title;

		private string building;
		private string storey;
		private string location;

		private string bimType;
		private string bimMaterial;

		private string layer;
		private string quantity1Name;
		private string quantity2Name;
		private string quantity3Name;
		private string quantityFName;

		private string formula1;
		private string formula2;
		private string formula3;
		private string formulaF;

		private decimal quantity1;
		private decimal quantity2;
		private decimal quantity3;
		private decimal quantityF;

		private int? selectedQuantity = new int?(0);

		private string unit1;
		private string unit2;
		private string unit3;
		private string unitF;
		private string takeOffType;
		private string globalId;
		private string functionState;

		private ParamItemTable paramItemTable;
		private ParamItemInputTable paramItemInputTable;
		private bool? @virtual;

		public ParamItemConditionTable()
		{

		}

		public virtual object Clone()
		{
			ParamItemConditionTable conditionTable = new ParamItemConditionTable();

			conditionTable.ConditionId = ConditionId;
			conditionTable.Title = Title;
			conditionTable.Description = Description;
			conditionTable.DatabaseName = DatabaseName;
			conditionTable.Username = Username;
			conditionTable.Password = Password;
			conditionTable.Host = Host;
			conditionTable.BidNo = BidNo;
			conditionTable.CndNo = CndNo;
			conditionTable.CndId = CndId;
			conditionTable.CndType = CndType;
			conditionTable.PickType = PickType;
			conditionTable.PickData = PickData;

			conditionTable.Building = Building;
			conditionTable.Storey = Storey;
			conditionTable.Layer = Layer;
			conditionTable.Location = Location;

			conditionTable.Quantity1 = Quantity1;
			conditionTable.Quantity2 = Quantity2;
			conditionTable.Quantity3 = Quantity3;
			conditionTable.QuantityF = QuantityF;

			conditionTable.Quantity1Name = Quantity1Name;
			conditionTable.Quantity2Name = Quantity2Name;
			conditionTable.Quantity3Name = Quantity3Name;
			conditionTable.QuantityFName = QuantityFName;

			conditionTable.Formula1 = Formula1;
			conditionTable.Formula2 = Formula2;
			conditionTable.Formula3 = Formula3;
			conditionTable.FormulaF = FormulaF;

			conditionTable.Unit1 = Unit1;
			conditionTable.Unit2 = Unit2;
			conditionTable.Unit3 = Unit3;
			conditionTable.UnitF = UnitF;
			conditionTable.SelectedQuantity = SelectedQuantity;
			conditionTable.TakeOffType = TakeOffType;
			conditionTable.GlobalId = GlobalId;

			conditionTable.BimMaterial = BimMaterial;
			conditionTable.BimType = BimType;
			conditionTable.FunctionState = FunctionState;
			conditionTable.Virtual = Virtual;
			conditionTable.ProjectId = ProjectId;

			return conditionTable;
		}

		public virtual ConditionTable convertToConditionTable()
		{
			ConditionTable conditionTable = new ConditionTable();

			conditionTable.ConditionId = ConditionId;
			conditionTable.Title = Title;
			conditionTable.Description = Description;
			conditionTable.DatabaseName = DatabaseName;
			conditionTable.Username = Username;
			conditionTable.Password = Password;
			conditionTable.Host = Host;
			conditionTable.BidNo = BidNo;
			conditionTable.CndNo = CndNo;
			conditionTable.CndId = CndId;
			conditionTable.CndType = CndType;
			conditionTable.PickType = PickType;
			conditionTable.PickData = PickData;

			conditionTable.Building = Building;
			conditionTable.Storey = Storey;
			conditionTable.Layer = Layer;
			conditionTable.Location = Location;

			conditionTable.Quantity1 = Quantity1;
			conditionTable.Quantity2 = Quantity2;
			conditionTable.Quantity3 = Quantity3;
			conditionTable.QuantityF = QuantityF;

			conditionTable.Quantity1Name = Quantity1Name;
			conditionTable.Quantity2Name = Quantity2Name;
			conditionTable.Quantity3Name = Quantity3Name;
			conditionTable.QuantityFName = QuantityFName;

			conditionTable.Formula1 = Formula1;
			conditionTable.Formula2 = Formula2;
			conditionTable.Formula3 = Formula3;
			conditionTable.FormulaF = FormulaF;

			conditionTable.Unit1 = Unit1;
			conditionTable.Unit2 = Unit2;
			conditionTable.Unit3 = Unit3;
			conditionTable.UnitF = UnitF;
			conditionTable.DefaultQuantity = SelectedQuantity;
			conditionTable.TakeOffType = TakeOffType;
			conditionTable.GlobalId = GlobalId;

			conditionTable.BimMaterial = BimMaterial;
			conditionTable.BimType = BimType;
			conditionTable.FunctionState = FunctionState;
			conditionTable.Virtual = Virtual;

			return conditionTable;
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="CONDITIONID" </summary>
		/// <returns> Long </returns>
		public virtual long? ConditionId
		{
			get
			{
				return conditionId;
			}
			set
			{
				this.conditionId = value;
			}
		}


		public override long? Id
		{
			get
			{
				return conditionId;
			}
		}

		/// <summary>
		/// @hibernate.property column="VIRT" type="boolean" </summary>
		/// <returns> description </returns>
		public virtual bool? Virtual
		{
			get
			{
				return @virtual;
			}
			set
			{
				this.@virtual = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DESCRIPTION" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string Description
		{
			get
			{
				return description;
			}
			set
			{
				this.description = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TITLE" type="costos_string" </summary>
		/// <returns> description </returns>
		public override string Title
		{
			get
			{
				return title;
			}
			set
			{
				this.title = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SELQTY" type="int" </summary>
		/// <returns> description </returns>
		public virtual int? SelectedQuantity
		{
			get
			{
				return selectedQuantity;
			}
			set
			{
				this.selectedQuantity = value;
			}
		}


		public override string ToString()
		{
			return ConditionId + ". " + Title;
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="QTY1" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Quantity1
		{
			get
			{
				return quantity1;
			}
			set
			{
				this.quantity1 = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="QTY2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Quantity2
		{
			get
			{
				return quantity2;
			}
			set
			{
				this.quantity2 = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="QTY3" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Quantity3
		{
			get
			{
				return quantity3;
			}
			set
			{
				this.quantity3 = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="QTYF" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal QuantityF
		{
			get
			{
				return quantityF;
			}
			set
			{
				this.quantityF = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="UNIT1" type="costos_string" </summary>
		/// <returns> groupCode </returns>
		public virtual string Unit1
		{
			get
			{
				return unit1;
			}
			set
			{
				this.unit1 = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="UNIT2" type="costos_string" </summary>
		/// <returns> groupCode </returns>
		public virtual string Unit2
		{
			get
			{
				return unit2;
			}
			set
			{
				this.unit2 = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="UNIT3" type="costos_string" </summary>
		/// <returns> groupCode </returns>
		public virtual string Unit3
		{
			get
			{
				return unit3;
			}
			set
			{
				this.unit3 = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="UNITF" type="costos_string" </summary>
		/// <returns> groupCode </returns>
		public virtual string UnitF
		{
			get
			{
				return unitF;
			}
			set
			{
				this.unitF = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DBNAME" type="costos_string" </summary>
		/// <returns> groupCode </returns>
		public virtual string DatabaseName
		{
			get
			{
				return databaseName;
			}
			set
			{
				this.databaseName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="USERNAME" type="costos_string" </summary>
		/// <returns> groupCode </returns>
		public virtual string Username
		{
			get
			{
				return username;
			}
			set
			{
				this.username = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PASSWORD" type="costos_string" </summary>
		/// <returns> groupCode </returns>
		public virtual string Password
		{
			get
			{
				return password;
			}
			set
			{
				this.password = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="HOST" type="costos_string" </summary>
		/// <returns> groupCode </returns>
		public virtual string Host
		{
			get
			{
				return host;
			}
			set
			{
				this.host = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="BIDNO" type="int" </summary>
		/// <returns> groupCode </returns>
		public virtual int? BidNo
		{
			get
			{
				return bidNo;
			}
			set
			{
				this.bidNo = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CNDNO" type="int" </summary>
		/// <returns> groupCode </returns>
		public virtual int? CndNo
		{
			get
			{
				return cndNo;
			}
			set
			{
				this.cndNo = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CNDTYPE" type="costos_string" </summary>
		/// <returns> groupCode </returns>
		public virtual string CndType
		{
			get
			{
				return cndType;
			}
			set
			{
				this.cndType = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CNDID" type="int" </summary>
		/// <returns> groupCode </returns>
		public virtual int? CndId
		{
			get
			{
				return cndId;
			}
			set
			{
				this.cndId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="GLOBALID" type="costos_string" </summary>
		/// <returns> string </returns>
		public virtual string GlobalId
		{
			get
			{
				return globalId;
			}
			set
			{
				this.globalId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PICKTYPE" type="int"
		/// </summary>
		public virtual int? PickType
		{
			get
			{
				return pickType;
			}
			set
			{
				this.pickType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PICKDATA" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string PickData
		{
			get
			{
				return pickData;
			}
			set
			{
				this.pickData = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TAKEOFFTYPE" type="costos_string" </summary>
		/// <returns> takeOffType </returns>
		public virtual string TakeOffType
		{
			get
			{
				return takeOffType;
			}
			set
			{
				this.takeOffType = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="BUILDING" type="costos_string" </summary>
		/// <returns> building </returns>
		public virtual string Building
		{
			get
			{
				return building;
			}
			set
			{
				this.building = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="STOREY" type="costos_string" </summary>
		/// <returns> building </returns>
		public virtual string Storey
		{
			get
			{
				return storey;
			}
			set
			{
				this.storey = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LOCATION" type="costos_string" </summary>
		/// <returns> building </returns>
		public virtual string Location
		{
			get
			{
				return location;
			}
			set
			{
				this.location = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LAYER" type="costos_string" </summary>
		/// <returns> building </returns>
		public virtual string Layer
		{
			get
			{
				return layer;
			}
			set
			{
				this.layer = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="QTY1NAME" type="costos_string" </summary>
		/// <returns> building </returns>
		public virtual string Quantity1Name
		{
			get
			{
				return quantity1Name;
			}
			set
			{
				this.quantity1Name = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="QTY2NAME" type="costos_string" </summary>
		/// <returns> building </returns>
		public virtual string Quantity2Name
		{
			get
			{
				return quantity2Name;
			}
			set
			{
				this.quantity2Name = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="QTY3NAME" type="costos_string" </summary>
		/// <returns> building </returns>
		public virtual string Quantity3Name
		{
			get
			{
				return quantity3Name;
			}
			set
			{
				this.quantity3Name = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="QTYFNAME" type="costos_string" </summary>
		/// <returns> building </returns>
		public virtual string QuantityFName
		{
			get
			{
				return quantityFName;
			}
			set
			{
				this.quantityFName = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FORMULA1" type="costos_string" </summary>
		/// <returns> formula1 </returns>
		public virtual string Formula1
		{
			get
			{
				return formula1;
			}
			set
			{
				this.formula1 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FORMULA2" type="costos_string" </summary>
		/// <returns> formula1 </returns>
		public virtual string Formula2
		{
			get
			{
				return formula2;
			}
			set
			{
				this.formula2 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FORMULA3" type="costos_string" </summary>
		/// <returns> formula1 </returns>
		public virtual string Formula3
		{
			get
			{
				return formula3;
			}
			set
			{
				this.formula3 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FORMULAF" type="costos_text" </summary>
		/// <returns> formulaF </returns>
		public virtual string FormulaF
		{
			get
			{
				return formulaF;
			}
			set
			{
				this.formulaF = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="BIMTYPE" type="costos_string" </summary>
		/// <returns> building </returns>
		public virtual string BimType
		{
			get
			{
				return bimType;
			}
			set
			{
				this.bimType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FCTSTATE" type="costos_text" </summary>
		/// <returns> building </returns>
		public virtual string FunctionState
		{
			get
			{
				return functionState;
			}
			set
			{
				this.functionState = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="BIMMATERIAL" type="costos_text" </summary>
		/// <returns> building </returns>
		public virtual string BimMaterial
		{
			get
			{
				return bimMaterial;
			}
			set
			{
				this.bimMaterial = value;
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
		/// @hibernate.many-to-one
		///  column="PARAMINPUTID" </summary>
		/// <returns> ParamItemTable </returns>
		public virtual ParamItemInputTable ParamItemInputTable
		{
			get
			{
				return paramItemInputTable;
			}
			set
			{
				this.paramItemInputTable = value;
			}
		}


		public virtual BoqItemTable convertToBoqItem(DateTime projectStartDate, long? code, ProjectDBUtil currentDBUtil, bool online, bool useProductivity, bool replaceQuantity)
		{
			BoqItemTable boqTable = BlankResourceInitializer.createBlankBoqItem(this, code, projectStartDate,useProductivity);

			Timestamp updateTime = new Timestamp(DateTimeHelper.CurrentUnixTimeMillis());

			//if ( useProductivity ) {
			//	boqTable.setCalculationType(BoqItemTable.s_PRODUCTIVITY_METHOD);
			//}
			//else {
			//	boqTable.setCalculationType(BoqItemTable.s_TOTAL_UNITS_METHOD);			
			//}	
			//boqTable.setProductivity(BigDecimalMath.ONE);
			//boqTable.setQuantity(BigDecimalMath.ONE);
			//boqTable.setDuration(BigDecimalMath.ONE);

			boqTable.LastUpdate = updateTime;
			boqTable.CreateDate = updateTime;

			boqTable.BoqItemAssemblySet = new HashSet<object>();
			boqTable.BoqItemEquipmentSet = new HashSet<object>();
			boqTable.BoqItemSubcontractorSet = new HashSet<object>();
			boqTable.BoqItemLaborSet = new HashSet<object>();
			boqTable.BoqItemMaterialSet = new HashSet<object>();
			boqTable.BoqItemConsumableSet = new HashSet<object>();
			boqTable.BoqItemConditionSet = new HashSet<object>();

			ConditionTable conditionTable = (ConditionTable)convertToConditionTable();
			BoqItemConditionTable boqConditionTable = new BoqItemConditionTable();

			boqConditionTable.Factor1 = BigDecimalMath.ONE;
			boqConditionTable.Factor2 = BigDecimalMath.ONE;
			boqConditionTable.QuantityPerUnit = BigDecimalMath.ONE;
			boqConditionTable.Sumup = BigDecimalMath.ZERO;

			if (replaceQuantity)
			{
				if (conditionTable.DefaultQuantity == null || conditionTable.DefaultQuantity == 0 || conditionTable.DefaultQuantity == 1)
				{
					boqTable.Quantity = conditionTable.Quantity1;
				}
				else if (conditionTable.DefaultQuantity == 2)
				{
					boqTable.Quantity = conditionTable.Quantity2;
				}
				else if (conditionTable.DefaultQuantity == 3)
				{
					boqTable.Quantity = conditionTable.Quantity3;
				}
				else if (conditionTable.DefaultQuantity == 4)
				{
					boqTable.Quantity = conditionTable.QuantityF;
				}
			}
			if (conditionTable.DefaultQuantity == null || conditionTable.DefaultQuantity == 0 || conditionTable.DefaultQuantity == 1)
			{
				boqConditionTable.SelectedUnit = BoqItemConditionTable.SELECTED_UNIT1;
				boqTable.Quantity = conditionTable.Quantity1;
				boqTable.MeasuredQuantity = conditionTable.Quantity1;
				//boqTable.setEstimatedQuantity(conditionTable.getQuantity1());		
				boqTable.Unit = conditionTable.Unit1;
				boqTable.SecondUnit = Unit1ToUnit2Util.Instance.getUnit2(conditionTable.Unit1);
				boqTable.UnitsDiv = Unit1ToUnit2Util.Instance.getUnitDiv(conditionTable.Unit1);
			}
			else if (conditionTable.DefaultQuantity == 2)
			{
				boqConditionTable.SelectedUnit = BoqItemConditionTable.SELECTED_UNIT2;
				boqTable.Quantity = conditionTable.Quantity2;
				boqTable.MeasuredQuantity = conditionTable.Quantity2;
				//boqTable.setEstimatedQuantity(conditionTable.getQuantity2());		
				boqTable.Unit = conditionTable.Unit2;
				boqTable.SecondUnit = Unit1ToUnit2Util.Instance.getUnit2(conditionTable.Unit2);
				boqTable.UnitsDiv = Unit1ToUnit2Util.Instance.getUnitDiv(conditionTable.Unit2);
			}
			else if (conditionTable.DefaultQuantity == 3)
			{
				boqConditionTable.SelectedUnit = BoqItemConditionTable.SELECTED_UNIT3;
				boqTable.Quantity = conditionTable.Quantity3;
				//boqTable.setEstimatedQuantity(conditionTable.getQuantity3());
				boqTable.MeasuredQuantity = conditionTable.Quantity3;
				boqTable.Unit = conditionTable.Unit3;
				boqTable.SecondUnit = Unit1ToUnit2Util.Instance.getUnit2(conditionTable.Unit3);
				boqTable.UnitsDiv = Unit1ToUnit2Util.Instance.getUnitDiv(conditionTable.Unit3);
			}
			else if (conditionTable.DefaultQuantity == 4)
			{
				boqConditionTable.SelectedUnit = BoqItemConditionTable.SELECTED_UNITF;
				boqTable.Quantity = conditionTable.QuantityF;
				//boqTable.setEstimatedQuantity(conditionTable.getQuantity3());
				boqTable.MeasuredQuantity = conditionTable.QuantityF;
				boqTable.Unit = conditionTable.UnitF;
				boqTable.SecondUnit = Unit1ToUnit2Util.Instance.getUnit2(conditionTable.UnitF);
				boqTable.UnitsDiv = Unit1ToUnit2Util.Instance.getUnitDiv(conditionTable.UnitF);
			}

			boqConditionTable.LastUpdate = updateTime;

			boqConditionTable.ConditionTable = conditionTable;
			boqConditionTable.BoqItemTable = boqTable;

			boqTable.BoqItemConditionSet.Add(boqConditionTable);

			boqTable.recalculate();

			return boqTable;
		}

		public override decimal TableRate
		{
			get
			{
				return Quantity1;
			}
		}

		public override DateTime LastUpdate
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

	}
}