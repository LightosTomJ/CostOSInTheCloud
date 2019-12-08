
namespace Models.local.Interfaces
{
	public interface IQuotetemplate
	{
		long Id { get; set; }
		System.Byte[] Xcellfile { get; set; }
		string Editorid { get; set; }
		System.DateTime? Createdate { get; set; }
		System.DateTime? Lastupdate { get; set; }
		string Title { get; set; }
		bool? Ismaterial { get; set; }
		long? Layoutid { get; set; }
		bool? Dflt { get; set; }
		
		Quotetemplate Clone();
	}
}
