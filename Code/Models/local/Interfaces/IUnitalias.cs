
namespace Models.local.Interfaces
{
	public interface IUnitalias
	{
		long Id { get; set; }
		string Frunit { get; set; }
		string Tounit { get; set; }
		
		Unitalias Clone();
	}
}
