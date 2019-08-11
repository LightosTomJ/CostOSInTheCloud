using System;
using System.Collections.Generic;

namespace Models.local
{

	using BaseEntity = nomitech.common.@base.BaseEntity;
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="PRJDBMS"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class ProjectDbmsTable : BaseEntity
	{

		private long? id;

		private string hostName;
		private string hostPort;
		private int? dbms;
		private string instanceName;
		private string hostUsername;
		private string hostPassword;
		private string databaseName;
		private ISet<ProjectUrlTable> projectUrls;

		public virtual ProjectDbmsTable Data
		{
			set
			{
				HostName = value.HostName;
				HostPort = value.HostPort;
				Dbms = value.Dbms;
				DatabaseName = value.DatabaseName;
				InstanceName = value.InstanceName;
				HostUsername = value.HostUsername;
				HostPassword = value.HostPassword;
			}
		}

		public virtual object clone()
		{
			ProjectDbmsTable o = new ProjectDbmsTable();
			o.Id = Id;
			o.Data = this;
			return o;
		}

		public virtual ProjectDbmsTable copy()
		{
			ProjectDbmsTable o = new ProjectDbmsTable();
			o.Id = Id;
			o.Data = this;
			if (projectUrls == null)
			{
				projectUrls = new HashSet<ProjectUrlTable>();
			}
			foreach (ProjectUrlTable urlTable in projectUrls)
			{
				projectUrls.Add((ProjectUrlTable) urlTable.clone());
			}
			o.ProjectUrls = projectUrls;

			return o;
		}

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
		/// @hibernate.property column="HNAME" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string HostName
		{
			get
			{
				return hostName;
			}
			set
			{
				this.hostName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="DBNAME" type="costos_string" </summary>
		/// <returns> editorId </returns>
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
		/// @hibernate.property column="HPORT" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string HostPort
		{
			get
			{
				return hostPort;
			}
			set
			{
				this.hostPort = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="HDBMS" type="int" </summary>
		/// <returns> editorId </returns>
		public virtual int? Dbms
		{
			get
			{
				return dbms;
			}
			set
			{
				this.dbms = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="HINST" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string InstanceName
		{
			get
			{
				return instanceName;
			}
			set
			{
				this.instanceName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="HUSER" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string HostUsername
		{
			get
			{
				return hostUsername;
			}
			set
			{
				this.hostUsername = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="HPASS" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public virtual string HostPassword
		{
			get
			{
				return hostPassword;
			}
			set
			{
				this.hostPassword = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PROJECTDBMSID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ProjectUrlTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<ProjectUrlTable> ProjectUrls
		{
			get
			{
				return projectUrls;
			}
			set
			{
				this.projectUrls = value;
			}
		}

	}

}