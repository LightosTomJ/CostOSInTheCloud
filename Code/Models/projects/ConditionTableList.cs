using System;
using System.Collections.Generic;

namespace Models.projects
{
    [Serializable]
    public class ConditionList
    {
        // public Vector _o_items;
        public List<Condition> items;
        public const long serialVersionUID = 1L;

        public ConditionList()
        {
            items = new List<Condition>();
        }
    }
}