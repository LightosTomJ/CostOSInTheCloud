using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ParamItemConditionTableList
    {
        public List<ParamItemConditionTable> Conditions;
        public const long serialVersionUID = 1L;

        public ParamItemConditionTableList()
        {
            Conditions = new List<ParamItemConditionTable>();
        }
    }
}