using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ExtraCode4TableList
    {
        public IList<ExtraCode4Table> GroupCodes { get; set; }
        public const long serialVersionUID = 1L;

        public ExtraCode4TableList()
        {
            GroupCodes = new List<ExtraCode4Table>();
        }
    }
}