using System;
using System.Collections.Generic;

namespace Models.local.BaseClass
{
    public partial class BcSpatialinfo
    {
        public long Id { get; set; }
        public double? MaxX { get; set; }
        public double? MaxY { get; set; }
        public double? MaxZ { get; set; }
        public double? MinX { get; set; }
        public double? MinY { get; set; }
        public double? MinZ { get; set; }
        public long? ElementId { get; set; }
        public long? ModelId { get; set; }

        public virtual BcElement Element { get; set; }
        public virtual BcModel Model { get; set; }
    }
}
