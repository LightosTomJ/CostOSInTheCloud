namespace Model.local
{
    public class TakeoffLegendTable
    {
        public long? id { get; set; }
        public decimal xPos { get; set; }
        public decimal yPos { get; set; }
        public decimal rotationAngle { get; set; }
        public int? zoom { get; set; }
        public string legendTxt { get; set; }
        public string fontName { get; set; }
        public string fontColor { get; set; }

        public TakeoffConditionTable conditionTable { get; set; }

        public TakeoffLegendTable()
        { }
    }
}