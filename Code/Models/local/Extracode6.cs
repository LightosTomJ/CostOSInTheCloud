
namespace Models.local
{
	public class Extracode6 : BaseClass.Extracode6//, Interfaces.IExtracode6
	{
		public Extracode6 Clone()
		{
			Extracode6 c = new Extracode6();
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
