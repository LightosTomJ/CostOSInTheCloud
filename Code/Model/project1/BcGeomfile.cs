using System;
using System.Collections.Generic;

namespace Model.project1
{
    public partial class BcGeomfile
    {
        public BcGeomfile()
        {
            BcGeometry = new HashSet<BcGeometry>();
        }

        public long Id { get; set; }
        public byte[] Fdata { get; set; }
        public string Fname { get; set; }
        public int? Ftype { get; set; }
        public Guid Fguid { get; set; }
        public int? Novertices { get; set; }
        public int? Noelements { get; set; }
        public int? Elemoffset { get; set; }
        public string OriginalFormat { get; set; }
        public int? SerializationType { get; set; }
        public long? ModelId { get; set; }

        public virtual BcModel Model { get; set; }
        public virtual ICollection<BcGeometry> BcGeometry { get; set; }
    }
}
