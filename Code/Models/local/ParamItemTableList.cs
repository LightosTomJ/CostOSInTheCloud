using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ParamItemTableList
    {
        public List<ParamItemTable> ParamItems;
        public const long serialVersionUID = 1L;

        public ParamItemTableList()
        {
            ParamItems = new List<ParamItemTable>();
        }
    }
}