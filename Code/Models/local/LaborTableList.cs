using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class LaborTableList
    {
        public List<LaborTable> Labors { get; set; }
        public const long serialVersionUID = 1L;

        public LaborTableList()
        {
            Labors = new List<LaborTable>();

        }
    }
}