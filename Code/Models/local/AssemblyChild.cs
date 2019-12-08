
namespace Models.local
{
	public class AssemblyChild : BaseClass.AssemblyChild//, Interfaces.IAssemblyChild
	{
		public AssemblyChild Clone()
		{
			AssemblyChild c = new AssemblyChild();
			c.Assemblychildid = Assemblychildid;
			c.Lastupdate = Lastupdate;
			c.Frate = Frate;
			c.Factor1 = Factor1;
			c.Factor2 = Factor2;
			c.Divider = Divider;
			c.Qtypunit = Qtypunit;
			c.Qtypunitform = Qtypunitform;
			c.Qtypuformstate = Qtypuformstate;
			c.Localfactor = Localfactor;
			c.Localcountry = Localcountry;
			c.Localstate = Localstate;
			c.Exchangerate = Exchangerate;
			c.Fixedcost = Fixedcost;
			c.Finalfixedcost = Finalfixedcost;
			c.PvVars = PvVars;
			c.Childid = Childid;
			c.Assemblyid = Assemblyid;
			c.Assembly = Assembly;
			c.Child = Child;

			return c;
		}
	}
}
