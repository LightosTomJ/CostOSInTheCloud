
namespace Models.local.Interfaces
{
	public interface ICountry
	{
		long Id { get; set; }
		string Ccode { get; set; }
		string Cname { get; set; }
		
		Country Clone();
	}
}
