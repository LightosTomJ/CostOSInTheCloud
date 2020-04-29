using System;
using System.Collections.Generic;

namespace Models.DB.Local
{
    public partial class ProjectURL
    {
        public ProjectURL()
        {
            Prjprop = new HashSet<PrjProp>();
        }

        public long Projecturlid { get; set; }
        public string Url { get; set; }
        public string Dbusr { get; set; }
        public string Dbpswd { get; set; }
        public string Dbhost { get; set; }
        public string Dbport { get; set; }
        public string Dbprefix { get; set; }
        public bool? Dbsingle { get; set; }
        public string Dbname { get; set; }
        public int? Dbsrv { get; set; }
        public string Dbsrvname { get; set; }
        public int? Qsent { get; set; }
        public int? Qrecv { get; set; }
        public bool? Defrev { get; set; }
        public string Editorid { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Rvson { get; set; }
        public string Creuserid { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Lastupdate { get; set; }
        public int? Underreview { get; set; }
        public int? Pending { get; set; }
        public int? Approved { get; set; }
        public int? Completed { get; set; }
        public decimal? Esttotal { get; set; }
        public decimal? Quotedtotal { get; set; }
        public decimal? Markuptotal { get; set; }
        public bool? Mustrecalc { get; set; }
        public bool? Frozen { get; set; }
        public long? Benchmarkid { get; set; }
        public string Description { get; set; }
        public long? Projectinfoid { get; set; }
        public long? Projectdbmsid { get; set; }

        public virtual PrjDBMS Projectdbms { get; set; }
        public virtual ProjectInfo Projectinfo { get; set; }
        public virtual ICollection<PrjProp> Prjprop { get; set; }
    }
}
