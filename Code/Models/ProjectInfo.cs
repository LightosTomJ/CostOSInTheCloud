using System;
using System.Collections.Generic;

namespace Models.project1
{
    public partial class Projectinfo
    {
        public Projectinfo()
        {
            Projecturl = new HashSet<Projecturl>();
            Projectuser = new HashSet<Projectuser>();
            Takeoffcon = new HashSet<Takeoffcon>();
        }

        public long Projectinfoid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Epscode { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public bool? Primavera { get; set; }
        public bool? Locfac { get; set; }
        public string Locprof { get; set; }
        public string Selfac { get; set; }
        public bool? Bimtakeoff { get; set; }
        public bool? Ostakeoff { get; set; }
        public string Storagetype { get; set; }
        public string Codestyle { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Editorid { get; set; }
        public decimal? Totalcost { get; set; }
        public decimal? Offeredprice { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string Unit { get; set; }
        public string Country { get; set; }
        public string Client { get; set; }
        public decimal? Basement { get; set; }
        public decimal? Mainsite { get; set; }
        public decimal? Unitcost { get; set; }
        public string State { get; set; }
        public string Prjtype { get; set; }
        public string Prjsubcat { get; set; }
        public string Contractor { get; set; }
        public string Geoloc { get; set; }
        public int? Floors { get; set; }
        public int? Duration { get; set; }
        public decimal? Clientbudget { get; set; }
        public DateTime? Subdate { get; set; }
        public string Defrev { get; set; }
        public decimal? Cusepsrate1 { get; set; }
        public decimal? Cusepsrate2 { get; set; }
        public decimal? Cusepsrate3 { get; set; }
        public decimal? Cusepsrate4 { get; set; }
        public decimal? Cusepsrate5 { get; set; }
        public decimal? Cusepsrate6 { get; set; }
        public decimal? Cusepsrate7 { get; set; }
        public decimal? Cusepsrate8 { get; set; }
        public decimal? Cusepsrate9 { get; set; }
        public decimal? Cusepsrate10 { get; set; }
        public string Cusepstext1 { get; set; }
        public string Cusepstext2 { get; set; }
        public string Cusepstext3 { get; set; }
        public string Cusepstext4 { get; set; }
        public string Cusepstext5 { get; set; }
        public string Cusepstext6 { get; set; }
        public string Cusepstext7 { get; set; }
        public string Cusepstext8 { get; set; }
        public string Cusepstext9 { get; set; }
        public string Cusepstext10 { get; set; }
        public string Cusepstext11 { get; set; }
        public string Cusepstext12 { get; set; }
        public string Cusepstext13 { get; set; }
        public string Cusepstext14 { get; set; }
        public string Cusepstext15 { get; set; }
        public string Cusepstext16 { get; set; }
        public string Cusepstext17 { get; set; }
        public string Cusepstext18 { get; set; }
        public string Cusepstext19 { get; set; }
        public string Cusepstext20 { get; set; }
        public decimal? Cuscumrate1 { get; set; }
        public decimal? Cuscumrate2 { get; set; }
        public decimal? Cuscumrate3 { get; set; }
        public decimal? Cuscumrate4 { get; set; }
        public decimal? Cuscumrate5 { get; set; }
        public decimal? Cuscumrate6 { get; set; }
        public decimal? Cuscumrate7 { get; set; }
        public decimal? Cuscumrate8 { get; set; }
        public decimal? Cuscumrate9 { get; set; }
        public decimal? Cuscumrate10 { get; set; }
        public decimal? Cuscumrate11 { get; set; }
        public decimal? Cuscumrate12 { get; set; }
        public decimal? Cuscumrate13 { get; set; }
        public decimal? Cuscumrate14 { get; set; }
        public decimal? Cuscumrate15 { get; set; }
        public decimal? Cuscumrate16 { get; set; }
        public decimal? Cuscumrate17 { get; set; }
        public decimal? Cuscumrate18 { get; set; }
        public decimal? Cuscumrate19 { get; set; }
        public decimal? Cuscumrate20 { get; set; }
        public DateTime? Cusepsdate1 { get; set; }
        public DateTime? Cusepsdate2 { get; set; }
        public DateTime? Cusepsdate3 { get; set; }
        public DateTime? Cusepsdate4 { get; set; }
        public DateTime? Cusepsdate5 { get; set; }
        public DateTime? Cusepsdate6 { get; set; }
        public DateTime? Cusepsdate7 { get; set; }
        public DateTime? Cusepsdate8 { get; set; }
        public DateTime? Cusepsdate9 { get; set; }
        public DateTime? Cusepsdate10 { get; set; }
        public decimal? Equcost { get; set; }
        public decimal? Subcost { get; set; }
        public decimal? Labcost { get; set; }
        public decimal? Matcost { get; set; }
        public decimal? Concost { get; set; }
        public decimal? Manhours { get; set; }
        public decimal? Equhours { get; set; }
        public long? Projectepsid { get; set; }
        public string Creatorid { get; set; }
        public DateTime? Createdate { get; set; }

        public virtual Projecteps Projecteps { get; set; }
        public virtual ICollection<Projecturl> Projecturl { get; set; }
        public virtual ICollection<Projectuser> Projectuser { get; set; }
        public virtual ICollection<Takeoffcon> Takeoffcon { get; set; }
    }
}
