using System;
using System.Collections.Generic;

namespace Models
{
    public partial class BcGroup
    {
        public BcGroup()
        {
            BcGroupelem = new HashSet<BcGroupelem>();
            BcGroupprop = new HashSet<BcGroupprop>();
            InverseParent = new HashSet<BcGroup>();
        }

        public long Id { get; set; }
        public string Description { get; set; }
        public string Globalid { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long? ModelId { get; set; }
        public long? ParentId { get; set; }

        public virtual BcModel Model { get; set; }
        public virtual BcGroup Parent { get; set; }
        public virtual ICollection<BcGroupelem> BcGroupelem { get; set; }
        public virtual ICollection<BcGroupprop> BcGroupprop { get; set; }
        public virtual ICollection<BcGroup> InverseParent { get; set; }
    }
}
