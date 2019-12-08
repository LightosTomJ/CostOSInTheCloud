
namespace Models.local.Interfaces
{
	public interface IAlcUserGroups
	{
		System.Guid UserId { get; set; }
		System.Guid GroupId { get; set; }
		
		AlcUserGroups Clone();
	}
}
