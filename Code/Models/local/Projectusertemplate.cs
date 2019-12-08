
namespace Models.local
{
	public class Projectusertemplate : BaseClass.Projectusertemplate//, Interfaces.IProjectusertemplate
	{
		public Projectusertemplate Clone()
		{
			Projectusertemplate c = new Projectusertemplate();
			c.Templateid = Templateid;
			c.Name = Name;
			c.Xchange = Xchange;
			c.Esclte = Esclte;
			c.Props = Props;
			c.Takeoff = Takeoff;
			c.Rsrc = Rsrc;
			c.Estim = Estim;
			c.Admn = Admn;
			c.Squote = Squote;
			c.Rquote = Rquote;
			c.Aquote = Aquote;
			c.Wbs = Wbs;
			c.Aditms = Aditms;
			c.Rmitms = Rmitms;
			c.Editms = Editms;
			c.Vaitms = Vaitms;
			c.Varsusr = Varsusr;
			c.Varsadmin = Varsadmin;
			c.Varsviewer = Varsviewer;
			c.Createuser = Createuser;
			c.Createdate = Createdate;
			c.Editorid = Editorid;
			c.Lastupdate = Lastupdate;

			return c;
		}
	}
}
