
namespace Models.local.Interfaces
{
	public interface IBcElemconnection
	{
		long Id { get; set; }
		string Globalid { get; set; }
		string Name { get; set; }
		int? Relatedtype { get; set; }
		int? Relatingtype { get; set; }
		long? ModelId { get; set; }
		long? RelatedelemId { get; set; }
		long? RelatingelemId { get; set; }
		BaseClass.BcModel Model { get; set; }
		BaseClass.BcElement Relatedelem { get; set; }
		BaseClass.BcElement Relatingelem { get; set; }
		
		BcElemconnection Clone();
	}
}
