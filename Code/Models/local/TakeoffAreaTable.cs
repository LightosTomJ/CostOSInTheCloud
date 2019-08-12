using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class TakeoffAreaTable
    {
        public long? id { get; set; }
        public bool? blankFill { get; set; }
        public bool? connectedLine { get; set; }
        public decimal bezierTension { get; set; }
        public List<TakeoffPointTable> polygon { get; set; }
        public TakeoffConditionTable conditionTable { get; set; }
        public List<TakeoffTriangleTable> triangles { get; set; } // in case we use elevations

        public TakeoffAreaTable()
        {
            polygon = new List<TakeoffPointTable>();
            triangles = new List<TakeoffTriangleTable>();
        }
    }
}