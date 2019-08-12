using System;

namespace Model.proj
{

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="WSFILE"
	/// hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class WorksheetFileTable : ProjectIdEntity
	{

		private long? id;
		private string fileName;
		private string filePath;
		private sbyte[] excelFile;
		private string activeSheets;
		private int? numberOfSheets;
		private bool? xmlFile;
		private WorksheetRevisionTable worksheetRevision;
		private bool? tcmFile;

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

		public virtual WorksheetFileTable Data
		{
			set
			{
				FileName = value.FileName;
				FilePath = value.FilePath;
				NumberOfSheets = value.NumberOfSheets;
				ExcelFile = value.ExcelFile;
				ActiveSheets = value.ActiveSheets;
				XmlFile = value.XmlFile;
				TcmFile = value.TcmFile;
			}
		}

		public virtual object clone()
		{
			WorksheetFileTable fTable = new WorksheetFileTable();

			fTable.Id = Id;
			fTable.Data = this;
			fTable.ProjectId = ProjectId;

			return fTable;
		}

		/// <summary>
		/// @hibernate.property column="XMLFILE" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? XmlFile
		{
			get
			{
				return xmlFile;
			}
			set
			{
				this.xmlFile = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="TITLE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string FileName
		{
			get
			{
				return fileName;
			}
			set
			{
				this.fileName = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FPATH" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string FilePath
		{
			get
			{
				return filePath;
			}
			set
			{
				this.filePath = value;
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
		/// @hibernate.property column="NUMSHEETS" type="int" </summary>
		/// <returns> description </returns>
		public virtual int? NumberOfSheets
		{
			get
			{
				return numberOfSheets;
			}
			set
			{
				this.numberOfSheets = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="FILEREVID"
		/// </summary>
		/// <returns> WorksheetRevisionTable </returns>
		public virtual WorksheetRevisionTable WorksheetRevision
		{
			get
			{
				return worksheetRevision;
			}
			set
			{
				this.worksheetRevision = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ACTSHEETS" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ActiveSheets
		{
			get
			{
				return activeSheets;
			}
			set
			{
				this.activeSheets = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="TCMFILE" type="boolean" </summary>
		/// <returns> Boolean </returns>
		public virtual bool? TcmFile
		{
			get
			{
				return tcmFile;
			}
			set
			{
				this.tcmFile = value;
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