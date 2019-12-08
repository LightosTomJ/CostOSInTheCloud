
namespace Models.local
{
	public class BcClassification : BaseClass.BcClassification//, Interfaces.IBcClassification
	{
		public BcClassification Clone()
		{
			BcClassification c = new BcClassification();
			c.Id = Id;
			c.Edition = Edition;
			c.Location = Location;
			c.Name = Name;
			c.ModelId = ModelId;
			c.Model = Model;
			c.BcClassitem = BcClassitem;

			return c;
		}
	}
}
