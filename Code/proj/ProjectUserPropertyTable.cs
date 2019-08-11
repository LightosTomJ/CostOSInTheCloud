namespace Models.proj
{
	using BaseEntity = nomitech.common.@base.BaseEntity;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;

	//#RXL_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="PRJUSERPROP"
	/// </summary>
	//#RXL_END
	public class ProjectUserPropertyTable : BaseEntity, ProjectIdEntity
	{

		private long? id;
		private string userId;
		private string propKey;
		private string propValue;

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
		/// @hibernate.property column="PKEY" type="costos_string" </summary>
		/// <returns> code </returns>
		public virtual string PropKey
		{
			get
			{
				return propKey;
			}
			set
			{
				this.propKey = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PVAL" type="costos_text" </summary>
		/// <returns> code </returns>
		public virtual string PropValue
		{
			get
			{
				return propValue;
			}
			set
			{
				this.propValue = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PROPUSER" type="costos_string" </summary>
		/// <returns> code </returns>
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

		public virtual ProjectUserPropertyTable Data
		{
			set
			{
				UserId = value.UserId;
				PropKey = value.PropKey;
				PropValue = value.PropValue;
			}
		}

		public virtual ProjectUserPropertyTable clone()
		{
			ProjectUserPropertyTable po = new ProjectUserPropertyTable();
			po.Id = Id;
			po.Data = this;
			po.ProjectId = ProjectId;
			return po;
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