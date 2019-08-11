using System;

namespace Models.local
{
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="LICTBL"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class ConcLicenseTable
	{

		private long? id;
		private string hashKey;

		/// <summary>
		/// @hibernate.id generator-class="native"
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
		/// This hash contains the xml
		/// @hibernate.property column="HASHKEY" type="nomitech.common.db.types.EncryptedStringUserType" </summary>
		/// <returns> description nomitech.common.db.types.EncryptedStringUserType </returns>
		public virtual string HashKey
		{
			get
			{
				return hashKey;
			}
			set
			{
				this.hashKey = value;
			}
		}
	}

}