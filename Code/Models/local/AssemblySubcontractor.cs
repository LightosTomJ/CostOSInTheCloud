
namespace Models.local
{
	public class AssemblySubcontractor : BaseClass.AssemblySubcontractor//, Interfaces.IAssemblySubcontractor
	{
		public AssemblySubcontractor Clone()
		{
			AssemblySubcontractor c = new AssemblySubcontractor();
			c.Assemblysubcontractorid = Assemblysubcontractorid;
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
			c.PvVars = PvVars;
			c.Subcontractorid = Subcontractorid;
			c.Assemblyid = Assemblyid;
			c.Assembly = Assembly;
			c.Subcontractor = Subcontractor;

			return c;
		}
	}
}
