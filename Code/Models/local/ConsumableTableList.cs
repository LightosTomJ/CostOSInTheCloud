using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ConsumableTableList
    {
        public IList<ConsumableTable> Consumables { get; set; }
        public const long serialVersionUID = 1L;

        public ConsumableTableList()
        {
            Consumables = new List<ConsumableTable>();
        }
    }
}