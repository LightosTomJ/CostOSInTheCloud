
namespace Models.local.Interfaces
{
	public interface IUsersessions
	{
		long Id { get; set; }
		string Username { get; set; }
		string Serialkey { get; set; }
		System.DateTime? LoggedinDate { get; set; }
		System.DateTime? LastupdateDate { get; set; }
		
		Usersessions Clone();
	}
}
