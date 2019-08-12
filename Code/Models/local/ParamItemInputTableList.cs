using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ParamItemInputTableList
    {
        // public Vector _o_items;
        public List<ParamItemInputTable> ParamItemInput;
        public const long serialVersionUID = 1L;

        public ParamItemInputTableList()
        {
            ParamItemInput = new List<ParamItemInputTable>();
        }
    }
}