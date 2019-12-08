
namespace Models.local.Interfaces
{
	public interface IAlcAmusers
	{
		System.Guid UserGid { get; set; }
		string UserId { get; set; }
		string Name { get; set; }
		string Password { get; set; }
		
		AlcAmusers Clone();
	}
}
