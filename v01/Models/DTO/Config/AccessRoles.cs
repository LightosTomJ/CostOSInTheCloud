using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO.Config
{
    public class AccessRoles
    {
        public string Group { get; set; }
        public string Name { get; set; }
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
        public string UserId { get; set; }


        public AccessRoles()
        { }
    }
}
