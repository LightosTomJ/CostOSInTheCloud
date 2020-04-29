using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class BcGroup
    {
        public BcGroup()
        {
            BcGroupelem = new HashSet<BcGroupElem>();
            BcGroupprop = new HashSet<BcGroupProp>();
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
        public virtual ICollection<BcGroupElem> BcGroupelem { get; set; }
        public virtual ICollection<BcGroupProp> BcGroupprop { get; set; }
        public virtual ICollection<BcGroup> InverseParent { get; set; }
    }
}
