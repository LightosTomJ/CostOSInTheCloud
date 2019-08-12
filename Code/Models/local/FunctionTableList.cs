using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class FunctionTableList
    {
        public List<FunctionTable> Functions { get; set; }
        public const long serialVersionUID = 1L;

        public FunctionTableList()
        {
            Functions = new List<FunctionTable>();
        }
    }
}