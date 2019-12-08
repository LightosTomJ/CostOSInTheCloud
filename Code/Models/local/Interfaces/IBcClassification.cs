
namespace Models.local.Interfaces
{
	public interface IBcClassification
	{
		long Id { get; set; }
		string Edition { get; set; }
		string Location { get; set; }
		string Name { get; set; }
		long? ModelId { get; set; }
		Models.local.BaseClass.BcModel Model { get; set; }
		System.Collections.Generic.ICollection<BcClassitem> BcClassitem { get; set; }
		
		BcClassification Clone();
	}
}
