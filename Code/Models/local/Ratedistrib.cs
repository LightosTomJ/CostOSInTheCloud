
namespace Models.local
{
	public class Ratedistrib : BaseClass.Ratedistrib//, Interfaces.IRatedistrib
	{
		public Ratedistrib Clone()
		{
			Ratedistrib c = new Ratedistrib();
			c.Id = Id;
			c.Templateid = Templateid;
			c.Name = Name;
			c.Description = Description;
			c.Sortorder = Sortorder;
			c.Disttype = Disttype;
			c.Balanced = Balanced;
			c.Dstrbtd = Dstrbtd;
			c.Targetfield = Targetfield;
			c.Targetcostfield = Targetcostfield;
			c.Distranges = Distranges;
			c.Distrates = Distrates;
			c.Mapped = Mapped;
			c.Sheetno = Sheetno;
			c.Cellx = Cellx;
			c.Celly = Celly;
			c.Stovalnum = Stovalnum;
			c.Template = Template;

			return c;
		}
	}
}
