using System;
using System.Collections.Generic;

namespace Models.project
{
    [Serializable]
    public class Condition
    {

        public const int PICK_NONE = 0;
        public const int PICK_ELEMENTS = 1;
        public const int PICK_FACES = 2;
        public const int PICK_LINES = 3;
        public const int PICK_AREA = 4;
        public const int PICK_LENGTH = 5;
        public const int PICK_POINT = 6;

        public const string MANUAL = "Manual Takeoff";
        public const string TAKEOFF = "On-Screen Takeoff";
        public const string IFC_FILE = "IFC File";
        public const string BIM_CITY = "BIM";
        public const string BIM_MEASURE = "MEASURE";
        public const string EXTRAXXION = "ExtrAXXION";

        public const string FUNCTION = "Function Takeoff";
        public const string MAP = "Map Takeoff";

        public const sbyte ADDITION_OPERAND = 0;
        public const sbyte DEDUCTION_OPERAND = 1;

        public static readonly string[] FIELDS = new string[] { "title", "conditionId", "operand", "formulaF", "quantity1", "unit1", "quantity2", "unit2", "quantity3", "unit3", "quantityF", "unitF", "building", "storey", "location", "layer", "takeOffType", "globalId", "description", "lastUpdate" };

        public long? conditionId;
        public string databaseName;
        public string username;
        public string password;
        public string host;
        public int? bidNo;
        public int? cndNo;
        public int? cndId;
        public string cndType;
        public int? pickType;
        public string pickData;

        public string description;
        public string title;


        public string building = "";
        public string storey = "";
        public string location = "";

        public string bimType = "";
        public string bimMaterial = "";

        public string layer = "";
        public string quantity1Name = "";
        public string quantity2Name = "";
        public string quantity3Name = "";
        public string quantityFName = "";

        public string formula1;
        public string formula2;
        public string formula3;
        public string formulaF;

        public decimal quantity1;
        public decimal quantity2;
        public decimal quantity3;
        public decimal quantityF;

        public int? defaultQuantity = new int?(0);

        public string unit1;
        public string unit2;
        public string unit3;
        public string unitF;
        public string takeOffType = MANUAL;
        public string globalId;
        public string functionState;
        public bool? @virtual;
        public sbyte? operand = ADDITION_OPERAND;

        [NonSerialized]
        public ISet<BoqItemCondition> boqItemConditionSet;

        public Condition()
        { }
    }
}