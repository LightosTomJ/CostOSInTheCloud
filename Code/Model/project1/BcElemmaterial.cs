using System;
using System.Collections.Generic;

namespace Model.project1
{
    public partial class BcElemmaterial
    {
        public long Id { get; set; }
        public double? Thickness { get; set; }
        public long? EleminfoId { get; set; }
        public long? MaterialId { get; set; }
        public long? ModelId { get; set; }

        public virtual BcElementinfo Eleminfo { get; set; }
        public virtual BcMaterial Material { get; set; }
        public virtual BcModel Model { get; set; }
    }
}
