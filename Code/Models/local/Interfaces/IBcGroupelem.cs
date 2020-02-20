
namespace Models.local.Interfaces
{
	public interface IBcGroupelem
	{
		long Id { get; set; }
		long? ElemId { get; set; }
		long? GroupId { get; set; }
		long? ModelId { get; set; }
		BaseClass.BcElement Elem { get; set; }
		BaseClass.BcGroup Group { get; set; }
		BaseClass.BcModel Model { get; set; }
		
		BcGroupelem Clone();
	}
}
