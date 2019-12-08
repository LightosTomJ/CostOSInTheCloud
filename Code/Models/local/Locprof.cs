
namespace Models.local
{
	public class Locprof : BaseClass.Locprof//, Interfaces.ILocprof
	{
		public Locprof Clone()
		{
			Locprof c = new Locprof();
			c.Functionid = Functionid;
			c.Fromcountry = Fromcountry;
			c.Fromstate = Fromstate;
			c.Name = Name;
			c.Supstate = Supstate;
			c.Editorid = Editorid;
			c.Createuserid = Createuserid;
			c.Createdate = Createdate;
			c.Lastupdate = Lastupdate;
			c.Locfactor = Locfactor;

			return c;
		}
	}
}
