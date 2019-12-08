
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
		Models.local.BaseClass.BcElement Containedby { get; set; }
		Models.local.BaseClass.BcModel Model { get; set; }
		Models.local.BaseClass.BcElement Parent { get; set; }
		System.Collections.Generic.ICollection<BcElemclassitem> BcElemclassitem { get; set; }
		System.Collections.Generic.ICollection<BcElemconnection> BcElemconnectionRelatedelem { get; set; }
		System.Collections.Generic.ICollection<BcElemconnection> BcElemconnectionRelatingelem { get; set; }
		System.Collections.Generic.ICollection<BcElemcovering> BcElemcoveringCoverelem { get; set; }
		System.Collections.Generic.ICollection<BcElemcovering> BcElemcoveringRelatingelem { get; set; }
		System.Collections.Generic.ICollection<BcElementinfo> BcElementinfo { get; set; }
		System.Collections.Generic.ICollection<BcElemprop> BcElemprop { get; set; }
		System.Collections.Generic.ICollection<BcGeometry> BcGeometry { get; set; }
		System.Collections.Generic.ICollection<BcGroupelem> BcGroupelem { get; set; }
		System.Collections.Generic.ICollection<BcQuantity> BcQuantity { get; set; }
		System.Collections.Generic.ICollection<BcSpatialinfo> BcSpatialinfo { get; set; }
		System.Collections.Generic.ICollection<BcElement> InverseContainedby { get; set; }
		System.Collections.Generic.ICollection<BcElement> InverseParent { get; set; }
		
		BcElement Clone();
	}
}
