
namespace Models.local
{
	public class Wsrevision : BaseClass.Wsrevision//, Interfaces.IWsrevision
	{
		public Wsrevision Clone()
		{
			Wsrevision c = new Wsrevision();
			c.Id = Id;
			c.Title = Title;
			c.Createdate = Createdate;
			c.Lastupdate = Lastupdate;
			c.Createuserid = Createuserid;
			c.Editorid = Editorid;
			c.Description = Description;
			c.Pblk = Pblk;
			c.Mappingid = Mappingid;
			c.Mapping = Mapping;
			c.Wsfile = Wsfile;

			return c;
		}
	}
}
