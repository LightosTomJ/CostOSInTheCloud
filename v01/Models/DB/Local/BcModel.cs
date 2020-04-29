using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class BcModel
    {
        public BcModel()
        {
            BcClassification = new HashSet<BcClassification>();
            BcClassitem = new HashSet<BcClassItem>();
            BcElemclassitem = new HashSet<BcElemClassItem>();
            BcElemconnection = new HashSet<BcElemConnection>();
            BcElemcovering = new HashSet<BcElemCovering>();
            BcElement = new HashSet<BcElement>();
            BcElementinfo = new HashSet<BcElementInfo>();
            BcElemmaterial = new HashSet<BcElemMaterial>();
            BcElemprop = new HashSet<BcElemProp>();
            BcGeometry = new HashSet<BcGeometry>();
            BcGeomfile = new HashSet<BcGeomFile>();
            BcGroup = new HashSet<BcGroup>();
            BcGroupelem = new HashSet<BcGroupElem>();
            BcGroupprop = new HashSet<BcGroupProp>();
            BcMaterial = new HashSet<BcMaterial>();
            BcQuantity = new HashSet<BcQuantity>();
            BcSpatialinfo = new HashSet<BcSpatialInfo>();
        }

        public long Id { get; set; }
        public string Appname { get; set; }
        public bool? Defrev { get; set; }
        public string Failcause { get; set; }
        public string Fpath { get; set; }
        public string Globalid { get; set; }
        public string Name { get; set; }
        public double? Offsetx { get; set; }
        public double? Offsety { get; set; }
        public double? Offsetz { get; set; }
        public string Rev { get; set; }
        public byte? Status { get; set; }
        public double? VertexFactor { get; set; }
        public long? ProjectId { get; set; }

        public virtual BcProject Project { get; set; }
        public virtual ICollection<BcClassification> BcClassification { get; set; }
        public virtual ICollection<BcClassItem> BcClassitem { get; set; }
        public virtual ICollection<BcElemClassItem> BcElemclassitem { get; set; }
        public virtual ICollection<BcElemConnection> BcElemconnection { get; set; }
        public virtual ICollection<BcElemCovering> BcElemcovering { get; set; }
        public virtual ICollection<BcElement> BcElement { get; set; }
        public virtual ICollection<BcElementInfo> BcElementinfo { get; set; }
        public virtual ICollection<BcElemMaterial> BcElemmaterial { get; set; }
        public virtual ICollection<BcElemProp> BcElemprop { get; set; }
        public virtual ICollection<BcGeometry> BcGeometry { get; set; }
        public virtual ICollection<BcGeomFile> BcGeomfile { get; set; }
        public virtual ICollection<BcGroup> BcGroup { get; set; }
        public virtual ICollection<BcGroupElem> BcGroupelem { get; set; }
        public virtual ICollection<BcGroupProp> BcGroupprop { get; set; }
        public virtual ICollection<BcMaterial> BcMaterial { get; set; }
        public virtual ICollection<BcQuantity> BcQuantity { get; set; }
        public virtual ICollection<BcSpatialInfo> BcSpatialinfo { get; set; }
    }
}
