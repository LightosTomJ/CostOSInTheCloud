namespace Model.local
{
	using BaseEntity = Desktop.common.nomitech.common.@base.BaseEntity;
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="UNITALIAS"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	public class UnitAliasTable : BaseEntity
	{

		private long? id;
		private string fromUnit;
		private string toUnit;

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
		/// @hibernate.property column="FRUNIT" type="costos_string" index="IDX_FROMUNIT" </summary>
		/// <returns> editorId </returns>
		public virtual string FromUnit
		{
			get
			{
				return fromUnit;
			}
			set
			{
				this.fromUnit = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="TOUNIT" type="costos_string" index="IDX_TOUNIT" </summary>
		/// <returns> editorId </returns>
		public virtual string ToUnit
		{
			get
			{
				return toUnit;
			}
			set
			{
				this.toUnit = value;
			}
		}
	}

}