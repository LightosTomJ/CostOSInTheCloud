
namespace Models.local
{
	public class AlcObjectsStatus : BaseClass.AlcObjectsStatus//, Interfaces.IAlcObjectsStatus
	{
		public AlcObjectsStatus Clone()
		{
			AlcObjectsStatus c = new AlcObjectsStatus();
			c.ObjId = ObjId;
			c.Version = Version;

			return c;
		}
	}
}
