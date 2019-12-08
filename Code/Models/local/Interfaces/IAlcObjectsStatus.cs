
namespace Models.local.Interfaces
{
	public interface IAlcObjectsStatus
	{
		string ObjId { get; set; }
		System.Guid Version { get; set; }
		
		AlcObjectsStatus Clone();
	}
}
