using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ExtraCode9TableList
    {
        public IList<ExtraCode9Table> GroupCodes { get; set; }
        public const long serialVersionUID = 1L;

        public ExtraCode9TableList()
        {
            GroupCodes = new List<ExtraCode9Table>();
        }
    }
}