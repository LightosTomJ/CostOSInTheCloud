
namespace Models.local.Interfaces
{
	public interface ITakeoffpoint
	{
		long Id { get; set; }
		decimal? Zpos { get; set; }
		decimal? Xpos { get; set; }
		decimal? Ypos { get; set; }
		long? Pid { get; set; }
		long? Sid { get; set; }
		long? Cid { get; set; }
		int? Polycount { get; set; }
		int? Pointcount { get; set; }
		int? Elevcount { get; set; }
		BaseClass.Takeoffcon C { get; set; }
		BaseClass.Takeoffarea P { get; set; }
		BaseClass.Takeoffline S { get; set; }
		
		Takeoffpoint Clone();
	}
}
