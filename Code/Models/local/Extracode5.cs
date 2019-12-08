
namespace Models.local
{
	public class Extracode5 : BaseClass.Extracode5//, Interfaces.IExtracode5
	{
		public Extracode5 Clone()
		{
			Extracode5 c = new Extracode5();
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
