using System;
using System.Collections.Generic;

namespace Model.proj
{

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="WSDATAMAPPING"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class WorksheetDataMappingTable : ProjectIdEntity
	{

	//	//Import Algorithms:
	//	public static final Integer ALG_NONE = 0;
	//	public static final Integer ALG_UNIT_ONLY = 1;
	//	public static final Integer ALG_EMPTY_ROWS_TOP_BOTTOM_AND_UNIT = 2;
	//	public static final Integer ALG_TIMBERLINE = 3;

		private long? id;
		private string title;
	//	private Integer importAlgorithm;

		private bool? commentAutoDetect;
		private bool? treeAutoDetect;
		private bool? keepItemsOnly;
		private string treeMapping;
		private string tablePreference;
		private int? groupColumnIndex;

		// Like Ignore Row or Ignore Cell 
		private string cellDataToIgnore;
		private ISet<WorksheetIdentifyColumnTable> identifyColumns;
		private WorksheetRevisionTable revision;
		private sbyte[] excelFile;

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

		public virtual WorksheetDataMappingTable Data
		{
			set
			{
				Title = value.Title;
				CellDataToIgnore = value.CellDataToIgnore;
				GroupColumnIndex = value.GroupColumnIndex;
				TreeMapping = value.TreeMapping;
				AutoDetectComments = value.AutoDetectComments;
				AutoDetectTree = value.AutoDetectTree;
				KeepItemsOnly = value.KeepItemsOnly;
				TablePreference = value.TablePreference;
				ExcelFile = value.ExcelFile;
			}
		}

		public virtual object clone()
		{
			WorksheetDataMappingTable o = new WorksheetDataMappingTable();
			o.Id = Id;
			o.Data = this;
			o.ProjectId = ProjectId;
			return o;
		}

		//#RXL_START
		/// <summary>
		/// @hibernate.property column="XCELLFILE" type="binary" length="73741824" </summary>
		/// <returns> description </returns>
		//#RXL_END
		public virtual sbyte[] ExcelFile
		{
			get
			{
				return excelFile;
			}
			set
			{
				this.excelFile = value;
			}
		}

		public virtual WorksheetDataMappingTable deepCopy()
		{
			WorksheetDataMappingTable o = (WorksheetDataMappingTable)clone();

			o.IdentifyColumns = new HashSet<WorksheetIdentifyColumnTable>();

			if (IdentifyColumns == null)
			{
				IdentifyColumns = Collections.EMPTY_SET;
			}

			foreach (WorksheetIdentifyColumnTable colTable in IdentifyColumns)
			{
				o.IdentifyColumns.Add((WorksheetIdentifyColumnTable)colTable.clone());
			}

			return o;
		}

		/// <summary>
		/// @hibernate.property column="TITLE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Title
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
		/// @hibernate.property column="CELLDTINGN" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string CellDataToIgnore
		{
			get
			{
				return cellDataToIgnore;
			}
			set
			{
				this.cellDataToIgnore = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="GROUPCOL" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? GroupColumnIndex
		{
			get
			{
				return groupColumnIndex;
			}
			set
			{
				this.groupColumnIndex = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="TREEMAPPING" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string TreeMapping
		{
			get
			{
				return treeMapping;
			}
			set
			{
				this.treeMapping = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COMMENTDETECT" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? AutoDetectComments
		{
			get
			{
				return commentAutoDetect;
			}
			set
			{
				this.commentAutoDetect = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="TREEDETECT" type="boolean" </summary>
		/// <returns> Boolean </returns>
		public virtual bool? AutoDetectTree
		{
			get
			{
				return treeAutoDetect;
			}
			set
			{
				this.treeAutoDetect = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="KEEPITEMS" type="boolean" </summary>
		/// <returns> Boolean </returns>
		public virtual bool? KeepItemsOnly
		{
			get
			{
				return keepItemsOnly;
			}
			set
			{
				this.keepItemsOnly = value;
			}
		}
		/// <summary>
		/// @hibernate.property column="TABLEPREFER" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string TablePreference
		{
			get
			{
				return tablePreference;
			}
			set
			{
				this.tablePreference = value;
			}
		}

		/// <summary>
		/// @hibernate.one-to-one
		/// 	cascade="save-update"
		/// </summary>
		public virtual WorksheetRevisionTable Revision
		{
			get
			{
				return revision;
			}
			set
			{
				this.revision = value;
			}
		}

		/// <summary>
		/// @hibernate.set
		///  inverse="true"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="MAPPINGID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.WorksheetIdentifyColumnTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<WorksheetIdentifyColumnTable> IdentifyColumns
		{
			get
			{
				return identifyColumns;
			}
			set
			{
				this.identifyColumns = value;
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