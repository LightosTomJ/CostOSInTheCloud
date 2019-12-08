
namespace Models.local
{
	public class Gekcode : BaseClass.Gekcode//, Interfaces.IGekcode
	{
		public Gekcode Clone()
		{
			Gekcode c = new Gekcode();
			c.Gekcodeid = Gekcodeid;
			c.Lastupdate = Lastupdate;
			c.Description = Description;
			c.Groupcode = Groupcode;
			c.Title = Title;
			c.Notes = Notes;
			c.Editorid = Editorid;
			c.Ufact = Ufact;
			c.Unit = Unit;

			return c;
		}
	}
}
