
namespace Models.local
{
	public class Projectspecvar : BaseClass.Projectspecvar//, Interfaces.IProjectspecvar
	{
		public Projectspecvar Clone()
		{
			Projectspecvar c = new Projectspecvar();
			c.Id = Id;
			c.Templateid = Templateid;
			c.Name = Name;
			c.Description = Description;
			c.Datatype = Datatype;
			c.Defval = Defval;
			c.Stoval = Stoval;
			c.Sortorder = Sortorder;
			c.Cellx = Cellx;
			c.Celly = Celly;
			c.Sheetno = Sheetno;
			c.Mapped = Mapped;
			c.Stovalnum = Stovalnum;
			c.Isnumber = Isnumber;
			c.Mandatory = Mandatory;
			c.Pushfield = Pushfield;
			c.Template = Template;

			return c;
		}
	}
}
