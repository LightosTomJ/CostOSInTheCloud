
namespace Models.local
{
	public class BcElemclassitem : BaseClass.BcElemclassitem//, Interfaces.IBcElemclassitem
	{
		public BcElemclassitem Clone()
		{
			BcElemclassitem c = new BcElemclassitem();
			c.Id = Id;
			c.ClassificationId = ClassificationId;
			c.ElementId = ElementId;
			c.ModelId = ModelId;
			c.Classification = Classification;
			c.Element = Element;
			c.Model = Model;

			return c;
		}
	}
}
