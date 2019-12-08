
namespace Models.local
{
	public class Extracode2 : BaseClass.Extracode2//, Interfaces.IExtracode2
	{
		public Extracode2 Clone()
		{
			Extracode2 c = new Extracode2();
			c.Groupcodeid = Groupcodeid;
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
