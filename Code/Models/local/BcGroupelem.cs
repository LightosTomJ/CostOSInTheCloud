
namespace Models.local
{
	public class BcGroupelem : BaseClass.BcGroupelem//, Interfaces.IBcGroupelem
	{
		public BcGroupelem Clone()
		{
			BcGroupelem c = new BcGroupelem();
			c.Id = Id;
			c.ElemId = ElemId;
			c.GroupId = GroupId;
			c.ModelId = ModelId;
			c.Elem = Elem;
			c.Group = Group;
			c.Model = Model;

			return c;
		}
	}
}
