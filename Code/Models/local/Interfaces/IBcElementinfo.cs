//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IBcElementinfo
	{
		long Id { get; set; }
		string Label { get; set; }
		string Material { get; set; }
		string Type { get; set; }
		long? ElementId { get; set; }
		long? ModelId { get; set; }
		BaseClass.BcElement Element { get; set; }
		BaseClass.BcModel Model { get; set; }
		//ICollection<BcElemmaterial> BcElemmaterial { get; set; }
		
		BcElementinfo Clone();
	}
}
