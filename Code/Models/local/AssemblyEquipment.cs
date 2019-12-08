
namespace Models.local
{
	public class AssemblyEquipment : BaseClass.AssemblyEquipment//, Interfaces.IAssemblyEquipment
	{
		public AssemblyEquipment Clone()
		{
			AssemblyEquipment c = new AssemblyEquipment();
			c.Assemblyequipmentid = Assemblyequipmentid;
			c.Lastupdate = Lastupdate;
			c.Frate = Frate;
			c.Fdeprate = Fdeprate;
			c.Energyprice = Energyprice;
			c.Finalfuelrate = Finalfuelrate;
			c.Fuelrate = Fuelrate;
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
			c.Equipmentid = Equipmentid;
			c.Assemblyid = Assemblyid;
			c.Assembly = Assembly;
			c.Equipment = Equipment;

			return c;
		}
	}
}
