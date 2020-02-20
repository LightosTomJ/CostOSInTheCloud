using System;

namespace Models.local.Interfaces
{
	public interface IQuotetemplate
	{
		long Id { get; set; }
		Byte[] Xcellfile { get; set; }
		string Editorid { get; set; }
		DateTime? Createdate { get; set; }
		DateTime? Lastupdate { get; set; }
		string Title { get; set; }
		bool? Ismaterial { get; set; }
		long? Layoutid { get; set; }
		bool? Dflt { get; set; }
		
		Quotetemplate Clone();
	}
}
