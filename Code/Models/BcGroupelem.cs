using System;
using System.Collections.Generic;

namespace Models
{
    public partial class BcGroupelem
    {
        public long Id { get; set; }
        public long? ElemId { get; set; }
        public long? GroupId { get; set; }
        public long? ModelId { get; set; }

        public virtual BcElement Elem { get; set; }
        public virtual BcGroup Group { get; set; }
        public virtual BcModel Model { get; set; }
    }
}
