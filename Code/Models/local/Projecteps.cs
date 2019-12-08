
namespace Models.local
{
	public class Projecteps : BaseClass.Projecteps//, Interfaces.IProjecteps
	{
		public Projecteps Clone()
		{
			Projecteps c = new Projecteps();
			c.Projectepsid = Projectepsid;
			c.Code = Code;
			c.Title = Title;
			c.Editorid = Editorid;
			c.Description = Description;
			c.Lastupdate = Lastupdate;
			c.Parentid = Parentid;
			c.Projectinfo = Projectinfo;

			return c;
		}
	}
}
