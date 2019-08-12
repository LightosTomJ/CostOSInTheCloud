using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ExtraCode5TableList
    {
        public IList<ExtraCode5Table> GroupCodes { get; set; }
        public const long serialVersionUID = 1L;

        public ExtraCode5TableList()
        {
            GroupCodes = new List<ExtraCode5Table>();
        }
    }
}