using System;
using System.Collections.Generic;

namespace Models.project1
{
    public partial class BcProject
    {
        public BcProject()
        {
            BcModel = new HashSet<BcModel>();
            InverseParent = new HashSet<BcProject>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string Descr { get; set; }
        public string Globalid { get; set; }
        public bool? Deleted { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }

        public virtual BcProject Parent { get; set; }
        public virtual ICollection<BcModel> BcModel { get; set; }
        public virtual ICollection<BcProject> InverseParent { get; set; }
    }
}
