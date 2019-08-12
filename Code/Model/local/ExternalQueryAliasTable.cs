namespace Model.local
{
	using BaseEntity = Desktop.common.nomitech.common.@base.BaseEntity;


	//#RXP_START
	/// <summary>
	/// @author George Hatzisymeon
	/// 
	/// @hibernate.class table="EXTALIAS"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	public class ExternalQueryAliasTable : BaseEntity
	{

		private long? id;
		private short? lineNumber;
		private string fromAliasClassName;
		private string fromAlias;
		private string toField;
		private string dataMapping;
		private bool? isQueryColumnID;
		private ExternalQueryTable externalQueryTable;

		/// <summary>
		/// @hibernate.id generator-class="native" unsaved-value="null" column="ALIASID" </summary>
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
		/// @hibernate.property column="LINENUMBER" type="short" </summary>
		/// <returns> current line number </returns>
		public virtual short? LineNumber
		{
			get
			{
				return lineNumber;
			}
			set
			{
				this.lineNumber = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FROMALIASCLASSNAME" type="costos_string" </summary>
		/// <returns> fromAliasClass </returns>
		public virtual string FromAliasClassName
		{
			get
			{
				return fromAliasClassName;
			}
			set
			{
				this.fromAliasClassName = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FROMALIAS" type="costos_string" </summary>
		/// <returns> fromAlias </returns>
		public virtual string FromAlias
		{
			get
			{
				return fromAlias;
			}
			set
			{
				this.fromAlias = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TOFIELD" type="costos_string" </summary>
		/// <returns> toField </returns>
		public virtual string ToField
		{
			get
			{
				return toField;
			}
			set
			{
				this.toField = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DATAMAPPING" type="costos_text" </summary>
		/// <returns> map </returns>
		public virtual string DataMapping
		{
			get
			{
				return dataMapping;
			}
			set
			{
				this.dataMapping = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ISQUERYCOLUMNID" type="boolean" </summary>
		/// <returns> queryColumnID </returns>
		public virtual bool? IsQueryColumnID
		{
			get
			{
				return isQueryColumnID;
			}
			set
			{
				this.isQueryColumnID = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one column="QUERYID" cascade="none" </summary>
		/// <returns> ChildTable </returns>
		public virtual ExternalQueryTable ExternalQueryTable
		{
			get
			{
				return externalQueryTable;
			}
			set
			{
				this.externalQueryTable = value;
			}
		}


		public virtual ExternalQueryAliasTable Data
		{
			set
			{
				LineNumber = value.LineNumber;
				FromAliasClassName = value.FromAliasClassName;
				FromAlias = value.FromAlias;
				ToField = value.ToField;
				DataMapping = value.DataMapping;
				IsQueryColumnID = value.IsQueryColumnID;
			}
		}

		public override ExternalQueryAliasTable clone()
		{
			ExternalQueryAliasTable qat = new ExternalQueryAliasTable();
			qat.Id = Id;
			qat.Data = this;
			return qat;
		}

	}

}