using System;
using System.Collections.Generic;

namespace Models.local.BaseClass
{
    public partial class Equipment
    {
        public Equipment()
        {
            AssemblyEquipment = new HashSet<AssemblyEquipment>();
        }

        public long Equipmentid { get; set; }
        public string Description { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Unit { get; set; }
        public string Groupcode { get; set; }
        public string Gekcode { get; set; }
        public string Fueltype { get; set; }
        public decimal? Reservationrate { get; set; }
        public decimal? Sparepartsrate { get; set; }
        public decimal? Tiresrate { get; set; }
        public decimal? Fuelrate { get; set; }
        public decimal? Lubricatesrate { get; set; }
        public decimal? Depreciationrate { get; set; }
        public decimal? Fuelconsumption { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public decimal? Totalrate { get; set; }
        public string Notes { get; set; }
        public string Editorid { get; set; }
        public string Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public string Rescode { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Accrights { get; set; }
        public string Keyw { get; set; }
        public string Title { get; set; }
        public int? DeprecationCalcMethod { get; set; }
        public decimal? InitAquasitionPrice { get; set; }
        public decimal? SalvageValue { get; set; }
        public decimal? InterestRate { get; set; }
        public decimal? DepreciationYears { get; set; }
        public decimal? OccupationHoursPerMonth { get; set; }
        public decimal? OccupationalFactor { get; set; }
        public bool? Virtual { get; set; }
        public bool? Predicted { get; set; }
        public bool? Conceptual { get; set; }
        public int? Tchtype { get; set; }
        public decimal? Tval { get; set; }
        public string Tunit { get; set; }
        public int? Tcolor { get; set; }
        public int? Tregtype { get; set; }
        public string Trids { get; set; }
        public DateTime? Trdate { get; set; }
        public string Extracode1 { get; set; }
        public string Extracode2 { get; set; }
        public string Extracode3 { get; set; }
        public string Extracode4 { get; set; }
        public string Extracode5 { get; set; }
        public string Extracode6 { get; set; }
        public string Extracode7 { get; set; }
        public string Extracode8 { get; set; }
        public string Extracode9 { get; set; }
        public string Extracode10 { get; set; }
        public int? Overtype { get; set; }

        public virtual ICollection<AssemblyEquipment> AssemblyEquipment { get; set; }
    }
}
