
namespace Models.local.Interfaces
{
	public interface IPrincipals
	{
		string Principalid { get; set; }
		string Authtype { get; set; }
		string Color { get; set; }
		string Email { get; set; }
		bool? Enbl { get; set; }
		string Hashkey { get; set; }
		string Name { get; set; }
		string Password { get; set; }
		
		Principals Clone();
	}
}
