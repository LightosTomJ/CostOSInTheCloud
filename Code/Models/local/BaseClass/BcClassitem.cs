using System;
using System.Collections.Generic;

namespace Models.local.BaseClass
{
    public partial class BcClassitem
    {
        public BcClassitem()
        {
            BcElemclassitem = new HashSet<BcElemclassitem>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long? ClassificationId { get; set; }
        public long? ModelId { get; set; }

        public virtual BcClassification Classification { get; set; }
        public virtual BcModel Model { get; set; }
        public virtual ICollection<BcElemclassitem> BcElemclassitem { get; set; }
    }
}
