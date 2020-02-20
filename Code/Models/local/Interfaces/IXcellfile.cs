//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IXcellfile
	{
		long Xcellid { get; set; }
		System.Byte[] Xcellfile1 { get; set; }
		int? Sheet { get; set; }
		int? Cellx { get; set; }
		int? Celly { get; set; }
		//ICollection<Projecttemplate> Projecttemplate { get; set; }
		
		Xcellfile Clone();
	}
}
