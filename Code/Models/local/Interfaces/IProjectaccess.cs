
namespace Models.local.Interfaces
{
	public interface IProjectaccess
	{
		long Paid { get; set; }
		string Title { get; set; }
		string Acccon { get; set; }
		bool? Aladd { get; set; }
		bool? Alupd { get; set; }
		bool? Alrem { get; set; }
		long? Puid { get; set; }
		BaseClass.Projectuser Pu { get; set; }
		
		Projectaccess Clone();
	}
}
