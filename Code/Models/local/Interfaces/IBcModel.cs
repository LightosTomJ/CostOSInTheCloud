
namespace Models.local.Interfaces
{
	public interface IBcModel
	{
		long Id { get; set; }
		string Appname { get; set; }
		bool? Defrev { get; set; }
		string Failcause { get; set; }
		string Fpath { get; set; }
		string Globalid { get; set; }
		string Name { get; set; }
		double? Offsetx { get; set; }
		double? Offsety { get; set; }
		double? Offsetz { get; set; }
		string Rev { get; set; }
		byte? Status { get; set; }
		double? VertexFactor { get; set; }
		long? ProjectId { get; set; }
		Models.local.BaseClass.BcProject Project { get; set; }
		System.Collections.Generic.ICollection<BcClassification> BcClassification { get; set; }
		System.Collections.Generic.ICollection<BcClassitem> BcClassitem { get; set; }
		System.Collections.Generic.ICollection<BcElemclassitem> BcElemclassitem { get; set; }
		System.Collections.Generic.ICollection<BcElemconnection> BcElemconnection { get; set; }
		System.Collections.Generic.ICollection<BcElemcovering> BcElemcovering { get; set; }
		System.Collections.Generic.ICollection<BcElement> BcElement { get; set; }
		System.Collections.Generic.ICollection<BcElementinfo> BcElementinfo { get; set; }
		System.Collections.Generic.ICollection<BcElemmaterial> BcElemmaterial { get; set; }
		System.Collections.Generic.ICollection<BcElemprop> BcElemprop { get; set; }
		System.Collections.Generic.ICollection<BcGeometry> BcGeometry { get; set; }
		System.Collections.Generic.ICollection<BcGeomfile> BcGeomfile { get; set; }
		System.Collections.Generic.ICollection<BcGroup> BcGroup { get; set; }
		System.Collections.Generic.ICollection<BcGroupelem> BcGroupelem { get; set; }
		System.Collections.Generic.ICollection<BcGroupprop> BcGroupprop { get; set; }
		System.Collections.Generic.ICollection<BcMaterial> BcMaterial { get; set; }
		System.Collections.Generic.ICollection<BcQuantity> BcQuantity { get; set; }
		System.Collections.Generic.ICollection<BcSpatialinfo> BcSpatialinfo { get; set; }
		
		BcModel Clone();
	}
}
