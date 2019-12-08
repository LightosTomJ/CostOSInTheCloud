
namespace Models.local
{
	public class Labor : BaseClass.Labor//, Interfaces.ILabor
	{
		public Labor Clone()
		{
			Labor c = new Labor();
			c.Laborid = Laborid;
			c.Description = Description;
			c.Unit = Unit;
			c.Rate = Rate;
			c.Ika = Ika;
			c.Totalrate = Totalrate;
			c.Groupcode = Groupcode;
			c.Gekcode = Gekcode;
			c.Project = Project;
			c.Virtual = Virtual;
			c.Predicted = Predicted;
			c.Conceptual = Conceptual;
			c.Tchtype = Tchtype;
			c.Tunit = Tunit;
			c.Tval = Tval;
			c.Tcolor = Tcolor;
			c.Tregtype = Tregtype;
			c.Trids = Trids;
			c.Trdate = Trdate;
			c.Contactperson = Contactperson;
			c.Phonenumber = Phonenumber;
			c.Mobilenumber = Mobilenumber;
			c.Faxnumber = Faxnumber;
			c.Email = Email;
			c.City = City;
			c.Address = Address;
			c.Notes = Notes;
			c.Editorid = Editorid;
			c.Stateprovince = Stateprovince;
			c.Country = Country;
			c.Createuser = Createuser;
			c.Createdate = Createdate;
			c.Lastupdate = Lastupdate;
			c.Accrights = Accrights;
			c.Keyw = Keyw;
			c.Rescode = Rescode;
			c.Title = Title;
			c.Currency = Currency;
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
			c.Overtype = Overtype;
			c.AssemblyLabor = AssemblyLabor;

			return c;
		}
	}
}
