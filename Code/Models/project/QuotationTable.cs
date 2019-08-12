using System;
using System.Collections.Generic;

namespace Models.project
{
    [Serializable]
    public class QuotationTable
    {

        public static readonly string[] FIELDS = new string[] { "subject", "quotationId", "quoteType", "status", "performance", "companyName", "contactPerson", "email", "phoneNumber", "mobileNumber", "city", "address", "stateProvince", "country", "currency", "geoLocation", "url", "guid", "toMail", "ccMail", "bccMail", "editorId", "createDate", "sentDate", "receivedDate", "description", "notes", "workPackage" };

        public static string MATERIAL_QUOTE = "enum.quotetype.material";
        public static string SUBCONTRACTOR_QUOTE = "enum.quotetype.subcontractor";
        public static string WORKPACKAGE_QUOTE = "enum.quotetype.workpackage";

        public static string PENDING_STATUS = "enum.quotation.status.pending";
        public static string RECEIVED_STATUS = "enum.quotation.status.received";
        public static string WORKPACKAGE_STATUS = "enum.quotation.status.wp";

        public string title;
        public bool? onSiteDelivery;
        public bool? hasMaterialRate;
        public string subject;
        public string description;
        public string quoteType;
        public long? quotationId;
        public string companyName;
        public string contactPerson;
        public string email;
        public string phoneNumber;
        public string mobileNumber;
        public string faxNumber;

        public string country;
        public string stateProvince;
        public string city;
        public string address;
        public string url;
        public string toMail;
        public string ccMail;
        public string bccMail;
        public string editorId;
        public string status;
        public string guid;
        public string geoLocation;

        public int? performance;
        public string currency;

        public string notes;
        public DateTime createDate;
        public DateTime sentDate;
        public DateTime receivedDate;
        public long? templateId;

        [NonSerialized]
        public ISet<QuoteItemTable> quoteItemSet;

        public QuotationTable()
        { }
    }
}