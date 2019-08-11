using System;
using System.Collections.Generic;

namespace Models.proj
{

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="PROJECTTEMPLATE"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class ProjectTemplateTable : ProjectIdEntity
	{

		private long? id;
		private long? databaseId;
		private long? databaseCreateDate;
		private string title;
		private string editorId;
		private string userId;
		private DateTime lastUpdate;
		private DateTime createDate;
		private string createUserId;
		private bool? pblk;
		private bool? hasBuildUps;
		private bool? hasDistributors;
		private bool? allowForViewers;
		private string description;
		private bool? selected = false;
		private ISet<ProjectVariableTable> variableSet;
		private ISet<RateBuildUpTable> rateBuildUpSet;
		private ISet<RateBuildUpColumnsTable> rateBuildUpColumnsSet;
		private ISet<RateDistributorTable> rateDistributorSet;
		private ProjectExcelFile excelFile;
		private string templateUsersAndRoles;

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


		public virtual ProjectTemplateTable Data
		{
			set
			{
				Title = value.Title;
				EditorId = value.EditorId;
				UserId = value.UserId;
				LastUpdate = value.LastUpdate;
				CreateDate = value.CreateDate;
				CreateUserId = value.CreateUserId;
				DatabaseId = value.DatabaseId;
				DatabaseCreateDate = value.DatabaseCreateDate;
				Pblk = value.Pblk;
				HasBuildUps = value.HasBuildUps;
				HasDistributors = value.HasDistributors;
				Description = value.Description;
				AllowForViewers = value.AllowForViewers;
				TemplateUsersAndRoles = value.TemplateUsersAndRoles;
			}
		}

		public virtual object clone()
		{
			ProjectTemplateTable o = new ProjectTemplateTable();
			o.Data = this;
			o.Id = Id;
			o.ProjectId = ProjectId;
			return o;
		}

		public virtual ProjectTemplateTable deepCopyVariablesOnly()
		{
			ProjectTemplateTable p = (ProjectTemplateTable) clone();

			p.VariableSet = new HashSet<ProjectVariableTable>();

			if (VariableSet == null)
			{
				VariableSet = Collections.EMPTY_SET;
			}

			foreach (ProjectVariableTable var in VariableSet)
			{
				p.VariableSet.Add((ProjectVariableTable) var.clone());
			}

			return p;
		}

		public virtual ProjectTemplateTable deepCopy()
		{
			ProjectTemplateTable p = (ProjectTemplateTable) clone();

			p.VariableSet = new HashSet<ProjectVariableTable>();
			p.RateBuildUpSet = new HashSet<RateBuildUpTable>();
			p.RateBuildUpColumnsSet = new HashSet<RateBuildUpColumnsTable>();
			p.RateDistributorSet = new HashSet<RateDistributorTable>();
			p.Selected = Selected;
			p.TemplateUsersAndRoles = TemplateUsersAndRoles;
			if (VariableSet == null)
			{
				VariableSet = Collections.EMPTY_SET;
			}
			if (RateBuildUpColumnsSet == null)
			{
				RateBuildUpColumnsSet = Collections.EMPTY_SET;
			}
			if (RateBuildUpSet == null)
			{
				RateBuildUpSet = Collections.EMPTY_SET;
			}
			if (RateDistributorSet == null)
			{
				RateDistributorSet = Collections.EMPTY_SET;
			}

			foreach (ProjectVariableTable var in VariableSet)
			{
				p.VariableSet.Add((ProjectVariableTable) var.clone());
			}

			foreach (RateBuildUpTable var in RateBuildUpSet)
			{
				p.RateBuildUpSet.Add((RateBuildUpTable) var.clone());
			}

			foreach (RateBuildUpColumnsTable var in RateBuildUpColumnsSet)
			{
				p.RateBuildUpColumnsSet.Add((RateBuildUpColumnsTable) var.clone());
			}

			foreach (RateDistributorTable var in RateDistributorSet)
			{
				p.RateDistributorSet.Add((RateDistributorTable) var.clone());
			}

			if (ExcelFile != null)
			{
				p.ExcelFile = (ProjectExcelFile) ExcelFile.clone();
			}

			return p;
		}

		public virtual ProjectTemplateTable deepCopyRateBuildUpsOnly()
		{
			ProjectTemplateTable p = (ProjectTemplateTable) clone();

			p.VariableSet = new HashSet<ProjectVariableTable>();
			p.RateBuildUpSet = new HashSet<RateBuildUpTable>();
			p.RateBuildUpColumnsSet = new HashSet<RateBuildUpColumnsTable>();
			p.RateDistributorSet = new HashSet<RateDistributorTable>();

			if (RateBuildUpColumnsSet == null)
			{
				RateBuildUpColumnsSet = Collections.EMPTY_SET;
			}
			if (RateBuildUpSet == null)
			{
				RateBuildUpSet = Collections.EMPTY_SET;
			}

			foreach (RateBuildUpTable var in RateBuildUpSet)
			{
				p.RateBuildUpSet.Add((RateBuildUpTable) var.clone());
			}

			foreach (RateBuildUpColumnsTable var in RateBuildUpColumnsSet)
			{
				p.RateBuildUpColumnsSet.Add((RateBuildUpColumnsTable) var.clone());
			}

			return p;
		}

		/// <summary>
		/// @hibernate.set
		///  inverse="true"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="TEMPLATEID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.RateDistributorTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<RateDistributorTable> RateDistributorSet
		{
			get
			{
				return rateDistributorSet;
			}
			set
			{
				this.rateDistributorSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="TEMPLATEID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.ProjectVariableTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<ProjectVariableTable> VariableSet
		{
			get
			{
				return variableSet;
			}
			set
			{
				this.variableSet = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  class="nomitech.common.db.project.ProjectExcelFile"
		///  column="TEMPLATEID"
		///  unique="false" </summary>
		/// <returns> Set </returns>
		public virtual ProjectExcelFile ExcelFile
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


		/// <summary>
		/// @hibernate.set
		///  inverse="true"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="TEMPLATEID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.RateBuildUpTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<RateBuildUpTable> RateBuildUpSet
		{
			get
			{
				return rateBuildUpSet;
			}
			set
			{
				this.rateBuildUpSet = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="TEMPLATEID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.RateBuildUpColumnsTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<RateBuildUpColumnsTable> RateBuildUpColumnsSet
		{
			get
			{
				return rateBuildUpColumnsSet;
			}
			set
			{
				this.rateBuildUpColumnsSet = value;
			}
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


		/// <summary>
		/// @hibernate.property column="USERID" type="costos_string" </summary>
		/// <returns> current userId </returns>
		public virtual string UserId
		{
			get
			{
				return userId;
			}
			set
			{
				this.userId = value;
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
		/// @hibernate.property column="CREATEUSER" type="costos_string" </summary>
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
		/// @hibernate.property column="DATABASEID" type="long" index="IDX_MDBID" </summary>
		/// <returns> String </returns>
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
		/// @hibernate.property column="DBCREATEDATE" type="long" </summary>
		/// <returns> String </returns>
		public virtual long? DatabaseCreateDate
		{
			get
			{
				return databaseCreateDate;
			}
			set
			{
				this.databaseCreateDate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PBLK" type="boolean" </summary>
		/// <returns> String </returns>
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
		/// @hibernate.property column="HASBUILDUPS" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? HasBuildUps
		{
			get
			{
				return hasBuildUps;
			}
			set
			{
				this.hasBuildUps = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="HASDISTRIBUTORS" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? HasDistributors
		{
			get
			{
				return hasDistributors;
			}
			set
			{
				this.hasDistributors = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ALLOWVIEWERS" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? AllowForViewers
		{
			get
			{
				return allowForViewers;
			}
			set
			{
				this.allowForViewers = value;
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


		public override string ToString()
		{
			return Title + " [" + editorId + "]";
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
		//#RXL_START
		/// <summary>
		/// @hibernate.property column="TEMPLATEROLES" type="costos_text" </summary>
		/// <returns> String </returns>
		//#RXL_END
		public virtual string TemplateUsersAndRoles
		{
			get
			{
				return templateUsersAndRoles;
			}
			set
			{
				this.templateUsersAndRoles = value;
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