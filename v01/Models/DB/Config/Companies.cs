using System;
using System.Collections.Generic;

namespace Models.DB.Config
{
    public partial class Companies
    {
        public Companies()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string CompanyNumber { get; set; }
        public string Vatnumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UserId { get; set; }
        public string Website { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
