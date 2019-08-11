using System;

namespace Models.proj
{

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	//#RXL_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="XCHANGERATE"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	[Serializable]
	public class ExchangeRateTable : ProjectIdEntity
	{

		private long? id;
		private string fromCurrency;
		private string toCurrency;
		private decimal rate;
		private DateTime date;


		public ExchangeRateTable() : base()
		{
		}

		public ExchangeRateTable(string fromCurrency, string toCurrency, decimal rate, DateTime date) : base()
		{
			this.fromCurrency = fromCurrency;
			this.toCurrency = toCurrency;
			this.rate = rate;
			this.date = date;
		}
		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="XCHANGERATEID" </summary>
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
		/// Description Here
		/// 
		/// @hibernate.property column="FROM_CURRENCY" type="costos_string" index="IDX_FROMCUR" </summary>
		/// <returns> String </returns>
		public virtual string FromCurrency
		{
			get
			{
				return fromCurrency;
			}
			set
			{
				this.fromCurrency = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="TO_CURRENCY" type="costos_string" index="IDX_TOCUR" </summary>
		/// <returns> String </returns>
		public virtual string ToCurrency
		{
			get
			{
				return toCurrency;
			}
			set
			{
				this.toCurrency = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="RATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal Rate
		{
			get
			{
				return rate;
			}
			set
			{
				this.rate = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="RATE_DATE" type="timestamp" index="IDX_RATEDATE" </summary>
		/// <returns> String </returns>
		public virtual DateTime RateDate
		{
			get
			{
				return date;
			}
			set
			{
				this.date = value;
			}
		}

		public virtual object clone()
		{
			ExchangeRateTable obj = new ExchangeRateTable();

			obj.Id = Id;
			obj.RateDate = RateDate;
			obj.FromCurrency = FromCurrency;
			obj.ToCurrency = ToCurrency;
			obj.Rate = Rate;
			obj.ProjectId = ProjectId;

			return obj;
		}

		public virtual ExchangeRateTable Data
		{
			set
			{
				RateDate = value.RateDate;
				FromCurrency = value.FromCurrency;
				ToCurrency = value.ToCurrency;
				Rate = value.Rate;
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