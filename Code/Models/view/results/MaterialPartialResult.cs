using Models.local.BaseClass;
using Models.result.Interfaces;
using Models.results.DAO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Models.result
{
    [Serializable]
    public class MaterialPartialResult : MaterialPartial, IPartialResult
    {
        //List<Material> Results { get; set; }
        public IList<Material> Results = new List<Material>();
        public MaterialPartialResult()
        {
            // We need this constructor to initialize the webservice
        }

        public MaterialPartialResult(int? resultSize, int? partialSize, int? partialStart,
                                      string sortByField, bool ascending, string query, string queryType,
                                      decimal seconds, int? pageSize, IList<Material> partialResult) //: base()
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

        public List<Material> GetResults()
        {
            return (List<Material>)Results;
        }

        IList IPartialResult.Result => throw new NotImplementedException();
    }
}