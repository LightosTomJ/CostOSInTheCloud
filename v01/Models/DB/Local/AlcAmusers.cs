using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class AlcAmUsers
    {
        public Guid UserGid { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
