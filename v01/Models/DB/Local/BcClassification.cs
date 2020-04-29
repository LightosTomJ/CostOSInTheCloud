using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class BcClassification
    {
        public BcClassification()
        {
            BcClassitem = new HashSet<BcClassItem>();
        }

        public long Id { get; set; }
        public string Edition { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public long? ModelId { get; set; }

        public virtual BcModel Model { get; set; }
        public virtual ICollection<BcClassItem> BcClassitem { get; set; }
    }
}
