using System;
using System.Collections.Generic;

namespace Models.project
{
    [Serializable]
    public class BoqItemWithGroupCodeTableList
    {
        public List<BoqItemTable> items;
        //public List<GroupCode> groupCodes;
        public string groupToUse;
        public string currencyCode;
        public const long serialVersionUID = 1L;

        public BoqItemWithGroupCodeTableList()
        {
            items = new List<BoqItemTable>();
        }
    }
}