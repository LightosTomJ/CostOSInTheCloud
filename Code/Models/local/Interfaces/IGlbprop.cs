
namespace Models.local.Interfaces
{
	public interface IGlbprop
	{
		long Id { get; set; }
		string Pkey { get; set; }
		string Pval { get; set; }
		
		Glbprop Clone();
	}
}
