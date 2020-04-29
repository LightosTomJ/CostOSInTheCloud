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
	public class WscolidentsService
	{
		private LocalContext localContext;

		public WscolidentsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> WscolidentCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.WsColident.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.WsColident>> GetAllWscolidents()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.WsColident> wscolidents = await localContext.WsColident.ToListAsync();
				return wscolidents;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateWscolident(List<Models.DB.Local.WsColident> Wscolidents)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.WsColident wscolident in Wscolidents)
				{
					localContext.WsColident.Add(wscolident);
					await localContext.SaveChangesAsync();
					returnid = wscolident.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateWscolident(Models.DB.Local.WsColident wscolident)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.WsColident.Update(wscolident);
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
		public async Task<bool> DeleteWscolident(long wscolidentId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.WsColident wscolident = localContext.WsColident.First(p => p.Id == wscolidentId);
				localContext.WsColident.Remove(wscolident);
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
