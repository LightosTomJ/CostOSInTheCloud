using System.Collections;

namespace Model.result.Interfaces
{
    public interface IPartialResult
    {
        int? ResultSize { get; set; }
        int? PartialSize { get; set; }
        int? PartialStart { get; set; }
        string SortByField { get; set; }
        bool Ascending { get; set; }
        string Query { get; set; }
        string QueryType { get; set; }
        decimal Seconds { get; set; }
        int? PageSize { get; set; }

        IList Result { get; }
    }
}