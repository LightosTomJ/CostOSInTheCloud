
namespace Models.local
{
	public class Subcontractor : BaseClass.Subcontractor//, Interfaces.ISubcontractor
	{
		public Subcontractor Clone()
		{
			Subcontractor c = new Subcontractor();
			c.Subcontractorid = Subcontractorid;
			c.Description = Description;
			c.Accuracy = Accuracy;
			c.Inclusion = Inclusion;
			c.Virtual = Virtual;
			c.Predicted = Predicted;
			c.Tchtype = Tchtype;
			c.Tval = Tval;
			c.Tunit = Tunit;
			c.Tcolor = Tcolor;
			c.Tregtype = Tregtype;
			c.Trids = Trids;
			c.Trdate = Trdate;
			c.Conceptual = Conceptual;
			c.Unit = Unit;
			c.Matrate = Matrate;
			c.Rate = Rate;
			c.Ika = Ika;
			c.Qty = Qty;
			c.Totalrate = Totalrate;
			c.Groupcode = Groupcode;
			c.Gekcode = Gekcode;
			c.Editorid = Editorid;
			c.Performance = Performance;
			c.Project = Project;
			c.Contactperson = Contactperson;
			c.Company = Company;
			c.Phonenumber = Phonenumber;
			c.Mobilenumber = Mobilenumber;
			c.Faxnumber = Faxnumber;
			c.Email = Email;
			c.Url = Url;
			c.Country = Country;
			c.City = City;
			c.Stateprovince = Stateprovince;
			c.Address = Address;
			c.Notes = Notes;
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
			c.AssemblySubcontractor = AssemblySubcontractor;

			return c;
		}
	}
}
