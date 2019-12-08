
namespace Models.local.Interfaces
{
	public interface ILocprof
	{
		long Functionid { get; set; }
		string Fromcountry { get; set; }
		string Fromstate { get; set; }
		string Name { get; set; }
		bool? Supstate { get; set; }
		string Editorid { get; set; }
		string Createuserid { get; set; }
		System.DateTime? Createdate { get; set; }
		System.DateTime? Lastupdate { get; set; }
		System.Collections.Generic.ICollection<Locfactor> Locfactor { get; set; }
		
		Locprof Clone();
	}
}
