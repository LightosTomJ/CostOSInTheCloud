
namespace Models.local.Interfaces
{
	public interface IAlcObjectsInUse
	{
		string ObjId { get; set; }
		System.Guid UserId { get; set; }
		int UseMode { get; set; }
		
		AlcObjectsInUse Clone();
	}
}
