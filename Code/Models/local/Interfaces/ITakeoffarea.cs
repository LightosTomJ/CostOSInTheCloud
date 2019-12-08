
namespace Models.local.Interfaces
{
	public interface ITakeoffarea
	{
		long Id { get; set; }
		bool? Blankfill { get; set; }
		bool? Conline { get; set; }
		decimal? Tension { get; set; }
		long? Aid { get; set; }
		int? Areacount { get; set; }
		Models.local.BaseClass.Takeoffcon A { get; set; }
		System.Collections.Generic.ICollection<Takeoffpoint> Takeoffpoint { get; set; }
		System.Collections.Generic.ICollection<Takeofftriangle> Takeofftriangle { get; set; }
		
		Takeoffarea Clone();
	}
}
