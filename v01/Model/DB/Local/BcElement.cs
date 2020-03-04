using System;
using System.Collections.Generic;

namespace Model.DB.Local
{
    public partial class BcElement
    {
        public BcElement()
        {
            BcElemclassitem = new HashSet<BcElemclassitem>();
            BcElemconnectionRelatedelem = new HashSet<BcElemconnection>();
            BcElemconnectionRelatingelem = new HashSet<BcElemconnection>();
            BcElemcoveringCoverelem = new HashSet<BcElemcovering>();
            BcElemcoveringRelatingelem = new HashSet<BcElemcovering>();
            BcElementinfo = new HashSet<BcElementinfo>();
            BcElemprop = new HashSet<BcElemprop>();
            BcGeometry = new HashSet<BcGeometry>();
            BcGroupelem = new HashSet<BcGroupelem>();
            BcQuantity = new HashSet<BcQuantity>();
            BcSpatialinfo = new HashSet<BcSpatialinfo>();
            InverseContainedby = new HashSet<BcElement>();
            InverseParent = new HashSet<BcElement>();
        }

        public long Id { get; set; }
        public string Globalid { get; set; }
        public bool? Hasgeom { get; set; }
        public string Layer { get; set; }
        public string Name { get; set; }
        public bool? Spatial { get; set; }
        public string Tagid { get; set; }
        public int? Type { get; set; }
        public string Typedesc { get; set; }
        public long? ContainedbyId { get; set; }
        public long? ModelId { get; set; }
        public long? ParentId { get; set; }

        public virtual BcElement Containedby { get; set; }
        public virtual BcModel Model { get; set; }
        public virtual BcElement Parent { get; set; }
        public virtual ICollection<BcElemclassitem> BcElemclassitem { get; set; }
        public virtual ICollection<BcElemconnection> BcElemconnectionRelatedelem { get; set; }
        public virtual ICollection<BcElemconnection> BcElemconnectionRelatingelem { get; set; }
        public virtual ICollection<BcElemcovering> BcElemcoveringCoverelem { get; set; }
        public virtual ICollection<BcElemcovering> BcElemcoveringRelatingelem { get; set; }
        public virtual ICollection<BcElementinfo> BcElementinfo { get; set; }
        public virtual ICollection<BcElemprop> BcElemprop { get; set; }
        public virtual ICollection<BcGeometry> BcGeometry { get; set; }
        public virtual ICollection<BcGroupelem> BcGroupelem { get; set; }
        public virtual ICollection<BcQuantity> BcQuantity { get; set; }
        public virtual ICollection<BcSpatialinfo> BcSpatialinfo { get; set; }
        public virtual ICollection<BcElement> InverseContainedby { get; set; }
        public virtual ICollection<BcElement> InverseParent { get; set; }
    }
}
