
namespace Models.local.Interfaces
{
	public interface IPrjprop
	{
		long Id { get; set; }
		string Pkey { get; set; }
		string Pval { get; set; }
		long? Projecturlid { get; set; }
		Models.local.BaseClass.Projecturl Projecturl { get; set; }
		
		Prjprop Clone();
	}
}
