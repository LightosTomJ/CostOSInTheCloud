
namespace Models.local.Interfaces
{
	public interface IRoles
	{
		string Roleid { get; set; }
		string Principalid { get; set; }
		string Role { get; set; }
		string Rolegroup { get; set; }
		
		Roles Clone();
	}
}
