using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class BcClassItem
    {
        public BcClassItem()
        {
            BcElemclassitem = new HashSet<BcElemClassItem>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long? ClassificationId { get; set; }
        public long? ModelId { get; set; }

        public virtual BcClassification Classification { get; set; }
        public virtual BcModel Model { get; set; }
        public virtual ICollection<BcElemClassItem> BcElemclassitem { get; set; }
    }
}
