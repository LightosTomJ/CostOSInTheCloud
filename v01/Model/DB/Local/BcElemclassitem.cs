using System;
using System.Collections.Generic;

namespace Model.DB.Local
{
    public partial class BcElemclassitem
    {
        public long Id { get; set; }
        public long? ClassificationId { get; set; }
        public long? ElementId { get; set; }
        public long? ModelId { get; set; }

        public virtual BcClassitem Classification { get; set; }
        public virtual BcElement Element { get; set; }
        public virtual BcModel Model { get; set; }
    }
}
