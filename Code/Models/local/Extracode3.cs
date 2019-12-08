
namespace Models.local
{
	public class Extracode3 : BaseClass.Extracode3//, Interfaces.IExtracode3
	{
		public Extracode3 Clone()
		{
			Extracode3 c = new Extracode3();
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
