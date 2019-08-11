namespace Models.local
{
	using BaseEntity = nomitech.common.@base.BaseEntity;
	//#RXP_START
	/// <summary>
	/// @author: Stamatis Vergos
	/// 
	/// @hibernate.class table="TEAMALIAS"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	public class TeamAliasTable : BaseEntity
	{

		private long? id;
		private string team;
		private string alias;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="ID" </summary>
		/// <returns> Long </returns>
		public override long? Id
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
		/// @hibernate.property column="TEAM" type="costos_string" index="IDX_TEAM" </summary>
		/// <returns> editorId </returns>
		public virtual string Team
		{
			get
			{
				return team;
			}
			set
			{
				this.team = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ALIAS" type="costos_string" index="IDX_ALIAS" </summary>
		/// <returns> editorId </returns>
		public virtual string Alias
		{
			get
			{
				return alias;
			}
			set
			{
				this.alias = value;
			}
		}
	}

}