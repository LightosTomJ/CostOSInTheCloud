
namespace Models.local
{
	public class BcElementinfo : BaseClass.BcElementinfo//, Interfaces.IBcElementinfo
	{
		public BcElementinfo Clone()
		{
			BcElementinfo c = new BcElementinfo();
			c.Id = Id;
			c.Label = Label;
			c.Material = Material;
			c.Type = Type;
			c.ElementId = ElementId;
			c.ModelId = ModelId;
			c.Element = Element;
			c.Model = Model;
			c.BcElemmaterial = BcElemmaterial;

			return c;
		}
	}
}
