using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class SupplierTableList
    {
        // public Vector _o_items;
        public List<SupplierTable> items;
        public const long serialVersionUID = 1L;

        public SupplierTableList()
        {
            items = new List<SupplierTable>();
        }
    }
}