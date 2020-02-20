//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IBcElement
	{
		long Id { get; set; }
		string Globalid { get; set; }
		bool? Hasgeom { get; set; }
		string Layer { get; set; }
		string Name { get; set; }
		bool? Spatial { get; set; }
		string Tagid { get; set; }
		int? Type { get; set; }
		string Typedesc { get; set; }
		long? ContainedbyId { get; set; }
		long? ModelId { get; set; }
		long? ParentId { get; set; }
		BaseClass.BcElement Containedby { get; set; }
		BaseClass.BcModel Model { get; set; }
		BaseClass.BcElement Parent { get; set; }
		//ICollection<BcElemclassitem> BcElemclassitem { get; set; }
		//ICollection<BcElemconnection> BcElemconnectionRelatedelem { get; set; }
		//ICollection<BcElemconnection> BcElemconnectionRelatingelem { get; set; }
		//ICollection<BcElemcovering> BcElemcoveringCoverelem { get; set; }
		//ICollection<BcElemcovering> BcElemcoveringRelatingelem { get; set; }
		//ICollection<BcElementinfo> BcElementinfo { get; set; }
		//ICollection<BcElemprop> BcElemprop { get; set; }
		//ICollection<BcGeometry> BcGeometry { get; set; }
		//ICollection<BcGroupelem> BcGroupelem { get; set; }
		//ICollection<BcQuantity> BcQuantity { get; set; }
		//ICollection<BcSpatialinfo> BcSpatialinfo { get; set; }
		//ICollection<BcElement> InverseContainedby { get; set; }
		//ICollection<BcElement> InverseParent { get; set; }
		
		BcElement Clone();
	}
}
