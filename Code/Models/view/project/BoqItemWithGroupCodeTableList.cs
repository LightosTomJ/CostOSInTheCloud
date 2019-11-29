using System;
using System.Collections.Generic;

namespace Models.project
{
    [Serializable]
    public class BoqItemWithGroupCodeList
    {
        public List<BoqItemTable> items;
        //public List<GroupCode> groupCodes;
        public string groupToUse;
        public string currencyCode;
        public const long serialVersionUID = 1L;

        public BoqItemWithGroupCodeList()
        {
            items = new List<BoqItemTable>();
        }
    }
}