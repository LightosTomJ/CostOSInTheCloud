
namespace Models.local
{
	public class BcQuantity : BaseClass.BcQuantity//, Interfaces.IBcQuantity
	{
		public BcQuantity Clone()
		{
			BcQuantity c = new BcQuantity();
			c.Id = Id;
			c.Grpname = Grpname;
			c.Name = Name;
			c.Nameid = Nameid;
			c.Qtype = Qtype;
			c.Val = Val;
			c.ElementId = ElementId;
			c.ModelId = ModelId;
			c.Element = Element;
			c.Model = Model;

			return c;
		}
	}
}
