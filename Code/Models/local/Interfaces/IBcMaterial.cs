//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IBcMaterial
	{
		long Id { get; set; }
		string Code { get; set; }
		string Name { get; set; }
		long? ModelId { get; set; }
		BaseClass.BcModel Model { get; set; }
		//ICollection<BcElemmaterial> BcElemmaterial { get; set; }
		
		BcMaterial Clone();
	}
}
