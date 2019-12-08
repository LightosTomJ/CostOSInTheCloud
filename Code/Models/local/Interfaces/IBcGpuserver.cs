
namespace Models.local.Interfaces
{
	public interface IBcGpuserver
	{
		long Id { get; set; }
		bool? Active { get; set; }
		long? AvaMem { get; set; }
		long? Capacity { get; set; }
		long? CurMem { get; set; }
		int? CurSessions { get; set; }
		string Dedicated { get; set; }
		string Hostname { get; set; }
		System.DateTime? LastUpdate { get; set; }
		int? Maxsessions { get; set; }
		string Name { get; set; }
		bool? Onln { get; set; }
		string Paswd { get; set; }
		string Port { get; set; }
		string Renderer { get; set; }
		string Username { get; set; }
		string Vendor { get; set; }
		
		BcGpuserver Clone();
	}
}
