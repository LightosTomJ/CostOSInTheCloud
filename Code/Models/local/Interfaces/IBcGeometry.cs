
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
		Models.local.BaseClass.BcElement Element { get; set; }
		Models.local.BaseClass.BcGeomfile Geomfile { get; set; }
		Models.local.BaseClass.BcModel Model { get; set; }
		
		BcGeometry Clone();
	}
}
