
namespace Models.local.Interfaces
{
	public interface IAlcSettingCodes
	{
		System.Guid Id { get; set; }
		string Code { get; set; }
		
		AlcSettingCodes Clone();
	}
}
