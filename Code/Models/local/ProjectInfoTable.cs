using System;
using System.Collections.Generic;

namespace Model.local
{
    [Serializable]
    public class ProjectInfoTable
    {

        public const string DOTTED_STYLE = "dotted";
        public const string NUMERIC5_STYLE = "numeric5";
        public const string NUMERIC6_STYLE = "numeric6";
        // public static final String ALPHABETIC_STYLE = "alphabetic";
        public const string RICHARDSON_STYLE = "richardson";

        public const string FILE_STORAGE = "CEP File";
        public const string SERVER_STORAGE = "Server";

        // MONO CUSTOMEPS EDW:
        public static readonly string[] CUSTOM_EPS_FIELDS = new string[] { "customEpsRate1", "customEpsRate2", "customEpsRate3", "customEpsRate4", "customEpsRate5", "customEpsRate6", "customEpsRate7", "customEpsRate8", "customEpsRate9", "customEpsRate10", "customEpsText1", "customEpsText2", "customEpsText3", "customEpsText4", "customEpsText5", "customEpsText6", "customEpsText7", "customEpsText8", "customEpsText9", "customEpsText10", "customEpsText11", "customEpsText12", "customEpsText13", "customEpsText14", "customEpsText15", "customEpsText16", "customEpsText17", "customEpsText18", "customEpsText19", "customEpsText20", "customEpsDate1", "customEpsDate2", "customEpsDate3", "customEpsDate4", "customEpsDate5", "customEpsDate6", "customEpsDate7", "customEpsDate8", "customEpsDate9", "customEpsDate10" };

        public static readonly string[] FIELDS = new string[] { "code", "title", "projectType", "client", "location", "stateProvince", "country", "currency", "status", "submissionDate", "unitCost", "basementSize", "superstructureSize", "unit", "customEpsRate1", "customEpsRate2", "customEpsRate3", "customEpsRate4", "customEpsRate5", "customEpsRate6", "customEpsRate7", "customEpsRate8", "customEpsRate9", "customEpsRate10", "customEpsText1", "customEpsText2", "customEpsText3", "customEpsText4", "customEpsText5", "customEpsText6", "customEpsText7", "customEpsText8", "customEpsText9", "customEpsText10", "customCumRate1", "customCumRate2", "customCumRate3", "customCumRate4", "customCumRate5", "customCumRate6", "customCumRate7", "customCumRate8", "customCumRate9", "customCumRate10", "equipmentTotalCost", "subcontractorTotalCost", "laborTotalCost", "materialTotalCost", "consumableTotalCost", "laborManhours", "equipmentHours", "totalCost", "offeredPrice", "lastUpdate", "customEpsText11", "customEpsText12", "customEpsText13", "customEpsText14", "customEpsText15", "customEpsText16", "customEpsText17", "customEpsText18", "customEpsText19", "customEpsText20", "customCumRate11", "customCumRate12", "customCumRate13", "customCumRate14", "customCumRate15", "customCumRate16", "customCumRate17", "customCumRate18", "customCumRate19", "customCumRate20", "customEpsDate1", "customEpsDate2", "customEpsDate3", "customEpsDate4", "customEpsDate5", "customEpsDate6", "customEpsDate7", "customEpsDate8", "customEpsDate9", "customEpsDate10", "defaultRevision" };

        public static readonly Type[] CLASSES = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(DateTime), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(decimal), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(DateTime), typeof(string) };

        public long? projectInfoId { get; set; }

        public string code { get; set; }
        public string title { get; set; }
        public string editorId { get; set; }
        public string description { get; set; }
        public string codeStyle = DOTTED_STYLE;
        public DateTime lastUpdate { get; set; }
        public DateTime createDate { get; set; }
        public string storageType = FILE_STORAGE;

        public string location { get; set; }
        public string unit { get; set; }
        public string country { get; set; }
        public string client { get; set; }
        public string stateProvince { get; set; }
        public string contractor { get; set; }
        public string geoLocation { get; set; }

        public bool? hasBimTakeoff { get; set; }
        public bool? hasOnScreenTakeoff { get; set; }

        public bool? primaveraConnected { get; set; }

        public bool? locationFactors { get; set; }
        public string locationProfile { get; set; }
        public string selectedFactor { get; set; }

        public string projectType { get; set; }
        public string subCategory { get; set; }
        public string projectIconMediaId { get; set; }
        public decimal basementSize { get; set; }
        public decimal superstructureSize { get; set; }
        public decimal unitCost { get; set; }
        public decimal clientBudget { get; set; }
        public int? floors { get; set; }
        public int? paymentDuration { get; set; }

        public decimal totalCost { get; set; }
        public decimal offeredPrice { get; set; }
        public string status { get; set; }
        public string currency { get; set; }
        public DateTime submissionDate { get; set; }

        public string defaultRevision { get; set; }

        public decimal customEpsRate1 { get; set; }
        public decimal customEpsRate2 { get; set; }
        public decimal customEpsRate3 { get; set; }
        public decimal customEpsRate4 { get; set; }
        public decimal customEpsRate5 { get; set; }
        public decimal customEpsRate6 { get; set; }
        public decimal customEpsRate7 { get; set; }
        public decimal customEpsRate8 { get; set; }
        public decimal customEpsRate9 { get; set; }
        public decimal customEpsRate10 { get; set; }

        public string customEpsText1 { get; set; }
        public string customEpsText2 { get; set; }
        public string customEpsText3 { get; set; }
        public string customEpsText4 { get; set; }
        public string customEpsText5 { get; set; }
        public string customEpsText6 { get; set; }
        public string customEpsText7 { get; set; }
        public string customEpsText8 { get; set; }
        public string customEpsText9 { get; set; }
        public string customEpsText10 { get; set; }
        public string customEpsText11 { get; set; }
        public string customEpsText12 { get; set; }
        public string customEpsText13 { get; set; }
        public string customEpsText14 { get; set; }
        public string customEpsText15 { get; set; }
        public string customEpsText16 { get; set; }
        public string customEpsText17 { get; set; }
        public string customEpsText18 { get; set; }
        public string customEpsText19 { get; set; }
        public string customEpsText20 { get; set; }

        public decimal customCumRate1 { get; set; }
        public decimal customCumRate2 { get; set; }
        public decimal customCumRate3 { get; set; }
        public decimal customCumRate4 { get; set; }
        public decimal customCumRate5 { get; set; }
        public decimal customCumRate6 { get; set; }
        public decimal customCumRate7 { get; set; }
        public decimal customCumRate8 { get; set; }
        public decimal customCumRate9 { get; set; }
        public decimal customCumRate10 { get; set; }
        public decimal customCumRate11 { get; set; }
        public decimal customCumRate12 { get; set; }
        public decimal customCumRate13 { get; set; }
        public decimal customCumRate14 { get; set; }
        public decimal customCumRate15 { get; set; }
        public decimal customCumRate16 { get; set; }
        public decimal customCumRate17 { get; set; }
        public decimal customCumRate18 { get; set; }
        public decimal customCumRate19 { get; set; }
        public decimal customCumRate20 { get; set; }

        public DateTime customEpsDate1 { get; set; }
        public DateTime customEpsDate2 { get; set; }
        public DateTime customEpsDate3 { get; set; }
        public DateTime customEpsDate4 { get; set; }
        public DateTime customEpsDate5 { get; set; }
        public DateTime customEpsDate6 { get; set; }
        public DateTime customEpsDate7 { get; set; }
        public DateTime customEpsDate8 { get; set; }
        public DateTime customEpsDate9 { get; set; }
        public DateTime customEpsDate10 { get; set; }

        public decimal equipmentTotalCost { get; set; }
        public decimal subcontractorTotalCost { get; set; }
        public decimal laborTotalCost { get; set; }
        public decimal materialTotalCost { get; set; }
        public decimal consumableTotalCost { get; set; }
        public decimal laborManhours { get; set; }
        public decimal equipmentHours { get; set; }

        public ProjectEPSTable projectEPSTable { get; set; }

        public string epsCode { get; set; }

        //ContainedIn
        //OneToMany(mappedBy="projectInfoTable")
        public ISet<ProjectWBSTable> wbsSet = new HashSet<ProjectWBSTable>(0);
        public ISet<ProjectWBS2Table> wbs2Set = new HashSet<ProjectWBS2Table>(0);
        public ISet<ProjectUrlTable> urlSet = new HashSet<ProjectUrlTable>(0);
        public ISet<TakeoffConditionTable> takeoffSet = new HashSet<TakeoffConditionTable>(0);
        public ISet<ProjectUserTable> userSet = new HashSet<ProjectUserTable>(0);

        public ProjectInfoTable()
        { }
    }
}