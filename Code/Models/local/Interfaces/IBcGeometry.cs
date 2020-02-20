
namespace Models.local.Interfaces
{
	public interface IBcGeometry
	{
		long Id { get; set; }
		string Globalid { get; set; }
		int? Type { get; set; }
		long? ElementId { get; set; }
		long? GeomfileId { get; set; }
		long? ModelId { get; set; }
		BaseClass.BcElement Element { get; set; }
		BaseClass.BcGeomfile Geomfile { get; set; }
		BaseClass.BcModel Model { get; set; }
		
		BcGeometry Clone();
	}
}
