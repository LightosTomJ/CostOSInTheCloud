
namespace Models.local
{
	public class Cntrlog : BaseClass.Cntrlog//, Interfaces.ICntrlog
	{
		public Cntrlog Clone()
		{
			Cntrlog c = new Cntrlog();
			c.Id = Id;
			c.Logdate = Logdate;
			c.Editorid = Editorid;
			c.Description = Description;
			c.Src = Src;
			c.Fltr = Fltr;
			c.Prjid = Prjid;
			c.Oprtn = Oprtn;

			return c;
		}
	}
}
