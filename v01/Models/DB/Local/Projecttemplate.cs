using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class ProjectTemplate
    {
        public ProjectTemplate()
        {
            Projectspecvar = new HashSet<ProjectSpecVar>();
            Ratebuildup = new HashSet<RateBuildUp>();
            Ratebuildupcols = new HashSet<RateBuildUpCols>();
            Ratedistrib = new HashSet<RateDistrib>();
        }

        public long Id { get; set; }
        public long? Templateid { get; set; }
        public string Title { get; set; }
        public string Editorid { get; set; }
        public string Userid { get; set; }
        public DateTime? Lastupdate { get; set; }
        public DateTime? Createdate { get; set; }
        public string Createuser { get; set; }
        public long? Databaseid { get; set; }
        public long? Dbcreatedate { get; set; }
        public bool? Pblk { get; set; }
        public bool? Hasbuildups { get; set; }
        public bool? Hasdistributors { get; set; }
        public bool? Allowviewers { get; set; }
        public string Description { get; set; }

        public virtual XcellFile Template { get; set; }
        public virtual ICollection<ProjectSpecVar> Projectspecvar { get; set; }
        public virtual ICollection<RateBuildUp> Ratebuildup { get; set; }
        public virtual ICollection<RateBuildUpCols> Ratebuildupcols { get; set; }
        public virtual ICollection<RateDistrib> Ratedistrib { get; set; }
    }
}
