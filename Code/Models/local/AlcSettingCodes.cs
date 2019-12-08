
namespace Models.local
{
	public class AlcSettingCodes : BaseClass.AlcSettingCodes//, Interfaces.IAlcSettingCodes
	{
		public AlcSettingCodes Clone()
		{
			AlcSettingCodes c = new AlcSettingCodes();
			c.Id = Id;
			c.Code = Code;

			return c;
		}
	}
}
