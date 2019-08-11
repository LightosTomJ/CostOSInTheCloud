using System;

namespace nomitech.common.db.layout
{

	//#RXP_START
	/// <summary>
	/// @author george
	/// 
	/// @hibernate.class table="LAYOUTCPANEL"
	/// </summary>
	//#RXP_END
	[Serializable]
	public class LayoutPanelTable
	{

		private long? layoutPanelId;

		private string columnsPreference;
		private string lockedColumns;
		private string dockingState;
		private string sortablePreference;
		private string filtersPreference;
		private bool? headerAutoresize;
		private bool? enableFilters;
		private int? headerRowHeight;
		private bool? showsAssignments;
		private bool? showsSideBar;
		private bool? showsVisualizer;
		private string selectedVisualizer;
		private bool? showingExtraLevel;
		private bool? enableGrouping; // Column Grouping
		private bool? displayGrouping; // Show Groups in Columns
		private string groupedColumns;
		private string groupedColumnOrders;
		private bool? visible;

		// Old Columns that shall be removed
		private string columns;
		private string columnWidths;
		private bool? sortTypeUp;
		private int? sortIndex;

		private LayoutTable layoutTable;

		/// <summary>
		/// @hibernate.id generator-class="native" 
		///               unsaved-value="null"
		///               column="LAYOUTCPANELID" </summary>
		/// <returns> Long </returns>
		public virtual long? LayoutPanelId
		{
			get
			{
				return layoutPanelId;
			}
			set
			{
				this.layoutPanelId = value;
			}
		}

		/// <summary>
		/// @hibernate.many-to-one
		///  column="LAYOUTCID" </summary>
		/// <returns> LayoutTable </returns>
		public virtual LayoutTable LayoutTable
		{
			get
			{
				return layoutTable;
			}
			set
			{
				this.layoutTable = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="PREFCOLS" type="costos_text" </summary>
		/// <returns> Returns the type. </returns>
		public virtual string ColumnsPreference
		{
			get
			{
				return columnsPreference;
			}
			set
			{
				this.columnsPreference = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="LOCKEDCOLS" type="costos_text" </summary>
		/// <returns> Returns the type. </returns>
		public virtual string LockedColumns
		{
			get
			{
				return lockedColumns;
			}
			set
			{
				this.lockedColumns = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="DOCKSTATE" type="costos_text" </summary>
		/// <returns> Returns the type. </returns>
		public virtual string DockingState
		{
			get
			{
				return dockingState;
			}
			set
			{
				this.dockingState = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="SORTEDCOLS" type="costos_text" </summary>
		/// <returns> Returns the type. </returns>
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
		/// @hibernate.property column="FILTERCOLS" type="costos_text" </summary>
		/// <returns> Returns the type. </returns>
		public virtual string FiltersPreference
		{
			get
			{
				return filtersPreference;
			}
			set
			{
				this.filtersPreference = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ASSMENT" type="boolean"
		/// </summary>
		public virtual bool? ShowsAssignments
		{
			get
			{
				return showsAssignments;
			}
			set
			{
				this.showsAssignments = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="VIZER" type="boolean"
		/// </summary>
		public virtual bool? ShowsVisualizer
		{
			get
			{
				return showsVisualizer;
			}
			set
			{
				this.showsVisualizer = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SELVIZER" type="string"
		/// </summary>
		public virtual string SelectedVisualizer
		{
			get
			{
				return selectedVisualizer;
			}
			set
			{
				this.selectedVisualizer = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SIDE" type="boolean"
		/// </summary>
		public virtual bool? ShowsSideBar
		{
			get
			{
				return showsSideBar;
			}
			set
			{
				this.showsSideBar = value;
			}
		}


		/// <summary>
		/// @hibernate.property column="GRPN" type="boolean"
		/// </summary>
		public virtual bool? EnableGrouping
		{
			get
			{
				return enableGrouping;
			}
			set
			{
				this.enableGrouping = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="DSGRP" type="boolean"
		/// </summary>
		public virtual bool? DisplayGrouping
		{
			get
			{
				return displayGrouping;
			}
			set
			{
				this.displayGrouping = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="GRPCOLS" type="costos_text"
		/// </summary>
		public virtual string GroupedColumns
		{
			get
			{
				return groupedColumns;
			}
			set
			{
				this.groupedColumns = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="GRPORDS" type="costos_text"
		/// </summary>
		public virtual string GroupedColumnOrders
		{
			get
			{
				return groupedColumnOrders;
			}
			set
			{
				this.groupedColumnOrders = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="VSBLE" type="boolean"
		/// </summary>
		public virtual bool? Visible
		{
			get
			{
				return visible;
			}
			set
			{
				this.visible = value;
			}
		}

		///////////////////////////////////
		// TO BE DELETED:
		///////////////////////////////////		
		/// <summary>
		/// @hibernate.property column="COLUMNS" type="costos_string" </summary>
		/// <returns> Returns the type. </returns>
		public virtual string Columns
		{
			get
			{
				return columns;
			}
			set
			{
				this.columns = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="COLUMNWIDTHS" type="costos_string" </summary>
		/// <returns> Returns the type. </returns>
		public virtual string ColumnWidths
		{
			get
			{
				return columnWidths;
			}
			set
			{
				this.columnWidths = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SORTTYPEUP" type="boolean" </summary>
		/// <returns> Returns the type. </returns>
		public virtual bool? SortTypeUp
		{
			get
			{
				return sortTypeUp;
			}
			set
			{
				this.sortTypeUp = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="SORTINDEX" type="int" </summary>
		/// <returns> Returns the type. </returns>
		public virtual int? SortIndex
		{
			get
			{
				return sortIndex;
			}
			set
			{
				this.sortIndex = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="AUTORESIZE" type="boolean" </summary>
		/// <returns> Returns the type. </returns>
		public virtual bool? HeaderAutoresize
		{
			get
			{
				return headerAutoresize;
			}
			set
			{
				this.headerAutoresize = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="ROWHEIGHT" type="int" </summary>
		/// <returns> Returns the type. </returns>
		public virtual int? HeaderRowHeight
		{
			get
			{
				return headerRowHeight;
			}
			set
			{
				this.headerRowHeight = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="FILTERS" type="boolean" </summary>
		/// <returns> Returns the type. </returns>
		public virtual bool? EnableFilters
		{
			get
			{
				return enableFilters;
			}
			set
			{
				this.enableFilters = value;
			}
		}

		/// <summary>
		/// @hibernate.property column="XTRALVL" type="boolean" </summary>
		/// <returns> Returns the type. </returns>
		public virtual bool? ShowingExtraLevel
		{
			get
			{
				return showingExtraLevel;
			}
			set
			{
				this.showingExtraLevel = value;
			}
		}

		public virtual object clone()
		{
			LayoutPanelTable o = new LayoutPanelTable();

			o.LayoutPanelId = LayoutPanelId;

			o.Columns = Columns;
			o.ColumnWidths = ColumnWidths;
			o.EnableFilters = EnableFilters;
			o.SortTypeUp = SortTypeUp;
			o.SortIndex = SortIndex;
			o.HeaderAutoresize = HeaderAutoresize;
			o.HeaderRowHeight = HeaderRowHeight;
			o.ColumnsPreference = ColumnsPreference;
			o.LockedColumns = LockedColumns;
			o.DockingState = DockingState;
			o.SortablePreference = SortablePreference;
			o.FiltersPreference = FiltersPreference;
			o.ShowsAssignments = ShowsAssignments;
			o.ShowsVisualizer = ShowsVisualizer;
			o.SelectedVisualizer = SelectedVisualizer;
			o.ShowsSideBar = ShowsSideBar;
			o.ShowingExtraLevel = ShowingExtraLevel;
			o.EnableGrouping = EnableGrouping;
			o.DisplayGrouping = DisplayGrouping;
			o.GroupedColumns = GroupedColumns;
			o.GroupedColumnOrders = GroupedColumnOrders;
			o.Visible = Visible;

			return o;
		}

		public virtual LayoutPanelTable Data
		{
			set
			{
				LayoutPanelId = value.LayoutPanelId;
    
				Columns = value.Columns;
				ColumnWidths = value.ColumnWidths;
				EnableFilters = value.EnableFilters;
				SortTypeUp = value.SortTypeUp;
				SortIndex = value.SortIndex;
				HeaderAutoresize = value.HeaderAutoresize;
				HeaderRowHeight = value.HeaderRowHeight;
				ColumnsPreference = value.ColumnsPreference;
				LockedColumns = value.LockedColumns;
				DockingState = value.DockingState;
				SortablePreference = value.SortablePreference;
				FiltersPreference = value.FiltersPreference;
				ShowsVisualizer = value.ShowsVisualizer;
				SelectedVisualizer = value.SelectedVisualizer;
				ShowsAssignments = value.ShowsAssignments;
				ShowsSideBar = value.ShowsSideBar;
				ShowingExtraLevel = value.ShowingExtraLevel;
				EnableGrouping = value.EnableGrouping;
				DisplayGrouping = value.DisplayGrouping;
				GroupedColumns = value.GroupedColumns;
				GroupedColumnOrders = value.GroupedColumnOrders;
				Visible = value.Visible;
			}
		}

		public virtual LayoutPanelTable copyWithLayoutTable()
		{
			LayoutPanelTable o = (LayoutPanelTable)clone();

			if (LayoutTable != null)
			{
				o.LayoutTable = (LayoutTable)LayoutTable.clone();
			}

			return o;
		}

		public override string ToString()
		{
			return "" + LayoutPanelId;
		}
	}

}