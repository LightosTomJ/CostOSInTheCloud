using System;

namespace Model.proj
{

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;
	using ResourceHistoryTable = nomitech.common.@base.ResourceHistoryTable;
	using ResourceTable = nomitech.common.@base.ResourceTable;
	using MaterialTable = nomitech.common.db.local.MaterialTable;
	//#RXL_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="MATHISTORY"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXL_END
	public class MaterialHistoryTable : ResourceHistoryTable, ProjectIdEntity
	{

		private long? materialHistoryId;
		private string baseTableId;
		private string resource;
		private DateTime predictionDate;
		private MaterialTable materialTable;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="ID" </summary>
		/// <returns> Long </returns>
		public virtual long? MaterialHistoryId
		{
			get
			{
				return materialHistoryId;
			}
			set
			{
				this.materialHistoryId = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="MATERIALID" </summary>
		/// <returns> MaterialTable </returns>
		public virtual MaterialTable MaterialTable
		{
			get
			{
				return materialTable;
			}
			set
			{
				this.materialTable = value;
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
				return MaterialTable;
			}
			set
			{
				MaterialTable = (MaterialTable) value;
			}
		}

		public override object clone()
		{
			MaterialHistoryTable result = new MaterialHistoryTable();
			result.MaterialHistoryId = MaterialHistoryId;
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