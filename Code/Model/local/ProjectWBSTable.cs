using System;

namespace Model.local
{

	using BaseTable = Desktop.common.nomitech.common.@base.BaseTable;
	using GroupCode = Desktop.common.nomitech.common.@base.GroupCode;
	using ItemCode = Desktop.common.nomitech.common.@base.ItemCode;
	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;

	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using IndexedEmbedded = org.hibernate.search.annotations.IndexedEmbedded;
	using Store = org.hibernate.search.annotations.Store;

	//#RXL_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="PROJECTWBS"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class ProjectWBSTable implements nomitech.common.base.GroupCode, nomitech.common.base.ItemCode, java.awt.datatransfer.Transferable, nomitech.common.base.ProjectIdEntity, java.io.Serializable, nomitech.common.base.BaseTable
	[Serializable]
	public class ProjectWBSTable : GroupCode, ItemCode, Transferable, ProjectIdEntity, BaseTable
	{

		public static readonly string[] FIELDS = new string[] {"projectWBSId", "groupCode", "itemCode", "title", "unit", "unitFactor", "quantity", "editorId", "description", "lastUpdate"};


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> projectWBSId = null;
		private long? projectWBSId = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String groupCode = null;
		private string groupCode = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String title = null;
		private string title = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String editorId = null;
		private string editorId = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String description = null;
		private string description = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date lastUpdate = null;
		private DateTime lastUpdate = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String unit = null;
		private string unit = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal unitFactor = null;
		private decimal unitFactor = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String itemCode;
		private string itemCode;
		private decimal quantity;

		//OneToOne( cascade = { CascadeType.PERSIST, CascadeType.REMOVE } )
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @IndexedEmbedded private ProjectInfoTable projectInfoTable = null;
		private ProjectInfoTable projectInfoTable = null;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String projectName = null;
		private string projectName = null;

		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.projectWBSDataFlavor};

		public ProjectWBSTable()
		{
		}

	//	public boolean equals(Object val) {
	//		if ( !(val instanceof ProjectWBSTable) ) {
	//			return false;
	//		}
	//		final String lastUpdate = "lastUpdate";
	//		ProjectWBSTable group = (ProjectWBSTable)val;
	//		Iterator iter = group.o_map.keySet().iterator();
	//		while ( iter.hasNext() ) {
	//			String key = (String)iter.next();
	//			if ( key.equals(lastUpdate) )
	//				continue;
	//			else if ( !group.o_map.get(key).equals(o_map.get(key)) ) {
	//				return false;
	//			}
	//		}
	//		return true;
	//	}

		public virtual object Clone()
		{
			ProjectWBSTable obj = new ProjectWBSTable();

			obj.ProjectWBSId = ProjectWBSId;
			obj.LastUpdate = LastUpdate;
			obj.Description = Description;
			obj.GroupCode = GroupCode;
			obj.ItemCode = ItemCode;
			obj.Title = Title;
			obj.Unit = Unit;
			obj.Quantity = Quantity;
			obj.UnitFactor = UnitFactor;
			obj.EditorId = EditorId;
			obj.ProjectId = ProjectId;

			return obj;
		}

		public virtual ProjectWBSTable Data
		{
			set
			{
				//setConsumableId(value.getConsumableId());
				LastUpdate = value.LastUpdate;
				Description = value.Description;
				GroupCode = value.GroupCode;
				ItemCode = value.ItemCode;
				Title = value.Title;
				EditorId = value.EditorId;
				Quantity = value.Quantity;
				Unit = value.Unit;
				UnitFactor = value.UnitFactor;
			}
		}



		// only for writeable fields!
	//	public void setFieldData(String field, ProjectWBSTable data) {
	//		if ( field.equals("title") ) {
	//			setTitle(data.getTitle());			
	//		}		
	//		else if ( field.equals("description") ) {
	//			setDescription(data.getDescription());		
	//		}				
	//	}

		public virtual long? Id
		{
			get
			{
				return projectWBSId;
			}
		}


		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="PROJECTWBSID" </summary>
		/// <returns> Long </returns>
		public virtual long? ProjectWBSId
		{
			get
			{
				return projectWBSId;
			}
			set
			{
				projectWBSId = value;
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
				lastUpdate = value;
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
				description = value;
			}
		}
		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CODE" type="costos_string" index="IDX_GROUPCODE" </summary>
		/// <returns> code </returns>
		public virtual string GroupCode
		{
			get
			{
				return groupCode;
			}
			set
			{
				groupCode = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ITEMCODE" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string ItemCode
		{
			get
			{
				return itemCode;
			}
			set
			{
				this.itemCode = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TITLE" type="costos_text" </summary>
		/// <returns> code </returns>
		public virtual string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
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
				editorId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="UFACT" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> quantity </returns>
		public virtual decimal UnitFactor
		{
			get
			{
				return unitFactor;
			}
			set
			{
				this.unitFactor = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="UNIT" type="costos_string" </summary>
		/// <returns> editorId </returns>
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


		public override string ToString()
		{
			return GroupCode + " - " + Title;
		}

		/// <summary>
		/// @hibernate.property column="QUANTITY" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> quantity </returns>
		public virtual decimal Quantity
		{
			get
			{
				return quantity;
			}
			set
			{
				this.quantity = value;
			}
		}


		//#RXP_START
		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PROJECTNAME" type="costos_string" </summary>
		/// <returns> name </returns>
		//#RXP_END
		public virtual string ProjectName
		{
			get
			{
				if (projectInfoTable != null)
				{
					projectName = projectInfoTable.Code;
				}
				if (string.ReferenceEquals(projectName, null))
				{
					projectName = "-";
				}
    
				return projectName;
			}
			set
			{
				this.projectName = value;
			}
		}


		//#RXP_START
		/// <summary>
		/// @hibernate.many-to-one
		///  column="PROJECTINFOID"
		///  cascade="none" </summary>
		/// <returns> ProjectInfoTable </returns>
		//#RXP_END
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

		public virtual DataFlavor[] TransferDataFlavors
		{
			get
			{
				lock (this)
				{
					return s_supportedDataFlavors;
				}
			}
		}

		public virtual bool isDataFlavorSupported(DataFlavor flavor)
		{
			return DataFlavors.projectWBSDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.projectWBSDataFlavor.Equals(flavor))
				{
					return this;
				}
        
				throw new UnsupportedFlavorException(flavor);
			}
		}

		public override int compareTo(GroupCode o)
		{
			return groupCode.CompareTo(o.GroupCode);
		}

		/////////////////////////////////////////////////////
		// SORTING FIELDS                                  //
		/////////////////////////////////////////////////////
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getGroupCode_sorted()
		public virtual string GroupCode_sorted
		{
			get
			{
				return groupCode;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getTitle_sorted()
		public virtual string Title_sorted
		{
			get
			{
				return title;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getEditorId_sorted()
		public virtual string EditorId_sorted
		{
			get
			{
				return editorId;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getDescription_sorted()
		public virtual string Description_sorted
		{
			get
			{
				return description;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.util.Date getLastUpdate_sorted()
		public virtual DateTime LastUpdate_sorted
		{
			get
			{
				return lastUpdate;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getUnit_sorted()
		public virtual string Unit_sorted
		{
			get
			{
				return unit;
			}
		}
		public override decimal TableRate
		{
			get
			{
				return null;
			}
		}

		public override string CreateUserId
		{
			get
			{
				return EditorId;
			}
			set
			{
    
			}
		}

		public override DateTime CreateDate
		{
			get
			{
				return LastUpdate;
			}
			set
			{
    
			}
		}



		public override GroupCode Data
		{
			set
			{
				Data = (ProjectWBSTable)value;
			}
		}

		public override void setFieldData(string field, GroupCode groupCodeTable)
		{
			setFieldData(field,(ProjectWBSTable)groupCodeTable);
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