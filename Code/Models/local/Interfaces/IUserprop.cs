
namespace Models.local.Interfaces
{
	public interface IUserprop
	{
		long Id { get; set; }
		string Userid { get; set; }
		string Pkey { get; set; }
		string Pval { get; set; }
		
		Userprop Clone();
	}
}
