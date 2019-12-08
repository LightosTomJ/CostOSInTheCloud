
namespace Models.local
{
	public class AssemblyMaterial : BaseClass.AssemblyMaterial//, Interfaces.IAssemblyMaterial
	{
		public AssemblyMaterial Clone()
		{
			AssemblyMaterial c = new AssemblyMaterial();
			c.Assemblymaterialid = Assemblymaterialid;
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
			c.Materialid = Materialid;
			c.Assemblyid = Assemblyid;
			c.Assembly = Assembly;
			c.Material = Material;

			return c;
		}
	}
}
