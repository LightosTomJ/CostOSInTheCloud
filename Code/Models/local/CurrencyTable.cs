using System;

namespace Models.local
{

	using DocumentId = org.hibernate.search.annotations.DocumentId;
	using Field = org.hibernate.search.annotations.Field;
	using Indexed = org.hibernate.search.annotations.Indexed;
	using Store = org.hibernate.search.annotations.Store;

	using Currency = Desktop.common.nomitech.common.currency.Currency;

	//#RXP_START
	/// <summary>
	/// @author: Stamatis Vergos
	/// 
	/// @hibernate.class table="CURRENCY"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Indexed public class CurrencyTable implements java.io.Serializable
	[Serializable]
	public class CurrencyTable
	{

		public static readonly string[] FIELDS = new string[] {"id", "name", "symbol", "code", "flag"};

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @DocumentId private System.Nullable<long> id;
		private long? id;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store=org.hibernate.search.annotations.Store.YES) private String name;
		private string name;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store=org.hibernate.search.annotations.Store.YES) private String symbol;
		private string symbol;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store=org.hibernate.search.annotations.Store.YES) private String code;
		private string code;
//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Field(store=org.hibernate.search.annotations.Store.YES) private String flag;
		private string flag;

		public virtual Currency Data
		{
			set
			{
				Name = value.Name;
				Symbol = value.Symbol;
				Flag = value.Flag;
				Code = value.Code;
			}
		}


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
		/// @hibernate.property column="CNAME" type="costos_string" index="IDX_CNAME" </summary>
		/// <returns> description nomitech.common.db.types.costos_string </returns>
		public virtual string Name
		{
			get
			{
				return name;
			}
			set
			{
				this.name = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SYMBOL" type="costos_string" index="IDX_CNAME" </summary>
		/// <returns> description nomitech.common.db.types.costos_string </returns>
		public virtual string Symbol
		{
			get
			{
				return symbol;
			}
			set
			{
				this.symbol = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ISOCODE" type="costos_string" index="IDX_CNAME" </summary>
		/// <returns> description nomitech.common.db.types.costos_text </returns>
		public virtual string Code
		{
			get
			{
				return code;
			}
			set
			{
				this.code = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="ISOFLAG" type="costos_string" index="IDX_CNAME" </summary>
		/// <returns> description nomitech.common.db.types.costos_text </returns>
		public virtual string Flag
		{
			get
			{
				return flag;
			}
			set
			{
				this.flag = value;
			}
		}



	}

}