
namespace Models.local
{
	public class Fncton : BaseClass.Fncton//, Interfaces.IFncton
	{
		public Fncton Clone()
		{
			Fncton c = new Fncton();
			c.Functionid = Functionid;
			c.Lastupdate = Lastupdate;
			c.Takeoff = Takeoff;
			c.Createuserid = Createuserid;
			c.Editorid = Editorid;
			c.Createdate = Createdate;
			c.Name = Name;
			c.Unit = Unit;
			c.Grouping = Grouping;
			c.Description = Description;
			c.Lang = Lang;
			c.Pswd = Pswd;
			c.Snum = Snum;
			c.Prttype = Prttype;
			c.Impl = Impl;
			c.Restype = Restype;
			c.FnctonArgument = FnctonArgument;

			return c;
		}
	}
}
