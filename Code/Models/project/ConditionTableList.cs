using System;
using System.Collections.Generic;

namespace Models.project
{
    [Serializable]
    public class ConditionTableList
    {
        // public Vector _o_items;
        public List<ConditionTable> items;
        public const long serialVersionUID = 1L;

        public ConditionTableList()
        {
            items = new List<ConditionTable>();
        }
    }
}