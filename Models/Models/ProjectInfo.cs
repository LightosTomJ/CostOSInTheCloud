using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ProjectInfo
    {
        public ProjectInfo()
        {
            ProjectUrl = new HashSet<ProjectUrl>();
            ProjectUser = new HashSet<ProjectUser>();
            ProjectWbs = new HashSet<ProjectWbs>();
            ProjectWbs2 = new HashSet<ProjectWbs2>();
            TakeOffCon = new HashSet<TakeOffCon>();
        }

        public long Projectinfoid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public bool? Primavera { get; set; }
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
        public long? Projectepsid { get; set; }
        public string Epscode { get; set; }
        public bool? Locfac { get; set; }
        public string Locprof { get; set; }
        public string Selfac { get; set; }
        public string Creatorid { get; set; }
        public DateTime? Createdate { get; set; }

        public virtual ProjectEps Projecteps { get; set; }
        public virtual ICollection<ProjectUrl> ProjectUrl { get; set; }
        public virtual ICollection<ProjectUser> ProjectUser { get; set; }
        public virtual ICollection<ProjectWbs> ProjectWbs { get; set; }
        public virtual ICollection<ProjectWbs2> ProjectWbs2 { get; set; }
        public virtual ICollection<TakeOffCon> TakeOffCon { get; set; }
    }
}
