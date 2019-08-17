using Model.local;
using Model.result.Interfaces;
using Models.results.DAO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Models.result
{
    [Serializable]
    public class EquipmentPartialResult : EquipmentPartial, IPartialResult
    {
        //List<EquipmentTable> Results { get; set; }
        public IList<EquipmentTable> Results = new List<EquipmentTable>();
        public EquipmentPartialResult()
        {
            // We need this constructor to initialize the webservice
        }

        public EquipmentPartialResult(int? resultSize, int? partialSize, int? partialStart,
                                      string sortByField, bool ascending, string query, string queryType,
                                      decimal seconds, int? pageSize, IList<EquipmentTable> partialResult) //: base()
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

        public List<EquipmentTable> GetResults()
        {
            return (List<EquipmentTable>)Results;
        }

        IList IPartialResult.Result => throw new NotImplementedException();
    }
}