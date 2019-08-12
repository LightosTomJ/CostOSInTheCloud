using System;
using System.Collections.Generic;

namespace Model.local
{

	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;
	using ConditionTable = Desktop.common.nomitech.common.db.project.ConditionTable;

	/// <summary>
	/// @hibernate.class table="FNCTON_ARGUMENT"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class FunctionArgumentTable : IComparable<FunctionArgumentTable>, ProjectIdEntity
	{

		public const string DECIMAL = ParamItemInputTable.DECIMAL;
		public const string INTEGER = ParamItemInputTable.INTEGER;
		public const string SELECTIONLIST = ParamItemInputTable.SELECTIONLIST;
		public const string BOOLEAN = ParamItemInputTable.BOOLEAN;

		public const string COUNTRY = ParamItemInputTable.COUNTRY;
		public const string TAKEOFF = ParamItemInputTable.TAKEOFF;
		public const string ARRAY = ParamItemInputTable.ARRAY;
		public const string CALCARRAY = ParamItemInputTable.CALCARRAY;
		public const string CALLIST = ParamItemInputTable.CALCLIST;

		public const string IMAGE = ParamItemInputTable.IMAGE;
		public const string NOTES = ParamItemInputTable.NOTES;
		public const string TEXT = ParamItemInputTable.TEXT;
		public const string LOCFACTOR = ParamItemInputTable.LOCFACTOR;

		public const string CALCVALUE = ParamItemInputTable.CALCVALUE;
		public const string DATE = ParamItemInputTable.DATE;

		private long? id;
		private string name;
		private string type;
		private string unit;
		private string description;
		private string selectionList;
		private string grouping;
		private string validationStatement;
		private string dependencyStatement;
		private string defaultValue;
		private int? sortOrder;
		private bool? editable;
		private string arrayType;
		private FunctionTable functionTable;

		// Used only to transfer conditions:
		private ISet<ConditionTable> conditionSet;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="FARGID" </summary>
		/// <returns> Long </returns>
		public virtual long? Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="NAME" type="costos_string" </summary>
		/// <returns> name </returns>
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
		/// @hibernate.property column="SORDER" type="int" </summary>
		/// <returns> name </returns>
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


		/// <summary>
		/// @hibernate.many-to-one
		///  column="FID" </summary>
		/// <returns> FunctionTable </returns>
		public virtual FunctionTable FunctionTable
		{
			get
			{
				return functionTable;
			}
			set
			{
				this.functionTable = value;
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
		/// @hibernate.property column="SELLIST" type="costos_text" </summary>
		/// <returns> description </returns>
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
		/// @hibernate.property column="TYPE" type="costos_string" </summary>
		/// <returns> lastUpdate </returns>
		public virtual string Type
		{
			get
			{
				return type;
			}
			set
			{
				this.type = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="UNIT" type="costos_string" </summary>
		/// <returns> lastUpdate </returns>
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
		/// @hibernate.property column="VALSTA" type="costos_text" </summary>
		/// <returns> lastUpdate </returns>
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
		/// @hibernate.property column="DEPSTA" type="costos_text" </summary>
		/// <returns> lastUpdate </returns>
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
		/// @hibernate.property column="DEFVAL" type="costos_text" </summary>
		/// <returns> lastUpdate </returns>
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
		/// @hibernate.property column="GROUPING" type="costos_string" </summary>
		/// <returns> lastUpdate </returns>
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

		public virtual ISet<ConditionTable> ConditionSet
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


		public virtual object clone()
		{
			FunctionArgumentTable fTable = new FunctionArgumentTable();

			fTable.Id = Id;
			fTable.Name = Name;
			fTable.Type = Type;
			fTable.Unit = Unit;
			fTable.Grouping = Grouping;
			fTable.DefaultValue = DefaultValue;
			fTable.Description = Description;
			fTable.DependencyStatement = DependencyStatement;
			fTable.ValidationStatement = ValidationStatement;
			fTable.SelectionList = SelectionList;
			fTable.SortOrder = SortOrder;
			fTable.ArrayType = ArrayType;
			fTable.Editable = Editable;
			fTable.ProjectId = ProjectId;

			return fTable;
		}

		public virtual int CompareTo(FunctionArgumentTable arg)
		{
			return -arg.SortOrder.compareTo(SortOrder);
		}
		public virtual FunctionArgumentTable Data
		{
			set
			{
    
				Name = value.Name;
				Type = value.Type;
				Unit = value.Unit;
				Grouping = value.Grouping;
				DefaultValue = value.DefaultValue;
				Description = value.Description;
				DependencyStatement = value.DependencyStatement;
				ValidationStatement = value.ValidationStatement;
				SelectionList = value.SelectionList;
				SortOrder = value.SortOrder;
				ArrayType = value.ArrayType;
				Editable = value.Editable;
			}
		}

		public virtual FunctionArgumentTable copyWithFunctionTable()
		{
			FunctionArgumentTable arg = (FunctionArgumentTable) clone();
			if (FunctionTable != null)
			{
				arg.FunctionTable = (FunctionTable) FunctionTable.Clone();
			}
			return arg;
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