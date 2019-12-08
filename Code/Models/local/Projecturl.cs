
namespace Models.local
{
	public class Projecturl : BaseClass.Projecturl//, Interfaces.IProjecturl
	{
		public Projecturl Clone()
		{
			Projecturl c = new Projecturl();
			c.Projecturlid = Projecturlid;
			c.Url = Url;
			c.Dbusr = Dbusr;
			c.Dbpswd = Dbpswd;
			c.Dbhost = Dbhost;
			c.Dbport = Dbport;
			c.Dbprefix = Dbprefix;
			c.Dbsingle = Dbsingle;
			c.Dbname = Dbname;
			c.Dbsrv = Dbsrv;
			c.Dbsrvname = Dbsrvname;
			c.Qsent = Qsent;
			c.Qrecv = Qrecv;
			c.Defrev = Defrev;
			c.Editorid = Editorid;
			c.Type = Type;
			c.Name = Name;
			c.Rvson = Rvson;
			c.Creuserid = Creuserid;
			c.Createdate = Createdate;
			c.Lastupdate = Lastupdate;
			c.Underreview = Underreview;
			c.Pending = Pending;
			c.Approved = Approved;
			c.Completed = Completed;
			c.Esttotal = Esttotal;
			c.Quotedtotal = Quotedtotal;
			c.Markuptotal = Markuptotal;
			c.Mustrecalc = Mustrecalc;
			c.Frozen = Frozen;
			c.Benchmarkid = Benchmarkid;
			c.Description = Description;
			c.Projectinfoid = Projectinfoid;
			c.Projectdbmsid = Projectdbmsid;
			c.Projectdbms = Projectdbms;
			c.Projectinfo = Projectinfo;
			c.Prjprop = Prjprop;

			return c;
		}
	}
}
