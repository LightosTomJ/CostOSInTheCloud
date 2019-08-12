namespace Model.proj
{
	using BaseEntity = nomitech.common.@base.BaseEntity;
	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="XCELLFILE"
	/// hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	public class ProjectExcelFile : BaseEntity, ProjectIdEntity
	{

		private long? id;
		private sbyte[] excelFile;
		private ProjectTemplateTable projectTemplate;

		private int? sheetIndex;
		private int? cellX;
		private int? cellY;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="XCELLID" </summary>
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
		/// @hibernate.property column="XCELLFILE" type="binary" length="73741824" </summary>
		/// <returns> description </returns>
		public virtual sbyte[] ExcelFile
		{
			get
			{
				return excelFile;
			}
			set
			{
				this.excelFile = value;
			}
		}

		/// <summary>
		/// @hibernate.one-to-one
		/// 	cascade="save-update"
		/// </summary>
		public virtual ProjectTemplateTable ProjectTemplate
		{
			get
			{
				return projectTemplate;
			}
			set
			{
				this.projectTemplate = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SHEET" type="int" </summary>
		/// <returns> description </returns>
		public virtual int? SheetIndex
		{
			get
			{
				return sheetIndex;
			}
			set
			{
				this.sheetIndex = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="CELLX" type="int" </summary>
		/// <returns> description </returns>
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
		/// <returns> description </returns>
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

		public virtual object clone()
		{
			ProjectExcelFile pexcelFile = new ProjectExcelFile();

			pexcelFile.Id = Id;
			//pexcelFile.setExcelFile(Arrays.copyOf(getExcelFile(), getExcelFile().length));
			pexcelFile.ExcelFile = ExcelFile;
			pexcelFile.SheetIndex = SheetIndex;
			pexcelFile.CellX = CellX;
			pexcelFile.CellY = CellY;
			pexcelFile.ProjectId = ProjectId;
			return pexcelFile;
		}

		public virtual ProjectExcelFile Data
		{
			set
			{
				//setId(value.getId());
				//setExcelFile(Arrays.copyOf(getExcelFile(), getExcelFile().length));
				ExcelFile = value.ExcelFile;
				SheetIndex = value.SheetIndex;
				CellX = value.CellX;
				CellY = value.CellY;
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