using System;
using System.Collections.Generic;

namespace Models
{
    public partial class BoQitemEquipment
    {
        public long Boqitemequipmentid { get; set; }
        public decimal? Factor1 { get; set; }
        public decimal? Factor2 { get; set; }
        public decimal? Factor3 { get; set; }
        public decimal? Costcenter { get; set; }
        public decimal? Totalunits { get; set; }
        public bool? Usertotalunits { get; set; }
        public DateTime? LastUpdate { get; set; }
        public long? Equipmentid { get; set; }
        public long? Boqitemid { get; set; }
        public decimal? Localfactor { get; set; }
        public string Localcountry { get; set; }
        public string Localstate { get; set; }
        public decimal? Energyprice { get; set; }
        public decimal? Fuelrate { get; set; }
        public decimal? Frate { get; set; }
        public decimal? Fdeprate { get; set; }
        public decimal? Totalcost { get; set; }
        public decimal? Qtypunit { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}
