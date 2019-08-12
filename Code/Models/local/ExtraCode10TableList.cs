using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ExtraCode10TableList
    {
        public IList<ExtraCode10Table> GroupCodes { get; set; }
        public const long serialVersionUID = 1L;

        public ExtraCode10TableList()
        {
            GroupCodes = new List<ExtraCode10Table>();
        }
    }
}