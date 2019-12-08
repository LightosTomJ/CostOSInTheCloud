
namespace Models.local.Interfaces
{
	public interface IBcGroup
	{
		long Id { get; set; }
		string Description { get; set; }
		string Globalid { get; set; }
		string Name { get; set; }
		string Type { get; set; }
		long? ModelId { get; set; }
		long? ParentId { get; set; }
		Models.local.BaseClass.BcModel Model { get; set; }
		Models.local.BaseClass.BcGroup Parent { get; set; }
		System.Collections.Generic.ICollection<BcGroupelem> BcGroupelem { get; set; }
		System.Collections.Generic.ICollection<BcGroupprop> BcGroupprop { get; set; }
		System.Collections.Generic.ICollection<BcGroup> InverseParent { get; set; }
		
		BcGroup Clone();
	}
}
