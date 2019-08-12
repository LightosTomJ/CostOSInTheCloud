using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ExtraCode2TableList
    {
        public IList<ExtraCode2Table> GroupCodes { get; set; }
        public const long serialVersionUID = 1L;

        public ExtraCode2TableList()
        {
            GroupCodes = new List<ExtraCode2Table>();
        }
    }
}