using System;

namespace Model.proj
{

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="RATEBUILDUP"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class RateBuildUpTable : ProjectIdEntity
	{

		private long? id;
		private string resourceType;
		private long? resourceId; // IN CENTRAL DATABASE
		private long? projectResourceId; // IN PROJECT DATABASE OR NULL
		private bool? online;
		private long? databaseCreationDate;

		private decimal rateOverwrite;
		private decimal finalRate;
		private string calculationFormula;

		private decimal rate0;
		private decimal rate1;
		private decimal rate2;
		private decimal rate3;
		private decimal rate4;
		private decimal rate5;
		private decimal rate6;
		private decimal rate7;
		private decimal rate8;
		private decimal rate9;
		private decimal rate10;
		private decimal rate11;
		private decimal rate12;
		private decimal rate13;
		private decimal rate14;


		private ProjectTemplateTable projectTemplateTable;

		public RateBuildUpTable()
		{

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
		/// @hibernate.many-to-one
		///  column="TEMPLATEID" </summary>
		/// <returns> ParamItemTable </returns>
		public virtual ProjectTemplateTable ProjectTemplateTable
		{
			get
			{
				return projectTemplateTable;
			}
			set
			{
				this.projectTemplateTable = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="RESTYPE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string ResourceType
		{
			get
			{
				return resourceType;
			}
			set
			{
				this.resourceType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="RESID" type="long" index="IDX_RESID" </summary>
		/// <returns> String </returns>
		public virtual long? ResourceId
		{
			get
			{
				return resourceId;
			}
			set
			{
				this.resourceId = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="RESPRJID" type="long"  index="IDX_RESPRJID" </summary>
		/// <returns> String </returns>
		public virtual long? ProjectResourceId
		{
			get
			{
				return projectResourceId;
			}
			set
			{
				this.projectResourceId = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ONLN" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? Online
		{
			get
			{
				return online;
			}
			set
			{
				this.online = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DBCREATEDATE" type="long" </summary>
		/// <returns> String </returns>
		public virtual long? DatabaseCreationDate
		{
			get
			{
				return databaseCreationDate;
			}
			set
			{
				this.databaseCreationDate = value;
			}
		}

		public virtual RateBuildUpTable Data
		{
			set
			{
				ResourceType = value.ResourceType;
				ProjectResourceId = value.ProjectResourceId;
				ResourceId = value.ResourceId;
				Online = value.Online;
				CalculationFormula = value.CalculationFormula;
				DatabaseCreationDate = value.DatabaseCreationDate;
				RateOverwrite = value.RateOverwrite;
				FinalRate = value.FinalRate;
				Rate0 = value.Rate0;
				Rate1 = value.Rate1;
				Rate2 = value.Rate2;
				Rate3 = value.Rate3;
				Rate4 = value.Rate4;
				Rate5 = value.Rate5;
				Rate6 = value.Rate6;
				Rate7 = value.Rate7;
				Rate8 = value.Rate8;
				Rate9 = value.Rate9;
				Rate10 = value.Rate10;
				Rate11 = value.Rate11;
				Rate12 = value.Rate12;
				Rate13 = value.Rate13;
				Rate14 = value.Rate14;
			}
		}

		public virtual object clone()
		{
			RateBuildUpTable o = new RateBuildUpTable();
			o.Data = this;
			o.Id = Id;
			o.ProjectId = ProjectId;
			return o;
		}

		/// <summary>
		/// @hibernate.property column="CALCFORMULA" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string CalculationFormula
		{
			get
			{
				return calculationFormula;
			}
			set
			{
				this.calculationFormula = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="OVERRATE1" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual decimal RateOverwrite
		{
			get
			{
				return rateOverwrite;
			}
			set
			{
				this.rateOverwrite = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FRATE" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal FinalRate
		{
			get
			{
				return finalRate;
			}
			set
			{
				this.finalRate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE0" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate0
		{
			get
			{
				return rate0;
			}
			set
			{
				this.rate0 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE1" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate1
		{
			get
			{
				return rate1;
			}
			set
			{
				this.rate1 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate2
		{
			get
			{
				return rate2;
			}
			set
			{
				this.rate2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE3" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate3
		{
			get
			{
				return rate3;
			}
			set
			{
				this.rate3 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE4" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate4
		{
			get
			{
				return rate4;
			}
			set
			{
				this.rate4 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE5" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate5
		{
			get
			{
				return rate5;
			}
			set
			{
				this.rate5 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE6" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate6
		{
			get
			{
				return rate6;
			}
			set
			{
				this.rate6 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE7" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate7
		{
			get
			{
				return rate7;
			}
			set
			{
				this.rate7 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE8" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate8
		{
			get
			{
				return rate8;
			}
			set
			{
				this.rate8 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE9" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate9
		{
			get
			{
				return rate9;
			}
			set
			{
				this.rate9 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE10" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate10
		{
			get
			{
				return rate10;
			}
			set
			{
				this.rate10 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE11" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate11
		{
			get
			{
				return rate11;
			}
			set
			{
				this.rate11 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE12" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate12
		{
			get
			{
				return rate12;
			}
			set
			{
				this.rate12 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE13" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate13
		{
			get
			{
				return rate13;
			}
			set
			{
				this.rate13 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="RATE14" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> rate </returns>
		public virtual decimal Rate14
		{
			get
			{
				return rate14;
			}
			set
			{
				this.rate14 = value;
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