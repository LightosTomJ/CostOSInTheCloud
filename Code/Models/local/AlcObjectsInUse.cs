
namespace Models.local
{
	public class AlcObjectsInUse : BaseClass.AlcObjectsInUse//, Interfaces.IAlcObjectsInUse
	{
		public AlcObjectsInUse Clone()
		{
			AlcObjectsInUse c = new AlcObjectsInUse();
			c.ObjId = ObjId;
			c.UserId = UserId;
			c.UseMode = UseMode;

			return c;
		}
	}
}
