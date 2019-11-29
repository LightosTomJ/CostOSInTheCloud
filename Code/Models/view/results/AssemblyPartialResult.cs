using Models.local.BaseClass;
using Models.result.Interfaces;
using Models.results.DAO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Models.result
{
    [Serializable]
    public class AssemblyPartialResult : AssemblyPartial, IPartialResult
    {
        //List<Assembly> Results { get; set; }
        public IList<Assembly> Results = new List<Assembly>();
        public AssemblyPartialResult()
        {
            // We need this constructor to initialize the webservice
        }

        public AssemblyPartialResult(int? resultSize, int? partialSize, int? partialStart,
                                      string sortByField, bool ascending, string query, string queryType,
                                      decimal seconds, int? pageSize, IList<Assembly> partialResult) //: base()
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

        public List<Assembly> GetResults()
        {
            return (List<Assembly>)Results;
        }

        IList IPartialResult.Result => throw new NotImplementedException();
    }
}