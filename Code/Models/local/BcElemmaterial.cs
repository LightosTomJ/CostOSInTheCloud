
namespace Models.local
{
	public class BcElemmaterial : BaseClass.BcElemmaterial//, Interfaces.IBcElemmaterial
	{
		public BcElemmaterial Clone()
		{
			BcElemmaterial c = new BcElemmaterial();
			c.Id = Id;
			c.Thickness = Thickness;
			c.EleminfoId = EleminfoId;
			c.MaterialId = MaterialId;
			c.ModelId = ModelId;
			c.Eleminfo = Eleminfo;
			c.Material = Material;
			c.Model = Model;

			return c;
		}
	}
}
