using System;
using System.Collections.Generic;

namespace Models.local
{

	using BaseEntity = Desktop.common.nomitech.common.@base.BaseEntity;

	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="EXTDATASOURCE"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	public class ExternalDatasourceTable : BaseEntity
	{

		public const sbyte? JDBC_DATASOURCE_TYPE = 0;
		public const sbyte? JSON_DATASOURCE_TYPE = 1;
		public const sbyte? XML_DATASOURCE_TYPE = 2;

		public const sbyte? JTDS_JDBC_TYPE = 0;
		public const sbyte? ORACLE_JDBC_TYPE = 1;
		public const sbyte? MariaDB_JDBC_TYPE = 2;
		public const sbyte? POSTGRES_JDBC_TYPE = 3;

		private long? id;
		private string title;
		private sbyte? type;

		// JDBC
		private sbyte? jdbcDatabaseType;
		private string jdbcDriverClass;
		private string jdbcDatabaseUrl;

		private string jdbcUsername;
		private string jdbcPassword;

		// General:
		private string createUserId;
		private DateTime createUserDate;
		private string editorId;
		private DateTime lastUpdate;
		private ISet<ExternalQueryTable> querySet;

		/// <summary>
		/// @hibernate.id generator-class="native" unsaved-value="null"
		///               column="DATASOURCEID" </summary>
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
		/// @hibernate.property column="DSTITLE" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// @hibernate.property column="DSTYPE" type="byte" </summary>
		/// <returns> description </returns>
		public virtual sbyte? Type
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
		/// @hibernate.property column="JDBCTYPE" type="byte" </summary>
		/// <returns> description </returns>
		public virtual sbyte? JdbcDatabaseType
		{
			get
			{
				return jdbcDatabaseType;
			}
			set
			{
				this.jdbcDatabaseType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="JDBCDRIVER" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string JdbcDriverClass
		{
			get
			{
				return jdbcDriverClass;
			}
			set
			{
				this.jdbcDriverClass = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="JDBCURL" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string JdbcDatabaseUrl
		{
			get
			{
				return jdbcDatabaseUrl;
			}
			set
			{
				this.jdbcDatabaseUrl = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="JDBCUSER" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string JdbcUsername
		{
			get
			{
				return jdbcUsername;
			}
			set
			{
				this.jdbcUsername = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="JDBCPSW"
		///                     type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string JdbcPassword
		{
			get
			{
				return jdbcPassword;
			}
			set
			{
				this.jdbcPassword = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CREATEUSER" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// @hibernate.property column="CREATEDATE" type="timestamp" </summary>
		/// <returns> description </returns>
		public virtual DateTime CreateUserDate
		{
			get
			{
				return createUserDate;
			}
			set
			{
				this.createUserDate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EDITORID" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// @hibernate.property column="LASTUPDATE" type="timestamp" </summary>
		/// <returns> description </returns>
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
		/// @hibernate.set
		///  inverse="false"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="DATASOURCEID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ExternalQueryTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<ExternalQueryTable> QuerySet
		{
			get
			{
				return querySet;
			}
			set
			{
				this.querySet = value;
			}
		}


		public virtual ExternalDatasourceTable Data
		{
			set
			{
				this.Title = value.Title;
				this.Type = value.Type;
				this.JdbcDatabaseType = value.JdbcDatabaseType;
				this.JdbcDriverClass = value.JdbcDriverClass;
				this.JdbcDatabaseUrl = value.JdbcDatabaseUrl;
				this.JdbcUsername = value.JdbcUsername;
				this.JdbcPassword = value.JdbcPassword;
    
				this.CreateUserId = value.CreateUserId;
				this.CreateUserDate = value.CreateUserDate;
				this.EditorId = value.EditorId;
				this.LastUpdate = value.LastUpdate;
			}
		}

		public override ExternalDatasourceTable clone()
		{
			ExternalDatasourceTable datasource = new ExternalDatasourceTable();
			datasource.Id = Id;
			datasource.Data = this;
			return datasource;
		}

		public virtual ExternalDatasourceTable deepCopy()
		{
			ExternalDatasourceTable datasource = clone();
			datasource.QuerySet = new HashSet<ExternalQueryTable>();

			foreach (ExternalQueryTable query in querySet)
			{
				datasource.QuerySet.Add(query.deepCopy());
			}

			return datasource;
		}

		public override string ToString()
		{
			return Title;
		}

	}

}