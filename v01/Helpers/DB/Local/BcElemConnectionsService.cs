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
	public class BcElemConnectionsService
	{
		private LocalContext localContext;

		public BcElemConnectionsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> BcElemConnectionCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.BcElemConnection.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.BcElemConnection>> GetAllBcElemConnections()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.BcElemConnection> bcElemConnections = await localContext.BcElemConnection.ToListAsync();
				return bcElemConnections;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateBcElemConnection(List<Models.DB.Local.BcElemConnection> BcElemConnections)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.BcElemConnection bcElemConnection in BcElemConnections)
				{
					localContext.BcElemConnection.Add(bcElemConnection);
					await localContext.SaveChangesAsync();
					returnid = bcElemConnection.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateBcElemConnection(Models.DB.Local.BcElemConnection bcElemConnection)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.BcElemConnection.Update(bcElemConnection);
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
		public async Task<bool> DeleteBcElemConnection(long bcElemConnectionId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.BcElemConnection bcElemConnection = localContext.BcElemConnection.First(p => p.Id == bcElemConnectionId);
				localContext.BcElemConnection.Remove(bcElemConnection);
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
