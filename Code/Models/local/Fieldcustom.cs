
namespace Models.local
{
	public class Fieldcustom : BaseClass.Fieldcustom//, Interfaces.IFieldcustom
	{
		public Fieldcustom Clone()
		{
			Fieldcustom c = new Fieldcustom();
			c.Id = Id;
			c.Name = Name;
			c.Displayname = Displayname;
			c.Formula = Formula;
			c.Rsrc = Rsrc;
			c.Editable = Editable;
			c.Sellist = Sellist;
			c.Selvals = Selvals;
			c.Defsel = Defsel;

			return c;
		}
	}
}
