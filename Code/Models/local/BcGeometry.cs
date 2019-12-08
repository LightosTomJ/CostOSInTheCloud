
namespace Models.local
{
	public class BcGeometry : BaseClass.BcGeometry//, Interfaces.IBcGeometry
	{
		public BcGeometry Clone()
		{
			BcGeometry c = new BcGeometry();
			c.Id = Id;
			c.Globalid = Globalid;
			c.Type = Type;
			c.ElementId = ElementId;
			c.GeomfileId = GeomfileId;
			c.ModelId = ModelId;
			c.Element = Element;
			c.Geomfile = Geomfile;
			c.Model = Model;

			return c;
		}
	}
}
