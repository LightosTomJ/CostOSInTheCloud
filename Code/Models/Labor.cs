using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Labor
    {
        public Labor()
        {
            AssemblyLabor = new HashSet<AssemblyLabor>();
            BoQitemLlabor = new HashSet<BoQitemLlabor>();
            LabHistory = new HashSet<LabHistory>();
        }

        public long Laborid { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Ika { get; set; }
        public decimal? Totalrate { get; set; }
        public string Groupcode { get; set; }
        public string Gekcode { get; set; }
        public string Project { get; set; }
        public string Contactperson { get; set; }
        public string Phonenumber { get; set; }
        public string Mobilenumber { get; set; }
        public string Faxnumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public string Editorid { get; set; }
        public string Stateprovince { get; set; }
        public string Country { get; set; }
        public string Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Title { get; set; }
        public string Currency { get; set; }
        public long? Databaseid { get; set; }
        public long? Databasecreationdate { get; set; }
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
        public bool? Virtual { get; set; }
        public bool? Predicted { get; set; }
        public int? Tchtype { get; set; }
        public decimal? Tunit { get; set; }
        public string Tval { get; set; }
        public int? Tcolor { get; set; }
        public int? Tregtype { get; set; }
        public string Trids { get; set; }
        public DateTime? Trdate { get; set; }
        public string Accrights { get; set; }
        public string Keyw { get; set; }
        public bool? Conceptual { get; set; }

        public virtual ICollection<AssemblyLabor> AssemblyLabor { get; set; }
        public virtual ICollection<BoQitemLlabor> BoQitemLlabor { get; set; }
        public virtual ICollection<LabHistory> LabHistory { get; set; }
    }
}
