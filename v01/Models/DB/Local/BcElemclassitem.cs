using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class BcElemClassItem
    {
        public long Id { get; set; }
        public long? ClassificationId { get; set; }
        public long? ElementId { get; set; }
        public long? ModelId { get; set; }

        public virtual BcClassItem Classification { get; set; }
        public virtual BcElement Element { get; set; }
        public virtual BcModel Model { get; set; }
    }
}
