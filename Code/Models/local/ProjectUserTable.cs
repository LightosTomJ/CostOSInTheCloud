using System.Collections.Generic;

namespace Model.local
{
    public class ProjectUserTable
    {

        public static readonly string[] FIELDS = new string[] { "id", "userId", "name", "email", "editExchange", "editEscalate", "editProps", "editTakeoff", "editResource", "estimator", "administrator", "sendQuotes", "submitQuotes", "awardQuotes", "wbs", "addItems", "removeItems", "editItems", "viewAllItems", "variablesUser", "variablesAdmin", "variablesViewer" };

        public long? id { get; set; }
        public string userId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        // Add on access:
        public bool? editExchange { get; set; }
        public bool? editEscalate { get; set; }
        public bool? editProps { get; set; }
        public bool? editTakeoff { get; set; }
        public bool? editResource { get; set; }
        public bool? estimator { get; set; }
        public bool? administrator { get; set; }
        public bool? sendQuotes { get; set; }
        public bool? submitQuotes { get; set; }
        public bool? awardQuotes { get; set; }
        public bool? wbs { get; set; }
        public bool? addItems { get; set; }
        public bool? removeItems { get; set; }
        public bool? editItems { get; set; }
        public bool? viewAllItems { get; set; }
        public bool? variablesUser { get; set; }
        public bool? variablesAdmin { get; set; }
        public bool? variablesViewer { get; set; }

        public ProjectInfoTable projectInfoTable;
        public ISet<ProjectAccessRuleTable> accessRules;

        public ProjectUserTable()
        { }
    }
}