
namespace Models.local.Interfaces
{
	public interface IAssemblyChild
	{
		long Assemblychildid { get; set; }
		System.DateTime? Lastupdate { get; set; }
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
		long? Childid { get; set; }
		long? Assemblyid { get; set; }
		Models.local.BaseClass.Assembly Assembly { get; set; }
		Models.local.BaseClass.Assembly Child { get; set; }
		
		AssemblyChild Clone();
	}
}
