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
	public class WsRevisionsService
	{
		private LocalContext localContext;

		public WsRevisionsService(LocalContext dbContext)
		{
			localContext = dbContext;
		}

		public async Task<long> WsRevisionCount()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				return await localContext.WsRevision.CountAsync();
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return -1;
		}

		public async Task<IList<Models.DB.Local.WsRevision>> GetAllWsRevisions()
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				IList<Models.DB.Local.WsRevision> wsRevisions = await localContext.WsRevision.ToListAsync();
				return wsRevisions;
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return null;
		}
		public async Task<long> CreateWsRevision(List<Models.DB.Local.WsRevision> WsRevisions)
		{
			long returnid = -1;
			try
			{
				if (localContext == null) localContext = new LocalContext();
				foreach (Models.DB.Local.WsRevision wsRevision in WsRevisions)
				{
					localContext.WsRevision.Add(wsRevision);
					await localContext.SaveChangesAsync();
					returnid = wsRevision.Id;
				}
			}
			catch (Exception ae)
			{
				Log.WriteLine(ae.Message);
				if (ae.InnerException != null) Log.WriteLine(ae.InnerException.ToString());
			}
			return returnid;
		}

		public async Task<bool> UpdateWsRevision(Models.DB.Local.WsRevision wsRevision)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				localContext.WsRevision.Update(wsRevision);
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
		public async Task<bool> DeleteWsRevision(long wsRevisionId)
		{
			try
			{
				if (localContext == null) localContext = new LocalContext();
				Models.DB.Local.WsRevision wsRevision = localContext.WsRevision.First(p => p.Id == wsRevisionId);
				localContext.WsRevision.Remove(wsRevision);
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
