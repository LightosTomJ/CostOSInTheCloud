using System;

namespace Models.local.Interfaces
{
	public interface IAlcAmusers
	{
		Guid UserGid { get; set; }
		string UserId { get; set; }
		string Name { get; set; }
		string Password { get; set; }
		
		AlcAmusers Clone();
	}
}
