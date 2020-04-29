using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class BcMaterial
    {
        public BcMaterial()
        {
            BcElemmaterial = new HashSet<BcElemMaterial>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public long? ModelId { get; set; }

        public virtual BcModel Model { get; set; }
        public virtual ICollection<BcElemMaterial> BcElemmaterial { get; set; }
    }
}
