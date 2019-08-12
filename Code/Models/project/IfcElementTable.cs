using System;
using System.Collections.Generic;

namespace Models.project
{
    public class IfcElementTable
    {
        public long? id;
        public string title;
        public string description;

        public string globalId;
        public string location;
        public string label;
        public string type;
        public string material;
        public string layer;
        public string building;
        public string fileName;
        public string ifcFile;
        public string storey;
        public string model;
        public string groupZone;
        public DateTime lastUpdate;

        public string name;
        public string objectType;
        public string color;
        public double? transparency;

        public decimal qty1;
        public string uom1;
        public string qtyName1;

        public decimal qty2;
        public string uom2;
        public string qtyName2;

        public decimal qty3;
        public string uom3;
        public string qtyName3;

        public string applicationName;
        public int? cndId;

        public decimal topElevation;
        public decimal bottomElevation;

        public string parentElementId;
        public string parentSpaceId;

        public bool? isDecomposed;

        public ISet<IfcElementPropertyTable> properties;
        
        public IfcElementTable()
        { }

    }
}