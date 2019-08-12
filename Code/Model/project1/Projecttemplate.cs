using System;
using System.Collections.Generic;

namespace Model.project1
{
    public partial class Projecttemplate
    {
        public Projecttemplate()
        {
            Projectspecvar = new HashSet<Projectspecvar>();
            Ratebuildup = new HashSet<Ratebuildup>();
            Ratebuildupcols = new HashSet<Ratebuildupcols>();
            Ratedistrib = new HashSet<Ratedistrib>();
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

        public virtual Xcellfile Template { get; set; }
        public virtual ICollection<Projectspecvar> Projectspecvar { get; set; }
        public virtual ICollection<Ratebuildup> Ratebuildup { get; set; }
        public virtual ICollection<Ratebuildupcols> Ratebuildupcols { get; set; }
        public virtual ICollection<Ratedistrib> Ratedistrib { get; set; }
    }
}
