using System.Collections.Generic;

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
		BaseClass.BcProject Project { get; set; }
		//ICollection<BcClassification> BcClassification { get; set; }
		//ICollection<BcClassitem> BcClassitem { get; set; }
		//ICollection<BcElemclassitem> BcElemclassitem { get; set; }
		//ICollection<BcElemconnection> BcElemconnection { get; set; }
		//ICollection<BcElemcovering> BcElemcovering { get; set; }
		//ICollection<BcElement> BcElement { get; set; }
		//ICollection<BcElementinfo> BcElementinfo { get; set; }
		//ICollection<BcElemmaterial> BcElemmaterial { get; set; }
		//ICollection<BcElemprop> BcElemprop { get; set; }
		//ICollection<BcGeometry> BcGeometry { get; set; }
		//ICollection<BcGeomfile> BcGeomfile { get; set; }
		//ICollection<BcGroup> BcGroup { get; set; }
		//ICollection<BcGroupelem> BcGroupelem { get; set; }
		//ICollection<BcGroupprop> BcGroupprop { get; set; }
		//ICollection<BcMaterial> BcMaterial { get; set; }
		//ICollection<BcQuantity> BcQuantity { get; set; }
		//ICollection<BcSpatialinfo> BcSpatialinfo { get; set; }
		
		BcModel Clone();
	}
}
