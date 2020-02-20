using System;

namespace Models.local.Interfaces
{
	public interface ICntrlog
	{
		long Id { get; set; }
		DateTime? Logdate { get; set; }
		string Editorid { get; set; }
		string Description { get; set; }
		string Src { get; set; }
		string Fltr { get; set; }
		long? Prjid { get; set; }
		byte? Oprtn { get; set; }
		
		Cntrlog Clone();
	}
}
