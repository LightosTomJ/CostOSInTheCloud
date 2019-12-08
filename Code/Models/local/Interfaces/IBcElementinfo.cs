
namespace Models.local.Interfaces
{
	public interface IBcElementinfo
	{
		long Id { get; set; }
		string Label { get; set; }
		string Material { get; set; }
		string Type { get; set; }
		long? ElementId { get; set; }
		long? ModelId { get; set; }
		Models.local.BaseClass.BcElement Element { get; set; }
		Models.local.BaseClass.BcModel Model { get; set; }
		System.Collections.Generic.ICollection<BcElemmaterial> BcElemmaterial { get; set; }
		
		BcElementinfo Clone();
	}
}
