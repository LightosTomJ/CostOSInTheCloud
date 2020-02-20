
namespace Models.local.Interfaces
{
	public interface IBcElemmaterial
	{
		long Id { get; set; }
		double? Thickness { get; set; }
		long? EleminfoId { get; set; }
		long? MaterialId { get; set; }
		long? ModelId { get; set; }
		BaseClass.BcElementinfo Eleminfo { get; set; }
		BaseClass.BcMaterial Material { get; set; }
		BaseClass.BcModel Model { get; set; }
		
		BcElemmaterial Clone();
	}
}
