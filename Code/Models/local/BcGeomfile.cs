
namespace Models.local
{
	public class BcGeomfile : BaseClass.BcGeomfile//, Interfaces.IBcGeomfile
	{
		public BcGeomfile Clone()
		{
			BcGeomfile c = new BcGeomfile();
			c.Id = Id;
			c.Fdata = Fdata;
			c.Fname = Fname;
			c.Ftype = Ftype;
			c.Fguid = Fguid;
			c.Novertices = Novertices;
			c.Noelements = Noelements;
			c.Elemoffset = Elemoffset;
			c.OriginalFormat = OriginalFormat;
			c.SerializationType = SerializationType;
			c.ModelId = ModelId;
			c.Model = Model;
			c.BcGeometry = BcGeometry;

			return c;
		}
	}
}
