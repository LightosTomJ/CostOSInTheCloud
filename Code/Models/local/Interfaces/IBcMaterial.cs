
namespace Models.local.Interfaces
{
	public interface IBcMaterial
	{
		long Id { get; set; }
		string Code { get; set; }
		string Name { get; set; }
		long? ModelId { get; set; }
		Models.local.BaseClass.BcModel Model { get; set; }
		System.Collections.Generic.ICollection<BcElemmaterial> BcElemmaterial { get; set; }
		
		BcMaterial Clone();
	}
}
