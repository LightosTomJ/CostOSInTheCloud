//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IBcClassitem
	{
		long Id { get; set; }
		string Code { get; set; }
		string Name { get; set; }
		long? ClassificationId { get; set; }
		long? ModelId { get; set; }
		BaseClass.BcClassification Classification { get; set; }
		BaseClass.BcModel Model { get; set; }
		//.ICollection<BcElemclassitem> BcElemclassitem { get; set; }
		
		BcClassitem Clone();
	}
}
