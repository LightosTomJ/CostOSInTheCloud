using System;
using System.Collections.Generic;

namespace Model.project1
{
    public partial class AlcObjectsInUse
    {
        public string ObjId { get; set; }
        public Guid UserId { get; set; }
        public int UseMode { get; set; }
    }
}
