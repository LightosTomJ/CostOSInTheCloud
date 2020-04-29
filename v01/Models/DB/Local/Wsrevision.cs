using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class WsRevision
    {
        public WsRevision()
        {
            Wsfile = new HashSet<WsFile>();
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

        public virtual WsDataMapping Mapping { get; set; }
        public virtual ICollection<WsFile> Wsfile { get; set; }
    }
}
