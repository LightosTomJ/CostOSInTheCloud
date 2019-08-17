using Model.local;
using Model.result.Interfaces;
using Models.results.DAO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Models.result
{
    [Serializable]
    public class SubcontractorPartialResult : SubcontractorPartial, IPartialResult
    {
        public IList<SubcontractorTable> Results = new List<SubcontractorTable>();

        public SubcontractorPartialResult()
        {
            // We need this constructor to initialize the webservice	
        }

        public SubcontractorPartialResult(int? resultSize, int? partialSize, int? partialStart,
                                            string sortByField, bool ascending, string query, string queryType, 
                                            decimal seconds, int? pageSize, IList<SubcontractorTable> partialResult) //: base()
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
        public List<SubcontractorTable> GetResults()
        {
            return (List<SubcontractorTable>)Results;
        }

        IList IPartialResult.Result => throw new NotImplementedException();
    }
}