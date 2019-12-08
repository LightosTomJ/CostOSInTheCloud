
namespace Models.local.Interfaces
{
	public interface IEquipment
	{
		long Equipmentid { get; set; }
		string Description { get; set; }
		string Make { get; set; }
		string Model { get; set; }
		string Unit { get; set; }
		string Groupcode { get; set; }
		string Gekcode { get; set; }
		string Fueltype { get; set; }
		decimal? Reservationrate { get; set; }
		decimal? Sparepartsrate { get; set; }
		decimal? Tiresrate { get; set; }
		decimal? Fuelrate { get; set; }
		decimal? Lubricatesrate { get; set; }
		decimal? Depreciationrate { get; set; }
		decimal? Fuelconsumption { get; set; }
		string Currency { get; set; }
		string Country { get; set; }
		string State { get; set; }
		decimal? Totalrate { get; set; }
		string Notes { get; set; }
		string Editorid { get; set; }
		string Createuser { get; set; }
		System.DateTime? Createdate { get; set; }
		string Rescode { get; set; }
		System.DateTime? Lastupdate { get; set; }
		string Accrights { get; set; }
		string Keyw { get; set; }
		string Title { get; set; }
		int? DeprecationCalcMethod { get; set; }
		decimal? InitAquasitionPrice { get; set; }
		decimal? SalvageValue { get; set; }
		decimal? InterestRate { get; set; }
		decimal? DepreciationYears { get; set; }
		decimal? OccupationHoursPerMonth { get; set; }
		decimal? OccupationalFactor { get; set; }
		bool? Virtual { get; set; }
		bool? Predicted { get; set; }
		bool? Conceptual { get; set; }
		int? Tchtype { get; set; }
		decimal? Tval { get; set; }
		string Tunit { get; set; }
		int? Tcolor { get; set; }
		int? Tregtype { get; set; }
		string Trids { get; set; }
		System.DateTime? Trdate { get; set; }
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
		int? Overtype { get; set; }
		System.Collections.Generic.ICollection<AssemblyEquipment> AssemblyEquipment { get; set; }
		
		Equipment Clone();
	}
}
