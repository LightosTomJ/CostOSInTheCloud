
namespace Models.local.Interfaces
{
	public interface IFldfn
	{
		long Fldfnid { get; set; }
		string Name { get; set; }
		string Ftype { get; set; }
		string Fpath { get; set; }
		long? Rpdfnid { get; set; }
		int? Rpdfnfildefcount { get; set; }
		BaseClass.Rpdfn Rpdfn { get; set; }
		
		Fldfn Clone();
	}
}
