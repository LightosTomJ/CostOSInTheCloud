using System;
using System.Collections;

namespace Models.projects
{

    [Serializable]
    public class QuoteItemTable
    {

        public const string AWARDED_STATE = "enum.quote.status.awarded";
        public const string REJECTED_STATE = "enum.quote.status.rejected";
        public const string PENDING_STATE = "enum.quote.status.pending";
        public const string NOTAVAILABLE_STATE = "enum.quote.status.notavailable";
        public const string WORKITEM_STATE = "enum.quote.status.workitem";

        public static readonly string[] FIELDS = new string[] { "quoteItemId", "title", "state", "unit", "quantity", "manHours", "material", "rate", "insurance", "indirect", "finalRate" };

        public long? quoteItemId;
        public string title;
        public string unit;
        public decimal quantity;
        public decimal mainQuantity;
        public decimal insurance;
        public decimal manHours;
        public decimal material;
        public decimal indirectCost;
        public decimal shipmentCost;
        public decimal rate;
        public decimal totalCost;
        public decimal factor1;
        public decimal factor2;
        public string state;
        public bool? resource;
        public decimal finalRate;

        public QuotationTable quotationTable;
        public BoqItemTable boqItemTable;

        public BoqItemSubcontractor subcontractorTable;
        public BoqItemMaterial materialTable;

        public long? supplierDatabaseId;
        public long? databaseId;
        public long? databaseCreationDate;

        [NonSerialized]
        public IDictionary o_propertiesMap;

        public QuoteItemTable()
        { }

    }
}