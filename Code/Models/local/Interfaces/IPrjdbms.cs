
namespace Models.local.Interfaces
{
	public interface IPrjdbms
	{
		long Id { get; set; }
		string Hname { get; set; }
		string Hport { get; set; }
		int? Hdbms { get; set; }
		string Hinst { get; set; }
		string Huser { get; set; }
		string Hpass { get; set; }
		string Dbname { get; set; }
		System.Collections.Generic.ICollection<Projecturl> Projecturl { get; set; }
		
		Prjdbms Clone();
	}
}
