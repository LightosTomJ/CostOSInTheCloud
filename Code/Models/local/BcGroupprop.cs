
namespace Models.local
{
	public class BcGroupprop : BaseClass.BcGroupprop//, Interfaces.IBcGroupprop
	{
		public BcGroupprop Clone()
		{
			BcGroupprop c = new BcGroupprop();
			c.Id = Id;
			c.Grpname = Grpname;
			c.Name = Name;
			c.Isnum = Isnum;
			c.Numval = Numval;
			c.Qtytype = Qtytype;
			c.Txtval = Txtval;
			c.GroupId = GroupId;
			c.ModelId = ModelId;
			c.Group = Group;
			c.Model = Model;

			return c;
		}
	}
}
