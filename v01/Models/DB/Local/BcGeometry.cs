﻿using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class BcGeometry
    {
        public long Id { get; set; }
        public string Globalid { get; set; }
        public int? Type { get; set; }
        public long? ElementId { get; set; }
        public long? GeomfileId { get; set; }
        public long? ModelId { get; set; }

        public virtual BcElement Element { get; set; }
        public virtual BcGeomFile Geomfile { get; set; }
        public virtual BcModel Model { get; set; }
    }
}
