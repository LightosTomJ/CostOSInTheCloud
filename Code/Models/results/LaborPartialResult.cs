using Model.local;
using Model.result.Interfaces;
using Models.results.DAO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Models.result
{
    [Serializable]
    public class LaborPartialResult : LaborPartial, IPartialResult
    {
        //List<LaborTable> Results { get; set; }
        public IList<LaborTable> Results = new List<LaborTable>();
        public LaborPartialResult()
        {
            // We need this constructor to initialize the webservice
        }

        public LaborPartialResult(int? resultSize, int? partialSize, int? partialStart,
                                      string sortByField, bool ascending, string query, string queryType,
                                      decimal seconds, int? pageSize, IList<LaborTable> partialResult) //: base()
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

        public List<LaborTable> GetResults()
        {
            return (List<LaborTable>)Results;
        }

        IList IPartialResult.Result => throw new NotImplementedException();
    }
}