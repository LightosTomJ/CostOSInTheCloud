using System;


namespace Models.local.Interfaces
{
	public interface IAssemblySubcontractor
	{
		long Assemblysubcontractorid { get; set; }
		DateTime? Lastupdate { get; set; }
		decimal? Frate { get; set; }
		decimal? Fikarate { get; set; }
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
		string PvVars { get; set; }
		long? Subcontractorid { get; set; }
		long? Assemblyid { get; set; }
		BaseClass.Assembly Assembly { get; set; }
		BaseClass.Subcontractor Subcontractor { get; set; }
		
		AssemblySubcontractor Clone();
	}
}
