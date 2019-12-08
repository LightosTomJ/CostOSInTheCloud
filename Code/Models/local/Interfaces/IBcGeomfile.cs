
namespace Models.local.Interfaces
{
	public interface IBcGeomfile
	{
		long Id { get; set; }
		System.Byte[] Fdata { get; set; }
		string Fname { get; set; }
		int? Ftype { get; set; }
		System.Guid Fguid { get; set; }
		int? Novertices { get; set; }
		int? Noelements { get; set; }
		int? Elemoffset { get; set; }
		string OriginalFormat { get; set; }
		int? SerializationType { get; set; }
		long? ModelId { get; set; }
		Models.local.BaseClass.BcModel Model { get; set; }
		System.Collections.Generic.ICollection<BcGeometry> BcGeometry { get; set; }
		
		BcGeomfile Clone();
	}
}
