
namespace Models.local.Interfaces
{
	public interface IBcElemmaterial
	{
		long Id { get; set; }
		double? Thickness { get; set; }
		long? EleminfoId { get; set; }
		long? MaterialId { get; set; }
		long? ModelId { get; set; }
		Models.local.BaseClass.BcElementinfo Eleminfo { get; set; }
		Models.local.BaseClass.BcMaterial Material { get; set; }
		Models.local.BaseClass.BcModel Model { get; set; }
		
		BcElemmaterial Clone();
	}
}
