using System;

namespace Models.local.Interfaces
{
	public interface IAlcUserSettings
	{
		Guid UserId { get; set; }
		Guid SettingId { get; set; }
		Byte[] Value { get; set; }
		
		AlcUserSettings Clone();
	}
}
