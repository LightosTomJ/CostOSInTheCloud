
namespace Models.local.Interfaces
{
	public interface IBcProject
	{
		long Id { get; set; }
		string Code { get; set; }
		string Descr { get; set; }
		string Globalid { get; set; }
		bool? Deleted { get; set; }
		string Name { get; set; }
		long? ParentId { get; set; }
		Models.local.BaseClass.BcProject Parent { get; set; }
		System.Collections.Generic.ICollection<BcModel> BcModel { get; set; }
		System.Collections.Generic.ICollection<BcProject> InverseParent { get; set; }
		
		BcProject Clone();
	}
}
