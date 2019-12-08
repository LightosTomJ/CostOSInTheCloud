
namespace Models.local.Interfaces
{
	public interface IAd
	{
		long Id { get; set; }
		string Type { get; set; }
		string Statusmsg { get; set; }
		int? Port { get; set; }
		bool? Isssl { get; set; }
		string Binddn { get; set; }
		string Searchfilter { get; set; }
		string Password { get; set; }
		string Basedn { get; set; }
		bool? Enable { get; set; }
		decimal? Synctime { get; set; }
		string Hostname { get; set; }
		string Profile { get; set; }
		
		Ad Clone();
	}
}
