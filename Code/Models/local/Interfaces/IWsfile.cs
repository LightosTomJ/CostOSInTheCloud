
namespace Models.local.Interfaces
{
	public interface IWsfile
	{
		long Id { get; set; }
		bool? Xmlfile { get; set; }
		string Title { get; set; }
		string Fpath { get; set; }
		System.Byte[] Xcellfile { get; set; }
		int? Numsheets { get; set; }
		long? Filerevid { get; set; }
		string Actsheets { get; set; }
		bool? Tcmfile { get; set; }
		BaseClass.Wsrevision Filerev { get; set; }
		
		Wsfile Clone();
	}
}
