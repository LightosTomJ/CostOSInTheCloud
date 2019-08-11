using System;

namespace Models.local
{

	using ProjectIdEntity = Desktop.common.nomitech.common.@base.ProjectIdEntity;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="PARAMRETURN"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class ParamItemReturnTable : ProjectIdEntity
	{

		private long? paramReturnId;

		private string returnEquation;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="PARAMRETURNID" </summary>
		/// <returns> Long </returns>
		public virtual long? ParamReturnId
		{
			get
			{
				return paramReturnId;
			}
			set
			{
				this.paramReturnId = value;
			}
		}


		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="RETEQ" type="costos_text" </summary>
		/// <returns> title </returns>
		public virtual string ReturnEquation
		{
			get
			{
				return returnEquation;
			}
			set
			{
				this.returnEquation = value;
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

	}

}