
namespace Models.local.Interfaces
{
	public interface IParaminput
	{
		long Paraminputid { get; set; }
		string Name { get; set; }
		string Lbl { get; set; }
		bool? Hidden { get; set; }
		bool? Pblk { get; set; }
		string Artype { get; set; }
		string Arsizevar { get; set; }
		bool? Editable { get; set; }
		bool? Wasshown { get; set; }
		byte? Calcvaldigits { get; set; }
		string Description { get; set; }
		string Comment { get; set; }
		bool? Frmrowvis { get; set; }
		string Datatype { get; set; }
		string Dependency { get; set; }
		string Validation { get; set; }
		string Selection { get; set; }
		int? Sortorder { get; set; }
		string Grouping { get; set; }
		string Defvalue { get; set; }
		string Unit { get; set; }
		string Stoval { get; set; }
		long? Paramitemid { get; set; }
		BaseClass.Paramitem Paramitem { get; set; }
		
		Paraminput Clone();
	}
}
