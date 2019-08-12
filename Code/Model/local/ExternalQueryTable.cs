using System;
using System.Collections.Generic;

namespace Model.local
{

	using BaseEntity = Desktop.common.nomitech.common.@base.BaseEntity;

	//#RXP_START
	/// <summary>
	/// @author George Hatzisymeon
	/// 
	/// @hibernate.class table="EXTQUERY"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	public class ExternalQueryTable : BaseEntity
	{

		private long? id;
		private string title;
		private string query;
		private string resourceType;
		private ExternalDatasourceTable datasourceTable;
		private ISet<ExternalQueryAliasTable> queryAliasSet;

		// General:
		private string createUserId;
		private DateTime createUserDate;
		private string editorId;
		private DateTime lastUpdate;


		/// <summary>
		/// @hibernate.id generator-class="native" unsaved-value="null" column="QUERYID" </summary>
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
		/// @hibernate.property column="TITLE" type="costos_string" </summary>
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
		/// @hibernate.property column="DSQUERY" type="costos_text" </summary>
		/// <returns> description </returns>
		public virtual string Query
		{
			get
			{
				return query;
			}
			set
			{
				this.query = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="RESOURCETYPE" type="costos_string" </summary>
		/// <returns> resourceType </returns>
		public virtual string ResourceType
		{
			get
			{
				return resourceType;
			}
			set
			{
				this.resourceType = value;
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
		/// @hibernate.many-to-one
		///  column="DATASOURCEID"
		///  cascade="none" </summary>
		/// <returns> ExternalDatasourceTable </returns>
		public virtual ExternalDatasourceTable DatasourceTable
		{
			get
			{
				return datasourceTable;
			}
			set
			{
				this.datasourceTable = value;
			}
		}


		/// <summary>
		/// @hibernate.set inverse="false" cascade="all-delete-orphan"
		/// @hibernate.key column="QUERYID"
		/// @hibernate.one-to-many class="nomitech.common.db.local.ExternalQueryAliasTable"
		/// @hibernate.cache usage="nonstrict-read-write"
		/// </summary>
		/// <returns> Set </returns>
		public virtual ISet<ExternalQueryAliasTable> QueryAliasSet
		{
			get
			{
				return queryAliasSet;
			}
			set
			{
				this.queryAliasSet = value;
			}
		}


		public virtual ExternalQueryTable Data
		{
			set
			{
				Title = value.Title;
				Query = value.Query;
				ResourceType = value.ResourceType;
				CreateUserId = value.CreateUserId;
				CreateUserDate = value.CreateUserDate;
				EditorId = value.EditorId;
				LastUpdate = value.LastUpdate;
			}
		}

		public override ExternalQueryTable clone()
		{
			ExternalQueryTable qt = new ExternalQueryTable();
			qt.Id = Id;
			qt.Data = this;
			return qt;
		}

		public virtual ExternalQueryTable deepCopy()
		{
			ExternalQueryTable query = clone();
			query.QueryAliasSet = (new HashSet<ExternalQueryAliasTable>());

			foreach (ExternalQueryAliasTable queryAlias in queryAliasSet)
			{
				query.QueryAliasSet.Add(queryAlias.clone());
			}

			return query;
		}

		public override string ToString()
		{
			return Title;
		}

		public virtual string getToField(string fromAlias)
		{
			if (queryAliasSet == null)
			{
				return null;
			}

			foreach (ExternalQueryAliasTable queryAliasTable in queryAliasSet)
			{
				if (queryAliasTable.FromAlias.Equals(fromAlias))
				{
					return queryAliasTable.ToField;
				}
			}

			return null;
		}

		public virtual bool isQueryColumnId(string fromAlias)
		{
			if (queryAliasSet == null)
			{
				return false;
			}

			foreach (ExternalQueryAliasTable queryAliasTable in queryAliasSet)
			{
				if (queryAliasTable.FromAlias.Equals(fromAlias))
				{
					return queryAliasTable.IsQueryColumnID.Value;
				}
			}

			return false;
		}

		public virtual string getDataMapping(string toField)
		{
			if (queryAliasSet == null)
			{
				return null;
			}

			foreach (ExternalQueryAliasTable queryAliasTable in queryAliasSet)
			{
				string field = queryAliasTable.ToField;
				if (!string.ReferenceEquals(field, null))
				{
					if (field.Equals(toField))
					{
						return queryAliasTable.DataMapping;
					}
				}
			}

			return null;
		}

	}

}