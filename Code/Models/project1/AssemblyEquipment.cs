using System;
using System.Collections.Generic;

namespace Models.project1
{
    public partial class AssemblyEquipment
    {
        public long Assemblyequipmentid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public decimal? Frate { get; set; }
        public decimal? Fdeprate { get; set; }
        public decimal? Energyprice { get; set; }
        public decimal? Finalfuelrate { get; set; }
        public decimal? Fuelrate { get; set; }
        public decimal? Factor1 { get; set; }
        public decimal? Factor2 { get; set; }
        public decimal? Factor3 { get; set; }
        public decimal? Qtypunit { get; set; }
        public string Qtypunitform { get; set; }
        public byte? Qtypuformstate { get; set; }
        public decimal? Localfactor { get; set; }
        public string Localcountry { get; set; }
        public string Localstate { get; set; }
        public decimal? Exchangerate { get; set; }
        public decimal? Fixedcost { get; set; }
        public decimal? Finalfixedcost { get; set; }
        public decimal? Unithours { get; set; }
        public string PvVars { get; set; }
        public long? Equipmentid { get; set; }
        public long? Assemblyid { get; set; }

        public virtual Assembly Assembly { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
