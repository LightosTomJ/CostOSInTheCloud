
namespace Models.local.Interfaces
{
	public interface IAlcUl
	{
		System.Guid Ulgid { get; set; }
		System.DateTime Ulla { get; set; }
		short  Ulflag { get; set; }
		
		AlcUl Clone();
	}
}
