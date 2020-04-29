using Diagnostics.Logger;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.DB.Local
{
	public class BcGPUServersService
	{
		private LocalContext localContext;

		public BcGPUServersService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcGPUServerCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcGPUServer.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcGPUServer>> GetAllBcGPUServers()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcGPUServer> bcGPUServers = await localContext.BcGPUServer.ToListAsync();
				return bcGPUServers;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcGPUServer(List<Models.DB.Local.BcGPUServer> BcGPUServers)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcGPUServer bcGPUServer in BcGPUServers)
				{
					localContext.BcGPUServer.Add(bcGPUServer);
					await localContext.SaveChangesAsync();
					returnid = bcGPUServer.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcGPUServer(Models.DB.Local.BcGPUServer bcGPUServer)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcGPUServer.Update(bcGPUServer);
				await localContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
		public async Task<bool> DeleteBcGPUServer(long bcGPUServerId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcGPUServer bcGPUServer = localContext.BcGPUServer.First(p => p.Id == bcGPUServerId);
				localContext.BcGPUServer.Remove(bcGPUServer);
				await localContext.SaveChangesAsync();
				return true;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return false;
		}
	}
}
