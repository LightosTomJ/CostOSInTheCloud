
namespace Models.local
{
	public class Supplier : BaseClass.Supplier//, Interfaces.ISupplier
	{
		public Supplier Clone()
		{
			Supplier c = new Supplier();
			c.Supplierid = Supplierid;
			c.Description = Description;
			c.Groupcode = Groupcode;
			c.Gekcode = Gekcode;
			c.Performance = Performance;
			c.Url = Url;
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
			c.Rescode = Rescode;
			c.Lastupdate = Lastupdate;
			c.Title = Title;
			c.Geoloc = Geoloc;
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
			c.Material = Material;

			return c;
		}
	}
}
