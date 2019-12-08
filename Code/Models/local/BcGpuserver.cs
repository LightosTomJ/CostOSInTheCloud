
namespace Models.local
{
	public class BcGpuserver : BaseClass.BcGpuserver//, Interfaces.IBcGpuserver
	{
		public BcGpuserver Clone()
		{
			BcGpuserver c = new BcGpuserver();
			c.Id = Id;
			c.Active = Active;
			c.AvaMem = AvaMem;
			c.Capacity = Capacity;
			c.CurMem = CurMem;
			c.CurSessions = CurSessions;
			c.Dedicated = Dedicated;
			c.Hostname = Hostname;
			c.LastUpdate = LastUpdate;
			c.Maxsessions = Maxsessions;
			c.Name = Name;
			c.Onln = Onln;
			c.Paswd = Paswd;
			c.Port = Port;
			c.Renderer = Renderer;
			c.Username = Username;
			c.Vendor = Vendor;

			return c;
		}
	}
}
