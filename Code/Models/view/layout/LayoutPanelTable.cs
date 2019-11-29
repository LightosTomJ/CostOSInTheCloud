using System;

namespace Models.layout
{
    [Serializable]
    public class LayoutPanelTable
    {
        public long? layoutPanelId { get; set; }

        public string columnsPreference { get; set; }
        public string lockedColumns { get; set; }
        public string dockingState { get; set; }
        public string sortablePreference { get; set; }
        public string filtersPreference { get; set; }
        public bool? headerAutoresize { get; set; }
        public bool? enableFilters { get; set; }
        public int? headerRowHeight { get; set; }
        public bool? showsAssignments { get; set; }
        public bool? showsSideBar { get; set; }
        public bool? showsVisualizer { get; set; }
        public string selectedVisualizer { get; set; }
        public bool? showingExtraLevel { get; set; }
        public bool? enableGrouping { get; set; } // Column Grouping
        public bool? displayGrouping { get; set; } // Show Groups in Columns
        public string groupedColumns { get; set; }
        public string groupedColumnOrders { get; set; }
        public bool? visible { get; set; }

        // Old Columns that shall be removed
        public string columns { get; set; }
        public string columnWidths { get; set; }
        public bool? sortTypeUp { get; set; }
        public int? sortIndex { get; set; }

        public LayoutTable layoutTable { get; set; }

        public LayoutPanelTable()
        { }
    }
}