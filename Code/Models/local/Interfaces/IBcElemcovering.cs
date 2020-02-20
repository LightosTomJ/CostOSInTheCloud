
namespace Models.local.Interfaces
{
	public interface IBcElemcovering
	{
		long Id { get; set; }
		int? Type { get; set; }
		long? CoverelemId { get; set; }
		long? ModelId { get; set; }
		long? RelatingelemId { get; set; }
		BcElement Coverelem { get; set; }
		BcModel Model { get; set; }
		BcElement Relatingelem { get; set; }
		
		BcElemcovering Clone();
	}
}
