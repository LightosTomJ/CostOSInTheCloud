using System;

namespace Models.proj
{

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ParamItemInputTable = nomitech.common.db.local.ParamItemInputTable;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="PROJECTSPECVAR"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class ProjectVariableTable : ProjectIdEntity
	{

		public const string SHEET_CELL = "datatype.sheetcell";
		public const string CALCULATED_VALUE = ParamItemInputTable.CALCVALUE;

		private long? id;
		private string name;

		private string description;
		private string dataType;

		private string defaultValue;
		private string storedValue;
		private decimal storedValueNum;
		private int? sortOrder;

		private int? sheetNo;
		private bool? mapped;
		private int? cellX;
		private int? cellY;
		private bool? number;
		private bool? mandatory;
		private string pushField;
		private bool? hidden;
		private long? databaseTemplateId;
		private string databaseTemplateName;

		private ProjectTemplateTable projectTemplateTable;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="ID" </summary>
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

		public virtual ProjectVariableTable Data
		{
			set
			{
				Name = value.Name;
				Description = value.Description;
				DataType = value.DataType;
				DefaultValue = value.DefaultValue;
				StoredValue = value.StoredValue;
				StoredValueNum = value.StoredValueNum;
				SortOrder = value.SortOrder;
				SheetNo = value.SheetNo;
				CellX = value.CellX;
				CellY = value.CellY;
				Number = value.Number;
				Mandatory = value.Mandatory;
				Mapped = value.Mapped;
				PushField = value.PushField;
				Hidden = value.Hidden;
				ProjectTemplateTable = value.ProjectTemplateTable;
				DatabaseTemplateId = value.DatabaseTemplateId;
				DatabaseTemplateName = value.DatabaseTemplateName;
			}
		}

		public virtual object clone()
		{
			ProjectVariableTable o = new ProjectVariableTable();
			o.Data = this;
			o.Id = Id;
			o.ProjectId = ProjectId;
			return o;
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="TEMPLATEID" </summary>
		/// <returns> ProjectTemplateTable </returns>
		public virtual ProjectTemplateTable ProjectTemplateTable
		{
			get
			{
				return projectTemplateTable;
			}
			set
			{
				this.projectTemplateTable = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="NAME" type="costos_text" </summary>
		/// <returns> String </returns>
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
		/// @hibernate.property column="DESCRIPTION" type="costos_text" </summary>
		/// <returns> String </returns>
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
		/// @hibernate.property column="DATATYPE" type="costos_string" </summary>
		/// <returns> String </returns>
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
		/// @hibernate.property column="DEFVAL" type="costos_text" </summary>
		/// <returns> String </returns>
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
		/// @hibernate.property column="STOVAL" type="costos_text" </summary>
		/// <returns> String </returns>
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
		/// @hibernate.property column="CELLX" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? CellX
		{
			get
			{
				return cellX;
			}
			set
			{
				this.cellX = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CELLY" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? CellY
		{
			get
			{
				return cellY;
			}
			set
			{
				this.cellY = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SHEETNO" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? SheetNo
		{
			get
			{
				return sheetNo;
			}
			set
			{
				this.sheetNo = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="MAPPED" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? Mapped
		{
			get
			{
				return mapped;
			}
			set
			{
				this.mapped = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="STOVALNUM" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal StoredValueNum
		{
			get
			{
				return storedValueNum;
			}
			set
			{
				this.storedValueNum = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ISNUMBER" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? Number
		{
			get
			{
				return number;
			}
			set
			{
				this.number = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="MANDATORY" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? Mandatory
		{
			get
			{
				return mandatory;
			}
			set
			{
				this.mandatory = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PUSHFIELD" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string PushField
		{
			get
			{
				return pushField;
			}
			set
			{
				this.pushField = value;
			}
		}


		//#RXL_START
		/// <summary>
		/// @hibernate.property column="HIDDEN" type="boolean" </summary>
		/// <returns> hidden </returns>
		//#RXL_END
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


		//#RXL_START
		/// <summary>
		/// @hibernate.property column="DATABASETEMPLATEID" type="long" </summary>
		/// <returns> databaseTemplateId </returns>
		//#RXL_END
		public virtual long? DatabaseTemplateId
		{
			get
			{
				return databaseTemplateId;
			}
			set
			{
				this.databaseTemplateId = value;
			}
		}

		//#RXL_START
		/// <summary>
		/// @hibernate.property column="DATABASETEMPLATENAME" type="costos_string" </summary>
		/// <returns> String </returns>
		//#RXL_END
		public virtual string DatabaseTemplateName
		{
			get
			{
				return databaseTemplateName;
			}
			set
			{
				this.databaseTemplateName = value;
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