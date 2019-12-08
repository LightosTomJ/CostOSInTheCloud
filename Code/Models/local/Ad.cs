
namespace Models.local
{
	public class Ad : BaseClass.Ad//, Interfaces.IAd
	{
		public Ad Clone()
		{
			Ad c = new Ad();
			c.Id = Id;
			c.Type = Type;
			c.Statusmsg = Statusmsg;
			c.Port = Port;
			c.Isssl = Isssl;
			c.Binddn = Binddn;
			c.Searchfilter = Searchfilter;
			c.Password = Password;
			c.Basedn = Basedn;
			c.Enable = Enable;
			c.Synctime = Synctime;
			c.Hostname = Hostname;
			c.Profile = Profile;

			return c;
		}
	}
}
