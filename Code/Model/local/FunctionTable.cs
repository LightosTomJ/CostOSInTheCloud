using System;
using System.Collections.Generic;

namespace Model.local
{

	using BaseTable = Desktop.common.nomitech.common.@base.BaseTable;
	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;

	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;

	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="FNCTON"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class FunctionTable implements java.io.Serializable, nomitech.common.base.BaseTable, nomitech.common.base.ProjectIdEntity
	[Serializable]
	public class FunctionTable : BaseTable, ProjectIdEntity
	{

		public const string EXPR_LANGUAGE = "EXPR";
		public const string JS_LANGUAGE = "JS";

		public static readonly string[] FIELDS = new string[]{"functionId", "name", "description", "implementation", "lastUpdate", "createDate", "createUserId", "editorId", "grouping", "takeoff", "unit", "resultType"};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> id;
		private long? id;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String name;
		private string name;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String description;
		private string description;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String implementation;
		private string implementation;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date lastUpdate;
		private DateTime lastUpdate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date createDate;
		private DateTime createDate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String createUserId;
		private string createUserId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String editorId;
		private string editorId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String grouping;
		private string grouping;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private System.Nullable<bool> takeoff;
		private bool? takeoff;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String unit;
		private string unit;
		private string language;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String resultType;
		private string resultType;

		private string password;
		private string serialNumber;
		private string protectionType;

		private IList<FunctionArgumentTable> functionArgumentList;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="FUNCTIONID" </summary>
		/// <returns> Long </returns>
		public virtual long? FunctionId
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
		/// @hibernate.property column="LASTUPDATE" type="timestamp" </summary>
		/// <returns> lastUpdate </returns>
		public virtual DateTime LastUpdate
		{
			get
			{
				return lastUpdate;
			}
			set
			{
				lastUpdate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="TAKEOFF" type="boolean" </summary>
		/// <returns> lastUpdate </returns>
		public virtual bool? Takeoff
		{
			get
			{
				return takeoff;
			}
			set
			{
				this.takeoff = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CREATEUSERID" type="costos_string" </summary>
		/// <returns> lastUpdate </returns>
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
		/// <returns> lastUpdate </returns>
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
		/// @hibernate.property column="CREATEDATE" type="timestamp" </summary>
		/// <returns> lastUpdate </returns>
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
		/// @hibernate.property column="NAME" type="costos_string" index="IDX_FNAME" </summary>
		/// <returns> Returns the filterName. </returns>
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
		/// @hibernate.property column="UNIT" type="costos_string" </summary>
		/// <returns> Returns the UNIT. </returns>
		public virtual string Unit
		{
			get
			{
				return unit;
			}
			set
			{
				this.unit = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="GROUPING" type="costos_string" </summary>
		/// <returns> Returns the filterName. </returns>
		public virtual string Grouping
		{
			get
			{
				return grouping;
			}
			set
			{
				this.grouping = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DESCRIPTION" type="costos_text" </summary>
		/// <returns> Returns the filterName. </returns>
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
		/// @hibernate.property column="LANG" type="costos_string" </summary>
		/// <returns> Returns the language. </returns>
		public virtual string Language
		{
			get
			{
				return language;
			}
			set
			{
				this.language = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PSWD" type="nomitech.common.db.types.NotNullPasswordType" </summary>
		/// <returns> editorId </returns>
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
		/// @hibernate.property column="SNUM" type="nomitech.common.db.types.NotNullBigPasswordType" </summary>
		/// <returns> editorId </returns>
		public virtual string SerialNumber
		{
			get
			{
				return serialNumber;
			}
			set
			{
				this.serialNumber = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="PRTTYPE" type="nomitech.common.db.types.NotNullPasswordType" </summary>
		/// <returns> editorId </returns>
		public virtual string ProtectionType
		{
			get
			{
				return protectionType;
			}
			set
			{
				this.protectionType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="IMPL" type="costos_text" </summary>
		/// <returns> Returns the filterName. </returns>
		public virtual string Implementation
		{
			get
			{
				return implementation;
			}
			set
			{
				this.implementation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RESTYPE" type="costos_string" </summary>
		/// <returns> Returns the filterName. </returns>
		public virtual string ResultType
		{
			get
			{
				return resultType;
			}
			set
			{
				this.resultType = value;
			}
		}

		/// <summary>
		/// @hibernate.list  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="FID"
		/// @hibernate.list-index
		///  column="VARSCOUNT"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.FunctionArgumentTable"
		/// return List
		/// </summary>
		public virtual IList<FunctionArgumentTable> FunctionArgumentList
		{
			get
			{
				return functionArgumentList;
			}
			set
			{
				this.functionArgumentList = value;
			}
		}

		public virtual object Clone()
		{
			FunctionTable fTable = new FunctionTable();

			fTable.FunctionId = FunctionId;
			fTable.CreateDate = CreateDate;
			fTable.CreateUserId = CreateUserId;
			fTable.Description = Description;
			fTable.Language = Language;
			fTable.EditorId = EditorId;
			fTable.Implementation = Implementation;
			fTable.LastUpdate = LastUpdate;
			fTable.Name = Name;
			fTable.Grouping = Grouping;
			fTable.Takeoff = Takeoff;
			fTable.ResultType = ResultType;
			fTable.Unit = Unit;
			fTable.SerialNumber = SerialNumber;
			fTable.Password = Password;
			fTable.ProtectionType = ProtectionType;
			fTable.ProjectId = ProjectId;

			return fTable;
		}

		public virtual FunctionTable copyWithVariables()
		{
			return copyWithVariables(false);
		}

		public virtual FunctionTable copyWithVariables(bool resetIds)
		{
			FunctionTable fTable = (FunctionTable)Clone();

			if (resetIds)
			{
				fTable.FunctionId = null;
			}

			fTable.functionArgumentList = new List<FunctionArgumentTable>();

			if (FunctionArgumentList != null)
			{

				IEnumerator<FunctionArgumentTable> iter = FunctionArgumentList.GetEnumerator();
				while (iter.MoveNext())
				{
					FunctionArgumentTable arg = (FunctionArgumentTable)iter.Current.clone();
					if (resetIds)
					{
						arg.Id = null;
					}
					fTable.functionArgumentList.Add(arg);
				}
			}

			return fTable;
		}

		public virtual FunctionTable Data
		{
			set
			{
				CreateDate = value.CreateDate;
				CreateUserId = value.CreateUserId;
				Description = value.Description;
				EditorId = value.EditorId;
				Implementation = value.Implementation;
				LastUpdate = value.LastUpdate;
				Name = value.Name;
				Grouping = value.Grouping;
				Takeoff = value.Takeoff;
				ResultType = value.ResultType;
				Unit = value.Unit;
				Language = value.Language;
				SerialNumber = value.SerialNumber;
				Password = value.Password;
				ProtectionType = value.ProtectionType;
			}
		}

		public override long? Id
		{
			get
			{
				return FunctionId;
			}
		}

		public override string Title
		{
			get
			{
				return Name;
			}
			set
			{
				Name = value;
			}
		}


		public override decimal TableRate
		{
			get
			{
				return null;
			}
		}

		public virtual bool WriteProtected
		{
			get
			{
				return string.ReferenceEquals(ProtectionType, null) || !ProtectionType.Equals(ParamItemTable.PROTECT_NONE);
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