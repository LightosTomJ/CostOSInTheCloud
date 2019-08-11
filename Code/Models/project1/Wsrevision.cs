using System;
using System.Collections.Generic;

namespace Models.project1
{
    public partial class Wsrevision
    {
        public Wsrevision()
        {
            Wsfile = new HashSet<Wsfile>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Createuserid { get; set; }
        public string Editorid { get; set; }
        public string Description { get; set; }
        public bool? Pblk { get; set; }
        public long? Mappingid { get; set; }

        public virtual Wsdatamapping Mapping { get; set; }
        public virtual ICollection<Wsfile> Wsfile { get; set; }
    }
}
