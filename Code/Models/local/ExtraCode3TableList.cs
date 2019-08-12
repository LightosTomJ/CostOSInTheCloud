using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ExtraCode3TableList
    {
        public IList<ExtraCode3Table> GroupCodes { get; set; }
        public const long serialVersionUID = 1L;

        public ExtraCode3TableList()
        {
            GroupCodes = new List<ExtraCode3Table>();
        }
    }
}