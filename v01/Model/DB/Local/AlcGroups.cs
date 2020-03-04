using System;
using System.Collections.Generic;

namespace Model.DB.Local
{
    public partial class AlcGroups
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
