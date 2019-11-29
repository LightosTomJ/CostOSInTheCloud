using Models.local.BaseClass;
using Models.result.Interfaces;
using Models.results.DAO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Models.result
{
    [Serializable]
    public class SupplierPartialResult : SupplierPartial, IPartialResult
    {
        //List<Supplier> Results { get; set; }
        public IList<Supplier> Results = new List<Supplier>();
        public SupplierPartialResult()
        {
            // We need this constructor to initialize the webservice
        }

        public SupplierPartialResult(int? resultSize, int? partialSize, int? partialStart,
                                      string sortByField, bool ascending, string query, string queryType,
                                      decimal seconds, int? pageSize, IList<Supplier> partialResult) //: base()
        {
            this.ResultSize = resultSize;
            this.PartialSize = partialSize;
            this.PartialStart = partialStart;
            this.SortByField = sortByField;
            this.Ascending = ascending;
            this.Query = query;
            this.QueryType = queryType;
            this.Results = partialResult;
            this.Seconds = seconds;
            this.PageSize = pageSize;
        }

        public List<Supplier> GetResults()
        {
            return (List<Supplier>)Results;
        }

        IList IPartialResult.Result => throw new NotImplementedException();
    }
}