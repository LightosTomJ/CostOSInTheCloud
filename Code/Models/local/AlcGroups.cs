
namespace Models.local
{
	public class AlcGroups : BaseClass.AlcGroups//, Interfaces.IAlcGroups
	{
		public AlcGroups Clone()
		{
			AlcGroups c = new AlcGroups();
			c.Id = Id;
			c.Code = Code;
			c.Description = Description;

			return c;
		}
	}
}
