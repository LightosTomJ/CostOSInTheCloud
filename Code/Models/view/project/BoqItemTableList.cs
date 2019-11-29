using System;
using System.Collections.Generic;

namespace Models.project
{
    [Serializable]
    public class BoqItemTableList
    {
        public List<BoqItemTable> items;
        public const long serialVersionUID = 1L;

        public BoqItemTableList()
        {
            items = new List<BoqItemTable>();
        }
    }
}