﻿using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class BcElementInfo
    {
        public BcElementInfo()
        {
            BcElemmaterial = new HashSet<BcElemMaterial>();
        }

        public long Id { get; set; }
        public string Label { get; set; }
        public string Material { get; set; }
        public string Type { get; set; }
        public long? ElementId { get; set; }
        public long? ModelId { get; set; }

        public virtual BcElement Element { get; set; }
        public virtual BcModel Model { get; set; }
        public virtual ICollection<BcElemMaterial> BcElemmaterial { get; set; }
    }
}
