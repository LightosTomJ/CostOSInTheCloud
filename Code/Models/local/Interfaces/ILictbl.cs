using System;

namespace Models.local.Interfaces
{
	public interface ILictbl
	{
		long Id { get; set; }
		Byte[] Hashkey { get; set; }
		
		Lictbl Clone();
	}
}
