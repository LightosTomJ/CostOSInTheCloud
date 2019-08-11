namespace Models.local
{
	using BaseEntity = Desktop.common.nomitech.common.@base.BaseEntity;
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="PROJECTACCESS"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	public class ProjectAccessRuleTable : BaseEntity
	{

		private long? id;
		private string title;
		private string accessCondition; // BOQ Item Access Condition
		// AT LEAST ONE MUST BE TRUE FOR THIS TO HAVE A POINT:
		private bool? allowAdd;
		private bool? allowUpdate;
		private bool? allowRemove;

		private ProjectUserTable userTable;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="PAID" </summary>
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


		public virtual object clone()
		{
			ProjectAccessRuleTable userTable = new ProjectAccessRuleTable();
			userTable.Id = Id;
			userTable.Data = this;
			return userTable;
		}

		public virtual ProjectAccessRuleTable Data
		{
			set
			{
				Title = value.Title;
				AllowAdd = value.AllowAdd;
				AllowUpdate = value.AllowUpdate;
				AllowRemove = value.AllowRemove;
				AccessCondition = value.AccessCondition;
			}
		}

		/// <summary>
		/// @hibernate.property column="TITLE" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string Title
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


		/// <summary>
		/// @hibernate.property column="ACCCON" type="costos_text" </summary>
		/// <returns> code </returns>
		public virtual string AccessCondition
		{
			get
			{
				return accessCondition;
			}
			set
			{
				this.accessCondition = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ALADD" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? AllowAdd
		{
			get
			{
				return allowAdd;
			}
			set
			{
				this.allowAdd = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ALUPD" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? AllowUpdate
		{
			get
			{
				return allowUpdate;
			}
			set
			{
				this.allowUpdate = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ALREM" type="boolean" </summary>
		/// <returns> code </returns>
		public virtual bool? AllowRemove
		{
			get
			{
				return allowRemove;
			}
			set
			{
				this.allowRemove = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="PUID"
		///  cascade="none" </summary>
		/// <returns> ProjectUserTable </returns>
		public virtual ProjectUserTable UserTable
		{
			get
			{
				return userTable;
			}
			set
			{
				this.userTable = value;
			}
		}

	}

}