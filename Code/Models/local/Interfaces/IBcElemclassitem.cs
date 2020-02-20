
namespace Models.local.Interfaces
{
	public interface IBcElemclassitem
	{
		long Id { get; set; }
		long? ClassificationId { get; set; }
		long? ElementId { get; set; }
		long? ModelId { get; set; }
		BaseClass.BcClassitem Classification { get; set; }
		BaseClass.BcElement Element { get; set; }
		BaseClass.BcModel Model { get; set; }
		
		BcElemclassitem Clone();
	}
}
