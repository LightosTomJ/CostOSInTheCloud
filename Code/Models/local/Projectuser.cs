
namespace Models.local
{
	public class Projectuser : BaseClass.Projectuser//, Interfaces.IProjectuser
	{
		public Projectuser Clone()
		{
			Projectuser c = new Projectuser();
			c.Puid = Puid;
			c.Userid = Userid;
			c.Uname = Uname;
			c.Email = Email;
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
			c.Projectinfoid = Projectinfoid;
			c.Projectinfo = Projectinfo;
			c.Projectaccess = Projectaccess;

			return c;
		}
	}
}
