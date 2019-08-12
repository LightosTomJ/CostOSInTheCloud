using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class MaterialTableList
    {
        public List<MaterialTable> Materials { get; set; }
        public const long serialVersionUID = 1L;

        public MaterialTableList(MaterialTable[] items)
        {
            Materials = new List<MaterialTable>();
        }
    }
}