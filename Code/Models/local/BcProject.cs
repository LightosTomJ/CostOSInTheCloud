
namespace Models.local
{
	public class BcProject : BaseClass.BcProject//, Interfaces.IBcProject
	{
		public BcProject Clone()
		{
			BcProject c = new BcProject();
			c.Id = Id;
			c.Code = Code;
			c.Descr = Descr;
			c.Globalid = Globalid;
			c.Deleted = Deleted;
			c.Name = Name;
			c.ParentId = ParentId;
			c.Parent = Parent;
			c.BcModel = BcModel;
			c.InverseParent = InverseParent;

			return c;
		}
	}
}
