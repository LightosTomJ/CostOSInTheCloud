
namespace Models.local.Interfaces
{
	public interface IProjecteps
	{
		long Projectepsid { get; set; }
		string Code { get; set; }
		string Title { get; set; }
		string Editorid { get; set; }
		string Description { get; set; }
		System.DateTime? Lastupdate { get; set; }
		long? Parentid { get; set; }
		System.Collections.Generic.ICollection<Projectinfo> Projectinfo { get; set; }
		
		Projecteps Clone();
	}
}
