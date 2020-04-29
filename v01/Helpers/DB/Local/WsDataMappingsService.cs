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
	public class WsDataMappingsService
	{
		private LocalContext localContext;

		public WsDataMappingsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> WsDataMappingCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.WsDataMapping.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.WsDataMapping>> GetAllWsDataMappings()
		{
			IList<Models.DB.Local.WsDataMapping> WsDataMappings = new List<Models.DB.Local.WsDataMapping>();
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.WsDataMapping> wsDataMappings = await localContext.WsDataMapping.ToListAsync();
				return wsDataMappings;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateWsDataMapping(List<Models.DB.Local.WsDataMapping> WsDataMappings)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.WsDataMapping wsDataMapping in WsDataMappings)
				{
					localContext.WsDataMapping.Add(wsDataMapping);
					await localContext.SaveChangesAsync();
					returnid = wsDataMapping.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateWsDataMapping(long id, Models.DB.Local.WsDataMapping wsDataMapping)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.WsDataMapping.Update(wsDataMapping);
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
		public async Task<bool> DeleteWsDataMapping(long wsDataMappingId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.WsDataMapping wsDataMapping = localContext.WsDataMapping.First(p => p.Id == wsDataMappingId);
				localContext.WsDataMapping.Remove(wsDataMapping);
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
