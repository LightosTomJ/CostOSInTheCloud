
namespace Models.local
{
	public class BcSpatialinfo : BaseClass.BcSpatialinfo//, Interfaces.IBcSpatialinfo
	{
		public BcSpatialinfo Clone()
		{
			BcSpatialinfo c = new BcSpatialinfo();
			c.Id = Id;
			c.MaxX = MaxX;
			c.MaxY = MaxY;
			c.MaxZ = MaxZ;
			c.MinX = MinX;
			c.MinY = MinY;
			c.MinZ = MinZ;
			c.ElementId = ElementId;
			c.ModelId = ModelId;
			c.Element = Element;
			c.Model = Model;

			return c;
		}
	}
}
