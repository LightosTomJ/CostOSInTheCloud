
namespace Models.local
{
	public class BcGroup : BaseClass.BcGroup//, Interfaces.IBcGroup
	{
		public BcGroup Clone()
		{
			BcGroup c = new BcGroup();
			c.Id = Id;
			c.Description = Description;
			c.Globalid = Globalid;
			c.Name = Name;
			c.Type = Type;
			c.ModelId = ModelId;
			c.ParentId = ParentId;
			c.Model = Model;
			c.Parent = Parent;
			c.BcGroupelem = BcGroupelem;
			c.BcGroupprop = BcGroupprop;
			c.InverseParent = InverseParent;

			return c;
		}
	}
}
