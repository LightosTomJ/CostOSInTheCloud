
namespace Models.local.Interfaces
{
	public interface IBcGroupelem
	{
		long Id { get; set; }
		long? ElemId { get; set; }
		long? GroupId { get; set; }
		long? ModelId { get; set; }
		Models.local.BaseClass.BcElement Elem { get; set; }
		Models.local.BaseClass.BcGroup Group { get; set; }
		Models.local.BaseClass.BcModel Model { get; set; }
		
		BcGroupelem Clone();
	}
}
