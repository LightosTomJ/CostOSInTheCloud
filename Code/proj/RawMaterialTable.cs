using System;

namespace Models.proj
{

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	//#RXL_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="RAWMATERIAL"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	[Serializable]
	public class RawMaterialTable : ProjectIdEntity
	{
		private long? id;
		private string code;
		private decimal rate;
		private DateTime rateDate;

		public RawMaterialTable() : base()
		{
		}

		public RawMaterialTable(string name, decimal rate, DateTime date) : base()
		{
			this.code = name;
			this.rate = rate;
			this.rateDate = date;
		}

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="RAWMATID" </summary>
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
		/// @hibernate.property column="CODE" type="costos_string" index="IDX_CODE" </summary>
		/// <returns> String </returns>
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
				return rateDate;
			}
			set
			{
				this.rateDate = value;
			}
		}

		public virtual object clone()
		{
			RawMaterialTable obj = new RawMaterialTable();

			obj.Id = Id;
			obj.RateDate = RateDate;
			obj.Code = Code;
			obj.Rate = Rate;
			obj.ProjectId = ProjectId;

			return obj;
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