using System;
using System.Collections.Generic;

namespace Models.local
{

	//#RXP_START
	/// <summary>
	/// @author: George Hatzisymeon
	/// 
	/// 
	/// @hibernate.class table="FILTRO"
	/// 
	/// </summary>
	//#RXP_END
	[Serializable]
	public class FilterTable
	{

		private long? _primaryKey = null;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="FILTROID" </summary>
		/// <returns> Long </returns>
		public virtual long? FilterId
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


		private DateTime lastUpdate = null;
		/// <summary>
		/// @hibernate.property column="LASTUPDATE" type="timestamp" </summary>
		/// <returns> lastUpdate </returns>
		public virtual DateTime LastUpdate
		{
			get
			{
				return lastUpdate;
			}
			set
			{
				lastUpdate = value;
			}
		}

		private string filterName = null;

		/// <summary>
		/// @hibernate.property column="FILTRONAME" type="costos_string" </summary>
		/// <returns> Returns the filterName. </returns>
		public virtual string FilterName
		{
			get
			{
				return filterName;
			}
			set
			{
				this.filterName = value;
			}
		}

		private string filterType = null;
		/// <summary>
		/// @hibernate.property column="FILTROTYPE" type="costos_string" </summary>
		/// <returns> Returns the filterType. </returns>
		public virtual string FilterType
		{
			get
			{
				return filterType;
			}
			set
			{
				this.filterType = value;
			}
		}

		private string filterDescription = null;
		/// <summary>
		/// @hibernate.property column="FILTRODESCRIPTION" type="costos_string" </summary>
		/// <returns> Returns the filterDescription. </returns>
		public virtual string FilterDescription
		{
			get
			{
				return filterDescription;
			}
			set
			{
				this.filterDescription = value;
			}
		}

		public virtual object clone()
		{
			FilterTable o = new FilterTable();

			o.FilterId = FilterId;
			o.FilterDescription = FilterDescription;
			o.FilterName = FilterName;
			o.FilterType = FilterType;
			o.LastUpdate = LastUpdate;

			return o;
		}

		public virtual FilterTable copyWithProperties()
		{
			FilterTable o = new FilterTable();

			o.FilterId = FilterId;
			o.FilterDescription = FilterDescription;
			o.FilterName = FilterName;
			o.FilterType = FilterType;
			o.LastUpdate = LastUpdate;

			o.filterPropertyList = new List<FilterPropertyTable>();

			if (FilterPropertyList != null)
			{

				IEnumerator<FilterPropertyTable> iter = FilterPropertyList.GetEnumerator();
				while (iter.MoveNext())
				{
					o.filterPropertyList.Add((FilterPropertyTable)iter.Current.clone());
				}
			}
			return o;
		}

		private IList<FilterPropertyTable> filterPropertyList = new List<FilterPropertyTable>(0);

		/// <summary>
		/// @hibernate.list  
		///  cascade="all-delete-orphan"
		/// @hibernate.key
		///  column="FILTROID"
		/// @hibernate.list-index
		///  column="FILTROPROPERTIESCOUNT"
		/// @hibernate.one-to-many
		///  class="nomitech.common.db.local.FilterPropertyTable" </summary>
		/// <returns> List </returns>
		public virtual IList<FilterPropertyTable> FilterPropertyList
		{
			get
			{
				return filterPropertyList;
			}
			set
			{
				this.filterPropertyList = value;
			}
		}

		public virtual FilterTable Data
		{
			set
			{
    
				//setFilterId(value.getFilterId());
				FilterDescription = value.FilterDescription;
				FilterName = value.FilterName;
				FilterType = value.FilterType;
				LastUpdate = value.LastUpdate;
			}
		}
	}
}