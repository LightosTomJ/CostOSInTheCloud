
namespace Models.local.Interfaces
{
	public interface IFieldcustom
	{
		long Id { get; set; }
		string Name { get; set; }
		string Displayname { get; set; }
		string Formula { get; set; }
		string Rsrc { get; set; }
		bool? Editable { get; set; }
		bool? Sellist { get; set; }
		string Selvals { get; set; }
		string Defsel { get; set; }
		
		Fieldcustom Clone();
	}
}
