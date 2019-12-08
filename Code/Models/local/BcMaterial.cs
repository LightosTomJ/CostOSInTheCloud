
namespace Models.local
{
	public class BcMaterial : BaseClass.BcMaterial//, Interfaces.IBcMaterial
	{
		public BcMaterial Clone()
		{
			BcMaterial c = new BcMaterial();
			c.Id = Id;
			c.Code = Code;
			c.Name = Name;
			c.ModelId = ModelId;
			c.Model = Model;
			c.BcElemmaterial = BcElemmaterial;

			return c;
		}
	}
}
