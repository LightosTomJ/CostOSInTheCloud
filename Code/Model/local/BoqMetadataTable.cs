using System;

namespace Model.local
{

	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;


	/// <summary>
	/// @author: Stamatis Vergos
	/// 
	/// @hibernate.class table="BOQITEMMETADATA"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class BoqMetadataTable implements java.io.Serializable
	[Serializable]
	public class BoqMetadataTable
	{

		public static readonly string[] FIELDS = new string[] {"id", "fieldName", "columnName", "initialdisplayName", "fieldKey"};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> id;
		private long? id;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store=org.hibernate.search.annotations.Store.YES) private String fieldName;
		private string fieldName;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store=org.hibernate.search.annotations.Store.YES) private String columnName;
		private string columnName;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store=org.hibernate.search.annotations.Store.YES) private String initialDisplayName;
		private string initialDisplayName;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store=org.hibernate.search.annotations.Store.YES) private String fieldKey;
		private string fieldKey;


		/*public void setData(Country country) {
			setLabel(country.getLabel());
			setValue(country.getValue());
		}*/


		/// <summary>
		/// @hibernate.property column="FIELDKEY" type="costos_string" </summary>
		/// <returns> description nomitech.common.db.types.costos_string </returns>
		public virtual string FieldKey
		{
			get
			{
				return fieldKey;
			}
			set
			{
				this.fieldKey = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="INITIALDISPLAYNAME" type="costos_string" </summary>
		/// <returns> description nomitech.common.db.types.costos_string </returns>
		public virtual string InitialDisplayName
		{
			get
			{
				return initialDisplayName;
			}
			set
			{
				this.initialDisplayName = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FIELDNAME" type="costos_string" </summary>
		/// <returns> description nomitech.common.db.types.costos_string </returns>
		public virtual string FieldName
		{
			get
			{
				return fieldName;
			}
			set
			{
				this.fieldName = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLUMNNAME" type="costos_string" </summary>
		/// <returns> description nomitech.common.db.types.costos_string </returns>
		public virtual string ColumnName
		{
			get
			{
				return columnName;
			}
			set
			{
				this.columnName = value;
			}
		}


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



	}

}