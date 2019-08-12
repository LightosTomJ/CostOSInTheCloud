using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ExtraCode7TableList
    {
        public IList<ExtraCode7Table> GroupCodes { get; set; }
        public const long serialVersionUID = 1L;

        public ExtraCode7TableList()
        {
            GroupCodes = new List<ExtraCode7Table>();
        }
    }
}