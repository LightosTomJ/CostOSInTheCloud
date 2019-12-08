
namespace Models.local
{
	public class BcElemconnection : BaseClass.BcElemconnection//, Interfaces.IBcElemconnection
	{
		public BcElemconnection Clone()
		{
			BcElemconnection c = new BcElemconnection();
			c.Id = Id;
			c.Globalid = Globalid;
			c.Name = Name;
			c.Relatedtype = Relatedtype;
			c.Relatingtype = Relatingtype;
			c.ModelId = ModelId;
			c.RelatedelemId = RelatedelemId;
			c.RelatingelemId = RelatingelemId;
			c.Model = Model;
			c.Relatedelem = Relatedelem;
			c.Relatingelem = Relatingelem;

			return c;
		}
	}
}
