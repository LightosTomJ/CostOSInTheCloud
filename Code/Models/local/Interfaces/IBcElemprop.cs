
namespace Models.local.Interfaces
{
	public interface IBcElemprop
	{
		long Id { get; set; }
		string Grpname { get; set; }
		string Name { get; set; }
		bool? Isnum { get; set; }
		decimal? Numval { get; set; }
		int? Qtytype { get; set; }
		string Txtval { get; set; }
		long? ElementId { get; set; }
		long? ModelId { get; set; }
		BaseClass.BcElement Element { get; set; }
		BaseClass.BcModel Model { get; set; }
		
		BcElemprop Clone();
	}
}