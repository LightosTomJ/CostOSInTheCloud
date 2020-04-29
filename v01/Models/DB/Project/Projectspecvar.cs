using System;
using System.Collections.Generic;

namespace Models.DB.Project
{
    public partial class ProjectSpecVar
    {
        public long Id { get; set; }
        public long? Templateid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Datatype { get; set; }
        public string Defval { get; set; }
        public string Stoval { get; set; }
        public int? Sortorder { get; set; }
        public int? Cellx { get; set; }
        public int? Celly { get; set; }
        public int? Sheetno { get; set; }
        public bool? Mapped { get; set; }
        public decimal? Stovalnum { get; set; }
        public bool? Isnumber { get; set; }
        public bool? Mandatory { get; set; }
        public string Pushfield { get; set; }
        public bool? Hidden { get; set; }
        public long? Databasetemplateid { get; set; }
        public string Databasetemplatename { get; set; }
        public long? Prjid { get; set; }
        public long? RefId { get; set; }

        public virtual ProjectTemplate Template { get; set; }
    }
}
