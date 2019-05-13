using System;
using System.Collections.Generic;

namespace Models
{
    public partial class LocProf
    {
        public LocProf()
        {
            LocFactor = new HashSet<LocFactor>();
        }

        public long Functionid { get; set; }
        public string Fromcountry { get; set; }
        public string Fromstate { get; set; }
        public string Name { get; set; }
        public bool? Supstate { get; set; }
        public string Editorid { get; set; }
        public string Createuserid { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Lastupdate { get; set; }

        public virtual ICollection<LocFactor> LocFactor { get; set; }
    }
}
