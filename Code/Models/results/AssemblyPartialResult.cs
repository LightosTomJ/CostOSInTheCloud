using Model.local;
using Model.result.Interfaces;
using Models.results.DAO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Models.result
{
    [Serializable]
    public class AssemblyPartialResult : AssemblyPartial, IPartialResult
    {
        //List<AssemblyTable> Results { get; set; }
        public IList<AssemblyTable> Results = new List<AssemblyTable>();
        public AssemblyPartialResult()
        {
            // We need this constructor to initialize the webservice
        }

        public AssemblyPartialResult(int? resultSize, int? partialSize, int? partialStart,
                                      string sortByField, bool ascending, string query, string queryType,
                                      decimal seconds, int? pageSize, IList<AssemblyTable> partialResult) //: base()
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

        public List<AssemblyTable> GetResults()
        {
            return (List<AssemblyTable>)Results;
        }

        IList IPartialResult.Result => throw new NotImplementedException();
    }
}