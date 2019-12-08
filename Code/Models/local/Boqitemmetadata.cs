
namespace Models.local
{
	public class Boqitemmetadata : BaseClass.Boqitemmetadata//, Interfaces.IBoqitemmetadata
	{
		public Boqitemmetadata Clone()
		{
			Boqitemmetadata c = new Boqitemmetadata();
			c.Id = Id;
			c.Fieldkey = Fieldkey;
			c.Initialdisplayname = Initialdisplayname;
			c.Fieldname = Fieldname;
			c.Columnname = Columnname;

			return c;
		}
	}
}
