using System;
using System.Collections.Generic;

namespace Models
{
    public partial class BcElementinfo
    {
        public BcElementinfo()
        {
            BcElemmaterial = new HashSet<BcElemmaterial>();
        }

        public long Id { get; set; }
        public string Label { get; set; }
        public string Material { get; set; }
        public string Type { get; set; }
        public long? ElementId { get; set; }
        public long? ModelId { get; set; }

        public virtual BcElement Element { get; set; }
        public virtual BcModel Model { get; set; }
        public virtual ICollection<BcElemmaterial> BcElemmaterial { get; set; }
    }
}
