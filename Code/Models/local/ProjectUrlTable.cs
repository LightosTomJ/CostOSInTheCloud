using System;
using System.Collections.Generic;

namespace Models.local
{

	using BaseEntity = nomitech.common.@base.BaseEntity;
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="PROJECTURL"
	/// hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	public class ProjectUrlTable : BaseEntity
	{

		public static readonly string[] FIELDS = new string[] {"url", "defaultRevision", "type", "name", "revision", "editorId", "createUserId", "createDate", "lastUpdate", "underReviewItems", "pendingItems"};

		public const string WHATIF_TYPE = "What-IF";
		public const string SUBPROJECT_TYPE = "SubProject";
		public const string PROJECT_TYPE = "Project";

		private long? projectUrlId;
		private string url;
		private bool? defaultRevision;
		private string type;
		private string name;
		private string revision;
		private string editorId;
		private string createUserId;
		private DateTime createDate;
		private DateTime lastUpdate;
		private string username;
		private string password;
		private string hostname;
		private string port;
		private int? dbms; // 0 IS CEP
		private string dbmsName;
		private string databaseName;
		private int? underReviewItems;
		private int? pendingItems;
		private int? approvedItems;
		private int? completedItems;
		private bool? frozen;
		private string tablePrefix;
		private bool? createsNewDatabases;
		private decimal estimatedItemsTotalCost;
		private decimal quotedItemsTotalCost;
		private decimal markupTotalCost;

		private int? quotesSent;
		private int? quotesReceived;

		private ProjectInfoTable projectInfoTable;
		private ProjectDbmsTable dbmsTable;

		private long? benchmarkId;
		private string description;

		// not used by hibernate:
		private bool? requiresUpdate;

		private ISet<ProjectPropertyTable> propertySet = new HashSet<ProjectPropertyTable>(0);

		public ProjectUrlTable() : base()
		{
		}

		public virtual object clone()
		{
			ProjectUrlTable table = new ProjectUrlTable();

			table.ProjectUrlId = ProjectUrlId;
			table.QuotesSent = QuotesSent;
			table.QuotesReceived = QuotesReceived;

			table.ProjectUrlId = ProjectUrlId;
			table.Url = Url;
			table.DefaultRevision = DefaultRevision;
			table.Name = Name;
			table.Revision = Revision;
			table.Type = Type;
			table.EditorId = EditorId;
			table.LastUpdate = LastUpdate;
			table.CreateUserId = CreateUserId;
			table.CreateDate = CreateDate;

			table.ApprovedItems = ApprovedItems;
			table.CompletedItems = CompletedItems;
			table.UnderReviewItems = UnderReviewItems;
			table.PendingItems = PendingItems;

			table.EstimatedItemsTotalCost = EstimatedItemsTotalCost;
			table.QuotedItemsTotalCost = QuotedItemsTotalCost;
			table.MarkupTotalCost = MarkupTotalCost;
			table.Username = Username;
			table.Password = Password;
			table.Hostname = Hostname;
			table.Port = Port;
			table.DatabaseName = DatabaseName;
			table.TablePrefix = TablePrefix;
			table.CreatesNewDatabases = CreatesNewDatabases;
			table.Dbms = Dbms;
			table.DbmsName = DbmsName;
			table.Frozen = Frozen;
			table.BenchmarkId = BenchmarkId;
			table.Description = Description;

			return table;
		}

		public virtual ProjectUrlTable Data
		{
			set
			{
				ProjectUrlId = value.ProjectUrlId;
				QuotesSent = value.QuotesSent;
				QuotesReceived = value.QuotesReceived;
    
				ProjectUrlId = value.ProjectUrlId;
				Url = value.Url;
				DefaultRevision = value.DefaultRevision;
				Name = value.Name;
				Revision = value.Revision;
				Type = value.Type;
				EditorId = value.EditorId;
				LastUpdate = value.LastUpdate;
				CreateUserId = value.CreateUserId;
				CreateDate = value.CreateDate;
    
				ApprovedItems = value.ApprovedItems;
				CompletedItems = value.CompletedItems;
				UnderReviewItems = value.UnderReviewItems;
				PendingItems = value.PendingItems;
    
				EstimatedItemsTotalCost = value.EstimatedItemsTotalCost;
				QuotedItemsTotalCost = value.QuotedItemsTotalCost;
				MarkupTotalCost = value.MarkupTotalCost;
    
				Username = value.Username;
				Password = value.Password;
				Hostname = value.Hostname;
				Port = value.Port;
				DatabaseName = value.DatabaseName;
				TablePrefix = value.TablePrefix;
				CreatesNewDatabases = value.CreatesNewDatabases;
				Dbms = value.Dbms;
				DbmsName = value.DbmsName;
				Frozen = value.Frozen;
				BenchmarkId = value.BenchmarkId;
				Description = value.Description;
			}
		}

		public virtual ProjectUrlTable copy()
		{
			ProjectUrlTable o = (ProjectUrlTable) clone();

			if (DbmsTable != null)
			{
				o.DbmsTable = (ProjectDbmsTable) DbmsTable.clone();
			}

			return o;
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="PROJECTURLID" </summary>
		/// <returns> Long </returns>
		public virtual long? ProjectUrlId
		{
			get
			{
				return projectUrlId;
			}
			set
			{
				this.projectUrlId = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="URL" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string Url
		{
			get
			{
				return url;
			}
			set
			{
				this.url = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DBUSR" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string Username
		{
			get
			{
				return username;
			}
			set
			{
				this.username = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DBPSWD" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string Password
		{
			get
			{
				return password;
			}
			set
			{
				this.password = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DBHOST" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string Hostname
		{
			get
			{
				return hostname;
			}
			set
			{
				this.hostname = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DBPORT" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string Port
		{
			get
			{
				return port;
			}
			set
			{
				this.port = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DBPREFIX" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string TablePrefix
		{
			get
			{
				return tablePrefix;
			}
			set
			{
				this.tablePrefix = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DBSINGLE" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? CreatesNewDatabases
		{
			get
			{
				return createsNewDatabases;
			}
			set
			{
				this.createsNewDatabases = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DBNAME" type="costos_string" </summary>
		/// <returns> code </returns>
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
		/// @hibernate.property column="DBSRV" type="int" </summary>
		/// <returns> code </returns>
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
		/// @hibernate.property column="DBSRVNAME" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string DbmsName
		{
			get
			{
				return dbmsName;
			}
			set
			{
				this.dbmsName = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="QSENT" type="int" </summary>
		/// <returns> code </returns>
		public virtual int? QuotesSent
		{
			get
			{
				return quotesSent;
			}
			set
			{
				this.quotesSent = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="QRECV" type="int" </summary>
		/// <returns> code </returns>
		public virtual int? QuotesReceived
		{
			get
			{
				return quotesReceived;
			}
			set
			{
				this.quotesReceived = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DEFREV" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? DefaultRevision
		{
			get
			{
				return defaultRevision;
			}
			set
			{
				this.defaultRevision = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EDITORID" type="costos_string" </summary>
		/// <returns> code </returns>
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
		/// @hibernate.property column="TYPE" type="costos_string" </summary>
		/// <returns> code </returns>
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
		/// @hibernate.property column="NAME" type="costos_string" </summary>
		/// <returns> code </returns>
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
		/// @hibernate.property column="RVSON" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string Revision
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
		/// @hibernate.property column="CREUSERID" type="costos_string" </summary>
		/// <returns> code </returns>
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
		/// <returns> code </returns>
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
		/// <returns> code </returns>
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
		/// @hibernate.property column="UNDERREVIEW" type="int" </summary>
		/// <returns> underReviewItems </returns>
		public virtual int? UnderReviewItems
		{
			get
			{
				return underReviewItems;
			}
			set
			{
				this.underReviewItems = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PENDING" type="int" </summary>
		/// <returns> underReviewItems </returns>
		public virtual int? PendingItems
		{
			get
			{
				return pendingItems;
			}
			set
			{
				this.pendingItems = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="APPROVED" type="int" </summary>
		/// <returns> underReviewItems </returns>
		public virtual int? ApprovedItems
		{
			get
			{
				return approvedItems;
			}
			set
			{
				this.approvedItems = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COMPLETED" type="int" </summary>
		/// <returns> underReviewItems </returns>
		public virtual int? CompletedItems
		{
			get
			{
				return completedItems;
			}
			set
			{
				this.completedItems = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ESTTOTAL" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> underReviewItems </returns>
		public virtual decimal EstimatedItemsTotalCost
		{
			get
			{
				return estimatedItemsTotalCost;
			}
			set
			{
				this.estimatedItemsTotalCost = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="QUOTEDTOTAL" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> underReviewItems </returns>
		public virtual decimal QuotedItemsTotalCost
		{
			get
			{
				return quotedItemsTotalCost;
			}
			set
			{
				this.quotedItemsTotalCost = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="MARKUPTOTAL" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> underReviewItems </returns>
		public virtual decimal MarkupTotalCost
		{
			get
			{
				return markupTotalCost;
			}
			set
			{
				this.markupTotalCost = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="MUSTRECALC" type="boolean" </summary>
		/// <returns> underReviewItems </returns>
		public virtual bool? RequiresUpdate
		{
			get
			{
				return requiresUpdate;
			}
			set
			{
				this.requiresUpdate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FROZEN" type="boolean" </summary>
		/// <returns> underReviewItems </returns>
		public virtual bool? Frozen
		{
			get
			{
				return frozen;
			}
			set
			{
				this.frozen = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="BENCHMARKID" type="long" </summary>
		/// <returns> underReviewItems </returns>
		public virtual long? BenchmarkId
		{
			get
			{
				return benchmarkId;
			}
			set
			{
				this.benchmarkId = value;
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


		public virtual decimal calculateTotalCost()
		{
			return EstimatedItemsTotalCost + QuotedItemsTotalCost;
		}

		public virtual decimal calculateOfferedPrice()
		{
			return calculateTotalCost() + MarkupTotalCost;
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="PROJECTINFOID"
		///  cascade="none" </summary>
		/// <returns> ProjectInfoTable </returns>
		public virtual ProjectInfoTable ProjectInfoTable
		{
			get
			{
				return projectInfoTable;
			}
			set
			{
				this.projectInfoTable = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="PROJECTDBMSID" </summary>
		/// <returns> ProjectDbmsTable </returns>
		public virtual ProjectDbmsTable DbmsTable
		{
			get
			{
				return dbmsTable;
			}
			set
			{
				this.dbmsTable = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="false"
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="PROJECTURLID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ProjectPropertyTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<ProjectPropertyTable> PropertySet
		{
			get
			{
				return propertySet;
			}
			set
			{
				this.propertySet = value;
			}
		}


		public virtual ProjectUrlTable copyWithProject()
		{
			ProjectUrlTable urlTable = (ProjectUrlTable)copy();

			if (ProjectInfoTable != null)
			{
				urlTable.ProjectInfoTable = (ProjectInfoTable)ProjectInfoTable.clone();
			}

			return urlTable;
		}

		public override long? Id
		{
			get
			{
				return ProjectUrlId;
			}
		}

		public override string ToString()
		{
			return Name;
		}
	}

}