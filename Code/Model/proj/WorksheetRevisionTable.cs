using System;
using System.Collections.Generic;

namespace Model.proj
{

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="WSREVISION"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class WorksheetRevisionTable : ProjectIdEntity
	{

		private long? id;
		private string title;
		private string code;
		private string description;

		private DateTime createDate;
		private DateTime lastUpdate;
		private string createUserId;
		private string editorId;
		private bool? selected;
		private IList<WorksheetFileTable> files;
		private WorksheetDataMappingTable dataMapping;
		private bool? pblk;

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

		public virtual WorksheetRevisionTable Data
		{
			set
			{
				Code = value.Code;
				Title = value.Title;
				CreateDate = value.CreateDate;
				LastUpdate = value.LastUpdate;
				CreateUserId = value.CreateUserId;
				EditorId = value.EditorId;
				Description = value.Description;
				Selected = value.Selected;
				Pblk = value.Pblk;
			}
		}

		public virtual object clone()
		{
			WorksheetRevisionTable revTable = new WorksheetRevisionTable();
			revTable.Id = Id;
			revTable.Data = this;
			revTable.ProjectId = ProjectId;
			return revTable;
		}

		public virtual WorksheetRevisionTable deepCopy()
		{
			WorksheetRevisionTable p = (WorksheetRevisionTable)clone();

			p.FileList = new List<WorksheetFileTable>();

			if (FileList == null)
			{
				FileList = Collections.EMPTY_LIST;
			}


			foreach (WorksheetFileTable var in FileList)
			{
				p.FileList.Add((WorksheetFileTable) var.clone());
			}

			if (DataMapping != null)
			{
				p.DataMapping = (WorksheetDataMappingTable) DataMapping.deepCopy();
			}

			return p;
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

		//#RXL_START
		/// <summary>
		/// @hibernate.property column="CODE" type="costos_string" </summary>
		/// <returns> String </returns>
		//#RXL_END
		public virtual string Code
		{
			get
			{
				return code;
			}
			set
			{
				this.code = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CREATEDATE" type="timestamp" </summary>
		/// <returns> String </returns>
		public virtual DateTime CreateDate
		{
			get
			{
				return createDate;
			}
			set
			{
				this.createDate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="LASTUPDATE" type="timestamp" </summary>
		/// <returns> String </returns>
		public virtual DateTime LastUpdate
		{
			get
			{
				return lastUpdate;
			}
			set
			{
				this.lastUpdate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CREATEUSERID" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string CreateUserId
		{
			get
			{
				return createUserId;
			}
			set
			{
				this.createUserId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EDITORID" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string EditorId
		{
			get
			{
				return editorId;
			}
			set
			{
				this.editorId = value;
			}
		}

		//#RXP_START
		/// <summary>
		/// @hibernate.property column="DESCRIPTION" type="costos_text" </summary>
		/// <returns> String </returns>
		//#RXP_END
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

		//#RXL_START
		/// <summary>
		/// @hibernate.property column="SELECTED" type="boolean" </summary>
		/// <returns> String </returns>
		//#RXL_END
		public virtual bool? Selected
		{
			get
			{
				return selected;
			}
			set
			{
				this.selected = value;
			}
		}

		//#RXP_START
		/// <summary>
		/// @hibernate.property column="PBLK" type="boolean" </summary>
		/// <returns> String </returns>
		//#RXP_END
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

		//#RXL_START
		/// <summary>
		/// @hibernate.list  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="FILEREVID"
		/// @hibernate.list-index
		///  column="FINDEX"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.WorksheetFileTable"
		/// return List
		/// </summary>
		//#RXL_END
		public virtual IList<WorksheetFileTable> FileList
		{
			get
			{
				return files;
			}
			set
			{
				this.files = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  class="nomitech.common.db.project.WorksheetDataMappingTable"
		///  column="MAPPINGID"
		///  unique="false" </summary>
		/// <returns> Set </returns>
		public virtual WorksheetDataMappingTable DataMapping
		{
			get
			{
				return dataMapping;
			}
			set
			{
				this.dataMapping = value;
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