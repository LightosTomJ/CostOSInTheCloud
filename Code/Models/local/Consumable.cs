
namespace Models.local
{
	public class Consumable : BaseClass.Consumable//, Interfaces.IConsumable
	{
		public Consumable Clone()
		{
			Consumable c = new Consumable();
			c.Consumableid = Consumableid;
			c.Lastupdate = Lastupdate;
			c.Createuser = Createuser;
			c.Createdate = Createdate;
			c.Rescode = Rescode;
			c.Overtype = Overtype;
			c.Description = Description;
			c.Unit = Unit;
			c.Rate = Rate;
			c.Qty = Qty;
			c.Groupcode = Groupcode;
			c.Gekcode = Gekcode;
			c.Project = Project;
			c.Accrights = Accrights;
			c.Keyw = Keyw;
			c.Title = Title;
			c.Notes = Notes;
			c.Currency = Currency;
			c.Editorid = Editorid;
			c.Stateprovince = Stateprovince;
			c.Country = Country;
			c.Virtual = Virtual;
			c.Predicted = Predicted;
			c.Conceptual = Conceptual;
			c.Tchtype = Tchtype;
			c.Tval = Tval;
			c.Tunit = Tunit;
			c.Tcolor = Tcolor;
			c.Tregtype = Tregtype;
			c.Trids = Trids;
			c.Trdate = Trdate;
			c.Extracode1 = Extracode1;
			c.Extracode2 = Extracode2;
			c.Extracode3 = Extracode3;
			c.Extracode4 = Extracode4;
			c.Extracode5 = Extracode5;
			c.Extracode6 = Extracode6;
			c.Extracode7 = Extracode7;
			c.Extracode8 = Extracode8;
			c.Extracode9 = Extracode9;
			c.Extracode10 = Extracode10;
			c.AssemblyConsumable = AssemblyConsumable;

			return c;
		}
	}
}
