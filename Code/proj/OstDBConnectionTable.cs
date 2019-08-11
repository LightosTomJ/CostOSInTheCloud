namespace Models.proj
{
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using CryptUtil = nomitech.common.util.CryptUtil;

	//#RXL_START
	/// <summary>
	/// @hibernate.class table="OSTDBCON"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	public class OstDBConnectionTable : ProjectIdEntity
	{

		private long? id;

		private string host;
		private string username;
		private string password;
		private string databaseName;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="OSTCONID" </summary>
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
		/// @hibernate.property column="HOST" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string Host
		{
			get
			{
				return host;
			}
			set
			{
				this.host = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="USERNAME" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string Username
		{
			get
			{
				return username;
			}
			set
			{
				this.username = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PASSWORD" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string EncPassword
		{
			get
			{
				return password;
			}
			set
			{
				this.password = value;
			}
		}

		public virtual string Password
		{
			get
			{
				if (string.ReferenceEquals(EncPassword, null))
				{
					return null;
				}
    
				return CryptUtil.Instance.decryptHexString(EncPassword);
			}
			set
			{
				if (!string.ReferenceEquals(value, null))
				{
					EncPassword = CryptUtil.Instance.encryptHexString(value);
				}
			}
		}


		/// <summary>
		/// @hibernate.property column="DATABASENAME" type="costos_string" </summary>
		/// <returns> rate </returns>
		public virtual string DatabaseName
		{
			get
			{
				return databaseName;
			}
			set
			{
				this.databaseName = value;
			}
		}

		public override string ToString()
		{
			return host + " [" + databaseName + "]";
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