namespace Model.local
{
	using BaseEntity = Desktop.common.nomitech.common.@base.BaseEntity;
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="GLBPROP"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	public class GlobalPropertyTable : BaseEntity
	{

		private long? id;
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
	}

}