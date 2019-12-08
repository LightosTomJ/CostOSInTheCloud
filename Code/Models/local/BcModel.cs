
namespace Models.local
{
	public class BcModel : BaseClass.BcModel//, Interfaces.IBcModel
	{
		public BcModel Clone()
		{
			BcModel c = new BcModel();
			c.Id = Id;
			c.Appname = Appname;
			c.Defrev = Defrev;
			c.Failcause = Failcause;
			c.Fpath = Fpath;
			c.Globalid = Globalid;
			c.Name = Name;
			c.Offsetx = Offsetx;
			c.Offsety = Offsety;
			c.Offsetz = Offsetz;
			c.Rev = Rev;
			c.Status = Status;
			c.VertexFactor = VertexFactor;
			c.ProjectId = ProjectId;
			c.Project = Project;
			c.BcClassification = BcClassification;
			c.BcClassitem = BcClassitem;
			c.BcElemclassitem = BcElemclassitem;
			c.BcElemconnection = BcElemconnection;
			c.BcElemcovering = BcElemcovering;
			c.BcElement = BcElement;
			c.BcElementinfo = BcElementinfo;
			c.BcElemmaterial = BcElemmaterial;
			c.BcElemprop = BcElemprop;
			c.BcGeometry = BcGeometry;
			c.BcGeomfile = BcGeomfile;
			c.BcGroup = BcGroup;
			c.BcGroupelem = BcGroupelem;
			c.BcGroupprop = BcGroupprop;
			c.BcMaterial = BcMaterial;
			c.BcQuantity = BcQuantity;
			c.BcSpatialinfo = BcSpatialinfo;

			return c;
		}
	}
}
