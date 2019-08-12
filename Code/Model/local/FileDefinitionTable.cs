using System;

namespace Model.local
{
	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="FLDFN"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class FileDefinitionTable
	{

		public const string ICON_TYPE = "icon";
		public const string JRXML_TYPE = "jrxml";
		public const string IMAGE_TYPE = "image";

		private long? id;
		private string type;
		private string path;
		private string name;

		private ReportDefinitionTable reportDefinitionTable;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="FLDFNID" </summary>
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
		/// Description Here
		/// 
		/// @hibernate.property column="FTYPE" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Type
		{
			get
			{
				return type;
			}
			set
			{
				this.type = value;
			}
		}

		/// <summary>
		/// Description Here
		/// 
		/// @hibernate.property column="FPATH" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string Path
		{
			get
			{
				return path;
			}
			set
			{
				this.path = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="RPDFNID" </summary>
		/// <returns> ReportDefinitionTable </returns>
		public virtual ReportDefinitionTable ReportDefinitionTable
		{
			get
			{
				return reportDefinitionTable;
			}
			set
			{
				this.reportDefinitionTable = value;
			}
		}

		public virtual object clone()
		{
			FileDefinitionTable defTable = new FileDefinitionTable();
			defTable.Id = Id;
			defTable.Type = Type;
			defTable.Path = Path;
			defTable.Name = Path;

			return defTable;
		}

		public virtual FileDefinitionTable Data
		{
			set
			{
    
				Id = value.Id;
				Type = value.Type;
				Path = value.Path;
				Name = value.Name;
			}
		}

		public virtual FileDefinitionTable copyWithReportDefinitionTable()
		{
			FileDefinitionTable obj = (FileDefinitionTable)clone();
			if (ReportDefinitionTable != null)
			{
				obj.ReportDefinitionTable = (ReportDefinitionTable) ReportDefinitionTable.clone();
			}
			return obj;
		}
	}
}