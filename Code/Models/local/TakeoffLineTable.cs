using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class TakeoffLineTable
    {
        public long? id { get; set; }

        public decimal startXPos { get; set; }
        public decimal startYPos { get; set; }

        public decimal endXPos { get; set; }
        public decimal endYPos { get; set; }

        public IList<TakeoffPointTable> elevationSamples { get; set; }

        public TakeoffConditionTable conditionTable { get; set; }

        public TakeoffLineTable()
        { }


        public TakeoffLineTable(decimal startXPos, decimal startYPos, decimal endXPos, decimal endYPos)
        {
            this.startXPos = startXPos;
            this.startYPos = startYPos;
            this.endXPos = endXPos;
            this.endYPos = endYPos;
        }
    }
}