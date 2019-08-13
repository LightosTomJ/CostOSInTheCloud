using System;
using System.Collections.Generic;

namespace Models.cache
{
    public class WBS2Cache
    {
        public const string TABLE_NAME = "ProjectWBSTable";

        //public IDictionary<string, GroupCode> hashMap = new Dictionary<string, GroupCode>();

        public string o_code { get; set; }
        public string o_name { get; set; }

        public string o_codingSystem = "DOTTED_GC_STYLE";
        //public ProjectDBUtil o_prjDbUtil { get; set; }

        public WBS2Cache()
        { }

        //public WBSCache(ProjectDBUtil prjDBUtil)
        //{
        //    o_prjDbUtil = prjDBUtil;
        //    initCache(prjDBUtil.Properties.getProperty("project.code"), prjDBUtil.Properties.getProperty("project.name"));
        //}
    }
}