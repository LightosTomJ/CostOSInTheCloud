
namespace Models.local
{
	public class Paraminput : BaseClass.Paraminput//, Interfaces.IParaminput
	{
		public Paraminput Clone()
		{
			Paraminput c = new Paraminput();
			c.Paraminputid = Paraminputid;
			c.Name = Name;
			c.Lbl = Lbl;
			c.Hidden = Hidden;
			c.Pblk = Pblk;
			c.Artype = Artype;
			c.Arsizevar = Arsizevar;
			c.Editable = Editable;
			c.Wasshown = Wasshown;
			c.Calcvaldigits = Calcvaldigits;
			c.Description = Description;
			c.Comment = Comment;
			c.Frmrowvis = Frmrowvis;
			c.Datatype = Datatype;
			c.Dependency = Dependency;
			c.Validation = Validation;
			c.Selection = Selection;
			c.Sortorder = Sortorder;
			c.Grouping = Grouping;
			c.Defvalue = Defvalue;
			c.Unit = Unit;
			c.Stoval = Stoval;
			c.Paramitemid = Paramitemid;
			c.Paramitem = Paramitem;

			return c;
		}
	}
}
