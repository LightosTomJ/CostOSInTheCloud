using System;

namespace Models.local.Interfaces
{
	public interface IAlcUl
	{
		Guid Ulgid { get; set; }
		DateTime Ulla { get; set; }
		short  Ulflag { get; set; }
		
		AlcUl Clone();
	}
}
