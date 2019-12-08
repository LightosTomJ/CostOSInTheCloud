
namespace Models.local.Interfaces
{
	public interface IQueryrow
	{
		long Qrowid { get; set; }
		string Fname { get; set; }
		string Rname { get; set; }
		string Cndn { get; set; }
		string Ctype { get; set; }
		long? Qresid { get; set; }
		int? Qrowscount { get; set; }
		Models.local.BaseClass.Queryresource Qres { get; set; }
		
		Queryrow Clone();
	}
}
