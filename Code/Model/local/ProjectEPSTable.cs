using System;
using System.Collections.Generic;

namespace Model.local
{

	using GroupCode = Desktop.common.nomitech.common.@base.GroupCode;
	using BigDecimalMath = Desktop.common.nomitech.common.util.BigDecimalMath;

	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="PROJECTEPS"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class ProjectEPSTable implements nomitech.common.base.GroupCode, java.io.Serializable
	[Serializable]
	public class ProjectEPSTable : GroupCode
	{

		public static readonly string[] FIELDS = new string[] {"projectEPSId", "groupCode", "title", "unit", "unitFactor", "editorId", "notes", "description", "lastUpdate"};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> projectEPSId = null;
		private long? projectEPSId = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String code = null;
		private string code = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String title = null;
		private string title = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String editorId = null;
		private string editorId = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String description = null;
		private string description = null;

		private DateTime lastUpdate = null;

		private ISet<ProjectInfoTable> projects;
		private long? parentId;

		public ProjectEPSTable()
		{
			//if ( DatabaseDBUtil.getProperties() != null )
				//setEditorId(DatabaseDBUtil.getProperties().getUserId());
		}

		public virtual object Clone()
		{
			ProjectEPSTable obj = new ProjectEPSTable();

			obj.ProjectEPSId = ProjectEPSId;
			obj.LastUpdate = LastUpdate;
			obj.Description = Description;
			obj.Code = Code;
			obj.Title = Title;
			obj.EditorId = EditorId;

			return obj;
		}

		public virtual ProjectEPSTable Data
		{
			set
			{
    
				LastUpdate = value.LastUpdate;
				Description = value.Description;
				Code = value.Code;
				Title = value.Title;
				EditorId = value.EditorId;
			}
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="PROJECTEPSID" </summary>
		/// <returns> Long </returns>
		public virtual long? ProjectEPSId
		{
			get
			{
				return projectEPSId;
			}
			set
			{
				this.projectEPSId = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CODE" type="costos_string" index="IDX_CODE" </summary>
		/// <returns> code </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="TITLE" type="costos_string" </summary>
		/// <returns> editorId </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="EDITORID" type="costos_string" </summary>
		/// <returns> editorId </returns>
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


		/// <summary>
		/// Description Here
		/// 
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
				this.lastUpdate = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="false"
		///  cascade="delete"
		/// @hibernate.key
		///  column="PROJECTEPSID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.ProjectInfoTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<ProjectInfoTable> Projects
		{
			get
			{
				return projects;
			}
			set
			{
				this.projects = value;
			}
		}


		public virtual ProjectEPSTable copyWithProjects()
		{
			ProjectEPSTable epsTable = (ProjectEPSTable)Clone();

			ISet<ProjectInfoTable> set = Projects;
			if (set != null)
			{
				IEnumerator<ProjectInfoTable> iter = set.GetEnumerator();
				set = new HashSet<ProjectInfoTable>();
				while (iter.MoveNext())
				{
					set.Add((ProjectInfoTable) iter.Current.Clone());
				}
				epsTable.Projects = set;
			}
			return epsTable;
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PARENTID" type="long" </summary>
		/// <returns> Long </returns>
		public virtual long? ParentId
		{
			get
			{
				return parentId;
			}
			set
			{
				this.parentId = value;
			}
		}


		public override string ToString()
		{
			return Code + " - " + Title;
		}

		public override int compareTo(GroupCode o)
		{
			return code.CompareTo(o.GroupCode);
		}

		public override string GroupCode
		{
			get
			{
				return Code;
			}
			set
			{
				Code = value;
			}
		}

		public override long? Id
		{
			get
			{
				return ProjectEPSId;
			}
		}

		public override string CreateUserId
		{
			get
			{
				return null;
			}
			set
			{
    
			}
		}

		public override DateTime CreateDate
		{
			get
			{
				return null;
			}
			set
			{
    
			}
		}



		public override decimal TableRate
		{
			get
			{
				return null;
			}
		}

		public override GroupCode Data
		{
			set
			{
				Data = (ProjectEPSTable)value;
			}
		}

		public override void setFieldData(string field, GroupCode groupCodeTable)
		{
			setFieldData(field,(ProjectEPSTable)groupCodeTable);
		}

		public override string Notes
		{
			get
			{
				// TODO Auto-generated method stub
				return null;
			}
			set
			{
				// TODO Auto-generated method stub
    
			}
		}



		public override string Unit
		{
			set
			{
    
			}
			get
			{
				return null;
			}
		}


		public override decimal UnitFactor
		{
			get
			{
				return BigDecimalMath.ONE;
			}
			set
			{
    
			}
		}


		public override decimal Quantity
		{
			get
			{
				// TODO Auto-generated method stub
				return null;
			}
		}
	}

}