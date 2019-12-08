
namespace Models.local.Interfaces
{
	public interface ITakeoffline
	{
		long Id { get; set; }
		decimal? Sx { get; set; }
		decimal? Sy { get; set; }
		decimal? Ex { get; set; }
		decimal? Ey { get; set; }
		long? Lid { get; set; }
		int? Linescount { get; set; }
		Models.local.BaseClass.Takeoffcon L { get; set; }
		System.Collections.Generic.ICollection<Takeoffpoint> Takeoffpoint { get; set; }
		
		Takeoffline Clone();
	}
}
