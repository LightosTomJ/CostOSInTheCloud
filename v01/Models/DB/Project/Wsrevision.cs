using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class Wsrevision
    {
        public Wsrevision()
        {
            Wsfile = new HashSet<Wsfile>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Createuserid { get; set; }
        public string Editorid { get; set; }
        public bool? Selected { get; set; }
        public long? Mappingid { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }

        public virtual Wsdatamapping Mapping { get; set; }
        public virtual ICollection<Wsfile> Wsfile { get; set; }
    }
}
