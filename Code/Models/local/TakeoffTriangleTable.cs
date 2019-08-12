using System;

namespace Model.local
{
    [Serializable]
    public class TakeoffTriangleTable
    {
        public long? id;

        public decimal xPos1;
        public decimal yPos1;
        public decimal zPos1;
        public decimal xPos2;
        public decimal yPos2;
        public decimal zPos2;
        public decimal xPos3;
        public decimal yPos3;
        public decimal zPos3;

        public TakeoffAreaTable areaTable;

        public TakeoffTriangleTable()
        { }
    }
}