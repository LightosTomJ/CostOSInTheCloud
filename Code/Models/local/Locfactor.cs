
namespace Models.local
{
	public class Locfactor : BaseClass.Locfactor//, Interfaces.ILocfactor
	{
		public Locfactor Clone()
		{
			Locfactor c = new Locfactor();
			c.Lfid = Lfid;
			c.Parentecode = Parentecode;
			c.Editorid = Editorid;
			c.Onln = Onln;
			c.Codetype = Codetype;
			c.Tocountry = Tocountry;
			c.Tostate = Tostate;
			c.Tocity = Tocity;
			c.Tozipcode = Tozipcode;
			c.Labfac = Labfac;
			c.Matfac = Matfac;
			c.Subfac = Subfac;
			c.Confac = Confac;
			c.Equfac = Equfac;
			c.Assfac = Assfac;
			c.Geopoly = Geopoly;
			c.Fid = Fid;
			c.Faccount = Faccount;
			c.F = F;

			return c;
		}
	}
}
