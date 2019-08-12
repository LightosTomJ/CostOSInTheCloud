using System;

namespace Model.proj
{

	using ProjectIdEntity = nomitech.common.@base.ProjectIdEntity;


	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="RATEBUILDUPCOLS"
	/// @hibernate.cache usage="nonstrict-read-write"
	/// </summary>
	[Serializable]
	public class RateBuildUpColumnsTable : ProjectIdEntity
	{

		public const int? ADDITION_NUMBER = 0;
		public const int? MULTIPLIER_PERCENTAGE = 1;
		public const int? SUBTRACT_NUMBER = 2;
		public const int? MULTIPLIER_NUMBER = 3;
		public const int? DIVIDER_NUMBER = 4;
		public const int? ADDITION_SOFAR_NUMBER = 5;
		public const int? SUBTRACT_SOFAR_NUMBER = 6;
		public const int? MULTIPLIER_SOFAR_NUMBER = 7;
		public const int? DIVIDER_SOFAR_NUMBER = 8;


		private long? id;
		private string resourceType;
		private string rowFormula;
		private string columnName0;
		private int? columnType0;
		private bool? columnActive0;
		private string columnFormula0;
		private string columnName1;
		private int? columnType1;
		private bool? columnActive1;
		private string columnFormula1;
		private string columnName2;
		private int? columnType2;
		private bool? columnActive2;
		private string columnFormula2;
		private string columnName3;
		private int? columnType3;
		private bool? columnActive3;
		private string columnFormula3;
		private string columnName4;
		private int? columnType4;
		private bool? columnActive4;
		private string columnFormula4;
		private string columnName5;
		private int? columnType5;
		private bool? columnActive5;
		private string columnFormula5;
		private string columnName6;
		private int? columnType6;
		private bool? columnActive6;
		private string columnFormula6;
		private string columnName7;
		private int? columnType7;
		private bool? columnActive7;
		private string columnFormula7;
		private string columnName8;
		private int? columnType8;
		private bool? columnActive8;
		private string columnFormula8;
		private string columnName9;
		private int? columnType9;
		private bool? columnActive9;
		private string columnFormula9;
		private string columnName10;
		private int? columnType10;
		private bool? columnActive10;
		private string columnFormula10;
		private string columnName11;
		private int? columnType11;
		private bool? columnActive11;
		private string columnFormula11;
		private string columnName12;
		private int? columnType12;
		private bool? columnActive12;
		private string columnFormula12;
		private string columnName13;
		private int? columnType13;
		private bool? columnActive13;
		private string columnFormula13;
		private string columnName14;
		private int? columnType14;
		private bool? columnActive14;
		private string columnFormula14;

		private decimal columnValue0;
		private decimal columnValue1;
		private decimal columnValue2;
		private decimal columnValue3;
		private decimal columnValue4;
		private decimal columnValue5;
		private decimal columnValue6;
		private decimal columnValue7;
		private decimal columnValue8;
		private decimal columnValue9;
		private decimal columnValue10;
		private decimal columnValue11;
		private decimal columnValue12;
		private decimal columnValue13;
		private decimal columnValue14;

		private bool? applyToEveryResource;
		private string tablePreference;
		private string sortablePreference;
		private ProjectTemplateTable projectTemplateTable;

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

		public virtual RateBuildUpColumnsTable Data
		{
			set
			{
				ResourceType = value.ResourceType;
    
				TablePreference = value.TablePreference;
				SortablePreference = value.SortablePreference;
				ApplyToEveryResource = value.ApplyToEveryResource;
    
				ColumnName0 = value.ColumnName0;
				ColumnType0 = value.ColumnType0;
				ColumnFormula0 = value.ColumnFormula0;
				ColumnActive0 = value.ColumnActive0;
				ColumnValue0 = value.ColumnValue0;
    
				ColumnName1 = value.ColumnName1;
				ColumnType1 = value.ColumnType1;
				ColumnFormula1 = value.ColumnFormula1;
				ColumnActive1 = value.ColumnActive1;
				ColumnValue1 = value.ColumnValue1;
    
				ColumnName2 = value.ColumnName2;
				ColumnType2 = value.ColumnType2;
				ColumnFormula2 = value.ColumnFormula2;
				ColumnActive2 = value.ColumnActive2;
				ColumnValue2 = value.ColumnValue2;
    
				ColumnName3 = value.ColumnName3;
				ColumnType3 = value.ColumnType3;
				ColumnFormula3 = value.ColumnFormula3;
				ColumnActive3 = value.ColumnActive3;
				ColumnValue3 = value.ColumnValue3;
    
				ColumnName4 = value.ColumnName4;
				ColumnType4 = value.ColumnType4;
				ColumnFormula4 = value.ColumnFormula4;
				ColumnActive4 = value.ColumnActive4;
				ColumnValue4 = value.ColumnValue4;
    
				ColumnName5 = value.ColumnName5;
				ColumnType5 = value.ColumnType5;
				ColumnFormula5 = value.ColumnFormula5;
				ColumnActive5 = value.ColumnActive5;
				ColumnValue5 = value.ColumnValue5;
    
				ColumnName6 = value.ColumnName6;
				ColumnType6 = value.ColumnType6;
				ColumnFormula6 = value.ColumnFormula6;
				ColumnActive6 = value.ColumnActive6;
				ColumnValue6 = value.ColumnValue6;
    
				ColumnName7 = value.ColumnName7;
				ColumnType7 = value.ColumnType7;
				ColumnFormula7 = value.ColumnFormula7;
				ColumnActive7 = value.ColumnActive7;
				ColumnValue7 = value.ColumnValue7;
    
				ColumnName8 = value.ColumnName8;
				ColumnType8 = value.ColumnType8;
				ColumnFormula8 = value.ColumnFormula8;
				ColumnActive8 = value.ColumnActive8;
				ColumnValue8 = value.ColumnValue8;
    
				ColumnName9 = value.ColumnName9;
				ColumnType9 = value.ColumnType9;
				ColumnFormula9 = value.ColumnFormula9;
				ColumnActive9 = value.ColumnActive9;
				ColumnValue9 = value.ColumnValue9;
    
				ColumnName10 = value.ColumnName10;
				ColumnType10 = value.ColumnType10;
				ColumnFormula10 = value.ColumnFormula10;
				ColumnActive10 = value.ColumnActive10;
				ColumnValue10 = value.ColumnValue10;
    
				ColumnName11 = value.ColumnName11;
				ColumnType11 = value.ColumnType11;
				ColumnFormula11 = value.ColumnFormula11;
				ColumnActive11 = value.ColumnActive11;
				ColumnValue11 = value.ColumnValue11;
    
				ColumnName12 = value.ColumnName12;
				ColumnType12 = value.ColumnType12;
				ColumnFormula12 = value.ColumnFormula12;
				ColumnActive12 = value.ColumnActive12;
				ColumnValue12 = value.ColumnValue12;
    
				ColumnName13 = value.ColumnName13;
				ColumnType13 = value.ColumnType13;
				ColumnFormula13 = value.ColumnFormula13;
				ColumnActive13 = value.ColumnActive13;
				ColumnValue13 = value.ColumnValue13;
    
				ColumnName14 = value.ColumnName14;
				ColumnType14 = value.ColumnType14;
				ColumnFormula14 = value.ColumnFormula14;
				ColumnActive14 = value.ColumnActive14;
				ColumnValue14 = value.ColumnValue14;
    
				RowFormula = value.RowFormula;
			}
		}

		public virtual object clone()
		{
			RateBuildUpColumnsTable o = new RateBuildUpColumnsTable();
			o.Data = this;
			o.Id = Id;
			o.ProjectId = ProjectId;
			return o;
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
		/// @hibernate.property column="RESTYPE" type="costos_text" </summary>
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
		/// @hibernate.property column="TABLEPREF" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string TablePreference
		{
			get
			{
				return tablePreference;
			}
			set
			{
				this.tablePreference = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SORTPREF" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string SortablePreference
		{
			get
			{
				return sortablePreference;
			}
			set
			{
				this.sortablePreference = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="APPLYALL" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ApplyToEveryResource
		{
			get
			{
				return applyToEveryResource;
			}
			set
			{
				this.applyToEveryResource = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ROWFORMULA" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string RowFormula
		{
			get
			{
				return rowFormula;
			}
			set
			{
				this.rowFormula = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME0" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName0
		{
			get
			{
				return columnName0;
			}
			set
			{
				this.columnName0 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLTYPE0" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType0
		{
			get
			{
				return columnType0;
			}
			set
			{
				this.columnType0 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT0" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive0
		{
			get
			{
				return columnActive0;
			}
			set
			{
				this.columnActive0 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM0" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula0
		{
			get
			{
				return columnFormula0;
			}
			set
			{
				this.columnFormula0 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME1" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName1
		{
			get
			{
				return columnName1;
			}
			set
			{
				this.columnName1 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLTYPE1" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType1
		{
			get
			{
				return columnType1;
			}
			set
			{
				this.columnType1 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT1" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive1
		{
			get
			{
				return columnActive1;
			}
			set
			{
				this.columnActive1 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM1" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula1
		{
			get
			{
				return columnFormula1;
			}
			set
			{
				this.columnFormula1 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME2" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName2
		{
			get
			{
				return columnName2;
			}
			set
			{
				this.columnName2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLTYPE2" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType2
		{
			get
			{
				return columnType2;
			}
			set
			{
				this.columnType2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT2" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive2
		{
			get
			{
				return columnActive2;
			}
			set
			{
				this.columnActive2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM2" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula2
		{
			get
			{
				return columnFormula2;
			}
			set
			{
				this.columnFormula2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME3" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName3
		{
			get
			{
				return columnName3;
			}
			set
			{
				this.columnName3 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLTYPE3" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType3
		{
			get
			{
				return columnType3;
			}
			set
			{
				this.columnType3 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT3" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive3
		{
			get
			{
				return columnActive3;
			}
			set
			{
				this.columnActive3 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM3" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula3
		{
			get
			{
				return columnFormula3;
			}
			set
			{
				this.columnFormula3 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME4" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName4
		{
			get
			{
				return columnName4;
			}
			set
			{
				this.columnName4 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLTYPE4" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType4
		{
			get
			{
				return columnType4;
			}
			set
			{
				this.columnType4 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT4" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive4
		{
			get
			{
				return columnActive4;
			}
			set
			{
				this.columnActive4 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM4" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula4
		{
			get
			{
				return columnFormula4;
			}
			set
			{
				this.columnFormula4 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME5" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName5
		{
			get
			{
				return columnName5;
			}
			set
			{
				this.columnName5 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLTYPE5" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType5
		{
			get
			{
				return columnType5;
			}
			set
			{
				this.columnType5 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT5" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive5
		{
			get
			{
				return columnActive5;
			}
			set
			{
				this.columnActive5 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM5" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula5
		{
			get
			{
				return columnFormula5;
			}
			set
			{
				this.columnFormula5 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME6" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName6
		{
			get
			{
				return columnName6;
			}
			set
			{
				this.columnName6 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLTYPE6" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType6
		{
			get
			{
				return columnType6;
			}
			set
			{
				this.columnType6 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT6" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive6
		{
			get
			{
				return columnActive6;
			}
			set
			{
				this.columnActive6 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM6" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula6
		{
			get
			{
				return columnFormula6;
			}
			set
			{
				this.columnFormula6 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME7" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName7
		{
			get
			{
				return columnName7;
			}
			set
			{
				this.columnName7 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLTYPE7" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType7
		{
			get
			{
				return columnType7;
			}
			set
			{
				this.columnType7 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT7" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive7
		{
			get
			{
				return columnActive7;
			}
			set
			{
				this.columnActive7 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM7" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula7
		{
			get
			{
				return columnFormula7;
			}
			set
			{
				this.columnFormula7 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME8" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName8
		{
			get
			{
				return columnName8;
			}
			set
			{
				this.columnName8 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLTYPE8" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType8
		{
			get
			{
				return columnType8;
			}
			set
			{
				this.columnType8 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT8" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive8
		{
			get
			{
				return columnActive8;
			}
			set
			{
				this.columnActive8 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM8" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula8
		{
			get
			{
				return columnFormula8;
			}
			set
			{
				this.columnFormula8 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME9" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName9
		{
			get
			{
				return columnName9;
			}
			set
			{
				this.columnName9 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLTYPE9" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType9
		{
			get
			{
				return columnType9;
			}
			set
			{
				this.columnType9 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT9" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive9
		{
			get
			{
				return columnActive9;
			}
			set
			{
				this.columnActive9 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM9" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula9
		{
			get
			{
				return columnFormula9;
			}
			set
			{
				this.columnFormula9 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME10" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName10
		{
			get
			{
				return columnName10;
			}
			set
			{
				this.columnName10 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLTYPE10" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType10
		{
			get
			{
				return columnType10;
			}
			set
			{
				this.columnType10 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT10" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive10
		{
			get
			{
				return columnActive10;
			}
			set
			{
				this.columnActive10 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM10" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula10
		{
			get
			{
				return columnFormula10;
			}
			set
			{
				this.columnFormula10 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME11" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName11
		{
			get
			{
				return columnName11;
			}
			set
			{
				this.columnName11 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLTYPE11" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType11
		{
			get
			{
				return columnType11;
			}
			set
			{
				this.columnType11 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT11" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive11
		{
			get
			{
				return columnActive11;
			}
			set
			{
				this.columnActive11 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM11" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula11
		{
			get
			{
				return columnFormula11;
			}
			set
			{
				this.columnFormula11 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME12" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName12
		{
			get
			{
				return columnName12;
			}
			set
			{
				this.columnName12 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLTYPE12" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType12
		{
			get
			{
				return columnType12;
			}
			set
			{
				this.columnType12 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT12" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive12
		{
			get
			{
				return columnActive12;
			}
			set
			{
				this.columnActive12 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM12" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula12
		{
			get
			{
				return columnFormula12;
			}
			set
			{
				this.columnFormula12 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME13" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName13
		{
			get
			{
				return columnName13;
			}
			set
			{
				this.columnName13 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLTYPE13" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType13
		{
			get
			{
				return columnType13;
			}
			set
			{
				this.columnType13 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT13" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive13
		{
			get
			{
				return columnActive13;
			}
			set
			{
				this.columnActive13 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM13" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula13
		{
			get
			{
				return columnFormula13;
			}
			set
			{
				this.columnFormula13 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLNAME14" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnName14
		{
			get
			{
				return columnName14;
			}
			set
			{
				this.columnName14 = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="COLTYPE14" type="int" </summary>
		/// <returns> String </returns>
		public virtual int? ColumnType14
		{
			get
			{
				return columnType14;
			}
			set
			{
				this.columnType14 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLACT14" type="boolean" </summary>
		/// <returns> String </returns>
		public virtual bool? ColumnActive14
		{
			get
			{
				return columnActive14;
			}
			set
			{
				this.columnActive14 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLFORM14" type="costos_text" </summary>
		/// <returns> String </returns>
		public virtual string ColumnFormula14
		{
			get
			{
				return columnFormula14;
			}
			set
			{
				this.columnFormula14 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL0" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue0
		{
			get
			{
				return columnValue0;
			}
			set
			{
				this.columnValue0 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL1" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue1
		{
			get
			{
				return columnValue1;
			}
			set
			{
				this.columnValue1 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL2" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue2
		{
			get
			{
				return columnValue2;
			}
			set
			{
				this.columnValue2 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL3" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue3
		{
			get
			{
				return columnValue3;
			}
			set
			{
				this.columnValue3 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL4" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue4
		{
			get
			{
				return columnValue4;
			}
			set
			{
				this.columnValue4 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL5" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue5
		{
			get
			{
				return columnValue5;
			}
			set
			{
				this.columnValue5 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL6" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue6
		{
			get
			{
				return columnValue6;
			}
			set
			{
				this.columnValue6 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL7" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue7
		{
			get
			{
				return columnValue7;
			}
			set
			{
				this.columnValue7 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL8" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue8
		{
			get
			{
				return columnValue8;
			}
			set
			{
				this.columnValue8 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL9" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue9
		{
			get
			{
				return columnValue9;
			}
			set
			{
				this.columnValue9 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL10" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue10
		{
			get
			{
				return columnValue10;
			}
			set
			{
				this.columnValue10 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL11" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue11
		{
			get
			{
				return columnValue11;
			}
			set
			{
				this.columnValue11 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL12" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue12
		{
			get
			{
				return columnValue12;
			}
			set
			{
				this.columnValue12 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL13" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue13
		{
			get
			{
				return columnValue13;
			}
			set
			{
				this.columnValue13 = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLDEFVAL14" type="big_decimal" precision="30" scale="10" </summary>
		/// <returns> String </returns>
		public virtual decimal ColumnValue14
		{
			get
			{
				return columnValue14;
			}
			set
			{
				this.columnValue14 = value;
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