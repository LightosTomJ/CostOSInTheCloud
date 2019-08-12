using System;

namespace Model.local
{
    [Serializable]
    public class TakeoffPointTable
    {
        public long? id;
        public decimal xPos;
        public decimal yPos;
        public decimal zPos; // elevation

        public TakeoffAreaTable areaTable;
        public TakeoffLineTable lineTable;
        public TakeoffConditionTable conditionTable;

        public TakeoffPointTable()
        { }

        public TakeoffPointTable(decimal xpos1, decimal ypos1, decimal zpos1)
        {
            xPos = xpos1;
            yPos = ypos1;
            zPos = zpos1;
        }
    }
}