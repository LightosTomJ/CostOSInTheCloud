using Model.local;
using Model.result.Interfaces;
using Models.results.DAO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Models.result
{
    [Serializable]
    public class MaterialPartialResult : MaterialPartial, IPartialResult
    {
        //List<MaterialTable> Results { get; set; }
        public IList<MaterialTable> Results = new List<MaterialTable>();
        public MaterialPartialResult()
        {
            // We need this constructor to initialize the webservice
        }

        public MaterialPartialResult(int? resultSize, int? partialSize, int? partialStart,
                                      string sortByField, bool ascending, string query, string queryType,
                                      decimal seconds, int? pageSize, IList<MaterialTable> partialResult) //: base()
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

        public List<MaterialTable> GetResults()
        {
            return (List<MaterialTable>)Results;
        }

        IList IPartialResult.Result => throw new NotImplementedException();
    }
}