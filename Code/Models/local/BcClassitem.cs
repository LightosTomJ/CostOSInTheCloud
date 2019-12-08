
namespace Models.local
{
	public class BcClassitem : BaseClass.BcClassitem//, Interfaces.IBcClassitem
	{
		public BcClassitem Clone()
		{
			BcClassitem c = new BcClassitem();
			c.Id = Id;
			c.Code = Code;
			c.Name = Name;
			c.ClassificationId = ClassificationId;
			c.ModelId = ModelId;
			c.Classification = Classification;
			c.Model = Model;
			c.BcElemclassitem = BcElemclassitem;

			return c;
		}
	}
}
