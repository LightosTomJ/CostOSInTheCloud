
namespace Models.local
{
	public class AssemblyConsumable : BaseClass.AssemblyConsumable//, Interfaces.IAssemblyConsumable
	{
		public AssemblyConsumable Clone()
		{
			AssemblyConsumable c = new AssemblyConsumable();
			c.Assemblyconsumableid = Assemblyconsumableid;
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
			c.Consumableid = Consumableid;
			c.Assemblyid = Assemblyid;
			c.Assembly = Assembly;
			c.Consumable = Consumable;

			return c;
		}
	}
}
