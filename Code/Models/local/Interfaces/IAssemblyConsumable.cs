using System;

namespace Models.local.Interfaces
{
	public interface IAssemblyConsumable
	{
		long Assemblyconsumableid { get; set; }
		DateTime? Lastupdate { get; set; }
		decimal? Frate { get; set; }
		decimal? Factor1 { get; set; }
		decimal? Factor2 { get; set; }
		decimal? Divider { get; set; }
		decimal? Qtypunit { get; set; }
		string Qtypunitform { get; set; }
		byte? Qtypuformstate { get; set; }
		decimal? Localfactor { get; set; }
		string Localcountry { get; set; }
		string Localstate { get; set; }
		decimal? Exchangerate { get; set; }
		decimal? Fixedcost { get; set; }
		decimal? Finalfixedcost { get; set; }
		string PvVars { get; set; }
		long? Consumableid { get; set; }
		long? Assemblyid { get; set; }
		BaseClass.Assembly Assembly { get; set; }
		BaseClass.Consumable Consumable { get; set; }
		
		AssemblyConsumable Clone();
	}
}
