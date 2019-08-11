using System;

namespace Models.proj
{

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;


	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="RATEDISTRIB"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class RateDistributorTable : ProjectIdEntity
	{

		public const int BOQ_DISTRIBUTION = 0;
		public const int WBS1_DISTRIBUTION = 1;
		public const int WBS2_DISTRIBUTION = 2;
		public const int GC1_DISTRIBUTION = 3;
		public const int GC2_DISTRIBUTION = 4;
		public const int GC3_DISTRIBUTION = 5;
		public const int GC4_DISTRIBUTION = 6;
		public const int GC5_DISTRIBUTION = 7;
		public const int GC6_DISTRIBUTION = 8;
		public const int GC7_DISTRIBUTION = 9;
		public const int GC8_DISTRIBUTION = 10;
		public const int GC9_DISTRIBUTION = 11;

		private long? id;
		private ProjectTemplateTable projectTemplateTable;

		private string name;
		private string description;
		private int? sortOrder;
		private int? distributionType;
		private bool? balanced;
		private bool? distributed;
		private string targetField;
		private string targetCostField;
		private string distributionRanges;
		private string distributionRates;

		private bool? mapped;
		private int? sheetNo;
		private int? cellX;
		private int? cellY;
		private decimal storedValueNum;

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
		/// @hibernate.property column="NAME" type="costos_string" </summary>
		/// <returns> String </returns>
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
		/// @hibernate.property column="DESCRIPTION" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string Description
		{
			get
			{
				return description;
			}
			set
			{
				this.description = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SORTORDER" type="int" </summary>
		/// <returns> Integer </returns>
		public virtual int? SortOrder
		{
			get
			{
				return sortOrder;
			}
			set
			{
				this.sortOrder = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DISTTYPE" type="int" </summary>
		/// <returns> Integer </returns>
		public virtual int? DistributionType
		{
			get
			{
				return distributionType;
			}
			set
			{
				this.distributionType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="BALANCED" type="boolean" </summary>
		/// <returns> Integer </returns>
		public virtual bool? Balanced
		{
			get
			{
				return balanced;
			}
			set
			{
				this.balanced = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DSTRBTD" type="boolean" </summary>
		/// <returns> Integer </returns>
		public virtual bool? Distributed
		{
			get
			{
				return distributed;
			}
			set
			{
				this.distributed = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TARGETFIELD" type="costos_string" </summary>
		/// <returns> Integer </returns>
		public virtual string TargetField
		{
			get
			{
				return targetField;
			}
			set
			{
				this.targetField = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="TARGETCOSTFIELD" type="costos_string" </summary>
		/// <returns> Integer </returns>
		public virtual string TargetCostField
		{
			get
			{
				return targetCostField;
			}
			set
			{
				this.targetCostField = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="DISTRANGES" type="costos_text" </summary>
		/// <returns> Integer </returns>
		public virtual string DistributionRanges
		{
			get
			{
				return distributionRanges;
			}
			set
			{
				this.distributionRanges = value;
			}
		}



		/// <summary>
		/// @hibernate.property column="DISTRATES" type="costos_text" </summary>
		/// <returns> Integer </returns>
		public virtual string DistributionRates
		{
			get
			{
				return distributionRates;
			}
			set
			{
				this.distributionRates = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="MAPPED" type="boolean" </summary>
		/// <returns> Integer </returns>
		public virtual bool? Mapped
		{
			get
			{
				return mapped;
			}
			set
			{
				this.mapped = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SHEETNO" type="int" </summary>
		/// <returns> Integer </returns>
		public virtual int? SheetNo
		{
			get
			{
				return sheetNo;
			}
			set
			{
				this.sheetNo = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CELLX" type="int" </summary>
		/// <returns> Integer </returns>
		public virtual int? CellX
		{
			get
			{
				return cellX;
			}
			set
			{
				this.cellX = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="CELLY" type="int" </summary>
		/// <returns> Integer </returns>
		public virtual int? CellY
		{
			get
			{
				return cellY;
			}
			set
			{
				this.cellY = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="STOVALNUM" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> BigDecimal </returns>
		public virtual decimal StoredValueNum
		{
			get
			{
				return storedValueNum;
			}
			set
			{
				this.storedValueNum = value;
			}
		}

		public virtual RateDistributorTable Data
		{
			set
			{
				Name = value.Name;
				Description = value.Description;
				DistributionType = value.DistributionType;
				Balanced = value.Balanced;
				Distributed = value.Distributed;
				SortOrder = value.SortOrder;
				TargetField = value.TargetField;
				TargetCostField = value.TargetCostField;
				DistributionRanges = value.DistributionRanges;
				DistributionRates = value.DistributionRates;
				StoredValueNum = value.StoredValueNum;
				Mapped = value.Mapped;
				SheetNo = value.SheetNo;
				CellX = value.CellX;
				CellY = value.CellY;
			}
		}

		public virtual object clone()
		{
			RateDistributorTable dt = new RateDistributorTable();
			dt.Id = Id;
			dt.Data = this;
			dt.ProjectId = ProjectId;
			return dt;
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