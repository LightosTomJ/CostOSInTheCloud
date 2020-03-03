using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class Supplier
    {
        public Supplier()
        {
            Material = new HashSet<Material>();
        }

        public long Supplierid { get; set; }
        public string Description { get; set; }
        public string Groupcode { get; set; }
        public string Gekcode { get; set; }
        public string Performance { get; set; }
        public string Url { get; set; }
        public string Contactperson { get; set; }
        public string Phonenumber { get; set; }
        public string Mobilenumber { get; set; }
        public string Faxnumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public string Editorid { get; set; }
        public string Stateprovince { get; set; }
        public string Country { get; set; }
        public long? Databaseid { get; set; }
        public long? Databasecreationdate { get; set; }
        public string Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public string Rescode { get; set; }
        public DateTime? Lastupdate { get; set; }
        public string Title { get; set; }
        public string Geoloc { get; set; }
        public string Extracode1 { get; set; }
        public string Extracode2 { get; set; }
        public string Extracode3 { get; set; }
        public string Extracode4 { get; set; }
        public string Extracode5 { get; set; }
        public string Extracode6 { get; set; }
        public string Extracode7 { get; set; }
        public string Extracode8 { get; set; }
        public string Extracode9 { get; set; }
        public string Extracode10 { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }

        public virtual ICollection<Material> Material { get; set; }
    }
}
