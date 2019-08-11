using System;

namespace Models.proj
{

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;

	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// @hibernate.class table="WSCOLIDENT"
	/// hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class WorksheetIdentifyColumnTable : IComparable<WorksheetIdentifyColumnTable>, ProjectIdEntity
	{
		public const int? COLUMN_TYPE_INCOMING = 0;
		public const int? COLUMN_TYPE_OUTGOING = 1;

		public const int? FIELD_TYPE_TEXT = 0; // No Validation
		public const int? FIELD_TYPE_NUMBER = 1; // Validation to Number
		public const int? FIELD_TYPE_GROUPCODE = 2; // Validation to Group Code
		public const int? FIELD_TYPE_UNIT = 3; // Validation to Unit

		public const int? ACTION_ACCEPT = 0;
		public const int? ACTION_REJECT = 1;
		public const int? ACTION_CONCATENATE = 2;
		public const int? ACTION_SPLIT_NON_ENGLISH = 3;

		private long? id;
		private string fieldName;
		private int? columnIndex;
		private int? fieldType;
		private string fieldMap;

		private int? columnType;
		private int? mapAction;
		private string splitField;
		private bool? mappedForUniqueness;
		private bool? prefixSheetNameForUniqueness;
		private bool? prefixFileNameForUniqueness;
		private bool? excludeAutoMatch;

		private WorksheetDataMappingTable dataMapping;

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


		public virtual WorksheetIdentifyColumnTable Data
		{
			set
			{
				FieldName = value.FieldName;
				FieldType = value.FieldType;
				FieldMap = value.FieldMap;
				ColumnIndex = value.ColumnIndex;
				ColumnType = value.ColumnType;
				MapAction = value.MapAction;
				SplitField = value.SplitField;
				MappedForUniqueness = value.MappedForUniqueness;
				PrefixFileNameForUniqueness = value.PrefixFileNameForUniqueness;
				PrefixSheetNameForUniqueness = value.PrefixSheetNameForUniqueness;
				ExcludeAutoMatch = value.ExcludeAutoMatch;
			}
		}

		public virtual object clone()
		{
			WorksheetIdentifyColumnTable o = new WorksheetIdentifyColumnTable();
			o.Id = Id;
			o.Data = this;
			o.ProjectId = ProjectId;
			return o;
		}

		/// <summary>
		/// @hibernate.property column="SPLITFIELD" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string SplitField
		{
			get
			{
				return splitField;
			}
			set
			{
				this.splitField = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="MUNIQUE" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? MappedForUniqueness
		{
			get
			{
				return mappedForUniqueness;
			}
			set
			{
				this.mappedForUniqueness = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SHEETPREFIX" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? PrefixSheetNameForUniqueness
		{
			get
			{
				return prefixSheetNameForUniqueness;
			}
			set
			{
				this.prefixSheetNameForUniqueness = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FILEPREFIX" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? PrefixFileNameForUniqueness
		{
			get
			{
				return prefixFileNameForUniqueness;
			}
			set
			{
				this.prefixFileNameForUniqueness = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="EXAUMA" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ExcludeAutoMatch
		{
			get
			{
				return excludeAutoMatch;
			}
			set
			{
				this.excludeAutoMatch = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLTYPE" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType
		{
			get
			{
				return columnType;
			}
			set
			{
				this.columnType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="MAPACTION" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? MapAction
		{
			get
			{
				return mapAction;
			}
			set
			{
				this.mapAction = value;
			}
		}



		/// <summary>
		/// @hibernate.property column="FLDNAME" type="costos_string" </summary>
		/// <returns> String </returns>
		public virtual string FieldName
		{
			get
			{
				return fieldName;
			}
			set
			{
				this.fieldName = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLINDEX" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnIndex
		{
			get
			{
				return columnIndex;
			}
			set
			{
				this.columnIndex = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FLDTYPE" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? FieldType
		{
			get
			{
				return fieldType;
			}
			set
			{
				this.fieldType = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="FIELDMAP" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string FieldMap
		{
			get
			{
				return fieldMap;
			}
			set
			{
				this.fieldMap = value;
			}
		}


		/// <summary>
		/// @hibernate.many-to-one
		///  column="MAPPINGID" </summary>
		/// <returns> ParamItemTable </returns>
		public virtual WorksheetDataMappingTable DataMapping
		{
			get
			{
				return dataMapping;
			}
			set
			{
				this.dataMapping = value;
			}
		}


		public virtual int CompareTo(WorksheetIdentifyColumnTable o)
		{
			return columnIndex.compareTo(o.columnIndex);
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