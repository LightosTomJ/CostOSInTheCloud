using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ExtraCode6TableList
    {
        public IList<ExtraCode6Table> GroupCodes { get; set; }
        public const long serialVersionUID = 1L;

        public ExtraCode6TableList()
        {
            GroupCodes = new List<ExtraCode6Table>();
        }
    }
}