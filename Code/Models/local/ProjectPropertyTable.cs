namespace Models.local
{
	using BaseEntity = nomitech.common.@base.BaseEntity;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="PRJPROP"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	public class ProjectPropertyTable : ProjectIdEntity, BaseEntity
	{

		private long? prjPropId;
		private string propKey;
		private string propValue;
		private ProjectUrlTable urlTable;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="ID" </summary>
		/// <returns> Long </returns>
		public virtual long? PrjPropId
		{
			get
			{
				return prjPropId;
			}
			set
			{
				this.prjPropId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PKEY" type="costos_string" index="IDX_PROPKEY" </summary>
		/// <returns> editorId </returns>
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
		/// <returns> editorId </returns>
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
	//#RXP_START
		/// <summary>
		/// @hibernate.many-to-one
		///  column="PROJECTURLID"
		///  cascade="none" </summary>
		/// <returns> ProjectInfoTable </returns>
	//#RXP_END
		public virtual ProjectUrlTable UrlTable
		{
			get
			{
				return urlTable;
			}
			set
			{
				this.urlTable = value;
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


		public override long? Id
		{
			get
			{
				return PrjPropId;
			}
		}

		public override object clone()
		{
			ProjectPropertyTable result = new ProjectPropertyTable();
			result.PrjPropId = PrjPropId;
			result.PropKey = PropKey;
			result.PropValue = PropValue;
			result.ProjectId = ProjectId;
			return result;
		}
	}

}