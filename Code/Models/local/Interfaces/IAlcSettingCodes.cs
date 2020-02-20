using System;

namespace Models.local.Interfaces
{
	public interface IAlcSettingCodes
	{
		Guid Id { get; set; }
		string Code { get; set; }
		
		AlcSettingCodes Clone();
	}
}
