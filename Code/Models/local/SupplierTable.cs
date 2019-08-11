using System;
using System.Collections.Generic;

namespace Models.local
{


	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using ResourceWithAssignmentsTable = nomitech.common.@base.ResourceWithAssignmentsTable;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="SUPPLIER" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class SupplierTable extends nomitech.common.base.ResourceWithAssignmentsTable implements nomitech.common.base.ProjectIdEntity, java.awt.datatransfer.Transferable, java.io.Serializable
	[Serializable]
	public class SupplierTable : ResourceWithAssignmentsTable, ProjectIdEntity, Transferable
	{
		/*
		public static final String[] FIELDS = new String[] {
			"title",
			"supplierId",
			"geoLocation",
			"contactPerson",
			"groupCode",
			"gekCode",
			"editorId",
			"performance",
			"phoneNumber",
			"mobileNumber",
			"faxNumber",
			"email",
			"url",		
			"address",
			"city",
			"stateProvince",
			"country",
			"notes",
			"description",
			"lastUpdate",
			"extraCode1",
			"extraCode2",
			"extraCode3",
			"extraCode4",
			"extraCode5",
			"extraCode6",
			"extraCode7",
		};
		 */
		public static readonly string[] VIEWABLE_FIELDS = new string[] {"supplierId", "itemCode", "title", "geoLocation", "contactPerson", "performance", "phoneNumber", "mobileNumber", "faxNumber", "email", "url", "address", "city", "stateProvince", "country", "notes", "description", "editorId", "lastUpdate", "createUserId", "createDate", "groupCode", "gekCode", "extraCode1", "extraCode2", "extraCode3", "extraCode4", "extraCode5", "extraCode6", "extraCode7"};

		public static readonly Type[] CLASSES = new Type[] {typeof(Long), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string)};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> supplierId;
		private long? supplierId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String title;
		private string title;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String description;
		private string description;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String contactPerson;
		private string contactPerson;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String phoneNumber;
		private string phoneNumber;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String mobileNumber;
		private string mobileNumber;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String faxNumber;
		private string faxNumber;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String email;
		private string email;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String city;
		private string city;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String address;
		private string address;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String notes;
		private string notes;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String editorId;
		private string editorId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String stateProvince;
		private string stateProvince;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String groupCode;
		private string groupCode;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String gekCode;
		private string gekCode;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String url;
		private string url;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String performance;
		private string performance;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String country;
		private string country;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date lastUpdate;
		private DateTime lastUpdate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String createUserId;
		private string createUserId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String geoLocation;
		private string geoLocation;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private java.util.Date createDate;
		private DateTime createDate;

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode1;
		private string extraCode1;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode2;
		private string extraCode2;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode3;
		private string extraCode3;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode4;
		private string extraCode4;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode5;
		private string extraCode5;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode6;
		private string extraCode6;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode7;
		private string extraCode7;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode8 = "";
		private string extraCode8 = "";
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode9 = "";
		private string extraCode9 = "";
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String extraCode10 = "";
		private string extraCode10 = "";

		private string itemCode;

		//	@ContainedIn
		//	@OneToOne(mappedBy="supplierTable")
		private ISet<MaterialTable> materialSet = new HashSet<MaterialTable>(0);

		private static readonly DataFlavor[] s_supportedDataFlavors = new DataFlavor[] {DataFlavors.supplierDataFlavor};

		public SupplierTable()
		{
		}

		public virtual object valueForField(string field)
		{
			return null;
		}

		public virtual object scaledValueForField(string field)
		{
			return null;
		}

		public virtual object clone()
		{
			SupplierTable obj = new SupplierTable();

			obj.Address = Address;
			obj.ItemCode = ItemCode;
			obj.Title = Title;
			obj.GeoLocation = GeoLocation;
			obj.ContactPerson = ContactPerson;
			obj.SupplierId = SupplierId;
			obj.Description = Description;
			obj.LastUpdate = LastUpdate;
			obj.Notes = Notes;
			obj.GroupCode = GroupCode;
			obj.GekCode = GekCode;
			obj.EditorId = EditorId;
			obj.Performance = Performance;
			obj.PhoneNumber = PhoneNumber;
			obj.FaxNumber = FaxNumber;
			obj.MobileNumber = MobileNumber;
			obj.Email = Email;
			obj.Country = Country;
			obj.City = City;
			obj.Url = Url;
			obj.StateProvince = StateProvince;
			obj.DatabaseId = DatabaseId;
			obj.DatabaseCreationDate = DatabaseCreationDate;
			obj.CreateDate = CreateDate;
			obj.CreateUserId = CreateUserId;

			obj.ExtraCode1 = ExtraCode1;
			obj.ExtraCode2 = ExtraCode2;
			obj.ExtraCode3 = ExtraCode3;
			obj.ExtraCode4 = ExtraCode4;
			obj.ExtraCode5 = ExtraCode5;
			obj.ExtraCode6 = ExtraCode6;
			obj.ExtraCode7 = ExtraCode7;
			obj.ExtraCode8 = ExtraCode8;
			obj.ExtraCode9 = ExtraCode9;
			obj.ExtraCode10 = ExtraCode10;

			obj.ProjectId = ProjectId;

			//if ( getMaterialSet() != null ) {
			//	obj.materialSet = new Vector(materialSet.size());
			//	Iterator iter = materialSet.iterator();
			//	while ( iter.hasNext() ) {
			//		MaterialTable curMat = (MaterialTable)iter.next();
			//		obj.materialSet.add(curMat.clone());
			//	}			
			//}

			return (object)obj;
		}

		public virtual SupplierTable conversionClone(bool demo)
		{
			SupplierTable supplierTable = (SupplierTable)clone();
			if (demo)
			{
				supplierTable.Description = "";
				supplierTable.Email = "info@nomitech.eu";
				supplierTable.Url = "www.nomitech.eu";
				supplierTable.PhoneNumber = "";
				supplierTable.FaxNumber = "";
				supplierTable.MobileNumber = "";
			}

			return supplierTable;
		}

		public virtual SupplierTable copyWithMaterials()
		{
			SupplierTable obj = (SupplierTable)clone();

			if (MaterialSet != null)
			{
				obj.materialSet = new HashSet<object>();
				System.Collections.IEnumerator iter = materialSet.GetEnumerator();
				while (iter.MoveNext())
				{
					MaterialTable curMat = (MaterialTable)iter.Current;
					obj.materialSet.Add((MaterialTable)curMat.clone());
				}
			}

			return obj;
		}

		public virtual SupplierTable Data
		{
			set
			{
				Address = value.Address;
				ItemCode = value.ItemCode;
				Title = value.Title;
				ContactPerson = value.ContactPerson;
				//setSupplierId(value.getSupplierId());
				Description = value.Description;
				LastUpdate = value.LastUpdate;
				Notes = value.Notes;
				GroupCode = value.GroupCode;
				GekCode = value.GekCode;
				Performance = value.Performance;
				PhoneNumber = value.PhoneNumber;
				FaxNumber = value.FaxNumber;
				MobileNumber = value.MobileNumber;
				Email = value.Email;
				Country = value.Country;
				City = value.City;
				StateProvince = value.StateProvince;
				EditorId = value.EditorId;
				Url = value.Url;
				GeoLocation = value.GeoLocation;
				//setDatabaseId(value.getDatabaseId());
				//setDatabaseCreationDate(value.getDatabaseCreationDate());
				ExtraCode1 = value.ExtraCode1;
				ExtraCode2 = value.ExtraCode2;
				ExtraCode3 = value.ExtraCode3;
				ExtraCode4 = value.ExtraCode4;
				ExtraCode5 = value.ExtraCode5;
				ExtraCode6 = value.ExtraCode6;
				ExtraCode7 = value.ExtraCode7;
				ExtraCode8 = value.ExtraCode8;
				ExtraCode9 = value.ExtraCode9;
				ExtraCode10 = value.ExtraCode10;
    
				if (value.CreateDate != null)
				{
					CreateDate = value.CreateDate;
					CreateUserId = value.CreateUserId;
				}
			}
		}

		// only for writeable fields!
		public virtual void setFieldData(string field, SupplierTable data)
		{

		}

		public virtual long? Id
		{
			get
			{
				return supplierId;
			}
			set
			{
				SupplierId = value;
			}
		}


		/// <summary>
		/// @hibernate.id column="ID"
		///               generator-class="native" 
		///               unsaved-value="null"
		///               column="SUPPLIERID" </summary>
		/// <returns> Long </returns>
		public virtual long? SupplierId
		{
			get
			{
				return supplierId;
			}
			set
			{
				supplierId = value;
			}
		}


		/// <summary>
		/// description of the supplier
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
		/// group code
		/// 
		/// @hibernate.property column="GROUPCODE" type="costos_string" </summary>
		/// <returns> groupCode </returns>
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
		/// @hibernate.property column="GEKCODE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string GekCode
		{
			get
			{
				return gekCode;
			}
			set
			{
				this.gekCode = value;
			}
		}


		/// <summary>
		/// group code
		/// 
		/// @hibernate.property column="PERFORMANCE" type="costos_string" </summary>
		/// <returns> performance </returns>
		public virtual string Performance
		{
			get
			{
				return performance;
			}
			set
			{
				performance = value;
			}
		}

		/// <summary>
		/// url
		/// 
		/// @hibernate.property column="URL" type="costos_string" </summary>
		/// <returns> performance </returns>
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
		/// name of the supplier
		/// 
		/// @hibernate.property column="CONTACTPERSON" type="costos_string" </summary>
		/// <returns> contactPerson </returns>
		public virtual string ContactPerson
		{
			get
			{
				return contactPerson;
			}
			set
			{
				contactPerson = value;
			}
		}

		/// <summary>
		/// phoneNumber of supplier
		/// 
		/// @hibernate.property column="PHONENUMBER" type="costos_string" </summary>
		/// <returns> phoneNumber </returns>
		public virtual string PhoneNumber
		{
			get
			{
				return phoneNumber;
			}
			set
			{
				phoneNumber = value;
			}
		}
		/// <summary>
		/// phoneNumber of supplier
		/// 
		/// @hibernate.property column="MOBILENUMBER" type="costos_string" </summary>
		/// <returns> mobileNumber </returns>
		public virtual string MobileNumber
		{
			get
			{
				return mobileNumber;
			}
			set
			{
				mobileNumber = value;
			}
		}
		/// <summary>
		/// faxNumber of supplier
		/// 
		/// @hibernate.property column="FAXNUMBER" type="costos_string" </summary>
		/// <returns> mobileNumber </returns>
		public virtual string FaxNumber
		{
			get
			{
				return faxNumber;
			}
			set
			{
				faxNumber = value;
			}
		}

		/// <summary>
		/// eMail of supplier
		/// 
		/// @hibernate.property column="EMAIL" type="costos_string" </summary>
		/// <returns> eMail </returns>
		public virtual string Email
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
			}
		}
		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CITY" type="costos_string" </summary>
		/// <returns> city </returns>
		public virtual string City
		{
			get
			{
				return city;
			}
			set
			{
				city = value;
			}
		}
		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ADDRESS" type="costos_string" </summary>
		/// <returns> address </returns>
		public virtual string Address
		{
			get
			{
				return address;
			}
			set
			{
				address = value;
			}
		}
		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="NOTES" type="costos_string" </summary>
		/// <returns> notes </returns>
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
		/// custom editorId
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
		/// Description Here
		/// 
		/// @hibernate.property column="STATEPROVINCE" type="costos_string" </summary>
		/// <returns> stateProvince </returns>
		public virtual string StateProvince
		{
			get
			{
				return stateProvince;
			}
			set
			{
				stateProvince = value;
			}
		}
		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="COUNTRY" type="costos_string" </summary>
		/// <returns> country </returns>
		public virtual string Country
		{
			get
			{
				return country;
			}
			set
			{
				country = value;
			}
		}

		private long? databaseId;
		//#RXL_START
		/// <summary>
		/// USE BY PROJECT ONLY!
		/// 
		/// @hibernate.property column="DATABASEID" type="long" index="IDX_MDBID" </summary>
		/// <returns> lastUpdate </returns>
		//#RXL_END
		public virtual long? DatabaseId
		{
			get
			{
				return databaseId;
			}
			set
			{
				databaseId = value;
			}
		}

		private long? databaseCreationDate;
		//#RXL_START
		/// <summary>
		/// USE BY PROJECT ONLY!
		/// 
		/// @hibernate.property column="DATABASECREATIONDATE" type="long" </summary>
		/// <returns> lastUpdate </returns>
		//#RXL_END
		public virtual long? DatabaseCreationDate
		{
			get
			{
				return databaseCreationDate;
			}
			set
			{
				databaseCreationDate = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CREATEUSER" type="costos_string" </summary>
		/// <returns> stateProvince </returns>
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
		/// @hibernate.property column="CREATEDATE" type="timestamp" </summary>
		/// <returns> stateProvince </returns>
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
		/// @hibernate.property column="RESCODE" type="costos_string" </summary>
		/// <returns> description </returns>
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
		/// @hibernate.property column="TITLE" type="costos_string" index="IDX_TITLE" </summary>
		/// <returns> lastUpdate </returns>
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
		/// @hibernate.property column="GEOLOC" type="costos_string" </summary>
		/// <returns> extraCode10 </returns>
		public virtual string GeoLocation
		{
			get
			{
				return geoLocation;
			}
			set
			{
				this.geoLocation = value;
			}
		}


		public override string ToString()
		{
			/*
			 StringBuffer out = new StringBuffer();
			 Iterator iter = o_map.keySet().iterator();
	
			 while ( iter.hasNext() ) {
				 Object obj = (Object)iter.next();
				 if ( obj.toString().equals("description") ) continue;
				 out.append(obj.toString()+" :  "+o_map.get(obj)+"\n");
			 }
			 */
			if (DatabaseId != null)
			{
				return DatabaseId + ". " + Title;
			}
			return SupplierId + ". " + Title;
		}

		/// <summary>
		/// @hibernate.set
		///  inverse="false"  
		///  cascade="save-update"
		/// @hibernate.key
		///  column="SUPPLIERID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.MaterialTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> Set </returns>
		public virtual ISet<MaterialTable> MaterialSet
		{
			get
			{
				return materialSet;
			}
			set
			{
				this.materialSet = value;
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
			return DataFlavors.supplierDataFlavor.Equals(flavor);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public synchronized Object getTransferData(java.awt.datatransfer.DataFlavor flavor) throws java.awt.datatransfer.UnsupportedFlavorException, java.io.IOException
		public virtual object getTransferData(DataFlavor flavor)
		{
			lock (this)
			{
				if (DataFlavors.supplierDataFlavor.Equals(flavor))
				{
					return this;
				}
        
				throw new UnsupportedFlavorException(flavor);
			}
		}

		/////////////////////////////////////////////////////
		// SORTING FIELDS                                  //
		/////////////////////////////////////////////////////
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public java.util.Date getCreateDate_sorted()
		public virtual DateTime CreateDate_sorted
		{
			get
			{
				return createDate;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getGeoLocation_sorted()
		public virtual string GeoLocation_sorted
		{
			get
			{
				return geoLocation;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getUrl_sorted()
		public virtual string Url_sorted
		{
			get
			{
				return url;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCreateUserId_sorted()
		public virtual string CreateUserId_sorted
		{
			get
			{
				return createUserId;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getDescription_sorted()
		public virtual string Description_sorted
		{
			get
			{
				return description;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getContactPerson_sorted()
		public virtual string ContactPerson_sorted
		{
			get
			{
				return contactPerson;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getPhoneNumber_sorted()
		public virtual string PhoneNumber_sorted
		{
			get
			{
				return phoneNumber;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getMobileNumber_sorted()
		public virtual string MobileNumber_sorted
		{
			get
			{
				return mobileNumber;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getFaxNumber_sorted()
		public virtual string FaxNumber_sorted
		{
			get
			{
				return faxNumber;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getEmail_sorted()
		public virtual string Email_sorted
		{
			get
			{
				return email;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCity_sorted()
		public virtual string City_sorted
		{
			get
			{
				return city;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getAddress_sorted()
		public virtual string Address_sorted
		{
			get
			{
				return address;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getEditorId_sorted()
		public virtual string EditorId_sorted
		{
			get
			{
				return editorId;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getStateProvince_sorted()
		public virtual string StateProvince_sorted
		{
			get
			{
				return stateProvince;
			}
		}
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getGekCode_sorted()
		public virtual string GekCode_sorted
		{
			get
			{
				return gekCode;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getPerformance_sorted()
		public virtual string Performance_sorted
		{
			get
			{
				return performance;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getCountry_sorted()
		public virtual string Country_sorted
		{
			get
			{
				return country;
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
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode1_sorted()
		public virtual string ExtraCode1_sorted
		{
			get
			{
				return extraCode1;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode2_sorted()
		public virtual string ExtraCode2_sorted
		{
			get
			{
				return extraCode2;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode3_sorted()
		public virtual string ExtraCode3_sorted
		{
			get
			{
				return extraCode3;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode4_sorted()
		public virtual string ExtraCode4_sorted
		{
			get
			{
				return extraCode4;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode5_sorted()
		public virtual string ExtraCode5_sorted
		{
			get
			{
				return extraCode5;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode6_sorted()
		public virtual string ExtraCode6_sorted
		{
			get
			{
				return extraCode6;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode7_sorted()
		public virtual string ExtraCode7_sorted
		{
			get
			{
				return extraCode7;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode8_sorted()
		public virtual string ExtraCode8_sorted
		{
			get
			{
				return extraCode8;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode9_sorted()
		public virtual string ExtraCode9_sorted
		{
			get
			{
				return extraCode9;
			}
		}
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.NO) public String getExtraCode10_sorted()
		public virtual string ExtraCode10_sorted
		{
			get
			{
				return extraCode10;
			}
		}

		/// <summary>
		/// @hibernate.property column="EXTRACODE1" type="costos_string" not-null="true" </summary>
		/// <returns> extraCode1 </returns>
		public virtual string ExtraCode1
		{
			get
			{
				return extraCode1;
			}
			set
			{
				this.extraCode1 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EXTRACODE2" type="costos_string" not-null="true" </summary>
		/// <returns> extraCode2 </returns>
		public virtual string ExtraCode2
		{
			get
			{
				return extraCode2;
			}
			set
			{
				this.extraCode2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EXTRACODE3" type="costos_string" not-null="true" </summary>
		/// <returns> extraCode3 </returns>
		public virtual string ExtraCode3
		{
			get
			{
				return extraCode3;
			}
			set
			{
				this.extraCode3 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EXTRACODE4" type="costos_string" not-null="true" </summary>
		/// <returns> extraCode4 </returns>
		public virtual string ExtraCode4
		{
			get
			{
				return extraCode4;
			}
			set
			{
				this.extraCode4 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EXTRACODE5" type="costos_string" not-null="true" </summary>
		/// <returns> extraCode5 </returns>
		public virtual string ExtraCode5
		{
			get
			{
				return extraCode5;
			}
			set
			{
				this.extraCode5 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EXTRACODE6" type="costos_string" not-null="true" </summary>
		/// <returns> extraCode6 </returns>
		public virtual string ExtraCode6
		{
			get
			{
				return extraCode6;
			}
			set
			{
				this.extraCode6 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EXTRACODE7" type="costos_string" not-null="true" </summary>
		/// <returns> extraCode7 </returns>
		public virtual string ExtraCode7
		{
			get
			{
				return extraCode7;
			}
			set
			{
				this.extraCode7 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EXTRACODE8" type="costos_string" not-null="true" </summary>
		/// <returns> extraCode8 </returns>
		public virtual string ExtraCode8
		{
			get
			{
				return extraCode8;
			}
			set
			{
				this.extraCode8 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EXTRACODE9" type="costos_string" not-null="true" </summary>
		/// <returns> extraCode9 </returns>
		public virtual string ExtraCode9
		{
			get
			{
				return extraCode9;
			}
			set
			{
				this.extraCode9 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="EXTRACODE10" type="costos_string" not-null="true" </summary>
		/// <returns> extraCode10 </returns>
		public virtual string ExtraCode10
		{
			get
			{
				return extraCode10;
			}
			set
			{
				this.extraCode10 = value;
			}
		}

		public override decimal TableRate
		{
			get
			{
				return null;
			}
			set
			{
    
			}
		}

		public override ResourceTable Data
		{
			set
			{
				Data = (SupplierTable)value;
			}
		}

		public override void setFieldData(string field, ResourceTable databaseTable)
		{
			setFieldData(field, (SupplierTable)databaseTable);
		}

		public override string Unit
		{
			get
			{
				return null;
			}
			set
			{
				// TODO Auto-generated method stub
    
			}
		}


		public override string Project
		{
			set
			{
				// TODO Auto-generated method stub		
			}
			get
			{
				return null;
			}
		}


		public override decimal Quantity
		{
			set
			{
				// TODO Auto-generated method stub
    
			}
			get
			{
				return null;
			}
		}

		public override void recalculate()
		{

		}

		public override ISet<object> AssemblyAssignments
		{
			get
			{
				return null;
			}
		}

		public override ISet<object> BoqItemAssignments
		{
			get
			{
				return null;
			}
		}

		//	@Override
		//	public Set getResourceAssignments(String resourceName) {
		//		return getMaterialSet();
		//	}



		public override decimal Productivity
		{
			get
			{
				return null; // dummy
			}
			set
			{
				// dummy
			}
		}


		public override object deepCopy(bool removeIds, bool copyWithHistory)
		{
			return copyWithMaterials();
		}

		public override ISet<object> getResourceAssignments(string resourceName)
		{
			return MaterialSet;
		}

		public override bool? Virtual
		{
			get
			{
				return false;
			}
		}

		public override bool? Predicted
		{
			get
			{
				return false;
			}
		}

		public override System.Collections.IList ResourceAssignmentsList
		{
			get
			{
				System.Collections.IList list = new LinkedList();
    
				if (MaterialSet != null)
				{
					list.AddRange(MaterialSet);
				}
    
				return list;
			}
		}

		public override System.Collections.IList OrderedResourceAssignmentsList
		{
			get
			{
				System.Collections.IList list = new List<object>();
    
				if (MaterialSet != null)
				{
					list.AddRange(orderedList(MaterialSet));
				}
    
				return list;
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