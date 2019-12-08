
namespace Models.local
{
	public class Ratebuildup : BaseClass.Ratebuildup//, Interfaces.IRatebuildup
	{
		public Ratebuildup Clone()
		{
			Ratebuildup c = new Ratebuildup();
			c.Id = Id;
			c.Templateid = Templateid;
			c.Restype = Restype;
			c.Resid = Resid;
			c.Resprjid = Resprjid;
			c.Onln = Onln;
			c.Dbcreatedate = Dbcreatedate;
			c.Calcformula = Calcformula;
			c.Overrate1 = Overrate1;
			c.Frate = Frate;
			c.Rate0 = Rate0;
			c.Rate1 = Rate1;
			c.Rate2 = Rate2;
			c.Rate3 = Rate3;
			c.Rate4 = Rate4;
			c.Rate5 = Rate5;
			c.Rate6 = Rate6;
			c.Rate7 = Rate7;
			c.Rate8 = Rate8;
			c.Rate9 = Rate9;
			c.Rate10 = Rate10;
			c.Rate11 = Rate11;
			c.Rate12 = Rate12;
			c.Rate13 = Rate13;
			c.Rate14 = Rate14;
			c.Template = Template;

			return c;
		}
	}
}
