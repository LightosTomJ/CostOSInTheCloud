
namespace Models.local.Interfaces
{
	public interface ILictbl
	{
		long Id { get; set; }
		System.Byte[] Hashkey { get; set; }
		
		Lictbl Clone();
	}
}
