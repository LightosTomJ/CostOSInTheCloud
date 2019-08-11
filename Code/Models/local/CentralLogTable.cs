using System;

namespace Models.local
{

	using BaseEntity = nomitech.common.@base.BaseEntity;
	//#RXP_START 
	/// 
	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="CNTRLOG"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// 
	/// </summary>
	//#RXP_END
	public class CentralLogTable : BaseEntity
	{

		public const string RESOURSE_SOURCE = "RESOURCE";
		public const string LINE_ITEM_SOURCE = "LINEITEM";
		public const string PARAM_ITEM_SOURCE = "PARAMITEM";
		public const string MATERIAL_SOURCE = "MATERIAL";
		public const string LABOR_SOURCE = "LABOR";
		public const string SUBCONTRACTOR_SOURCE = "SUBCONTRACTOR";
		public const string OTHER_COST_SOURCE = "OTHERSOURCE";
		public const string RESOURSE_ASSIGNMENT_SOURCE = "RESOURSEASSSRC";
		public const string RESOURSE_ASSIGNMENT_PROJECT = "RESOURSEASSPRJ";
		public const string BOQ_ITEM_FORMULA_SOURCE = "FORMULA";
		public const string BOQ_ITEM_SOURCE = "BOQ";
		public const string BOQ_ITEM_ESTIMATOR = "ESTIMATOR";
		public const string BOQ_ITEM_EXCHANGE_RATE = "EXCHANGE_RATE";
		public const string BOQ_ITEM_SYNC = "SYNC_RATES";
		public const string EPS_SOURCE = "EPS";
		public const string PROJECT_SOURCE = "PROJECT";
		public const string PROJECT_RESOURCE_SOURCE = "PROJECT_RESOURCE";
		public const string GROUPCODE_SOURCE = "GROUPCODE";
		public const string QUOTATION_SOURCE = "QUOTATION";
		public const string QUOTEMPLATE_SOURCE = "QUOTETEMPLATE";
		public const string GLOBAL_PROPERTIES_SOURCE = "GLOBALPROPS";
		public const string TAKEOFF_SOURCE = "TAKEOFF";
		public const string SYNC_DATABASE_SOURCE = "SYNCDB";
		public const string GLOBAL_CHANGE_SOURCE = "GLOBCH";
		public const string PROJECT_VARS_SOURCE = "PROJECTVAR";
		public const string PROJECT_PROPS_SOURCE = "PROJECTPROP";
		public const string EXTERNAL_DATASOURCE_SOURCE = "EXTDATASOURCE";
		public const string EXTERNAL_QUERY_SOURCE = "EXTQUERY";

		public const string BIMCT_SOURCE = "BIMCT";

		public static readonly sbyte? OPERATION_CRE = (sbyte)0;
		public static readonly sbyte? OPERATION_UPD = (sbyte)1;
		public static readonly sbyte? OPERATION_DEL = (sbyte)2;
		//filter (if the action related to a specific table then the filter is the name of the table )	
		private long? id;
		private DateTime logDate;
		private string logEditorId;
		private sbyte? logOperation; // C U D
		private string logDescription;
		private string logFilter;
		private string logSource; // is in central database EPS, RESOURCES, GLOBAL PROPERTIES GROUP CODES ETC OR
		// OR
		private long? projectId; // is in project

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

		/// <summary>
		/// @hibernate.property column="LOGDATE" type="timestamp" </summary>
		/// <returns> code </returns>
		public virtual DateTime LogDate
		{
			get
			{
				return logDate;
			}
			set
			{
				this.logDate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EDITORID" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string LogEditorId
		{
			get
			{
				return logEditorId;
			}
			set
			{
				this.logEditorId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="DESCRIPTION" type="costos_text" </summary>
		/// <returns> code </returns>
		public virtual string LogDescription
		{
			get
			{
				return logDescription;
			}
			set
			{
				this.logDescription = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SRC" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string LogSource
		{
			get
			{
				return logSource;
			}
			set
			{
				this.logSource = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FLTR" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string LogFilter
		{
			get
			{
				return logFilter;
			}
			set
			{
				this.logFilter = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PRJID" type="long" index="IDX_PRJID" </summary>
		/// <returns> code </returns>
		public virtual long? ProjectId
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

		/// <summary>
		/// @hibernate.property column="OPRTN" type="byte" </summary>
		/// <returns> code </returns>
		public virtual sbyte? LogOperation
		{
			get
			{
				return logOperation;
			}
			set
			{
				this.logOperation = value;
			}
		}
	}

}