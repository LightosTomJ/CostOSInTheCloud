
namespace Models.local.Interfaces
{
	public interface IBcScene
	{
		long Id { get; set; }
		System.Guid Sguid { get; set; }
		string Sname { get; set; }
		System.Byte[] Sdata { get; set; }
		int? Stype { get; set; }
		
		BcScene Clone();
	}
}
