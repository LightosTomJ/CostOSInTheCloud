using System;

/*
 * Created on 14 ��� 2005
 *
 * TODO To change the template for this generated file go to
 * Window - Preferences - Java - Code Style - Code Templates
 */
namespace Model.local
{

	//#RXP_START
	/// <summary>
	/// @author george
	/// 
	/// @hibernate.class table="FILTROPROPERTY"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class FilterPropertyTable
	{
		private long? _primaryKey = null;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="FILTROPROPERTYID" </summary>
		/// <returns> Long </returns>
		public virtual long? FilterPropertyId
		{
			get
			{
				return _primaryKey;
			}
			set
			{
				_primaryKey = value;
			}
		}


		private bool? use = null;
		/// <summary>
		/// @hibernate.property column="USED" type="boolean" </summary>
		/// <returns> Returns the use. </returns>
		public virtual bool? Use
		{
			get
			{
				return use;
			}
			set
			{
				this.use = value;
			}
		}

		private string useType;
		public const string AND_USE_TYPE = "AND";
		public const string NOT_USE_TYPE = "NOT";
		public const string OR_USE_TYPE = "OR";

		/// <summary>
		/// @hibernate.property column="USETYPE" type="costos_string" </summary>
		/// <returns> Returns the field. </returns>
		public virtual string UseType
		{
			get
			{
				return useType;
			}
			set
			{
				this.useType = value;
			}
		}


		private string field = null;
		/// <summary>
		/// @hibernate.property column="FIELD" type="costos_string" </summary>
		/// <returns> Returns the field. </returns>
		public virtual string Field
		{
			get
			{
				return field;
			}
			set
			{
				this.field = value;
			}
		}

		private string restriction = null;
		/// <summary>
		/// @hibernate.property column="RESTRICTION" type="costos_string" </summary>
		/// <returns> Returns the restriction. </returns>
		public virtual string Restriction
		{
			get
			{
				return restriction;
			}
			set
			{
				this.restriction = value;
			}
		}

		public virtual object clone()
		{
			FilterPropertyTable o = new FilterPropertyTable();

			o.FilterPropertyId = FilterPropertyId;
			o.Field = System.Reflection.FieldInfo;
			o.Restriction = Restriction;
			o.Use = Use;
			o.UseType = UseType;

			return o;
		}

		public virtual FilterPropertyTable copyWithFilterTable()
		{
			FilterPropertyTable o = (FilterPropertyTable)clone();

			if (FilterTable != null)
			{
				o.FilterTable = (FilterTable)FilterTable.clone();
			}
			return o;
		}

		private FilterTable filterTable = null;
		/// <summary>
		/// @hibernate.many-to-one
		///  column="FILTROID" </summary>
		/// <returns> FilterTable </returns>
		public virtual FilterTable FilterTable
		{
			get
			{
				return filterTable;
			}
			set
			{
				this.filterTable = value;
			}
		}

		public virtual FilterPropertyTable Data
		{
			set
			{
				FilterPropertyId = value.FilterPropertyId;
				Field = value.Field;
				Restriction = value.Restriction;
				Use = value.Use;
				UseType = value.UseType;
			}
		}
	}

}