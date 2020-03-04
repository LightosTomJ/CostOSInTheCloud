using System;
using System.Collections.Generic;

namespace Model.DB.Local
{
    public partial class AlcObjectsStatus
    {
        public string ObjId { get; set; }
        public Guid Version { get; set; }
    }
}
