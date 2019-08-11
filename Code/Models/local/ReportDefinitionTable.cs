using System;
using System.Collections.Generic;

namespace Models.local
{

	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="RPDFN"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class ReportDefinitionTable
	{

		private long? id;
		private string name;
		private string icon;
		private string design;
		private string description;
		private string group;
		private string editorId;
		private string createUserId;
		private DateTime lastUpdate;
		private DateTime createDate;
		private bool? pblk;
		private bool? userReport;
		private bool? multiUserReport;
		private string reportType;
		private string reportUrl;
		private string reportRoles;

		public IList<FileDefinitionTable> fileDefinitionList;
		public const string JRXML_REPORT = "0";
		public const string JASPER_SERVER_REPORT = "1";
		public const string JASPER_SERVER_DASHBOARD = "2";
	//private final String 
		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="RPDFNID" </summary>
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
		/// Description Here
		/// 
		/// @hibernate.property column="RNAME" type="costos_string" </summary>
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
		/// Description Here
		/// 
		/// @hibernate.property column="RICN" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Icon
		{
			get
			{
				return icon;
			}
			set
			{
				this.icon = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="RDSGN" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Design
		{
			get
			{
				return design;
			}
			set
			{
				this.design = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="RDESC" type="costos_text" </summary>
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
		/// Description Here
		/// 
		/// @hibernate.property column="REDTID" type="costos_string" </summary>
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
		/// Description Here
		/// 
		/// @hibernate.property column="RCREUSER" type="costos_string" </summary>
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
		/// Description Here
		/// 
		/// @hibernate.property column="RLASTUPD" type="timestamp" </summary>
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
		/// Description Here
		/// 
		/// @hibernate.property column="RCREDATE" type="timestamp" </summary>
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
		/// Description Here
		/// 
		/// @hibernate.property column="RGRP" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Group
		{
			get
			{
				return group;
			}
			set
			{
				this.group = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="RPBLK" type="boolean" </summary>
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
		/// Description Here
		/// 
		/// @hibernate.property column="RUSRREP" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? UserReport
		{
			get
			{
				return userReport;
			}
			set
			{
				this.userReport = value;
			}
		}


		/// 
		/// <summary>
		/// @hibernate.property column="MLTUSRRPT" type="boolean" </summary>
		/// <returns> Boolean </returns>
		public virtual bool? MultiUserReport
		{
			get
			{
				return multiUserReport;
			}
			set
			{
				this.multiUserReport = value;
			}
		}


		/// 
		/// <summary>
		/// @hibernate.property column="REPORTTYPE" type="costos_string" </summary>
		/// <returns> Boolean </returns>

		public virtual string ReportType
		{
			get
			{
				return reportType;
			}
			set
			{
				this.reportType = value;
			}
		}
		/// 
		/// <summary>
		/// @hibernate.property column="RJSURL" type="costos_string" </summary>
		/// <returns> Boolean </returns>


		public virtual string ReportUrl
		{
			get
			{
				return reportUrl;
			}
			set
			{
				this.reportUrl = value;
			}
		}


		/// 
		/// <summary>
		/// @hibernate.property column="REPORTROLES" type="costos_string" </summary>
		/// <returns> Boolean </returns>
		public virtual string ReportRoles
		{
			get
			{
				return reportRoles;
			}
			set
			{
				this.reportRoles = value;
			}
		}


		public virtual ReportDefinitionTable Data
		{
			set
			{
    
				Id = value.Id;
				Name = value.Name;
				Description = value.Description;
				Group = value.Group;
				Design = value.Design;
				Icon = value.Icon;
				Pblk = value.Pblk;
				MultiUserReport = value.MultiUserReport;
				LastUpdate = value.LastUpdate;
				CreateDate = value.CreateDate;
				UserReport = value.UserReport;
				CreateUserId = value.CreateUserId;
				EditorId = value.EditorId;
				ReportType = value.ReportType;
				ReportUrl = value.ReportUrl;
				ReportRoles = value.ReportRoles;
			}
		}

		public virtual object clone()
		{
			ReportDefinitionTable obj = new ReportDefinitionTable();

			obj.Id = Id;
			obj.Name = Name;
			obj.Description = Description;
			obj.MultiUserReport = MultiUserReport;
			obj.Group = Group;
			obj.Design = Design;
			obj.Icon = Icon;
			obj.Pblk = Pblk;
			obj.LastUpdate = LastUpdate;
			obj.CreateDate = CreateDate;
			obj.CreateUserId = CreateUserId;
			obj.EditorId = EditorId;
			obj.UserReport = UserReport;
			obj.ReportType = ReportType;
			obj.ReportUrl = ReportUrl;
			obj.ReportRoles = ReportRoles;
			return obj;
		}

		public virtual ReportDefinitionTable copyWithResources()
		{
			ReportDefinitionTable def = (ReportDefinitionTable) clone();

			IList<FileDefinitionTable> list = new List<FileDefinitionTable>();

			if (FileDefinitionList != null)
			{
				foreach (FileDefinitionTable resDef in FileDefinitionList)
				{
					list.Add((FileDefinitionTable) resDef.clone());
				}
			}

			def.FileDefinitionList = list;

			return def;
		}

		/// <summary>
		/// @hibernate.list  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="RPDFNID"
		/// @hibernate.list-index
		///  column="RPDFNFILDEFCOUNT"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.FileDefinitionTable"
		/// </summary>
		/// <returns> List </returns>
		public virtual IList<FileDefinitionTable> FileDefinitionList
		{
			get
			{
				return fileDefinitionList;
			}
			set
			{
				this.fileDefinitionList = value;
			}
		}

	}

}