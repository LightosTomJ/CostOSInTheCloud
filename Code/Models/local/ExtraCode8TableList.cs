using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ExtraCode8TableList
    {
        public IList<ExtraCode8Table> GroupCodes { get; set; }
        public const long serialVersionUID = 1L;

        public ExtraCode8TableList()
        {
            GroupCodes = new List<ExtraCode8Table>();
        }
    }
}