using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class TakeOffCon
    {
        public TakeOffCon()
        {
            Takeoffarea = new HashSet<TakeOffArea>();
            Takeofflegend = new HashSet<TakeOffLegend>();
            Takeoffline = new HashSet<TakeOffLine>();
            Takeoffpoint = new HashSet<TakeOffPoint>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Colour { get; set; }
        public string Grouping { get; set; }
        public string Cndtype { get; set; }
        public int? Patterntype { get; set; }
        public int? Shapetype { get; set; }
        public bool? Elevation { get; set; }
        public int? Samples { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Depth { get; set; }
        public decimal? Thickness { get; set; }
        public string Takeoff { get; set; }
        public string Editorid { get; set; }
        public string Createuserid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public DateTime? Createdate { get; set; }
        public string Qty1type { get; set; }
        public string Qty2type { get; set; }
        public string Qty3type { get; set; }
        public string Uom1 { get; set; }
        public string Uom2 { get; set; }
        public string Uom3 { get; set; }
        public decimal? Qty1 { get; set; }
        public decimal? Qty2 { get; set; }
        public decimal? Qty3 { get; set; }
        public long? Projectinfoid { get; set; }

        public virtual ProjectInfo Projectinfo { get; set; }
        public virtual ICollection<TakeOffArea> Takeoffarea { get; set; }
        public virtual ICollection<TakeOffLegend> Takeofflegend { get; set; }
        public virtual ICollection<TakeOffLine> Takeoffline { get; set; }
        public virtual ICollection<TakeOffPoint> Takeoffpoint { get; set; }
    }
}
