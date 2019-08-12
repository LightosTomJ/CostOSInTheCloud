using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class EquipmentTableList
    {
        public IList<EquipmentTable> Equipments { get; set; }
        public const long serialVersionUID = 1L;

        public EquipmentTableList()
        {
            Equipments = new List<EquipmentTable>();
        }
    }
}