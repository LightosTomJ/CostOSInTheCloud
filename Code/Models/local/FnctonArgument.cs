
namespace Models.local
{
	public class FnctonArgument : BaseClass.FnctonArgument//, Interfaces.IFnctonArgument
	{
		public FnctonArgument Clone()
		{
			FnctonArgument c = new FnctonArgument();
			c.Fargid = Fargid;
			c.Name = Name;
			c.Sorder = Sorder;
			c.Artype = Artype;
			c.Editable = Editable;
			c.Fid = Fid;
			c.Description = Description;
			c.Sellist = Sellist;
			c.Type = Type;
			c.Unit = Unit;
			c.Valsta = Valsta;
			c.Depsta = Depsta;
			c.Defval = Defval;
			c.Grouping = Grouping;
			c.Varscount = Varscount;
			c.F = F;

			return c;
		}
	}
}
