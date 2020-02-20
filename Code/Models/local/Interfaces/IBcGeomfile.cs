using System;
//using System.Collections.Generic;

namespace Models.local.Interfaces
{
	public interface IBcGeomfile
	{
		long Id { get; set; }
		Byte[] Fdata { get; set; }
		string Fname { get; set; }
		int? Ftype { get; set; }
		Guid Fguid { get; set; }
		int? Novertices { get; set; }
		int? Noelements { get; set; }
		int? Elemoffset { get; set; }
		string OriginalFormat { get; set; }
		int? SerializationType { get; set; }
		long? ModelId { get; set; }
		BaseClass.BcModel Model { get; set; }
		//Collection<BcGeometry> BcGeometry { get; set; }
		
		BcGeomfile Clone();
	}
}
