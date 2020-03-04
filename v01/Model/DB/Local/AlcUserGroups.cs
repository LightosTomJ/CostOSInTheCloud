using System;
using System.Collections.Generic;

namespace Model.DB.Local
{
    public partial class AlcUserGroups
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
    }
}
