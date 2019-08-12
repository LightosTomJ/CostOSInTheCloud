using System;
using System.Collections.Generic;

namespace Model.project1
{
    public partial class Fieldcustom
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Displayname { get; set; }
        public string Formula { get; set; }
        public string Rsrc { get; set; }
        public bool? Editable { get; set; }
        public bool? Sellist { get; set; }
        public string Selvals { get; set; }
        public string Defsel { get; set; }
    }
}
