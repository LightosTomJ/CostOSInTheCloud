
namespace Models.local.Interfaces
{
	public interface IBcElemcovering
	{
		long Id { get; set; }
		int? Type { get; set; }
		long? CoverelemId { get; set; }
		long? ModelId { get; set; }
		long? RelatingelemId { get; set; }
		Models.local.BaseClass.BcElement Coverelem { get; set; }
		Models.local.BaseClass.BcModel Model { get; set; }
		Models.local.BaseClass.BcElement Relatingelem { get; set; }
		
		BcElemcovering Clone();
	}
}
