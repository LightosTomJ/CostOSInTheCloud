using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ExtraCode1TableList
    {
        public IList<ExtraCode1Table> GroupCodes { get; set; }
        public const long serialVersionUID = 1L;

        public ExtraCode1TableList()
        {
            GroupCodes = new List<ExtraCode1Table>();
        }
    }
}