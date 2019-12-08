
namespace Models.local.Interfaces
{
	public interface IWscolident
	{
		long Id { get; set; }
		string Splitfield { get; set; }
		bool? Munique { get; set; }
		bool? Sheetprefix { get; set; }
		bool? Fileprefix { get; set; }
		bool? Exauma { get; set; }
		int? Coltype { get; set; }
		int? Mapaction { get; set; }
		string Fldname { get; set; }
		int? Colindex { get; set; }
		int? Fldtype { get; set; }
		string Fieldmap { get; set; }
		long? Mappingid { get; set; }
		Models.local.BaseClass.Wsdatamapping Mapping { get; set; }
		
		Wscolident Clone();
	}
}
