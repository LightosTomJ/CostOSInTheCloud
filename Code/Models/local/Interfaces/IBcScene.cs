using System;

namespace Models.local.Interfaces
{
	public interface IBcScene
	{
		long Id { get; set; }
		Guid Sguid { get; set; }
		string Sname { get; set; }
		Byte[] Sdata { get; set; }
		int? Stype { get; set; }
		
		BcScene Clone();
	}
}
