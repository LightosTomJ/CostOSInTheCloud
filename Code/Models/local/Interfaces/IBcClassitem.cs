
namespace Models.local.Interfaces
{
	public interface IBcClassitem
	{
		long Id { get; set; }
		string Code { get; set; }
		string Name { get; set; }
		long? ClassificationId { get; set; }
		long? ModelId { get; set; }
		Models.local.BaseClass.BcClassification Classification { get; set; }
		Models.local.BaseClass.BcModel Model { get; set; }
		System.Collections.Generic.ICollection<BcElemclassitem> BcElemclassitem { get; set; }
		
		BcClassitem Clone();
	}
}
