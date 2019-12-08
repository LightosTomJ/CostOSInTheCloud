
namespace Models.local.Interfaces
{
	public interface IBoqitemmetadata
	{
		long Id { get; set; }
		string Fieldkey { get; set; }
		string Initialdisplayname { get; set; }
		string Fieldname { get; set; }
		string Columnname { get; set; }
		
		Boqitemmetadata Clone();
	}
}
