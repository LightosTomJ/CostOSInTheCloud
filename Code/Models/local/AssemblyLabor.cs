
namespace Models.local
{
	public class AssemblyLabor : BaseClass.AssemblyLabor//, Interfaces.IAssemblyLabor
	{
		public AssemblyLabor Clone()
		{
			AssemblyLabor c = new AssemblyLabor();
			c.Assemblylaborid = Assemblylaborid;
			c.Lastupdate = Lastupdate;
			c.Frate = Frate;
			c.Fikarate = Fikarate;
			c.Factor1 = Factor1;
			c.Factor2 = Factor2;
			c.Factor3 = Factor3;
			c.Qtypunit = Qtypunit;
			c.Qtypunitform = Qtypunitform;
			c.Qtypuformstate = Qtypuformstate;
			c.Localfactor = Localfactor;
			c.Localcountry = Localcountry;
			c.Localstate = Localstate;
			c.Exchangerate = Exchangerate;
			c.Fixedcost = Fixedcost;
			c.Finalfixedcost = Finalfixedcost;
			c.Unithours = Unithours;
			c.PvVars = PvVars;
			c.Laborid = Laborid;
			c.Assemblyid = Assemblyid;
			c.Assembly = Assembly;
			c.Labor = Labor;

			return c;
		}
	}
}
