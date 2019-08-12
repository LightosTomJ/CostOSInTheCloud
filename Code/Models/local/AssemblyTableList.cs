using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class AssemblyTableList
    {
        public IList<AssemblyTable> Assemblies { get; set; }
        public const long serialVersionUID = 1L;

        public AssemblyTableList()
        {
            Assemblies = new List<AssemblyTable>();
        }
    }
}