
namespace Models.local.Interfaces
{
	public interface ICurrency
	{
		long Id { get; set; }
		string Cname { get; set; }
		string Symbol { get; set; }
		string Isocode { get; set; }
		string Isoflag { get; set; }
		
		Currency Clone();
	}
}
