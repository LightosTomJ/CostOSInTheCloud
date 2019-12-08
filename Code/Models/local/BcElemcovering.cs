
namespace Models.local
{
	public class BcElemcovering : BaseClass.BcElemcovering//, Interfaces.IBcElemcovering
	{
		public BcElemcovering Clone()
		{
			BcElemcovering c = new BcElemcovering();
			c.Id = Id;
			c.Type = Type;
			c.CoverelemId = CoverelemId;
			c.ModelId = ModelId;
			c.RelatingelemId = RelatingelemId;
			c.Coverelem = Coverelem;
			c.Model = Model;
			c.Relatingelem = Relatingelem;

			return c;
		}
	}
}
