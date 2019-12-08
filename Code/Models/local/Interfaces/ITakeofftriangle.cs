
namespace Models.local.Interfaces
{
	public interface ITakeofftriangle
	{
		long Id { get; set; }
		decimal? Xpos1 { get; set; }
		decimal? Ypos1 { get; set; }
		decimal? Zpos1 { get; set; }
		decimal? Xpos2 { get; set; }
		decimal? Ypos2 { get; set; }
		decimal? Zpos2 { get; set; }
		decimal? Xpos3 { get; set; }
		decimal? Ypos3 { get; set; }
		decimal? Zpos3 { get; set; }
		long? Tid { get; set; }
		int? Triacount { get; set; }
		Models.local.BaseClass.Takeoffarea T { get; set; }
		
		Takeofftriangle Clone();
	}
}
