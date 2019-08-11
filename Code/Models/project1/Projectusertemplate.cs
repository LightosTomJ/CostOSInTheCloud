using System;
using System.Collections.Generic;

namespace Models.project1
{
    public partial class Projectusertemplate
    {
        public long Templateid { get; set; }
        public string Name { get; set; }
        public bool? Xchange { get; set; }
        public bool? Esclte { get; set; }
        public bool? Props { get; set; }
        public bool? Takeoff { get; set; }
        public bool? Rsrc { get; set; }
        public bool? Estim { get; set; }
        public bool? Admn { get; set; }
        public bool? Squote { get; set; }
        public bool? Rquote { get; set; }
        public bool? Aquote { get; set; }
        public bool? Wbs { get; set; }
        public bool? Aditms { get; set; }
        public bool? Rmitms { get; set; }
        public bool? Editms { get; set; }
        public bool? Vaitms { get; set; }
        public bool? Varsusr { get; set; }
        public bool? Varsadmin { get; set; }
        public bool? Varsviewer { get; set; }
        public string Createuser { get; set; }
        public DateTime? Createdate { get; set; }
        public string Editorid { get; set; }
        public DateTime? Lastupdate { get; set; }
    }
}
