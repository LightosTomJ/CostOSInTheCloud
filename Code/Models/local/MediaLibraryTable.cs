using System;

namespace Models.local
{

	//#RXP_START
	/// <summary>
	/// @author: Periklis Laros
	/// 
	/// 
	/// @hibernate.class table="MEDIALIBRARY"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class MediaLibraryTable
	{
		public const int Image_Media_Type = 0;
		public const int Project_Design_Media_Type = 1;
		private string id;
		private string name;
		private int type;
		private sbyte[] mediaBlob;
		private DateTime creationDate;
		private DateTime updateDate;
		private string userId;

		public MediaLibraryTable()
		{
	//		type = Image_Media_Type;
		}

		public MediaLibraryTable(string name, sbyte[] blob, int type) : this()
		{
			this.name = name;
			this.mediaBlob = blob;
			this.type = type;
		}

		/// <summary>
		/// @hibernate.id generator-class="uuid" 
		///               unsaved-value="null"
		///               column="ID" </summary>
		/// <returns> Long </returns>
		public virtual string Id
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
		/// Description Here
		/// 
		/// @hibernate.property column="NAME" type="costos_string" not-null="true" </summary>
		/// <returns> name </returns>
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
		/// @hibernate.property column="TYPE" type="int" not-null="true" </summary>
		/// <returns> type </returns>
		public virtual int Type
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
		/// @hibernate.property column="TEMPLATEIMAGE" type="binary" length="73741824" not-null="true" </summary>
		/// <returns> type </returns>
		public virtual sbyte[] MediaBlob
		{
			get
			{
				return mediaBlob;
			}
			set
			{
				this.mediaBlob = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="CREATION_DATE" type="timestamp" </summary>
		/// <returns> creationDate </returns>

		public virtual DateTime CreationDate
		{
			get
			{
				return creationDate;
			}
			set
			{
				this.creationDate = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="UPDATE_DATE" type="timestamp" </summary>
		/// <returns> creationDate </returns>
		public virtual DateTime UpdateDate
		{
			get
			{
				return updateDate;
			}
			set
			{
				this.updateDate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="USERID" type="costos_string" </summary>
		/// <returns> current userId </returns>
		public virtual string UserId
		{
			get
			{
				return userId;
			}
			set
			{
				this.userId = value;
			}
		}


		public virtual object clone()
		{
			MediaLibraryTable table = new MediaLibraryTable();
			table.Id = id;
			table.Name = name;
			table.Type = type;
			table.MediaBlob = mediaBlob;
			table.CreationDate = creationDate;
			table.UpdateDate = updateDate;
			table.UserId = userId;
			return table;
		}
		public override string ToString()
		{
			return name;
		}

	}

}