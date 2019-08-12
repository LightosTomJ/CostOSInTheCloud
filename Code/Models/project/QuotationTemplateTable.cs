using System;

namespace Models.project
{
    public class QuotationTemplateTable
    {

        public long? id;
        public sbyte[] excelFile;
        public string editorId;
        public DateTime createDate;
        public DateTime lastUpdate;
        public string title;
        public bool isMaterialQuote;
        public long? layoutTableId;
        public bool? dflt;

        public QuotationTemplateTable()
        { }
    }
}