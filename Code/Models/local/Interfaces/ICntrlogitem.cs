
namespace Models.local.Interfaces
{
	public interface ICntrlogitem
	{
		long Id { get; set; }
		long? Logid { get; set; }
		string Fltr { get; set; }
		byte? Oprtn { get; set; }
		long? Itemid { get; set; }
		string Item { get; set; }
		long? Prjid { get; set; }
		
		Cntrlogitem Clone();
	}
}
