
namespace Models.local
{
	public class Extracode1 : BaseClass.Extracode1//, Interfaces.IExtracode1
	{
		public Extracode1 Clone()
		{
			Extracode1 c = new Extracode1();
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
