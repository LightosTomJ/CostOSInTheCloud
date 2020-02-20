using System;

namespace Models.local.Interfaces
{
	public interface IAssemblyEquipment
	{
		long Assemblyequipmentid { get; set; }
		DateTime? Lastupdate { get; set; }
		decimal? Frate { get; set; }
		decimal? Fdeprate { get; set; }
		decimal? Energyprice { get; set; }
		decimal? Finalfuelrate { get; set; }
		decimal? Fuelrate { get; set; }
		decimal? Factor1 { get; set; }
		decimal? Factor2 { get; set; }
		decimal? Factor3 { get; set; }
		decimal? Qtypunit { get; set; }
		string Qtypunitform { get; set; }
		byte? Qtypuformstate { get; set; }
		decimal? Localfactor { get; set; }
		string Localcountry { get; set; }
		string Localstate { get; set; }
		decimal? Exchangerate { get; set; }
		decimal? Fixedcost { get; set; }
		decimal? Finalfixedcost { get; set; }
		decimal? Unithours { get; set; }
		string PvVars { get; set; }
		long? Equipmentid { get; set; }
		long? Assemblyid { get; set; }
		BaseClass.Assembly Assembly { get; set; }
		BaseClass.Equipment Equipment { get; set; }
		
		AssemblyEquipment Clone();
	}
}
