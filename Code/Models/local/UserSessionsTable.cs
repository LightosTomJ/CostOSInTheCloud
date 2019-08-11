using System;

namespace Models.local
{

	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Store = org.hibernate.search.annotations.Store;


	//#RXP_START
	/// <summary>
	/// @hibernate.class table="USERSESSIONS"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class UserSessionsTable
	{

		public static readonly string[] FIELDS = new string[] {"id", "userName", "loggeInDate"};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> id;
		private long? id;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String userName;
		private string userName;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store = org.hibernate.search.annotations.Store.YES) private String serialKey;
		private string serialKey;
		private DateTime loggeInDate;
		private DateTime lastUpdate;


		public UserSessionsTable()
		{

		}

		/// 
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
		/// @hibernate.property column="USERNAME" type="costos_string" </summary>
		/// <returns> description </returns>

		public virtual string UserName
		{
			get
			{
				return userName;
			}
			set
			{
				this.userName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SERIALKEY" type="costos_string" </summary>
		/// <returns> description </returns>
		public virtual string SerialKey
		{
			get
			{
				return serialKey;
			}
			set
			{
				this.serialKey = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LOGGEDIN_DATE" type="timestamp" </summary>
		/// <returns> loggeInDate </returns>
		public virtual DateTime LoggeInDate
		{
			get
			{
				return loggeInDate;
			}
			set
			{
				this.loggeInDate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="LASTUPDATE_DATE" type="timestamp" </summary>
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




	}
}