using System;
using System.Collections.Generic;

namespace Model.local
{

	using DatabaseTable = Desktop.common.nomitech.common.@base.DatabaseTable;
	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;

	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="PARAMINPUT"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class ParamItemInputTable : DatabaseTable, IComparable<ParamItemInputTable>, ProjectIdEntity
	{

		public static readonly string[] VIEWABLE_FIELDS = new string[] {"paramInputId", "name", "label", "description", "comment", "dataType", "sortOrder", "grouping", "dependencyStatement", "validationStatement", "selectionList", "hidden", "pblk"};

		/// <summary>
		/// Data Types:
		/// </summary>
		public const string DECIMAL = "datatype.decimal";
		public const string INTEGER = "datatype.integer";
		public const string TEXT = "datatype.text";
		public const string SELECTIONLIST = "datatype.list";
		public const string BIMMODEL = "datatype.bimmodel";
		public const string BOOLEAN = "datatype.boolean";
		public const string FORMULA = "datatype.formula";

		public const string COUNTRY = "datatype.country";
		public const string LOCFACTOR = "datatype.locfactor";
		public const string TAKEOFF = "datatype.takeoff";
		public const string ARRAY = "datatype.array";
		public const string CALCARRAY = "datatype.calcarray";
		public const string CALCLIST = "datatype.calclist";
		public const string SVGFILE = "datatype.svg";
		public const string PRJVAR = "datatype.prjvar";

		public const string IMAGE = "datatype.image";
		public const string CALCVALUE = "datatype.calcvalue";
		public const string DATE = "datatype.date";
		public const string NOTES = "datatype.notes";


		/// <summary>
		/// Array Types:
		/// </summary>
		public const string ROW_HEADER_ARRAY = "arraytype.rowheader";

		public const string FIXED_NUMBER_USER_DEFINED_ARRAY = "arraytype.fixed";
		public const string DYNAMIC_NUMBER_USER_DEFINED_ARRAY = "arraytype.dynamic";

		public const string FIXED_TEXT_USER_DEFINED_ARRAY = "arraytype.fixedtext";
		public const string DYNAMIC_TEXT_USER_DEFINED_ARRAY = "arraytype.dynamictext";

		public const string DYNAMIC_TEXT_AND_ASSIGN_RESOURCES_USER_DEFINED_ARRAY = "arraytype.dynamictext.assignres";

		public const string FIXED_FORMULA_USER_DEFINED_ARRAY = "arraytype.fixedformula";
		public const string DYNAMIC_FORMULA_USER_DEFINED_ARRAY = "arraytype.dynamicformula";

		public const string FIXED_FORMULA_TEXT_USER_DEFINED_ARRAY = "arraytype.fixedformula.text";
		public const string DYNAMIC_FORMULA_TEXT_USER_DEFINED_ARRAY = "arraytype.dynamicformula.text";

		public const string GIS_TAKEOFF_XY_ARRAY = "arraytype.gisxy";
		public const string GIS_TAKEOFF_XYZ_ARRAY = "arraytype.gisxyz";

		/// <summary>
		/// Array Views:
		/// </summary>
		public const string ARRAY_TABLE_VIEW = "arrayview.table";
		public const string ARRAY_PIECHART_VIEW = "arrayview.piechart";
		public const string ARRAY_XYCHART_VIEW = "arrayview.xychart"; // Scatter
		public const string ARRAY_XY_LINEAR_CHART_VIEW = "arrayview.xychart.linear";
		public const string ARRAY_XY_QUAD_CHART_VIEW = "arrayview.xychart.quadratic";
		public const string ARRAY_XY_CUBIC_CHART_VIEW = "arrayview.xychart.cubic";

		// Decimal Digits to show in display:
		public static readonly sbyte?[] CALC_VALUE_DECIMAL_DIGITS = new sbyte?[]{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
		public const sbyte? DEFAULT_CALC_VALUE_DECIMAL_DIGITS = 3;

		private long? paramInputId;
		private string unit;
		private string name;
		private string label;
		private string description;
		private string dataType;
		private string dependencyStatement;
		private string validationStatement;
		private string selectionList; // comma separated
		private string defaultValue;
		private string storedValue;
		private int? sortOrder;
		private bool? hidden;
		private bool? pblk;
		private string grouping;
		private string arrayType;
		private string arraySizeVar;
		private bool? editable;
		private bool? wasShowing;
		private bool? calcValue;
		private sbyte? calcValueDecimalDigits; // [0 - 10] decimal digits only in display
		private string comment;
		private bool? frmRowVisible;

		private ParamItemTable paramItemTable;
		private ISet<ParamItemConditionTable> conditionSet;


		public ParamItemInputTable()
		{

		}

		public virtual object Clone()
		{
			ParamItemInputTable obj = new ParamItemInputTable();

			obj.ParamInputId = ParamInputId;
			obj.Name = Name;
			obj.Label = Label;
			obj.Description = Description;
			obj.Comment = Comment;
			obj.DependencyStatement = DependencyStatement;
			obj.DefaultValue = DefaultValue;
			obj.Unit = Unit;
			obj.StoredValue = StoredValue;
			obj.DataType = DataType;
			obj.ValidationStatement = ValidationStatement;
			obj.SelectionList = SelectionList;
			obj.SortOrder = SortOrder;
			obj.Grouping = Grouping;
			obj.Hidden = Hidden;
			obj.Pblk = Pblk;
			obj.ArrayType = ArrayType;
			obj.ArraySizeVar = ArraySizeVar;
			obj.Editable = Editable;
			obj.WasShowing = WasShowing;
			obj.CalcValue = CalcValue;
			obj.CalcValueDecimalDigits = CalcValueDecimalDigits;
			obj.FrmRowVisible = FrmRowVisible;
			obj.ProjectId = ProjectId;

			return obj;
		}

		public virtual ParamItemInputTable Data
		{
			set
			{
				ParamInputId = value.ParamInputId;
				Name = value.Name;
				Label = value.Label;
				Description = value.Description;
				Comment = value.Comment;
				DependencyStatement = value.DependencyStatement;
				DefaultValue = value.DefaultValue;
				Unit = value.Unit;
				StoredValue = value.StoredValue;
				SortOrder = value.SortOrder;
				DataType = value.DataType;
				ValidationStatement = value.ValidationStatement;
				SelectionList = value.SelectionList;
				Grouping = value.Grouping;
				Hidden = value.Hidden;
				Pblk = value.Pblk;
				ArrayType = value.ArrayType;
				ArraySizeVar = value.ArraySizeVar;
				Editable = value.Editable;
				WasShowing = value.WasShowing;
				CalcValue = value.CalcValue;
				CalcValueDecimalDigits = value.CalcValueDecimalDigits;
				FrmRowVisible = value.FrmRowVisible;
			}
		}

		public virtual object copyWithConditions()
		{
			ParamItemInputTable paramItemTable = (ParamItemInputTable)Clone();

			if (ConditionSet != null)
			{
				paramItemTable.ConditionSet = new HashSet<ParamItemConditionTable>();

				foreach (ParamItemConditionTable conTable in ConditionSet)
				{
					paramItemTable.ConditionSet.Add((ParamItemConditionTable) conTable.Clone());
				}
			}

			return paramItemTable;
		}

		public virtual object copyWithParamItem()
		{
			ParamItemInputTable inputTable = (ParamItemInputTable)Clone();

			if (ParamItemTable != null)
			{
				inputTable.ParamItemTable = (ParamItemTable) ParamItemTable.Clone();
			}

			return inputTable;
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="PARAMINPUTID" </summary>
		/// <returns> Long </returns>
		public virtual long? ParamInputId
		{
			get
			{
				return paramInputId;
			}
			set
			{
				this.paramInputId = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="NAME" type="costos_string" </summary>
		/// <returns> title </returns>
		public virtual string Name
		{
			get
			{
				return name;
			}
			set
			{
				this.name = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="LBL" type="costos_string" </summary>
		/// <returns> title </returns>
		public virtual string Label
		{
			get
			{
				return label;
			}
			set
			{
				this.label = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="HIDDEN" type="boolean" </summary>
		/// <returns> title </returns>
		public virtual bool? Hidden
		{
			get
			{
				return hidden;
			}
			set
			{
				this.hidden = value;
			}
		}



		/// <summary>
		/// @hibernate.property column="PBLK" type="boolean" </summary>
		/// <returns> title </returns>
		public virtual bool? Pblk
		{
			get
			{
				return pblk;
			}
			set
			{
				this.pblk = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ARTYPE" type="costos_string" </summary>
		/// <returns> title </returns>
		public virtual string ArrayType
		{
			get
			{
				return arrayType;
			}
			set
			{
				this.arrayType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ARSIZEVAR" type="costos_string" </summary>
		/// <returns> title </returns>
		public virtual string ArraySizeVar
		{
			get
			{
				return arraySizeVar;
			}
			set
			{
				this.arraySizeVar = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EDITABLE" type="boolean" </summary>
		/// <returns> title </returns>
		public virtual bool? Editable
		{
			get
			{
				return editable;
			}
			set
			{
				this.editable = value;
			}
		}


		//RXL_START
		/// <summary>
		/// @hibernate.property column="WASSHOWN" type="boolean" </summary>
		/// <returns> wasShowing </returns>
		//RXL_END
		public virtual bool? WasShowing
		{
			get
			{
				return wasShowing;
			}
			set
			{
				this.wasShowing = value;
			}
		}


		//#RXL_START
		/// <summary>
		/// @hibernate.property column="CALCVALUE" type="boolean" </summary>
		/// <returns> calcValue </returns>
		//#RXL_END
		public virtual bool? CalcValue
		{
			get
			{
				return calcValue;
			}
			set
			{
				this.calcValue = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CALCVALDIGITS" type="byte" </summary>
		/// <returns> calcValueDecimalDigits </returns>
		public virtual sbyte? CalcValueDecimalDigits
		{
			get
			{
				return calcValueDecimalDigits;
			}
			set
			{
				this.calcValueDecimalDigits = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DESCRIPTION" type="costos_text" </summary>
		/// <returns> title </returns>
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
		/// This boolean determines if array formula row is visible in assembly runtime
		/// @hibernate.property column="FRMROWVIS" type="boolean" </summary>
		/// <returns> frmRowVisible </returns>
		public virtual bool? FrmRowVisible
		{
			get
			{
				return frmRowVisible;
			}
			set
			{
				this.frmRowVisible = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DATATYPE" type="costos_string" </summary>
		/// <returns> title </returns>
		public virtual string DataType
		{
			get
			{
				return dataType;
			}
			set
			{
				this.dataType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DEPENDENCY" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string DependencyStatement
		{
			get
			{
				return dependencyStatement;
			}
			set
			{
				this.dependencyStatement = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="VALIDATION" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string ValidationStatement
		{
			get
			{
				return validationStatement;
			}
			set
			{
				this.validationStatement = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SELECTION" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string SelectionList
		{
			get
			{
				return selectionList;
			}
			set
			{
				this.selectionList = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SORTORDER" type="int" </summary>
		/// <returns> title </returns>
		public virtual int? SortOrder
		{
			get
			{
				return sortOrder;
			}
			set
			{
				this.sortOrder = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="GROUPING" type="costos_string" </summary>
		/// <returns> title </returns>
		public virtual string Grouping
		{
			get
			{
				return grouping;
			}
			set
			{
				this.grouping = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DEFVALUE" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string DefaultValue
		{
			get
			{
				return defaultValue;
			}
			set
			{
				this.defaultValue = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="UNIT" type="costos_string" </summary>
		/// <returns> title </returns>
		public virtual string Unit
		{
			get
			{
				return unit;
			}
			set
			{
				this.unit = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="STOVAL" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string StoredValue
		{
			get
			{
				return storedValue;
			}
			set
			{
				this.storedValue = value;
			}
		}

		//#RXL_START
		/// <summary>
		/// @hibernate.set
		///  inverse="false"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PARAMINPUTID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ParamItemConditionTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		//#RXL_END
		public virtual ISet<ParamItemConditionTable> ConditionSet
		{
			get
			{
				return conditionSet;
			}
			set
			{
				this.conditionSet = value;
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


		public virtual int CompareTo(ParamItemInputTable o)
		{
			return SortOrder.compareTo(((ParamItemInputTable) o).SortOrder);
		}

		public override bool Equals(object o)
		{
			if (!(o is ParamItemInputTable))
			{
				return false;
			}

			ParamItemInputTable p = (ParamItemInputTable)o;

			if (p.ParamInputId != null && ParamInputId != null)
			{
				return p.ParamInputId == ParamInputId;
			}

			return p.Name.Equals(Name);
		}

		public override string Title
		{
			get
			{
				return Name;
			}
			set
			{
				// TODO Auto-generated method stub	
			}
		}

		public override decimal TableRate
		{
			get
			{
				// TODO Auto-generated method stub
				return null;
			}
		}

		public override long? Id
		{
			get
			{
				return ParamInputId;
			}
		}

		public override string ToString()
		{
			return Id + ". " + Name;
		}

		public override string EditorId
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

		public override string CreateUserId
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

		public override DateTime CreateDate
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

		public override DateTime LastUpdate
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