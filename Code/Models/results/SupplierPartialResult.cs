using Model.local;
using Model.result.Interfaces;
using Models.results.DAO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Models.result
{
    [Serializable]
    public class SupplierPartialResult : SupplierPartial, IPartialResult
    {
        //List<SupplierTable> Results { get; set; }
        public IList<SupplierTable> Results = new List<SupplierTable>();
        public SupplierPartialResult()
        {
            // We need this constructor to initialize the webservice
        }

        public SupplierPartialResult(int? resultSize, int? partialSize, int? partialStart,
                                      string sortByField, bool ascending, string query, string queryType,
                                      decimal seconds, int? pageSize, IList<SupplierTable> partialResult) //: base()
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

        public List<SupplierTable> GetResults()
        {
            return (List<SupplierTable>)Results;
        }

        IList IPartialResult.Result => throw new NotImplementedException();
    }
}