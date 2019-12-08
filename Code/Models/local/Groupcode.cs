
namespace Models.local
{
	public class Groupcode : BaseClass.Groupcode//, Interfaces.IGroupcode
	{
		public Groupcode Clone()
		{
			Groupcode c = new Groupcode();
			c.Groupcodeid = Groupcodeid;
			c.Lastupdate = Lastupdate;
			c.Description = Description;
			c.Groupcode1 = Groupcode1;
			c.Title = Title;
			c.Notes = Notes;
			c.Editorid = Editorid;
			c.Ufact = Ufact;
			c.Unit = Unit;

			return c;
		}
	}
}
