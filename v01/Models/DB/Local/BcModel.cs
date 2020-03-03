using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class BcModel
    {
        public BcModel()
        {
            BcClassification = new HashSet<BcClassification>();
            BcClassitem = new HashSet<BcClassitem>();
            BcElemclassitem = new HashSet<BcElemclassitem>();
            BcElemconnection = new HashSet<BcElemconnection>();
            BcElemcovering = new HashSet<BcElemcovering>();
            BcElement = new HashSet<BcElement>();
            BcElementinfo = new HashSet<BcElementinfo>();
            BcElemmaterial = new HashSet<BcElemmaterial>();
            BcElemprop = new HashSet<BcElemprop>();
            BcGeometry = new HashSet<BcGeometry>();
            BcGeomfile = new HashSet<BcGeomfile>();
            BcGroup = new HashSet<BcGroup>();
            BcGroupelem = new HashSet<BcGroupelem>();
            BcGroupprop = new HashSet<BcGroupprop>();
            BcMaterial = new HashSet<BcMaterial>();
            BcQuantity = new HashSet<BcQuantity>();
            BcSpatialinfo = new HashSet<BcSpatialinfo>();
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
        public virtual ICollection<BcClassitem> BcClassitem { get; set; }
        public virtual ICollection<BcElemclassitem> BcElemclassitem { get; set; }
        public virtual ICollection<BcElemconnection> BcElemconnection { get; set; }
        public virtual ICollection<BcElemcovering> BcElemcovering { get; set; }
        public virtual ICollection<BcElement> BcElement { get; set; }
        public virtual ICollection<BcElementinfo> BcElementinfo { get; set; }
        public virtual ICollection<BcElemmaterial> BcElemmaterial { get; set; }
        public virtual ICollection<BcElemprop> BcElemprop { get; set; }
        public virtual ICollection<BcGeometry> BcGeometry { get; set; }
        public virtual ICollection<BcGeomfile> BcGeomfile { get; set; }
        public virtual ICollection<BcGroup> BcGroup { get; set; }
        public virtual ICollection<BcGroupelem> BcGroupelem { get; set; }
        public virtual ICollection<BcGroupprop> BcGroupprop { get; set; }
        public virtual ICollection<BcMaterial> BcMaterial { get; set; }
        public virtual ICollection<BcQuantity> BcQuantity { get; set; }
        public virtual ICollection<BcSpatialinfo> BcSpatialinfo { get; set; }
    }
}
