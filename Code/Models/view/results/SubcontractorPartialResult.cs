using Models.local.BaseClass;
using Models.result.Interfaces;
using Models.results.DAO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Models.result
{
    [Serializable]
    public class SubcontractorPartialResult : SubcontractorPartial, IPartialResult
    {
        public IList<Subcontractor> Results = new List<Subcontractor>();

        public SubcontractorPartialResult()
        {
            // We need this constructor to initialize the webservice	
        }

        public SubcontractorPartialResult(int? resultSize, int? partialSize, int? partialStart,
                                            string sortByField, bool ascending, string query, string queryType, 
                                            decimal seconds, int? pageSize, IList<Subcontractor> partialResult) //: base()
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
        public List<Subcontractor> GetResults()
        {
            return (List<Subcontractor>)Results;
        }

        IList IPartialResult.Result => throw new NotImplementedException();
    }
}