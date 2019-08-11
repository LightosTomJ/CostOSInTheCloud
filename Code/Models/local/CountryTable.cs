using System;

namespace Models.local
{

	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;

	//#RXP_START
	/// <summary>
	/// @author: Stamatis Vergos
	/// 
	/// @hibernate.class table="COUNTRY"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class CountryTable implements java.io.Serializable
	[Serializable]
	public class CountryTable
	{

		public static readonly string[] FIELDS = new string[] {"id", "label", "value"};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> id;
		private long? id;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store=org.hibernate.search.annotations.Store.YES) private String countryCode;
		private string countryCode;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store=org.hibernate.search.annotations.Store.YES) private String countryName;
		private string countryName;

		/*public void setData(Country country) {
			setLabel(country.getLabel());
			setValue(country.getValue());
		}*/


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
		/// @hibernate.property column="CCODE" type="costos_string" </summary>
		/// <returns> description nomitech.common.db.types.costos_string </returns>
		public virtual string CountryCode
		{
			get
			{
				return countryCode;
			}
			set
			{
				this.countryCode = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CNAME" type="costos_string" </summary>
		/// <returns> description nomitech.common.db.types.costos_string </returns>
		public virtual string CountryName
		{
			get
			{
				return countryName;
			}
			set
			{
				this.countryName = value;
			}
		}


	}

}