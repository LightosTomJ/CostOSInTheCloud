using System;
using System.Collections.Generic;

namespace Model.DB.Local
{
    public partial class BcElemconnection
    {
        public long Id { get; set; }
        public string Globalid { get; set; }
        public string Name { get; set; }
        public int? Relatedtype { get; set; }
        public int? Relatingtype { get; set; }
        public long? ModelId { get; set; }
        public long? RelatedelemId { get; set; }
        public long? RelatingelemId { get; set; }

        public virtual BcModel Model { get; set; }
        public virtual BcElement Relatedelem { get; set; }
        public virtual BcElement Relatingelem { get; set; }
    }
}
