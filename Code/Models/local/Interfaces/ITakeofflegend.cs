
namespace Models.local.Interfaces
{
	public interface ITakeofflegend
	{
		long Id { get; set; }
		decimal? Xpos { get; set; }
		decimal? Ypos { get; set; }
		int? Zoom { get; set; }
		decimal? Rotangle { get; set; }
		string Legtxt { get; set; }
		string Fnt { get; set; }
		string Fntcolor { get; set; }
		long? Cid { get; set; }
		int? Lgdcount { get; set; }
		BaseClass.Takeoffcon C { get; set; }
		
		Takeofflegend Clone();
	}
}
