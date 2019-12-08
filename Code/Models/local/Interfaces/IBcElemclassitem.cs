
namespace Models.local.Interfaces
{
	public interface IBcElemclassitem
	{
		long Id { get; set; }
		long? ClassificationId { get; set; }
		long? ElementId { get; set; }
		long? ModelId { get; set; }
		Models.local.BaseClass.BcClassitem Classification { get; set; }
		Models.local.BaseClass.BcElement Element { get; set; }
		Models.local.BaseClass.BcModel Model { get; set; }
		
		BcElemclassitem Clone();
	}
}
