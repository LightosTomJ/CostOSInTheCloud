using System;

namespace Models.projects
{
    [Serializable]
    public class BoqItemTable
    {
        public static bool calculationsEnabled = true;

        public static readonly long? ONLINE_DB_CREATE_DATE = new long?(-1);
        public static readonly long? MISSING_DB_CREATE_DATE = new long?(100);

        public const sbyte RATE_TYPE_QUOTED = 0; // 6
        public const sbyte RATE_TYPE_LOCAL = 1; // 5
        public const sbyte RATE_TYPE_ONLINE = 2; // 4
        public const sbyte RATE_TYPE_TREND = 3; // 3
        public const sbyte RATE_TYPE_VIRTUAL = 4; // 1
        public const sbyte RATE_TYPE_CONCEPTUAL = 5; // 2
        public const sbyte RATE_TYPE_EMPTY = 6;
        public const sbyte RATE_TYPE_PROJECT = 7; // PROJECT OVERRIDEN
        public const sbyte RATE_TYPE_OVERRIDEN = 8; // DATABASE OVERRIDEN
        public const sbyte RATE_TYPE_OSTRAKON = 9; // OSTRAKON ASSEMBLY

        public const sbyte TAKEOFF_TYPE_NONE = 0;
        public const sbyte TAKEOFF_TYPE_MANUAL = 1;
        public const sbyte TAKEOFF_TYPE_FUNCTION = 2;
        public const sbyte TAKEOFF_TYPE_OST = 3;
        public const sbyte TAKEOFF_TYPE_BIM = 4;
        public const sbyte TAKEOFF_TYPE_MAP = 5;

        public const string s_ESTIMATED_ACCURACY = "enum.quotation.accuracy.estimated";
        public const string s_BOTH_ACCURACY = "enum.quotation.accuracy.semiquoted";
        public const string s_QUOTED_ACCURACY = "enum.quotation.accuracy.quoted";

        public static string s_PRODUCTIVITY_METHOD = "Productivity";
        public static string s_TOTAL_UNITS_METHOD = "Total Units";

        public static string s_SCHEDULED = "Scheduled";
        public static string s_UNPLANNED = "Unplanned";
        public static string s_SUPERSTRUCTURE_SURFACE_TYPE = "enum.boqsurfacetype.superstructure";
        public static string s_BASEMENT_SURFACE_TYPE = "enum.boqsurfacetype.basement";

        public const string s_PENDING_STATUS = "enum.boqstatus.pending";
        public const string s_APPROVED_STATUS = "enum.boqstatus.approved";
        public const string s_COMPLETED_STATUS = "enum.boqstatus.completed";
        public const string s_UNDERREVIEW_STATUS = "enum.boqstatus.underreview";

        public BoqItemTable()
        { }
    }
}