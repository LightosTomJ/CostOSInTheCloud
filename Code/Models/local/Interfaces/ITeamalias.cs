
namespace Models.local.Interfaces
{
	public interface ITeamalias
	{
		long Id { get; set; }
		string Team { get; set; }
		string Alias { get; set; }
		
		Teamalias Clone();
	}
}
