using System;

namespace Models.proj
{

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceHistoryTable = nomitech.common.@base.ResourceHistoryTable;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using LaborTable = nomitech.common.db.local.LaborTable;
	//#RXL_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="LABHISTORY"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	public class LaborHistoryTable : ResourceHistoryTable, ProjectIdEntity
	{

		private long? laborHistoryId;
		private string baseTableId;
		private string resource;
		private DateTime predictionDate;
		private LaborTable laborTable;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="ID" </summary>
		/// <returns> Long </returns>
		public virtual long? LaborHistoryId
		{
			get
			{
				return laborHistoryId;
			}
			set
			{
				this.laborHistoryId = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="LABORID" </summary>
		/// <returns> LaborTable </returns>
		public virtual LaborTable LaborTable
		{
			get
			{
				return laborTable;
			}
			set
			{
				this.laborTable = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="BASETABLEID" type="costos_string" </summary>
		/// <returns> editorId </returns>
		public override string BaseTableId
		{
			get
			{
				return baseTableId;
			}
			set
			{
				this.baseTableId = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="RSRC" type="costos_text" </summary>
		/// <returns> editorId </returns>
		public override string Resource
		{
			get
			{
				return resource;
			}
			set
			{
				this.resource = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="PREDDATE" type="timestamp" </summary>
		/// <returns> editorId </returns>
		public override DateTime PredictionDate
		{
			get
			{
				return predictionDate;
			}
			set
			{
				this.predictionDate = value;
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override @Transient public nomitech.common.base.ResourceTable getResourceTable()
		public override ResourceTable ResourceTable
		{
			get
			{
				return LaborTable;
			}
			set
			{
				LaborTable = (LaborTable) value;
			}
		}

		public override object clone()
		{
			LaborHistoryTable result = new LaborHistoryTable();
			result.LaborHistoryId = LaborHistoryId;
			result.BaseTableId = BaseTableId;
			result.PredictionDate = PredictionDate;
			result.Resource = Resource;
			result.ProjectId = ProjectId;
			return result;
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