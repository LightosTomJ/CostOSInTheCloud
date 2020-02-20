//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface ISupplier
	{
		long Supplierid { get; set; }
		string Description { get; set; }
		string Groupcode { get; set; }
		string Gekcode { get; set; }
		string Performance { get; set; }
		string Url { get; set; }
		string Contactperson { get; set; }
		string Phonenumber { get; set; }
		string Mobilenumber { get; set; }
		string Faxnumber { get; set; }
		string Email { get; set; }
		string City { get; set; }
		string Address { get; set; }
		string Notes { get; set; }
		string Editorid { get; set; }
		string Stateprovince { get; set; }
		string Country { get; set; }
		string Createuser { get; set; }
		System.DateTime? Createdate { get; set; }
		string Rescode { get; set; }
		System.DateTime? Lastupdate { get; set; }
		string Title { get; set; }
		string Geoloc { get; set; }
		string Extracode1 { get; set; }
		string Extracode2 { get; set; }
		string Extracode3 { get; set; }
		string Extracode4 { get; set; }
		string Extracode5 { get; set; }
		string Extracode6 { get; set; }
		string Extracode7 { get; set; }
		string Extracode8 { get; set; }
		string Extracode9 { get; set; }
		string Extracode10 { get; set; }
		//ICollection<Material> Material { get; set; }
		
		Supplier Clone();
	}
}
