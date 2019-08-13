using Model.local;
using System;
using System.Collections.Generic;

namespace Models.result
{
    [Serializable]
    public class AssemblyPartialResult
    {
        public const string PartialResult_Fields = "";
        //public const string PartialResult_Fields = "";

        public int? resultSize { get; set; }
        public int? partialSize { get; set; }
        public int? partialStart { get; set; }
        public int? pageSize { get; set; }
        public string sortByField { get; set; }
        public bool asceding { get; set; }
        public string query { get; set; }
        public string queryType { get; set; }
        public double seconds { get; set; }

        public IList<AssemblyTable> partialResult { get; set; }

        public AssemblyPartialResult()
        {
            partialResult = new List<AssemblyTable>();
            // We need this constructor to initialize the webservice
        }

        public AssemblyPartialResult(int? resultSize, int? partialSize, int? partialStart, string sortByField, bool asceding, string query, string queryType, double seconds, int? pageSize, IList<AssemblyTable> partialResult) : base()
        {
            this.resultSize = resultSize;
            this.partialSize = partialSize;
            this.partialStart = partialStart;
            this.sortByField = sortByField;
            this.asceding = asceding;
            this.query = query;
            this.queryType = queryType;
            this.partialResult = partialResult;
            this.seconds = seconds;
            this.pageSize = pageSize;
        }
    }
}