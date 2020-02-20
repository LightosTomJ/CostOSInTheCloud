using System.Collections.Generic;

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
		BaseClass.BcProject Parent { get; set; }
		//ICollection<BcModel> BcModel { get; set; }
		//ICollection<BcProject> InverseParent { get; set; }
		
		BcProject Clone();
	}
}
