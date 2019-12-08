using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IAssembly
	{
		long Assemblyid { get; set; }
		System.DateTime? Lastupdate { get; set; }
		bool? Virtual { get; set; }
		bool? Virtualequ { get; set; }
		bool? Virtualsub { get; set; }
		bool? Virtuallab { get; set; }
		bool? Virtualmat { get; set; }
		bool? Virtualcon { get; set; }
		int? Overtype { get; set; }
		bool? Actbased { get; set; }
		string Description { get; set; }
		string Unit { get; set; }
		decimal? Productivity { get; set; }
		decimal? Publishedrate { get; set; }
		string Publishedcode { get; set; }
		string Rescode { get; set; }
		string Groupcode { get; set; }
		string Gekcode { get; set; }
		string Project { get; set; }
		string Accrights { get; set; }
		string Keyw { get; set; }
		string Title { get; set; }
		string Notes { get; set; }
		string Editorid { get; set; }
		string Currency { get; set; }
		string Stateprovince { get; set; }
		decimal? Rate { get; set; }
		decimal? Labrate { get; set; }
		decimal? Matrate { get; set; }
		decimal? Subrate { get; set; }
		decimal? Conrate { get; set; }
		decimal? Equrate { get; set; }
		decimal? Umhours { get; set; }
		decimal? Uehours { get; set; }
		decimal? Qty { get; set; }
		string Accuracy { get; set; }
		string Createuser { get; set; }
		System.DateTime? Createdate { get; set; }
		string Bimtype { get; set; }
		string Bimmaterial { get; set; }
		string Country { get; set; }
		string Custxt1 { get; set; }
		string Custxt2 { get; set; }
		string Custxt3 { get; set; }
		string Custxt4 { get; set; }
		string Custxt5 { get; set; }
		string Custxt6 { get; set; }
		string Custxt7 { get; set; }
		string Custxt8 { get; set; }
		string Custxt9 { get; set; }
		string Custxt10 { get; set; }
		string Custxt11 { get; set; }
		string Custxt12 { get; set; }
		string Custxt13 { get; set; }
		string Custxt14 { get; set; }
		string Custxt15 { get; set; }
		string Custxt16 { get; set; }
		string Custxt17 { get; set; }
		string Custxt18 { get; set; }
		string Custxt19 { get; set; }
		string Custxt20 { get; set; }
		string Custxt21 { get; set; }
		string Custxt22 { get; set; }
		string Custxt23 { get; set; }
		string Custxt24 { get; set; }
		string Custxt25 { get; set; }
		decimal? Cusrate1 { get; set; }
		decimal? Cusrate2 { get; set; }
		decimal? Cusrate3 { get; set; }
		decimal? Cusrate4 { get; set; }
		decimal? Cusrate5 { get; set; }
		decimal? Cusrate6 { get; set; }
		decimal? Cusrate7 { get; set; }
		decimal? Cusrate8 { get; set; }
		decimal? Cusrate9 { get; set; }
		decimal? Cusrate10 { get; set; }
		decimal? Cusrate11 { get; set; }
		decimal? Cusrate12 { get; set; }
		decimal? Cusrate13 { get; set; }
		decimal? Cusrate14 { get; set; }
		decimal? Cusrate15 { get; set; }
		decimal? Cusrate16 { get; set; }
		decimal? Cusrate17 { get; set; }
		decimal? Cusrate18 { get; set; }
		decimal? Cusrate19 { get; set; }
		decimal? Cusrate20 { get; set; }
		string Extracode1 { get; set; }
		string Extracode2 { get; set; }
		string Extracode3 { get; set; }
		string Extracode4 { get; set; }
		string Extracode5 { get; set; }
		string Extracode6 { get; set; }
		string Extracode7 { get; set; }
		string Extracode8 { get; set; }
		string Extracode9 { get; set; }
		string Extracode10 { get; set; }
		string Vars { get; set; }
		decimal? Pugrcfactor { get; set; }
		decimal? Pugekfactor { get; set; }
		decimal? Puex1factor { get; set; }
		decimal? Puex2factor { get; set; }
		decimal? Puex3factor { get; set; }
		decimal? Puex4factor { get; set; }
		decimal? Puex5factor { get; set; }
		decimal? Puex6factor { get; set; }
		decimal? Puex7factor { get; set; }
        ICollection<IAssemblyChild> AssemblyChildAssembly  { get; set; }
		System.Collections.Generic.ICollection<AssemblyChild> AssemblyChildChild { get; set; }
		System.Collections.Generic.ICollection<AssemblyConsumable> AssemblyConsumable { get; set; }
		System.Collections.Generic.ICollection<AssemblyEquipment> AssemblyEquipment { get; set; }
		System.Collections.Generic.ICollection<AssemblyLabor> AssemblyLabor { get; set; }
		System.Collections.Generic.ICollection<AssemblyMaterial> AssemblyMaterial { get; set; }
		System.Collections.Generic.ICollection<AssemblySubcontractor> AssemblySubcontractor { get; set; }
		
		Assembly Clone();
	}
    //public interface IAssemblyChild<T> where T : IAssemblyChild
    //{
    //    List<T> AssemblyChild { get; set; }
    //}
}
