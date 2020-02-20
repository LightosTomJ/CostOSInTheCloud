
namespace Models.local.Interfaces
{
	public interface IRatebuildupcols
	{
		long Id { get; set; }
		long? Templateid { get; set; }
		string Restype { get; set; }
		string Tablepref { get; set; }
		string Sortpref { get; set; }
		bool? Applyall { get; set; }
		string Rowformula { get; set; }
		string Colname0 { get; set; }
		int? Coltype0 { get; set; }
		bool? Colact0 { get; set; }
		string Colform0 { get; set; }
		string Colname1 { get; set; }
		int? Coltype1 { get; set; }
		bool? Colact1 { get; set; }
		string Colform1 { get; set; }
		string Colname2 { get; set; }
		int? Coltype2 { get; set; }
		bool? Colact2 { get; set; }
		string Colform2 { get; set; }
		string Colname3 { get; set; }
		int? Coltype3 { get; set; }
		bool? Colact3 { get; set; }
		string Colform3 { get; set; }
		string Colname4 { get; set; }
		int? Coltype4 { get; set; }
		bool? Colact4 { get; set; }
		string Colform4 { get; set; }
		string Colname5 { get; set; }
		int? Coltype5 { get; set; }
		bool? Colact5 { get; set; }
		string Colform5 { get; set; }
		string Colname6 { get; set; }
		int? Coltype6 { get; set; }
		bool? Colact6 { get; set; }
		string Colform6 { get; set; }
		string Colname7 { get; set; }
		int? Coltype7 { get; set; }
		bool? Colact7 { get; set; }
		string Colform7 { get; set; }
		string Colname8 { get; set; }
		int? Coltype8 { get; set; }
		bool? Colact8 { get; set; }
		string Colform8 { get; set; }
		string Colname9 { get; set; }
		int? Coltype9 { get; set; }
		bool? Colact9 { get; set; }
		string Colform9 { get; set; }
		string Colname10 { get; set; }
		int? Coltype10 { get; set; }
		bool? Colact10 { get; set; }
		string Colform10 { get; set; }
		string Colname11 { get; set; }
		int? Coltype11 { get; set; }
		bool? Colact11 { get; set; }
		string Colform11 { get; set; }
		string Colname12 { get; set; }
		int? Coltype12 { get; set; }
		bool? Colact12 { get; set; }
		string Colform12 { get; set; }
		string Colname13 { get; set; }
		int? Coltype13 { get; set; }
		bool? Colact13 { get; set; }
		string Colform13 { get; set; }
		string Colname14 { get; set; }
		int? Coltype14 { get; set; }
		bool? Colact14 { get; set; }
		string Colform14 { get; set; }
		decimal? Coldefval0 { get; set; }
		decimal? Coldefval1 { get; set; }
		decimal? Coldefval2 { get; set; }
		decimal? Coldefval3 { get; set; }
		decimal? Coldefval4 { get; set; }
		decimal? Coldefval5 { get; set; }
		decimal? Coldefval6 { get; set; }
		decimal? Coldefval7 { get; set; }
		decimal? Coldefval8 { get; set; }
		decimal? Coldefval9 { get; set; }
		decimal? Coldefval10 { get; set; }
		decimal? Coldefval11 { get; set; }
		decimal? Coldefval12 { get; set; }
		decimal? Coldefval13 { get; set; }
		decimal? Coldefval14 { get; set; }
		BaseClass.Projecttemplate Template { get; set; }
		
		Ratebuildupcols Clone();
	}
}
