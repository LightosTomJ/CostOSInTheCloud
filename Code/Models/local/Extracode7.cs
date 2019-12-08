
namespace Models.local
{
	public class Extracode7 : BaseClass.Extracode7//, Interfaces.IExtracode7
	{
		public Extracode7 Clone()
		{
			Extracode7 c = new Extracode7();
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
