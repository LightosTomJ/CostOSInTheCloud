using System;

namespace Model.local
{
    public class ProjectUserTemplateTable
    {

        public static readonly string[] FIELDS = new string[] { "id", "name", "editExchange", "editEscalate", "editProps", "editTakeoff", "editResource", "estimator", "administrator", "sendQuotes", "submitQuotes", "awardQuotes", "wbs", "addItems", "removeItems", "editItems", "viewAllItems", "variablesUser", "variablesAdmin", "variablesViewer", "createUserId", "createUserDate", "editorId", "lastUpdate" };

        public long? id { get; set; }
        public string name { get; set; }

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

        public string createUserId { get; set; }

        public DateTime createUserDate { get; set; }

        public string editorId { get; set; }

        public DateTime lastUpdate { get; set; }

        public ProjectUserTemplateTable()
        { }
    }
}