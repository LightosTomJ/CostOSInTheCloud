
namespace Models.local
{
	public class AlcUserSettings : BaseClass.AlcUserSettings//, Interfaces.IAlcUserSettings
	{
		public AlcUserSettings Clone()
		{
			AlcUserSettings c = new AlcUserSettings();
			c.UserId = UserId;
			c.SettingId = SettingId;
			c.Value = Value;

			return c;
		}
	}
}
