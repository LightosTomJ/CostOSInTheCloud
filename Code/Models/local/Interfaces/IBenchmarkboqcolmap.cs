
namespace Models.local.Interfaces
{
	public interface IBenchmarkboqcolmap
	{
		long Id { get; set; }
		long? Templateid { get; set; }
		string Frombench { get; set; }
		string Toboq { get; set; }
		string Aggregate { get; set; }
		string Viewname { get; set; }
		
		Benchmarkboqcolmap Clone();
	}
}
