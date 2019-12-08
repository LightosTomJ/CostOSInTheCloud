
namespace Models.local.Interfaces
{
	public interface IAlcUserSettings
	{
		System.Guid UserId { get; set; }
		System.Guid SettingId { get; set; }
		System.Byte[] Value { get; set; }
		
		AlcUserSettings Clone();
	}
}
