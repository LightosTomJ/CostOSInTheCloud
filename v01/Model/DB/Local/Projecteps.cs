using System;
using System.Collections.Generic;

namespace Model.DB.Local
{
    public partial class Projecteps
    {
        public Projecteps()
        {
            Projectinfo = new HashSet<Projectinfo>();
        }

        public long Projectepsid { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Editorid { get; set; }
        public string Description { get; set; }
        public DateTime? Lastupdate { get; set; }
        public long? Parentid { get; set; }

        public virtual ICollection<Projectinfo> Projectinfo { get; set; }
    }
}
