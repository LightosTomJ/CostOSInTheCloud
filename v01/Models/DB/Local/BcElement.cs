using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class BcElement
    {
        public BcElement()
        {
            BcElemclassitem = new HashSet<BcElemClassItem>();
            BcElemconnectionRelatedelem = new HashSet<BcElemConnection>();
            BcElemconnectionRelatingelem = new HashSet<BcElemConnection>();
            BcElemcoveringCoverelem = new HashSet<BcElemCovering>();
            BcElemcoveringRelatingelem = new HashSet<BcElemCovering>();
            BcElementinfo = new HashSet<BcElementInfo>();
            BcElemprop = new HashSet<BcElemProp>();
            BcGeometry = new HashSet<BcGeometry>();
            BcGroupelem = new HashSet<BcGroupElem>();
            BcQuantity = new HashSet<BcQuantity>();
            BcSpatialinfo = new HashSet<BcSpatialInfo>();
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
        public virtual ICollection<BcElemClassItem> BcElemclassitem { get; set; }
        public virtual ICollection<BcElemConnection> BcElemconnectionRelatedelem { get; set; }
        public virtual ICollection<BcElemConnection> BcElemconnectionRelatingelem { get; set; }
        public virtual ICollection<BcElemCovering> BcElemcoveringCoverelem { get; set; }
        public virtual ICollection<BcElemCovering> BcElemcoveringRelatingelem { get; set; }
        public virtual ICollection<BcElementInfo> BcElementinfo { get; set; }
        public virtual ICollection<BcElemProp> BcElemprop { get; set; }
        public virtual ICollection<BcGeometry> BcGeometry { get; set; }
        public virtual ICollection<BcGroupElem> BcGroupelem { get; set; }
        public virtual ICollection<BcQuantity> BcQuantity { get; set; }
        public virtual ICollection<BcSpatialInfo> BcSpatialinfo { get; set; }
        public virtual ICollection<BcElement> InverseContainedby { get; set; }
        public virtual ICollection<BcElement> InverseParent { get; set; }
    }
}
