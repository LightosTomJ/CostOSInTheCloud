using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class TakeoffConditionTable
    {
        /* TAKEOFF TYPES */
        public const string ONSCREEN_TAKEOFF = "OST";
        public const string MAP_TAKEOFF = "MAP";

        /* CONDITION TYPES */
        public const string LINEAR_CONDITION = "type.linear";
        public const string AREA_CONDITION = "type.area";
        public const string SPOT_CONDITION = "type.spot";

        /* QTY TYPES */
        public static readonly string[] LINEAR_QTY_TYPES = new string[] { "linear.distance", "linear.elevationdistance", "linear.elevationdistance.wgs84datum", "linear.segment.count", "linear.surface.singleside", "linear.surface.bothside", "linear.surface.toporbottom", "linear.surface.topandbottom", "linear.surface.singleend", "linear.surface.bothends", "linear.surface.recttube", "linear.surface.circletube", "linear.surface.allside", "linear.surface.volume" };
        public static readonly string[] AREA_QTY_TYPES = new string[] { "area", "area.perimeter", "area.count", "area.volume", "area.elevationvolume" };
        public static readonly string[] SPOT_QTY_TYPES = new string[] { "spot", "spot.elevationheight", "spot.totalheight", "spot.perimeter", "spot.toporbottom", "spot.topandbottom", "spot.singlewidthside", "spot.bothwidthsides", "spot.singledepthside", "spot.bothdepthsides", "spot.allsides", "spot.fullallsides", "spot.volume" };

        public long? id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public string grouping { get; set; }
        public string conditionType { get; set; }
        public int? patternType { get; set; }
        public int? shapeType { get; set; }
        public bool? elevation { get; set; }
        public int? elevationSamples { get; set; }
        public decimal height { get; set; }
        public decimal width { get; set; }
        public decimal depth { get; set; }
        public decimal thickness { get; set; }
        public string takeoffType { get; set; }
        public string editorId { get; set; }
        public string createUserId { get; set; }
        public DateTime lastUpdate { get; set; }
        public DateTime createDate { get; set; }
        public ProjectInfoTable projectInfoTable { get; set; }

        public string qty1Type { get; set; }
        public string qty2Type { get; set; }
        public string qty3Type { get; set; }

        public string uom1 { get; set; }
        public string uom2 { get; set; }
        public string uom3 { get; set; }

        public decimal qty1 { get; set; }
        public decimal qty2 { get; set; }
        public decimal qty3 { get; set; }

        public List<TakeoffLineTable> linesList { get; set; }
        public List<TakeoffAreaTable> areaList { get; set; }
        public List<TakeoffPointTable> spotList { get; set; }
        public List<TakeoffLegendTable> legendList { get; set; }

        public TakeoffConditionTable()
        {
            linesList = new List<TakeoffLineTable>();
            areaList = new List<TakeoffAreaTable>();
            spotList = new List<TakeoffPointTable>();
            legendList = new List<TakeoffLegendTable>();
                
        }
    }
}