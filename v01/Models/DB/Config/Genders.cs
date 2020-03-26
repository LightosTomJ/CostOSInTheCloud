using System;
using System.Collections.Generic;

namespace Models.DB.Config
{
    public partial class Genders
    {
        public Genders()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public byte GenderId { get; set; }
        public string Type { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
