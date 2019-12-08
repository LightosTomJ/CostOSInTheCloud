
namespace Models.local
{
	public class BcElement : BaseClass.BcElement//, Interfaces.IBcElement
	{
		public BcElement Clone()
		{
			BcElement c = new BcElement();
			c.Id = Id;
			c.Globalid = Globalid;
			c.Hasgeom = Hasgeom;
			c.Layer = Layer;
			c.Name = Name;
			c.Spatial = Spatial;
			c.Tagid = Tagid;
			c.Type = Type;
			c.Typedesc = Typedesc;
			c.ContainedbyId = ContainedbyId;
			c.ModelId = ModelId;
			c.ParentId = ParentId;
			c.Containedby = Containedby;
			c.Model = Model;
			c.Parent = Parent;
			c.BcElemclassitem = BcElemclassitem;
			c.BcElemconnectionRelatedelem = BcElemconnectionRelatedelem;
			c.BcElemconnectionRelatingelem = BcElemconnectionRelatingelem;
			c.BcElemcoveringCoverelem = BcElemcoveringCoverelem;
			c.BcElemcoveringRelatingelem = BcElemcoveringRelatingelem;
			c.BcElementinfo = BcElementinfo;
			c.BcElemprop = BcElemprop;
			c.BcGeometry = BcGeometry;
			c.BcGroupelem = BcGroupelem;
			c.BcQuantity = BcQuantity;
			c.BcSpatialinfo = BcSpatialinfo;
			c.InverseContainedby = InverseContainedby;
			c.InverseParent = InverseParent;

			return c;
		}
	}
}
