using System;
using System.Collections.Generic;

namespace Models.cache
{
    public class ProjectVariableCache
    {
        //public ProjectDBUtil prjDbUtil { get; set; }
        public Dictionary<string, object> projectVariableMap = new Dictionary<string, object>();

        public ProjectVariableCache()
        { }
    }
}