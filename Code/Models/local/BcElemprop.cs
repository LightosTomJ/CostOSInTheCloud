
namespace Models.local
{
	public class BcElemprop : BaseClass.BcElemprop//, Interfaces.IBcElemprop
	{
		public BcElemprop Clone()
		{
			BcElemprop c = new BcElemprop();
			c.Id = Id;
			c.Grpname = Grpname;
			c.Name = Name;
			c.Isnum = Isnum;
			c.Numval = Numval;
			c.Qtytype = Qtytype;
			c.Txtval = Txtval;
			c.ElementId = ElementId;
			c.ModelId = ModelId;
			c.Element = Element;
			c.Model = Model;

			return c;
		}
	}
}
