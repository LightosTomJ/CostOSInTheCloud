using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ParamItemOutputTableList
    {
        // public Vector _o_items;
        public List<ParamItemOutputTable> ParamItemOutput;
        public const long serialVersionUID = 1L;

        public ParamItemOutputTableList()
        {
            ParamItemOutput = new List<ParamItemOutputTable>();
        }
    }
}