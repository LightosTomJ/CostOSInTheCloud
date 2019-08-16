using Model.local;
using System;
using System.Collections.Generic;

namespace Models.result
{
    [Serializable]
    public class ConsumablePartialResult
    {
        public const string PartialResult_Fields = "";
        //public const string PartialResult_Fields = "";

        public int? resultSize { get; set; }
        public int? partialSize { get; set; }
        public int? partialStart { get; set; }
        public int? pageSize { get; set; }
        public string sortByField { get; set; }
        public bool ascending { get; set; }
        public string query { get; set; }
        public string queryType { get; set; }
        public double seconds { get; set; }

        public IList<ConsumableTable> partialResult { get; set; }

        public ConsumablePartialResult()
        {
            partialResult = new List<ConsumableTable>();
            // We need this constructor to initialize the webservice
        }

        public ConsumablePartialResult(int? resultSize, int? partialSize, int? partialStart, string sortByField, bool ascending, string query, string queryType, double seconds, int? pageSize, IList<ConsumableTable> partialResult) : base()
        {
            this.resultSize = resultSize;
            this.partialSize = partialSize;
            this.partialStart = partialStart;
            this.sortByField = sortByField;
            this.ascending = ascending;
            this.query = query;
            this.queryType = queryType;
            this.partialResult = partialResult;
            this.seconds = seconds;
            this.pageSize = pageSize;
        }
    }
}