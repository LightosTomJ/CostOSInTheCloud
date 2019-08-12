using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class GroupCodeTableList
    {
        public List<GroupCodeTable> GroupCodes { get; set; }
        public const long serialVersionUID = 1L;

        public GroupCodeTableList()
        {
            GroupCodes = new List<GroupCodeTable>();
        }
    }
}