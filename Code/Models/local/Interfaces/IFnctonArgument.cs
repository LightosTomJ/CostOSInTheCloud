
namespace Models.local.Interfaces
{
	public interface IFnctonArgument
	{
		long Fargid { get; set; }
		string Name { get; set; }
		int? Sorder { get; set; }
		string Artype { get; set; }
		bool? Editable { get; set; }
		long? Fid { get; set; }
		string Description { get; set; }
		string Sellist { get; set; }
		string Type { get; set; }
		string Unit { get; set; }
		string Valsta { get; set; }
		string Depsta { get; set; }
		string Defval { get; set; }
		string Grouping { get; set; }
		int? Varscount { get; set; }
		BaseClass.Fncton F { get; set; }
		
		FnctonArgument Clone();
	}
}
