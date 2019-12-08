
namespace Models.local
{
	public class Benchmarkboqcolmap : BaseClass.Benchmarkboqcolmap//, Interfaces.IBenchmarkboqcolmap
	{
		public Benchmarkboqcolmap Clone()
		{
			Benchmarkboqcolmap c = new Benchmarkboqcolmap();
			c.Id = Id;
			c.Templateid = Templateid;
			c.Frombench = Frombench;
			c.Toboq = Toboq;
			c.Aggregate = Aggregate;
			c.Viewname = Viewname;

			return c;
		}
	}
}
