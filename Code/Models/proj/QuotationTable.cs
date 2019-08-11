using System;
using System.Collections.Generic;

namespace Models.proj
{

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceTable = nomitech.common.@base.ResourceTable;

	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;
	//#RXL_START
	/// <summary>
	/// @hibernate.class table="QUOTE" dynamic-update="true"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class QuotationTable extends nomitech.common.base.ResourceTable implements nomitech.common.base.ProjectIdEntity, java.io.Serializable
	[Serializable]
	public class QuotationTable : ResourceTable, ProjectIdEntity
	{

		public static readonly string[] FIELDS = new string[] {"subject", "quotationId", "quoteType", "status", "performance", "companyName", "contactPerson", "email", "phoneNumber", "mobileNumber", "city", "address", "stateProvince", "country", "currency", "geoLocation", "url", "guid", "toMail", "ccMail", "bccMail", "editorId", "createDate", "sentDate", "receivedDate", "description", "notes", "workPackage"};

		public static string MATERIAL_QUOTE = "enum.quotetype.material";
		public static string SUBCONTRACTOR_QUOTE = "enum.quotetype.subcontractor";
		public static string WORKPACKAGE_QUOTE = "enum.quotetype.workpackage";

		public static string PENDING_STATUS = "enum.quotation.status.pending";
		public static string RECEIVED_STATUS = "enum.quotation.status.received";
		public static string WORKPACKAGE_STATUS = "enum.quotation.status.wp";

		private string title;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private System.Nullable<bool> onSiteDelivery;
		private bool? onSiteDelivery;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private System.Nullable<bool> hasMaterialRate;
		private bool? hasMaterialRate;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String subject;
		private string subject;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String description;
		private string description;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String quoteType;
		private string quoteType;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> quotationId;
		private long? quotationId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String companyName;
		private string companyName;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String contactPerson;
		private string contactPerson;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String email;
		private string email;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String phoneNumber;
		private string phoneNumber;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String mobileNumber;
		private string mobileNumber;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String faxNumber;
		private string faxNumber;

		private string country;
		private string stateProvince;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String city;
		private string city;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String address;
		private string address;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String url;
		private string url;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String toMail;
		private string toMail;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String ccMail;
		private string ccMail;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String bccMail;
		private string bccMail;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String editorId;
		private string editorId;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String status;
		private string status;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String guid;
		private string guid;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String geoLocation;
		private string geoLocation;

		private int? performance;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String currency;
		private string currency;

		private string notes;
		private DateTime createDate;
		private DateTime sentDate;
		private DateTime receivedDate;
		private long? templateId;

		[NonSerialized]
		private ISet<QuoteItemTable> quoteItemSet;

		public virtual object clone()
		{
			QuotationTable quotationTable = new QuotationTable();

			quotationTable.QuotationId = QuotationId;
			quotationTable.Subject = Subject;
			quotationTable.Performance = Performance;
			quotationTable.Description = Description;
			quotationTable.QuoteType = QuoteType;
			quotationTable.Status = Status;
			quotationTable.Guid = Guid;
			quotationTable.CompanyName = CompanyName;
			quotationTable.ContactPerson = ContactPerson;
			quotationTable.Email = Email;
			quotationTable.PhoneNumber = PhoneNumber;
			quotationTable.FaxNumber = FaxNumber;
			quotationTable.MobileNumber = MobileNumber;
			quotationTable.City = City;
			quotationTable.Address = Address;
			quotationTable.Url = Url;
			quotationTable.ToMail = ToMail;
			quotationTable.CcMail = CcMail;
			quotationTable.BccMail = BccMail;
			quotationTable.EditorId = EditorId;
			quotationTable.Currency = Currency;
			quotationTable.StateProvince = StateProvince;
			quotationTable.Country = Country;
			quotationTable.GeoLocation = GeoLocation;
			quotationTable.TemplateId = TemplateId;
			quotationTable.HasMaterialRate = HasMaterialRate;
			quotationTable.OnSiteDelivery = OnSiteDelivery;
			quotationTable.Notes = Notes;
			quotationTable.Title = Title;
			quotationTable.CreateDate = CreateDate;
			quotationTable.SentDate = SentDate;
			quotationTable.ReceivedDate = ReceivedDate;
			quotationTable.ProjectId = ProjectId;

			return quotationTable;
		}

		public virtual QuotationTable Data
		{
			set
			{
				QuotationId = value.QuotationId;
				Subject = value.Subject;
				Performance = value.Performance;
				Description = value.Description;
				QuoteType = value.QuoteType;
				GeoLocation = value.GeoLocation;
				TemplateId = value.TemplateId;
				Status = value.Status;
				Guid = value.Guid;
				CompanyName = value.CompanyName;
				ContactPerson = value.ContactPerson;
				Email = value.Email;
				PhoneNumber = value.PhoneNumber;
				FaxNumber = value.FaxNumber;
				MobileNumber = value.MobileNumber;
				City = value.City;
				Address = value.Address;
				Url = value.Url;
				ToMail = value.ToMail;
				CcMail = value.CcMail;
				BccMail = value.BccMail;
				EditorId = value.EditorId;
				Currency = value.Currency;
				StateProvince = value.StateProvince;
				Country = value.Country;
				HasMaterialRate = value.HasMaterialRate;
				OnSiteDelivery = value.OnSiteDelivery;
				Notes = value.Notes;
				Title = value.Title;
				CreateDate = value.CreateDate;
				SentDate = value.SentDate;
				ReceivedDate = value.ReceivedDate;
			}
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="EXPENSEID" </summary>
		/// <returns> Long </returns>
		public virtual long? QuotationId
		{
			get
			{
				return quotationId;
			}
			set
			{
				this.quotationId = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PERFORMANCE" type="int" </summary>
		/// <returns> performance </returns>
		public virtual int? Performance
		{
			get
			{
				return performance;
			}
			set
			{
				this.performance = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="SUBJECT" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string Subject
		{
			get
			{
				return subject;
			}
			set
			{
				this.subject = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FAX" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string FaxNumber
		{
			get
			{
				return faxNumber;
			}
			set
			{
				this.faxNumber = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CURRENCY" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string Currency
		{
			get
			{
				return currency;
			}
			set
			{
				this.currency = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="DELIVERY" type="boolean" </summary>
		/// <returns> rate </returns>
		public virtual bool? OnSiteDelivery
		{
			get
			{
				return onSiteDelivery;
			}
			set
			{
				this.onSiteDelivery = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="HASMATRATE" type="boolean" </summary>
		/// <returns> rate </returns>
		public virtual bool? HasMaterialRate
		{
			get
			{
				return hasMaterialRate;
			}
			set
			{
				this.hasMaterialRate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="DESCRIPTION" type="costos_text" </summary>
		/// <returns> rate </returns>
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
		/// @hibernate.property column="NOTES" type="costos_text" </summary>
		/// <returns> rate </returns>
		public override string Notes
		{
			get
			{
				return notes;
			}
			set
			{
				this.notes = value;
			}
		}


		/// 
		/// <summary>
		/// @hibernate.property column="TITLE" type="costos_string" </summary>
		/// <returns> rate </returns>
		public override string Title
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


		public virtual string WorkPackage
		{
			set
			{
				Title = value;
			}
			get
			{
				return Title;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="COMPANY" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string CompanyName
		{
			get
			{
				return companyName;
			}
			set
			{
				this.companyName = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="GEOPOS" type="costos_string" </summary>
		/// <returns> rate </returns>
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


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="QUOTETEMPID" type="long" </summary>
		/// <returns> rate </returns>
		public virtual long? TemplateId
		{
			get
			{
				return templateId;
			}
			set
			{
				this.templateId = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CONTACT" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string ContactPerson
		{
			get
			{
				return contactPerson;
			}
			set
			{
				this.contactPerson = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EMAIL" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string Email
		{
			get
			{
				return email;
			}
			set
			{
				this.email = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PHONE" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string PhoneNumber
		{
			get
			{
				return phoneNumber;
			}
			set
			{
				this.phoneNumber = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="MOBILE" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string MobileNumber
		{
			get
			{
				return mobileNumber;
			}
			set
			{
				this.mobileNumber = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CITY" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string City
		{
			get
			{
				return city;
			}
			set
			{
				this.city = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="COUNTRY" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string Country
		{
			get
			{
				return country;
			}
			set
			{
				this.country = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="STATEPRO" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string StateProvince
		{
			get
			{
				return stateProvince;
			}
			set
			{
				this.stateProvince = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="ADDRESS" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string Address
		{
			get
			{
				return address;
			}
			set
			{
				this.address = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="URL" type="costos_string" </summary>
		/// <returns> rate </returns>
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
		/// Description Here
		/// 
		/// @hibernate.property column="TOMAIL" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string ToMail
		{
			get
			{
				return toMail;
			}
			set
			{
				this.toMail = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CCMAIL" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string CcMail
		{
			get
			{
				return ccMail;
			}
			set
			{
				this.ccMail = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="BCCMAIL" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string BccMail
		{
			get
			{
				return bccMail;
			}
			set
			{
				this.bccMail = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="QUOTETYPE" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string QuoteType
		{
			get
			{
				return quoteType;
			}
			set
			{
				this.quoteType = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="EDITORID" type="costos_string" </summary>
		/// <returns> rate </returns>
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
		/// @hibernate.property column="STATUS" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string Status
		{
			get
			{
				return status;
			}
			set
			{
				this.status = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="GUID" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string Guid
		{
			get
			{
				return guid;
			}
			set
			{
				this.guid = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CREATEDATE" type="timestamp" </summary>
		/// <returns> rate </returns>
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
		/// @hibernate.property column="SENTDATE" type="timestamp" </summary>
		/// <returns> rate </returns>
		public virtual DateTime SentDate
		{
			get
			{
				return sentDate;
			}
			set
			{
				this.sentDate = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="RECEIVEDDATE" type="timestamp" </summary>
		/// <returns> rate </returns>
		public virtual DateTime ReceivedDate
		{
			get
			{
				return receivedDate;
			}
			set
			{
				this.receivedDate = value;
			}
		}


		/// <summary>
		/// @hibernate.set
		///  inverse="true"  
		///  cascade="all-delete-orphan"
		///  lazy="true"
		/// @hibernate.key
		///  column="QUOTATIONID"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.project.QuoteItemTable"
		/// @hibernate.cache usage="nonstrict-read-write" </summary>
		/// <returns> List </returns>
		public virtual ISet<QuoteItemTable> QuoteItemSet
		{
			get
			{
				return quoteItemSet;
			}
			set
			{
				this.quoteItemSet = value;
			}
		}

		public virtual QuotationTable copyWithItems()
		{
			QuotationTable obj = (QuotationTable)clone();

			if (QuoteItemSet != null)
			{
				obj.quoteItemSet = new HashSet<object>();
				System.Collections.IEnumerator iter = quoteItemSet.GetEnumerator();
				while (iter.MoveNext())
				{
					QuoteItemTable curMat = (QuoteItemTable)iter.Current;
					obj.quoteItemSet.Add((QuoteItemTable)curMat.clone());
				}
			}

			return obj;
		}

		public override long? Id
		{
			get
			{
				return QuotationId;
			}
			set
			{
				QuotationId = value;
			}
		}


		public override string CreateUserId
		{
			get
			{
				return null; // dummy
			}
			set
			{
			}
		}

		public override DateTime LastUpdate
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
    
			}
		}

		public override void setFieldData(string field, ResourceTable resourceTable)
		{

		}

		public override string GroupCode
		{
			get
			{
				return null; // dummy
			}
			set
			{
			}
		}

		public override string GekCode
		{
			get
			{
				return null; // dummy
			}
			set
			{
			}
		}

		public override string ExtraCode1
		{
			get
			{
				return null; // dummy
			}
			set
			{
			}
		}

		public override string ExtraCode2
		{
			get
			{
				return null; // dummy
			}
			set
			{
			}
		}

		public override string ExtraCode3
		{
			get
			{
				return null; // dummy
			}
			set
			{
			}
		}

		public override string ExtraCode4
		{
			get
			{
				return null; // dummy
			}
			set
			{
			}
		}

		public override string ExtraCode5
		{
			get
			{
				return null; // dummy
			}
			set
			{
			}
		}

		public override string ExtraCode6
		{
			get
			{
				return null; // dummy
			}
			set
			{
			}
		}

		public override string ExtraCode7
		{
			get
			{
				return null; // dummy
			}
			set
			{
			}
		}

		public override string ExtraCode8
		{
			get
			{
				return null; // dummy
			}
		}

		public override string ExtraCode9
		{
			get
			{
				return null; // dummy
			}
		}

		public override string ExtraCode10
		{
			get
			{
				return null; // dummy
			}
		}










		public override decimal TableRate
		{
			get
			{
				return Quantity;
			}
			set
			{
			}
		}

		public override string Unit
		{
			get
			{
				return null;
			}
			set
			{
			}
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

		public override decimal Quantity
		{
			get
			{
				return null;
			}
			set
			{
			}
		}


		public override string Project
		{
			set
			{
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
				return QuoteItemSet;
			}
		}


		public override string ItemCode
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