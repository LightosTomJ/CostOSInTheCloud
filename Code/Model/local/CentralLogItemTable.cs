namespace Model.local
{
	using BaseEntity = Desktop.common.nomitech.common.@base.BaseEntity;
	//#RXP_START 
	/// 
	/// <summary>
	/// @author: George Hatzisymeon
	/// @hibernate.class table="CNTRLOGITEM"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// 
	/// </summary>
	//#RXP_END
	public class CentralLogItemTable : BaseEntity
	{

		private long? id;
		private long? logId; // CentralLogTable Id
		private string logFilter;
		private sbyte? operation;
		private long? itemId;
		private string item;
		private long? projectId; // is in project

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
		/// @hibernate.property column="LOGID" type="long" index="IDX_LOGID" </summary>
		/// <returns> logId </returns>
		public virtual long? LogId
		{
			get
			{
				return logId;
			}
			set
			{
				this.logId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FLTR" type="costos_string" </summary>
		/// <returns> logFilter </returns>
		public virtual string LogFilter
		{
			get
			{
				return logFilter;
			}
			set
			{
				this.logFilter = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="OPRTN" type="byte" </summary>
		/// <returns> operation </returns>
		public virtual sbyte? Operation
		{
			get
			{
				return operation;
			}
			set
			{
				this.operation = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ITEMID" type="long" index="IDX_ITEMID" </summary>
		/// <returns> itemId </returns>
		public virtual long? ItemId
		{
			get
			{
				return itemId;
			}
			set
			{
				this.itemId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ITEM" type="costos_text" </summary>
		/// <returns> item </returns>
		public virtual string Item
		{
			get
			{
				return item;
			}
			set
			{
				this.item = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PRJID" type="long" index="IDX_PRJID" </summary>
		/// <returns> projectId </returns>
		public virtual long? ProjectId
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