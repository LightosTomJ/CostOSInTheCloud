
namespace Models.local
{
	public class Rpdfn : BaseClass.Rpdfn//, Interfaces.IRpdfn
	{
		public Rpdfn Clone()
		{
			Rpdfn c = new Rpdfn();
			c.Rpdfnid = Rpdfnid;
			c.Rname = Rname;
			c.Ricn = Ricn;
			c.Rdsgn = Rdsgn;
			c.Rdesc = Rdesc;
			c.Redtid = Redtid;
			c.Rcreuser = Rcreuser;
			c.Rlastupd = Rlastupd;
			c.Rcredate = Rcredate;
			c.Rgrp = Rgrp;
			c.Rpblk = Rpblk;
			c.Rusrrep = Rusrrep;
			c.Mltusrrpt = Mltusrrpt;
			c.Reporttype = Reporttype;
			c.Rjsurl = Rjsurl;
			c.Reportroles = Reportroles;
			c.Fldfn = Fldfn;

			return c;
		}
	}
}
