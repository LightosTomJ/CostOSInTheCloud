
namespace Models.local.Interfaces
{
	public interface IBcQuantity
	{
		long Id { get; set; }
		string Grpname { get; set; }
		string Name { get; set; }
		int? Nameid { get; set; }
		int? Qtype { get; set; }
		decimal? Val { get; set; }
		long? ElementId { get; set; }
		long? ModelId { get; set; }
		Models.local.BaseClass.BcElement Element { get; set; }
		Models.local.BaseClass.BcModel Model { get; set; }
		
		BcQuantity Clone();
	}
}
