using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class SubcontractorTableList
    {
        // public Vector _o_items;
        public List<SubcontractorTable> items;
        public const long serialVersionUID = 1L;

        public SubcontractorTableList()
        {
            items = new List<SubcontractorTable>();
        }
    }
}