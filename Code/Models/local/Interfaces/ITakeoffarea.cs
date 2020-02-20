//using System.Collections.Generic;

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
		BaseClass.Takeoffcon A { get; set; }
		//ICollection<Takeoffpoint> Takeoffpoint { get; set; }
		//ICollection<Takeofftriangle> Takeofftriangle { get; set; }
		
		Takeoffarea Clone();
	}
}
