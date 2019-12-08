
namespace Models.local
{
	public class Projecttemplate : BaseClass.Projecttemplate//, Interfaces.IProjecttemplate
	{
		public Projecttemplate Clone()
		{
			Projecttemplate c = new Projecttemplate();
			c.Id = Id;
			c.Templateid = Templateid;
			c.Title = Title;
			c.Editorid = Editorid;
			c.Userid = Userid;
			c.Lastupdate = Lastupdate;
			c.Createdate = Createdate;
			c.Createuser = Createuser;
			c.Databaseid = Databaseid;
			c.Dbcreatedate = Dbcreatedate;
			c.Pblk = Pblk;
			c.Hasbuildups = Hasbuildups;
			c.Hasdistributors = Hasdistributors;
			c.Allowviewers = Allowviewers;
			c.Description = Description;
			c.Template = Template;
			c.Projectspecvar = Projectspecvar;
			c.Ratebuildup = Ratebuildup;
			c.Ratebuildupcols = Ratebuildupcols;
			c.Ratedistrib = Ratedistrib;

			return c;
		}
	}
}
