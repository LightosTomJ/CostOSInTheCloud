
namespace Models.local
{
	public class Wscolident : BaseClass.Wscolident//, Interfaces.IWscolident
	{
		public Wscolident Clone()
		{
			Wscolident c = new Wscolident();
			c.Id = Id;
			c.Splitfield = Splitfield;
			c.Munique = Munique;
			c.Sheetprefix = Sheetprefix;
			c.Fileprefix = Fileprefix;
			c.Exauma = Exauma;
			c.Coltype = Coltype;
			c.Mapaction = Mapaction;
			c.Fldname = Fldname;
			c.Colindex = Colindex;
			c.Fldtype = Fldtype;
			c.Fieldmap = Fieldmap;
			c.Mappingid = Mappingid;
			c.Mapping = Mapping;

			return c;
		}
	}
}
