
namespace Models.local.Interfaces
{
	public interface IBcSpatialinfo
	{
		long Id { get; set; }
		double? MaxX { get; set; }
		double? MaxY { get; set; }
		double? MaxZ { get; set; }
		double? MinX { get; set; }
		double? MinY { get; set; }
		double? MinZ { get; set; }
		long? ElementId { get; set; }
		long? ModelId { get; set; }
		BaseClass.BcElement Element { get; set; }
		BaseClass.BcModel Model { get; set; }
		
		BcSpatialinfo Clone();
	}
}