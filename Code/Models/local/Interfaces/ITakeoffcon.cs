//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface ITakeoffcon
	{
		long Id { get; set; }
		string Title { get; set; }
		string Description { get; set; }
		string Colour { get; set; }
		string Grouping { get; set; }
		string Cndtype { get; set; }
		int? Patterntype { get; set; }
		int? Shapetype { get; set; }
		bool? Elevation { get; set; }
		int? Samples { get; set; }
		decimal? Height { get; set; }
		decimal? Width { get; set; }
		decimal? Depth { get; set; }
		decimal? Thickness { get; set; }
		string Takeoff { get; set; }
		string Editorid { get; set; }
		string Createuserid { get; set; }
		System.DateTime? Lastupdate { get; set; }
		System.DateTime? Createdate { get; set; }
		string Qty1type { get; set; }
		string Qty2type { get; set; }
		string Qty3type { get; set; }
		string Uom1 { get; set; }
		string Uom2 { get; set; }
		string Uom3 { get; set; }
		decimal? Qty1 { get; set; }
		decimal? Qty2 { get; set; }
		decimal? Qty3 { get; set; }
		long? Projectinfoid { get; set; }
		BaseClass.Projectinfo Projectinfo { get; set; }
		//ICollection<Takeoffarea> Takeoffarea { get; set; }
		//ICollection<Takeofflegend> Takeofflegend { get; set; }
		//ICollection<Takeoffline> Takeoffline { get; set; }
		//ICollection<Takeoffpoint> Takeoffpoint { get; set; }
		
		Takeoffcon Clone();
	}
}
