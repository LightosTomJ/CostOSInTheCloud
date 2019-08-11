namespace Models.result
{


	public interface PartialResult
	{

		int? ResultSize {get;set;}
		int? PartialSize {get;set;}
		int? PartialStart {get;set;}
		string SortByField {get;set;}
		bool Asceding {get;set;}
		string Query {get;set;}
		string QueryType {get;set;}
		double Seconds {get;set;}
		int? PageSize {get;set;}

		System.Collections.IList Result {get;}
	}

	public static class PartialResult_Fields
	{
		public const string SEARCH_QUERY = "SEARCH";
		public const string FILTER_QUERY = "FILTER";
	}

}