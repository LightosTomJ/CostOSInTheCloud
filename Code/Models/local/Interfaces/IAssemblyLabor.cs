
namespace Models.local.Interfaces
{
	public interface IAssemblyLabor
	{
		long Assemblylaborid { get; set; }
		System.DateTime? Lastupdate { get; set; }
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
		decimal? Unithours { get; set; }
		string PvVars { get; set; }
		long? Laborid { get; set; }
		long? Assemblyid { get; set; }
		Models.local.BaseClass.Assembly Assembly { get; set; }
		Models.local.BaseClass.Labor Labor { get; set; }
		
		AssemblyLabor Clone();
	}
}
