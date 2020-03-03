namespace Models.projects
{
    public class IfcElementPropertyTable
    {

        public long? id;
        public string groupName;
        public string name;
        public int? qtyType;
        public bool? number;
        public string value;
        public decimal numberValue;
        public string metricUom;

        public IfcElementTable element;

        public IfcElementPropertyTable()
        { }
    }
}