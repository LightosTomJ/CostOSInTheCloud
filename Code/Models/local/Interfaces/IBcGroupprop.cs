
namespace Models.local.Interfaces
{
	public interface IBcGroupprop
	{
		long Id { get; set; }
		string Grpname { get; set; }
		string Name { get; set; }
		bool? Isnum { get; set; }
		decimal? Numval { get; set; }
		int? Qtytype { get; set; }
		string Txtval { get; set; }
		long? GroupId { get; set; }
		long? ModelId { get; set; }
		Models.local.BaseClass.BcGroup Group { get; set; }
		Models.local.BaseClass.BcModel Model { get; set; }
		
		BcGroupprop Clone();
	}
}
