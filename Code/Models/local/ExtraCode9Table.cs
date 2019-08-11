using System;

namespace Models.local
{

	using BaseTable = nomitech.common.@base.BaseTable;
	using GroupCode = nomitech.common.@base.GroupCode;

	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;

	//#RXP_START
	//#RXL_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="EXTRACODE9"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	//#RXL_END
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class ExtraCode9Table implements nomitech.common.base.GroupCode, java.awt.datatransfer.Transferable, java.io.Serializable, nomitech.common.base.BaseTable
	[Serializable]
	public class ExtraCode9Table : GroupCode, Transferable, BaseTable
	{

		public static readonly string[] FIELDS = new string[] {"extraCode9Id", "groupCode", "title", "unit", "unitFactor", "editorId", "notes", "description", "lastUpdate"};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> extraCode9Id = null;
		private long? extraCode9Id = null;
		private string extraCode9 = null;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String notes = null;
		private string notes = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date lastUpdate = null;
		private DateTime lastUpdate = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String unit = null;
		private string unit = null;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.math.BigDecimal unitFactor = null;
		private decimal unitFactor = null;

		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.extraCode9DataFlavor};

		public ExtraCode9Table()
		{
		}

	//	public boolean equals(Object val) {
	//		if ( !(val instanceof ExtraCode9Table) ) {
	//			return false;
	//		}
	//		final String lastUpdate = "lastUpdate";
	//		ExtraCode9Table group = (ExtraCode9Table)val;
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

		public virtual object clone()
		{
			ExtraCode9Table obj = new ExtraCode9Table();

			obj.ExtraCode9Id = ExtraCode9Id;
			obj.LastUpdate = LastUpdate;
			obj.Description = Description;
			obj.GroupCode = GroupCode;
			obj.Title = Title;
			obj.Notes = Notes;
			obj.EditorId = EditorId;
			obj.Unit = Unit;
			obj.UnitFactor = UnitFactor;

			return obj;
		}

		public virtual ExtraCode9Table Data
		{
			set
			{
				//setConsumableId(value.getConsumableId());
				LastUpdate = value.LastUpdate;
				Description = value.Description;
				GroupCode = value.GroupCode;
				Title = value.Title;
				Notes = value.Notes;
				EditorId = value.EditorId;
				Unit = value.Unit;
				UnitFactor = value.UnitFactor;
			}
		}

		// only for writeable fields!
		public virtual void setFieldData(string field, ExtraCode9Table data)
		{
			if (field.Equals("title"))
			{
				Title = data.Title;
			}
			else if (field.Equals("groupCode"))
			{
				GroupCode = data.GroupCode;
			}
			else if (field.Equals("unit"))
			{
				Unit = data.Unit;
			}
			else if (field.Equals("unitFactor"))
			{
				UnitFactor = data.UnitFactor;
			}
			else if (field.Equals("notes"))
			{
				Notes = data.Notes;
			}
			else if (field.Equals("description"))
			{
				Description = data.Description;
			}
		}

		public virtual long? Id
		{
			get
			{
				return extraCode9Id;
			}
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="GROUPCODEID" </summary>
		/// <returns> Long </returns>
		public virtual long? ExtraCode9Id
		{
			get
			{
				return extraCode9Id;
			}
			set
			{
				extraCode9Id = value;
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
		/// @hibernate.property column="GROUPCODE" type="costos_string" index="IDX_GROUPCODE" </summary>
		/// <returns> unit </returns>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) public String getGroupCode()
		public virtual string GroupCode
		{
			get
			{
				return extraCode9;
			}
			set
			{
				extraCode9 = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TITLE" type="costos_text" </summary>
		/// <returns> extraCode9 </returns>
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
		/// @hibernate.property column="NOTES" type="costos_string" </summary>
		/// <returns> extraCode9 </returns>
		public virtual string Notes
		{
			get
			{
				return notes;
			}
			set
			{
				notes = value;
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
			return DataFlavors.extraCode9DataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.extraCode9DataFlavor.Equals(flavor))
				{
					return this;
				}
        
				throw new UnsupportedFlavorException(flavor);
			}
		}

		public override int compareTo(GroupCode o)
		{
			return extraCode9.CompareTo(o.GroupCode);
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
				return extraCode9;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getNotes_sorted()
		public virtual string Notes_sorted
		{
			get
			{
				return notes;
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
				Data = (ExtraCode9Table)value;
			}
		}

		public override void setFieldData(string field, GroupCode groupCodeTable)
		{
			setFieldData(field,(ExtraCode9Table)groupCodeTable);
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